<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="AsignarSolicitudes.aspx.cs" Inherits="Dashboard_Bajas_Carrier.AsignarSolicitudes.AsignarSolicitudes" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarSolicitudes.aspx.cs"      Inherits="Dashboard_Bajas_Carrier.AsignarSolicitudes.AsignarSolicitudes" %>

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
                <p align="center">Asignación de Solicitudes</p>
            </h3>
        </table class="auto-style1">
         <br />
         <table>
             <tr>
                 <td>&nbsp;</td>
                 <td style="width: 50px;">
                     <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                 </td>
                 <td style="width: 190px;" >
                     <asp:DropDownList ID="cbUsuario" runat="server" AutoPostBack="true" Height="22px">
                     </asp:DropDownList>
                 </td>
                 <td style="width: 50px;">
                     <asp:Label ID="lblUsuarioAsignar" runat="server" Text="Usuario"></asp:Label>
                 </td>
                 <td style="width: 190px;" >
                     <asp:DropDownList ID="cbUsuarioAsignar" runat="server" AutoPostBack="False" Height="22px">
                     </asp:DropDownList>
                 </td>
                 <td style="width: 200px; ">
                     <asp:Label ID="lblCantidadSol" runat="server" Text="Cantidad de Solicitudes"></asp:Label>
                 </td>
                  <td style="width: 200px; ">
                      <asp:TextBox ID="txtCantSolicitudes" runat="server" Enabled="false" Width="68px"></asp:TextBox>
                 </td>
                  <td style="width: 200px; ">
                     <asp:Label ID="lblCantSolicitudesAsignadas" runat="server" Text="Cantidad de Solicitudes Asignadas"></asp:Label>
                 </td>
                  <td style="width: 200px; ">
                      <asp:TextBox ID="txtCantSolicitudesAsignadas" runat="server" Enabled="false" Width="68px"></asp:TextBox>
                 </td>
         </table>
         <br />
             <asp:GridView ID="gvSolicitudesaAsignar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1126px" AllowPaging="True" OnPageIndexChanging="gvSolicitudesaAsignar_PageIndexChanging" AutoGenerateColumns="False">
             <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Id" SortExpression="Id">
                         <ItemTemplate>
                             <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="IdSolicitud" SortExpression="IdSolicitud">
                         <ItemTemplate>
                             <asp:Label ID="lblIdSolicitud" runat="server" Text='<%# Bind("IdSolicitud") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Status" SortExpression="Status">
                         <ItemTemplate>
                             <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cédula" SortExpression="Cedula">
                         <ItemTemplate>
                             <asp:Label ID="lblCedula" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                         <ItemTemplate>
                             <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                         <ItemTemplate>
                             <asp:Label ID="lblProducto" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Monto" SortExpression="Monto">
                         <ItemTemplate>
                             <asp:Label ID="lblMonto" runat="server" Text='<%# Bind("Monto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Agente" SortExpression="Agente">
                         <ItemTemplate>
                             <asp:Label ID="lblAgente" runat="server" Text='<%# Bind("Agente") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
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
         <br />
         <table>
             <tr>
                 <td style="width: 400px;" ><asp:Label align="center" ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                 <td style="width: 100px;">
                     <asp:Button ID="btnAsignar" runat="server" Text="Asignar" />
                 </td>
                   <td style="width: 200px;">
                     <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                 </td>
             </tr>
         </table>
</div>

</asp:Content>
