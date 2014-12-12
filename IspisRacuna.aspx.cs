using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using BarDataAccessLayer;

namespace BarApplication
{
    public partial class IspisRacuna : System.Web.UI.Page
    {
        readonly DataTable _dt2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            var rDb = new RacunDb();
            var listRacun = rDb.SviRacuni();
            foreach (var racun in listRacun)
            {
                var menuItem = new ListItem();
                menuItem.Text = racun.RacunId.ToString(CultureInfo.InvariantCulture);
                menuItem.Value = racun.RacunId.ToString(CultureInfo.InvariantCulture);
                ddlRacun.Items.Add(menuItem);
            }
        }

        protected void btnOdaberiRacun_Click(object sender, EventArgs e)
        {
            lblNarudzbaTxt.Visible = true;
            lblKonobar.Visible = true;
            lblStol.Visible = true;
            lblStolTxt.Visible = true;
            lblVrijeme.Visible = true;
            lblVrijemeTxt.Visible = true;
            lblukupnaCjenaTxt.Visible = true;
            lblUkupnaCjena.Visible = true;
            lblKonobarTxt.Visible = true;
            gvNarudzba.Visible = true;

            var rDb = new RacunDb();
            BarObjekti.Racun r = rDb.SelectRacun(Int32.Parse(ddlRacun.SelectedValue));

            var kDb =new KonobarDb();
            BarObjekti.Konobar k = kDb.SelectKonobar(r.KonobarId);
            lblKonobar.Text = String.Concat(k.Ime, " ", k.Prezime);

            var sDb = new StolDb();
            BarObjekti.Stol s = sDb.SelectStol(r.StolId);
            lblStol.Text = s.BrojStola.ToString(CultureInfo.InvariantCulture);

            lblVrijeme.Text = r.Vrijeme.ToString(CultureInfo.InvariantCulture);

            var nDb = new NarudzbaDb();
            var listnarudzba = nDb.SelectAllNarudzbaDb(Int32.Parse(ddlRacun.SelectedValue));
            if (_dt2.Columns.Count == 0)
            {
                _dt2.Columns.Add("Naziv", typeof (string));
                _dt2.Columns.Add("Cjena", typeof (int));
                _dt2.Columns.Add("Kolicina", typeof (int));
            }
            int ukupnaCijena = 0;
            foreach (var narudzba in listnarudzba)
            {
                DataRow newRow = _dt2.NewRow();
                newRow[0] = narudzba.Naziv;
                newRow[1] = narudzba.Cijena;
                newRow[2] = narudzba.Kolicina;
                _dt2.Rows.Add(newRow);
                gvNarudzba.DataSource = _dt2;
                gvNarudzba.DataBind();
                ukupnaCijena = ukupnaCijena + narudzba.Cijena*narudzba.Kolicina;
            }
            lblUkupnaCjena.Text =String.Concat(ukupnaCijena.ToString(CultureInfo.InvariantCulture), " kn");
        }

        protected void btnNewOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?show=true");
        }
    }
}