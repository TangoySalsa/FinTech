<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudBuro.aspx.cs" Inherits="Dashboard_Bajas_Carrier.FinTech.SolicitudBuro" %>

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
                <p align="center">INFORMACIÓN DE SOLICITUDES</p>
            </h3>
        </table>
        <table>
          <tr>
              <td>

              </td>
              <td>
                  <asp:Label ID="lblFiltrar" runat="server" Text="Buscar: "></asp:Label>
              </td>
              <td style="width: 120px">
                  <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
              </td>
               <td style="width: 120px">
                   <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
              </td>
          </tr>
      </table>
        <br />
        <%--<table>--%><asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="gridView1_Sorting" AllowSorting="True" Width="1118px" EnableSortingAndPaging="True" CellPadding="4" BorderStyle="None" BorderWidth="1px">
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

        <%--</table>--%>
        <div class="container">

            <hr />
            <table>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblEdad" runat="server" Text="Edad:"></asp:Label>
                    </td>
                    <td style="width: 159px">&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;<asp:TextBox ID="txtEdad" runat="server" ToolTip="Edad" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                            ControlToValidate="txtEdad" ErrorMessage="*Edad"
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="valida_txtEdad" runat="server"
                         ControlToValidate="txtEdad"
                         ErrorMessage="*Edad"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                    </td>
                    &nbsp;&nbsp;
                    <%--<tr>--%>
                    <td>
                        <br />
                        <asp:Label ID="lblEstatusPersona" runat="server" Text="EstatusPersona:"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td style="width: 238px">&nbsp; <asp:DropDownList ID="cbEstatusPersona" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    </td>
                    &nbsp;&nbsp;

                    <td style="width: 10px">
                        <br />
                        <asp:Label ID="lblNumeroAsegurado" runat="server" Text="Asegurado:"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td style="width: 109px">
                        <asp:TextBox ID="txtNumeroAsegurado" runat="server" ToolTip="Numero Asegurado" Width="135px"></asp:TextBox>
                        <br />
                    </td>
                    &nbsp;&nbsp;

                    &nbsp;&nbsp;
                    <td>
                        <asp:Label ID="lblTipoAsegurado" runat="server" Text="Tipo Asegurado:"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td style="width: 198px">&nbsp;<asp:DropDownList ID="cbTipoAsegurado" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    </td>
                    &nbsp;&nbsp;
                    <%--</tr>--%>
                    <%--<hr />--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblBienesInmuebles" runat="server" Text="Bienes Inmuebles:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 159px">&nbsp;
                            <%--<asp:DropDownList ID="cbBienesInmuebles" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True">0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList>--%>

                            <asp:TextBox ID="txtBienesInmuebles" runat="server" ToolTip="Bienes Inmuebles" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtBienesInmuebles" runat="server"
                            ControlToValidate="txtBienesInmuebles" ErrorMessage="*Bienes Inmuebles" 
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="valida_txtBienesInmuebles" runat="server"
                         ControlToValidate="txtBienesInmuebles"
                         ErrorMessage="*Bienes Inmuebles"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                        </td>
                        &nbsp;&nbsp;
                        <td>
                            <asp:Label ID="lblBienMueble" runat="server" Text="Bien Mueble:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 238px">&nbsp;
                            <%--<asp:DropDownList ID="cbBienMueble" runat="server" AutoPostBack="True">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>--%>
                            <asp:TextBox ID="txtBienMueble" runat="server" ToolTip="Bien Mueble" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtBienMueble" runat="server"
                            ControlToValidate="txtBienMueble" ErrorMessage="*Bien Inmueble"
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="valida_txtBienMueble" runat="server"
                         ControlToValidate="txtBienMueble"
                         ErrorMessage="*Bien Inmueble"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>

                        </td>
                        &nbsp;&nbsp;
                        <td>
                            <asp:Label ID="lblPrendas" runat="server" Text="Prendas:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 109px">&nbsp;<asp:TextBox ID="txtPrendas" runat="server" ToolTip="Prendas" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtPrendas" runat="server"
                            ControlToValidate="txtPrendas" ErrorMessage="*Prendas"
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="valida_txtPrendas" runat="server"
                         ControlToValidate="txtPrendas"
                         ErrorMessage="*Prendas"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                        </td>
                        &nbsp;&nbsp;
                        <td>
                            <asp:Label ID="lblHipotecas" runat="server" Text="Hipotecas:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 198px">&nbsp;<asp:TextBox ID="txtHipotecas" runat="server" ToolTip="Hipotecas" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtHipotecas" runat="server"
                            ControlToValidate="txtPrendas" ErrorMessage="*Prendas"
                             SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="valida_txtHipotecas" runat="server"
                         ControlToValidate="txtHipotecas"
                         ErrorMessage="*Prendas"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                        </td>
                        &nbsp;&nbsp;
                    </tr>
                    <tr>
                        <td style="height: 42px">
                            <asp:Label ID="lblReportesComerciales" runat="server" Text="Reportes Comerciales:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 159px; height: 42px;">&nbsp;
                            <asp:TextBox ID="txtReportesComerciales" runat="server" ToolTip="Reportes Comerciales" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtReportesComerciales" runat="server"
                            ControlToValidate="txtReportesComerciales" ErrorMessage="*Reportes Comerciales"
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="valida_txtReportesComerciales" runat="server"
                         ControlToValidate="txtReportesComerciales"
                         ErrorMessage="*Reportes Comerciales"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                        </td>
                        &nbsp;&nbsp;
                        <td style="height: 42px">
                            <asp:Label ID="lblJuicios" runat="server" Text="Juicios:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 238px; height: 42px;">&nbsp;
                            <%--<asp:DropDownList ID="cbJuicios" runat="server" AutoPostBack="True">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>--%>
                            <asp:TextBox ID="txtJuicios" runat="server" ToolTip="Juicios" Width="75px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regular_txtJuicios" runat="server"
                            ControlToValidate="txtJuicios" ErrorMessage="*Juicios"
                            SetFocusOnError="true"
                            Display="None"
                            ForeColor="Red"
                            ValidationGroup="valida"
                            ValidationExpression="^[0-9]*">
                        </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="valida_txtJuicios" runat="server"
                         ControlToValidate="txtJuicios"
                         ErrorMessage="*Juicios"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                        </td>
                        &nbsp;&nbsp;
                        <td style="height: 42px">
                            <asp:Label ID="lblSalario" runat="server" Text="Salario:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="height: 42px; width: 109px;">&nbsp;<asp:DropDownList ID="cbSalario" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        </td>
                        &nbsp;&nbsp;
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 159px">&nbsp; <asp:DropDownList ID="cbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbProvincia_SelectedIndexChanged1">
                        </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblCanton" runat="server" Text="Canton:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 238px">&nbsp; <asp:DropDownList ID="cbCanton" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbCanton_SelectedIndexChanged1">
                        </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblDistrito" runat="server" Text="Distrito:"></asp:Label>
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 109px">&nbsp;<asp:DropDownList ID="cbDistrito" runat="server">
                        </asp:DropDownList>
                        </td>
                    </tr>
                </tr>
            </table>
            <table class="auto-style1" >
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                        <br />
                        <asp:TextBox  ID="txtComentarios" runat="server" TextMode="MultiLine" Width="400px" Height="75px"></asp:TextBox>
                        &nbsp;&nbsp; &nbsp;&nbsp;
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine" Width="400px" Height="75px"></asp:TextBox>
                    </td>
                </tr>
            </table>
             <div class="text-center">
             <asp:validationsummary id="valida" ValidationGroup="valida"  HeaderText="*Campos requeridos y númericos*" ForeColor="Red" runat="Server" showmessagebox="true" cssclass="validation-summary-errors" />
            </div>
            <table style="margin: 0 auto;">
                <tr>
                    <td>
                        <br />                        
                        <asp:Button ID="btnAceptar" runat="server"  Text="Aprobar" ValidationGroup="valida" ValidateRequestMode="Enabled" OnClick="btnAceptar_Click" />
                        &nbsp;&nbsp; &nbsp;&nbsp;
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" ValidationGroup="valida" ValidateRequestMode="Enabled" OnClick="btnRechazar_Click" />
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
    </div>
</asp:Content>
