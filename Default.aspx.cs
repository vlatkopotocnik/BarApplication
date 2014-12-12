using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarDataAccessLayer;


namespace BarApplication
{
    public partial class Default : Page
    {        
        public const int StolSlobodan = 0;
        public const int StolZauzet = 1;
        DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["show"] == "true")
            {
                pnlInvoice.Visible = true;
            }
            if (IsPostBack) return;
            {
                var hDb = new HitsDb();
                var hits = hDb.HitsCount();
                lblVisited.Text = hits.ToString(CultureInfo.InvariantCulture);
            }
            var kDb = new KonobarDb();
            var listKonobar = kDb.SelectAllKonobar();
            foreach (var konobar in listKonobar)
            {
                var menuItem = new ListItem
                {
                    Text = konobar.Ime + @" " + konobar.Prezime,
                    Value = konobar.KonobarId.ToString(CultureInfo.InvariantCulture)
                };
                ddlKonobar.Items.Add(menuItem);
            }
            var sDb = new StolDb();
            var listStol = sDb.SelectAllStol();
            foreach (var stol in listStol)
            {
                var menuItem = new ListItem
                {
                    Text = stol.BrojStola.ToString(CultureInfo.InvariantCulture),
                    Value = stol.StolId.ToString(CultureInfo.InvariantCulture)
                };
                ddlStol.Items.Add(menuItem);
            }   
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            

            // Read in the ArtiklId from the DataKeys collection
            int artiklId = Convert.ToInt32(dlArtikl.DataKeys[e.Item.ItemIndex]);
            // Read in the values
            var txtValue = (TextBox) e.Item.FindControl("txtValue");
            var naziv = (Label) e.Item.FindControl("lblNaziv");
            int value;
            if (!Int32.TryParse(txtValue.Text, out value))
            {
                var errorLabel = (Label)e.Item.FindControl("lblError");
                if (txtValue.Text == String.Empty)
                {
                    errorLabel.Text = (string) GetLocalResourceObject("Default_DataList1_UpdateCommand_Please_enter_a_value");
                    return;
                }
                errorLabel.Text = (string) GetLocalResourceObject("Default_DataList1_UpdateCommand_Please_enter_numbers_only");
                return;
            }
            ddlStol.Enabled = false;
            ddlKonobar.Enabled = false;
            var stolUProcesuNarudzbe = new StolDb();
            stolUProcesuNarudzbe.StolSlobodanZauzet(StolZauzet, Int32.Parse(ddlStol.SelectedValue));
            Session["StolSlobodanZauzet"] = Int32.Parse(ddlStol.SelectedValue);
            if (_dt.Columns.Count == 0)
            {
                _dt.Columns.Add("ArtiklId", typeof(int));
                _dt.Columns.Add("Naziv", typeof(string));
                _dt.Columns.Add("Kolicina", typeof(int));
            }
            if (ViewState["narudzba"] != null)
            {
                _dt = (DataTable)ViewState["narudzba"];
            }
            DataRow newRow = _dt.NewRow();
            newRow[0] = artiklId;
            newRow[1] = naziv.Text;
            try
            {
                newRow[2] = value;
            }
            catch (Exception ex)
            {
                var err = new ErrorHandling();
                err.ErrorLog(HttpContext.Current.Server.MapPath("~/Errors"), err.GetLogMessage() + "===>" + ex.Message);
                lblStatus.Text = ex.Message;
            }
            _dt.Rows.Add(newRow);
            gvRacun.DataSource = _dt;
            gvRacun.DataBind();
            ViewState.Add("narudzba", _dt);
            btnOrder.Visible = true;
            gvRacun.Visible = true;
            lblStatus.Text = String.Empty;
            // Revert the DataList back to its pre-editing state
            DataList1_ShowAndBind(false);
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            var stolUProcesuNarudzbe = new StolDb();
            stolUProcesuNarudzbe.StolSlobodanZauzet(StolSlobodan, Int32.Parse(ddlStol.SelectedValue));
            var r = new BarObjekti.Racun(Int32.Parse(ddlKonobar.SelectedValue),Int32.Parse(ddlStol.SelectedValue));
            var rDb = new RacunDb();
            int racunId = rDb.InsertRacun(r);
            for (int currentCount = 0; currentCount < gvRacun.Rows.Count; currentCount++)
            {
                var racDb = new RacunArtiklCjenikDb();
                racDb.InsertRacunArtiklCjenik(racunId, Int32.Parse(gvRacun.Rows[currentCount].Cells[2].Text), Int32.Parse(gvRacun.Rows[currentCount].Cells[0].Text));
            }
            DataList1_ShowAndBind(false);
            lblStatus.Visible = true;
            lblStatus.Text = String.Concat("Naručeno   (Račun br.: ", racunId, ")");
            ViewState["narudzba"] = null;
            ddlStol.Enabled = true;
            ddlKonobar.Enabled = true;
            gvRacun.Visible = false;
            btnOrder.Visible = false;
            Session.Abandon();
        }


       

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList1_ShowAndBind(true,e.Item.ItemIndex);
        }
        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1_ShowAndBind(false);
        }

        protected void DataList1_ShowAndBind(bool show,int index = -1)
        {
            // Set the DataList's EditItemIndex property to index
            if(show && index != -1) 
                dlArtikl.EditItemIndex = index;
            else
                dlArtikl.EditItemIndex = -1;
            // Rebind the data to the DataList
            dlArtikl.DataBind();
        }


        protected void btnNewOrder_Click(object sender, EventArgs e)
        {
            pnlInvoice.Visible = true;
        }

        protected void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("IspisRacuna.aspx");
        }

    }
}