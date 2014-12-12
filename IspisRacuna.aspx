<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IspisRacuna.aspx.cs" Inherits="BarApplication.IspisRacuna" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
                <asp:Button runat="server" ID="btnNewOrder" Text="NEW INVOICE" OnClick="btnNewOrder_Click"/>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblOdaberiteRacun" meta:resourcekey="lblOdaberiteRacunResource1"></asp:Label>
    <asp:DropDownList runat="server" ID="ddlRacun" meta:resourcekey="ddlRacunResource1"/>
    <center>
    <asp:Button runat="server" ID="btnOdaberiRacun" OnClick="btnOdaberiRacun_Click" meta:resourcekey="btnOdaberiRacunResource1"/>
    </center>
    <asp:Label runat="server" ID="lblIspisRacunaTxt" Visible="False" meta:resourcekey="lblIspisRacunaTxtResource1"></asp:Label>
    <br/>
    <asp:Label runat="server" ID="lblKonobarTxt" Font-Bold="True" Visible="False" meta:resourcekey="lblKonobarTxtResource1"></asp:Label>
    <asp:Label runat="server" ID="lblKonobar" Visible="False" meta:resourcekey="lblKonobarResource1"></asp:Label>
    <br/>
    <asp:Label runat="server" ID="lblStolTxt" Font-Bold="True" Visible="False" meta:resourcekey="lblStolTxtResource1"></asp:Label>
    <asp:Label runat="server" ID="lblStol" Visible="False" meta:resourcekey="lblStolResource1"></asp:Label>
    <br/>
    <asp:Label runat="server" ID="lblVrijemeTxt" Font-Bold="True" Visible="False" meta:resourcekey="lblVrijemeTxtResource1"></asp:Label>
    <asp:Label runat="server" ID="lblVrijeme" Visible="False" meta:resourcekey="lblVrijemeResource1"></asp:Label>
    <br/>
    <br/>
    <center>
        <asp:Label runat="server" ID="lblNarudzbaTxt" Visible="False" meta:resourcekey="lblNarudzbaTxtResource1"></asp:Label>
        <asp:GridView runat="server" ID="gvNarudzba" AutoGenerateColumns="False" Visible="False" meta:resourcekey="gvNarudzbaResource1">
            <Columns>
                <asp:BoundField DataField="Naziv" HeaderText="Naziv" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="Cjena" HeaderText="Cjena" meta:resourcekey="BoundFieldResource2" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="Kolicina" HeaderText="Količina" meta:resourcekey="BoundFieldResource3" DataFormatString="{0:0.00}" />
            </Columns>
        </asp:GridView>
        <asp:Label runat="server" ID="lblukupnaCjenaTxt" Visible="False" Font-Bold="True" meta:resourcekey="lblukupnaCjenaTxtResource1"></asp:Label>
        <asp:Label runat="server" ID="lblUkupnaCjena" Visible="False" meta:resourcekey="lblUkupnaCjenaResource1"></asp:Label>
    </center>
</asp:Content>

