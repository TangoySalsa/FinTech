<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CR_ICE_Verificar.aspx.cs" Inherits="Dashboard_Bajas_Carrier.CR_ICE.CR_ICE_Verificar" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; height: 100%">
        <br />        
        <div style="text-align:center">            
            <img src="../Icon/2fun2me.png" class="img-rounded" alt="2fun2me">               
        </div>                
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row" style="text-align:center">
            <div class="col-md-3 brd">
            </div>
            <div class="col-md-6 brd">
                <div style="height: 99%">
                    <div class="col-md-2">                        
                        <asp:Label runat="server" ID="Label1" Text="Numero:" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="col-md-10">
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtNumero"></asp:TextBox>                            
                        </div>
                        <div class="col-md-2">                                                        
                            <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-default btn-sm" OnClick="btnBuscar_Click"/> 
                        </div>
                    </div>
                    <br />
                </div>
                <br />
                <br />
                <asp:GridView ID="GridView1" CssClass="GridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" >
                    <AlternatingRowStyle BackColor="#e3e3e3" />                                      
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#0096db" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" Font-Size="Smaller" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>