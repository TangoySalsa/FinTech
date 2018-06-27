<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MontoPagos.aspx.cs" Inherits="Dashboard_Bajas_Carrier.Pagos.MontoPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; height: 100%">
         <table>
            <td style="width: 5000px; height: 150px;">
                <strong>
                    <img src="../Icon/2fun2me_.png" class="img-rounded" alt="2fun2me"  style="width: 316px; height: 100px">
                </strong>
            </td>
        </table>
        <table>
            <h3>             
                <p align="center"> Pagos </p>
            </h3>
        </table>
        <br />
        <table>
            <tr>
                <td>
                <asp:Label ID="lblIdCedito" runat="server" Text="Credito: "></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtIdCredito" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
            <tr>
                <td>
                <asp:Label ID="lblIdentificación" runat="server" Text="Identificación: "></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtIdentificación" runat="server"></asp:TextBox>
                </td>
                 <td>
                     <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                 <td style="width: 108px">
                        <asp:Label ID="lblMensajes" runat="server" Text="" Style="font-weight: 700" Visible="false" ForeColor="Red"></asp:Label>

                    </td>
            </tr>
        </table>
        <br />
        <table>
        <td style="width: 971px" align="center">
            <h3>&nbsp;&nbsp;
                <asp:Label ID="lblTitulo1" runat="server" Text="INFORMACIÓN DEL CREDITO :" Style="font-weight: 700"></asp:Label>

            </h3>
        </td>
    </table>
         <hr />
    <div class="container">
       <div style="width: 1500px">
           <table>
               <tr>
                   <td style="width:100px"></td>
                   <td>
                       <asp:Label ID="lblNombreCliente" runat="server" Text="Cliente: "></asp:Label>
                   </td>
                   <td style="width: 500px">
                       <asp:TextBox ID="txtNombreCliente" runat="server" Width="350px" Enabled="False"></asp:TextBox>
                   </td>
                   <td>
                       <asp:Label ID="lblStatus" runat="server" Text="Status: "></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtStatus" runat="server"  Enabled="false"></asp:TextBox>

                   </td>
                </tr>
                <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
               <tr>
                   <td style="width:50px"></td>
                   <td>
                    <asp:Label ID="lblProducto" runat="server" Text="Producto: "></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtProducto" runat="server" Enabled="false"></asp:TextBox>
                   </td>
                      <td>
                   <asp:Label ID="lblNumCuota" runat="server" Text="Num. Cuota: "></asp:Label>
                   </td>
                    <td>
                        <asp:DropDownList ID="cb_NumCuota" runat="server" OnSelectedIndexChanged="cb_NumCuota_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
               <tr>
                   <td style="width:50px"></td>
                   <td>
                    <asp:Label ID="lblCredito" runat="server" Text="Credito: "></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtCredito" runat="server" Enabled="false" ></asp:TextBox>
                   </td>
                    <td>
                    <asp:Label ID="lblInteresMora" runat="server" Text="Interés mora: "></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtInteresMora" runat="server" Enabled="False"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
               <tr>
                   <td style="width:50px"></td>
                   <td>
                      <asp:Label ID="lblSaldoCorte" runat="server" Text="Saldo al Corte: "></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="txtSaldoCorte" runat="server" Enabled="False"></asp:TextBox>
                   </td>
                   <td>
                    <asp:Label ID="lblInteresCuota" runat="server" Text="Interés Cuota: "></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtInteresCuota" runat="server" Enabled="false"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
               <tr>
                   <td style="width:50px"></td>
                   <td>
                      <asp:Label ID="lblSaldoPendiente" runat="server" Text="Saldo Pendiente: "></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="txtSaldoPendiente" runat="server" Enabled="False"></asp:TextBox>
                   </td>
                   <td>
                   <asp:Label ID="lblMontoCuota" runat="server" Text="Monto Cuota: "></asp:Label>
                   </td>
                    <td>
                       <asp:TextBox ID="txtMontoCuota" runat="server" Enabled="False"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td style="height:20px">
                       <br />
                   </td>
               </tr>
               <tr>
                   <td style="width:50px">

                   </td>
                   <td></td>
                   <td></td>
                   <td>
                       <asp:Label ID="lblMontoTotalPagar" runat="server" Text="Total a Pagar: "></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="txtTotalPagar" runat="server" Enabled="False"></asp:TextBox>
                   </td>
               </tr>
           </table>
       </div>
         <hr />
        <br />
        <table>
            <tr>
               <td style="width:300px"></td>
                   <td>
                      <asp:Label ID="lblMontoPagar" runat="server" Text="Monto a Pagar: "></asp:Label>
                   </td>
                   <td>
                        <asp:TextBox ID="txtMontoPagar" runat="server" Enabled="true"></asp:TextBox>
                   </td>
               <td style="width:100px">
                   <asp:Button ID="btnPagar" runat="server" Text="Realizar Pago" OnClick="btnPagar_Click" />
               </td>
               <td>
                   <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
               </td>
           </tr>
        </table>
    </div>
    </div>
</asp:Content>
