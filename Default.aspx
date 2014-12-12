<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BarApplication.Default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <asp:Button runat="server" ID="btnNewOrder" Text="NEW INVOICE" OnClick="btnNewOrder_Click" />
            <asp:Button runat="server" ID="btnPrintInvoice" Text="INVOICE LIST" OnClick="btnPrintInvoice_Click" />
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblStatus" ForeColor="Red" meta:resourcekey="lblErrorResource1"></asp:Label>
            <asp:Panel runat="server" ID="pnlInvoice" Visible="False">
                <asp:Label runat="server" ID="lblOdaberiteKonobara" meta:resourcekey="lblOdaberiteKonobaraResource1"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlKonobar" meta:resourcekey="ddlKonobarResource1" />
                <br />
                <br />
                <asp:Label runat="server" ID="lblOdaberiteStol" meta:resourcekey="lblOdaberiteStolResource1"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlStol" meta:resourcekey="ddlStolResource1" />
                <div class="container">
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblOdaberiteArtikl" meta:resourcekey="lblOdaberiteArtiklResource1" Font-Underline="True"></asp:Label>
                    <br />

                    <asp:DataList runat="server" ID="dlArtikl" DataKeyField="ArtiklId" DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" OnEditCommand="DataList1_EditCommand" OnCancelCommand="DataList1_CancelCommand" OnUpdateCommand="DataList1_UpdateCommand">

                        <EditItemTemplate>

                            <asp:Label ID="lblArtiklId" runat="server" Text='<%# Eval("ArtiklId") %>' Visible="False" />
                            <br />
                            <asp:Label ID="lblNaziv" runat="server" Text='<%# Eval("Naziv") %>' />
                            <br />
                            <asp:ImageButton ID="imgArtikl" runat="server" ImageUrl='<%# Eval("ImagePath", @"~\Images\Atrikl\{0}") %>' Height="133" Width="100" CommandName="Edit" CssClass="imgArtiklCss"></asp:ImageButton>
                            <br />
                            <asp:Label ID="lblValue" runat="server" Text="Enter quantity:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtValue" Width="50"></asp:TextBox>
                            <br />

                            <asp:Label runat="server" ID="lblError" ForeColor="red"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnADD" runat="server" Text="ADD" CommandName="Update" />

                            <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CommandName="Cancel" />

                        </EditItemTemplate>

                        <ItemTemplate>
                            <asp:Label ID="lblArtiklId" runat="server" Text='<%# Eval("ArtiklId") %>' Visible="False" />
                            <br />
                            <asp:Label ID="lblNaziv" runat="server" Text='<%# Eval("Naziv") %>' />
                            <br />
                            <asp:ImageButton ID="imgArtikl" runat="server" ImageUrl='<%# Eval("ImagePath", @"~\Images\Atrikl\{0}") %>' Height="133" Width="100" CommandName="Edit"></asp:ImageButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnString %>" SelectCommand="SELECT [ArtiklId], [Naziv], [ImagePath] FROM [Artikl]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <div style="align-items: center" >
                        <asp:GridView runat="server" ID="gvRacun" AutoGenerateColumns="False" meta:resourcekey="gvRacunResource1" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ArtiklId" meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv" meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="Kolicina" HeaderText="Količina" meta:resourcekey="BoundFieldResource5" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <br/>
                        <br/>
                        <asp:Button runat="server" ID="btnOrder" Visible="False" OnClick="btnOrder_Click" meta:resourcekey="btnOrderResource2" />
                    </div>

                </div>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<asp:Content runat="server" ID="FooterContent" ContentPlaceHolderID="Footer">
    <asp:Label runat="server" ID="lblVisitedTxt" Text="Visited: "></asp:Label>
    <asp:Label runat="server" ID="lblVisited"></asp:Label>
    <br />
</asp:Content>
