<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuentasCobrar.aspx.cs"      Inherits="Dashboard_Bajas_Carrier.Cobros.CuentasCobrar" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstatusSolicitudes.aspx.cs" Inherits="Dashboard_Bajas_Carrier.FinTech.EstatusSolicitudes" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <p align="center">Cuentas por Cobrar</p>
            </h3>
        </table>
        <table>
            <tr>
                <td>
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar por:"></asp:Label>
                </td>
            </tr>
            <tr><td></td></tr>
            <tr>
                <td>
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación:"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtIdentificacion" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                <asp:Label ID="lblIdCredito" runat="server" Text="Número de Credito:"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtIdCredito" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha desde: "></asp:Label>
                </td>
                <td></td>
                <td>
                   <input id="dtFechaInicio" type="date" name="dtFechaInicio" runat="server"> 
                </td>
                <td></td>
                <td>
                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha hasta:"></asp:Label>
                </td>
                <td></td>
                <td>
                 <input id="dtFechaFin" type="date" name="dtFechaFin" runat="server"> 
                </td>
                 <td></td>
                <td>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" OnClick="btnFiltrar_Click" Width="71px" />
                </td>
                <tr>
            <td></td>
                <td>
                </td>
                <td></td>
                <td>
                        <asp:Label ID="lblMensajes" runat="server" Text="" Style="font-weight: 700" Visible="false" ForeColor="Red"></asp:Label>
                </td>
                </tr>    
            
        </table>
          <br />
          
            <asp:GridView ID="gv_CuentasCobrar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1400px" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Credito" SortExpression="NumeroCredito">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NumeroCredito") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Identificacion" SortExpression="Identificacion">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Identificacion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente" SortExpression="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Producto" SortExpression="NombreProducto">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Núm Cuotas" SortExpression="CantidadCuotas">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("CantidadCuotas") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cuota" SortExpression="Cuota">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cuota") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Capital" SortExpression="Principal">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Principal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Intereses" SortExpression="Intereses">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Intereses") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tasa" SortExpression="Tasa_Interes">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tasa_Interes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Originación" SortExpression="Originacion">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Originacion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Vto" SortExpression="FechaPago">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("FechaPago") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tasa Anual" SortExpression="TasaAnual">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TasaAnual") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mes" SortExpression="Mes">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Mes") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Semana" SortExpression="Semana">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Semana") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dias" SortExpression="Dias">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dias") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estatus" SortExpression="Estatus">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label>
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
       
    </div>

</asp:Content>
