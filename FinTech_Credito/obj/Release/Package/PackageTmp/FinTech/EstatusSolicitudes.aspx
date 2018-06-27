<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstatusSolicitudes.aspx.cs" Inherits="Dashboard_Bajas_Carrier.FinTech.EstatusSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div style="width: 100%; height: 100%">
        <br />
        <table>
            <td style="width: 5000px; height: 218px;">
                <strong>
                    <img src="../Icon/2fun2me_.png" class="img-rounded" alt="2fun2me"  style="width: 316px; height: 100px">
                </strong>
            </td>
        </table>
        <table>
            <h3>&nbsp;&nbsp;               
                <p align="center">INFORMACIÓN DE ESTATUS DE SOLICITUDES</p>
            </h3>
        </table class="auto-style1">

         <asp:GridView ID="gvPreAprobadas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1126px" AllowPaging="True" OnPageIndexChanging="gvPreAprobadas_PageIndexChanging" OnSelectedIndexChanged="gvPreAprobadas_SelectedIndexChanged" AutoGenerateSelectButton="True">
             <AlternatingRowStyle BackColor="White" />
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
             <SortedAscendingCellStyle BackColor="#FDF5AC" />
             <SortedAscendingHeaderStyle BackColor="#4D0000" />
             <SortedDescendingCellStyle BackColor="#FCF6C0" />
             <SortedDescendingHeaderStyle BackColor="#820000" />
         </asp:GridView>
         <table>
            &nbsp;&nbsp;               
                <td>
                        <br />
                        <asp:Label align="center" ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <br />
                        
                    </td>

        </table>
         <table>
             <br />
           <tr>
             <td style="width: 370px">

             </td>
             <td>
                 <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" Visible="False" OnClick="btnAprobar_Click" />
             </td>
             <td>
                 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="False" OnClick="btnCancelar_Click" />
             </td>

           </tr>
         </table>
         <p>

         </p>
         <asp:GridView ID="gvRechazadas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1126px" AllowPaging="True" OnPageIndexChanging="gvRechazadas_PageIndexChanging">
             <AlternatingRowStyle BackColor="White" />
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
             <SortedAscendingCellStyle BackColor="#FDF5AC" />
             <SortedAscendingHeaderStyle BackColor="#4D0000" />
             <SortedDescendingCellStyle BackColor="#FCF6C0" />
             <SortedDescendingHeaderStyle BackColor="#820000" />
         </asp:GridView>
</div>


</asp:Content>
