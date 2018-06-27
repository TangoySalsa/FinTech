<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AprobacionesContabilidad.aspx.cs" Inherits="Dashboard_Bajas_Carrier.FinTech.AprobacionesContabilidad" %>

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
                <p align="center">Solicitudes Pendientes de Transferencia Bancaria</p>
            </h3>
        </table>
        <asp:GridView ID="gvPendientesTransferencia" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1036px" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvPendientesTransferencia_SelectedIndexChanged" OnPageIndexChanging="gvPendientesTransferencia_PageIndexChanging">
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
                        <asp:Label align="center" ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                        <br />
                        <asp:TextBox align="center" ID="txtComentarios" runat="server" TextMode="MultiLine" Width="400px" Height="75px"></asp:TextBox>
                        &nbsp;&nbsp; &nbsp;&nbsp;
                    </td>

        </table>

        <table>
            &nbsp;&nbsp;               
                <td>
                        <br />
                        <asp:Label align="center" ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <br />
                        
                    </td>

        </table>

        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnAceptar" runat="server" Text="Aprobar" OnClick="btnAceptar_Click" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                </td>
                  <td>
                    <br />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    &nbsp;&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>


</asp:Content>
