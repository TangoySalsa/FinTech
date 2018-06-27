<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudCredito.aspx.cs" Inherits="FinTech.SolicitudCredito" MasterPageFile="~/Site.Master" %>--%>
<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="SolicitudCredito.aspx.cs" Inherits="FinTech.SolicitudCredito" MasterPageFile="~/Site.Master" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <script language=javascript type=text/javascript>
function stopRKey(evt) {
var evt = (evt) ? evt : ((event) ? event : null);
var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
if ((evt.keyCode == 13) && (node.type=="text")) {return false;}
}
document.onkeypress = stopRKey;
</script>
    <script>
        function EjecutarBoton() {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type=="text")) {
                document.getElementById("<%=btnFiltro.ClientID%>").click();
                return false;
            }
        }
</script>
<script language=javascript type=text/javascript>
         function EjecutarBotonBuscar(evt) {
              var evt = (evt) ? evt : ((event) ? event : null);
              var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
         if ((evt.keyCode == 13) && (node.type == "text")) {
               document.getElementById("<%=btnBuscar.ClientID%>").click();
             return false;
            }
}
</script>
    <div style="width: 100%; height: 100%">
        <br />
        <div style="text-align: left">
            <table>
                <td style="width: 2000px; height: 100px;">
                    <strong>
                        <img src="../Icon/2fun2me_.png" class="img-rounded" alt="2fun2me"  style="width: 316px; height: 100px"> 
                    </strong>
                </td>
                <td style="width: 1047px; height: 218px;">
                    <table style="text-align: left">
                        <td style="width: 200px">
                            <h3>
                                <strong>
                                    <asp:Label ID="Label1" runat="server" Text="Núm. Solicitud:"></asp:Label></strong></h3>
                        </td>
                        <td style="width: 128px">

                            <h3>

                                <asp:Label ID="LblSolicitud" runat="server" Text=""></asp:Label>
                            </h3>
                        </td>
                        <td style="width: 78px">
                            <h3>
                                <strong>
                                    <asp:Label ID="Label3" runat="server" Text="Fecha:"></asp:Label></strong></h3>
                        </td>
                        <td>

                            <h3>

                                <asp:Label ID="lblFechaI" runat="server" Text=""></asp:Label>
                            </h3>
                        </td>
                    </table>
                </td>
            </table>
        </div>
    </div>

      <table>
          <tr>
              <td>
                  <asp:Label ID="lblBuscar" runat="server" Text="Buscar: "></asp:Label>
              </td>
               <td style="width: 200px" >
                   <asp:TextBox ID="txtBuscarporIdentificacion" runat="server" onkeypress="EjecutarBoton(event);" ></asp:TextBox>
              </td>
              <td style="width: 550px" >
                  <asp:Button ID="btnFiltro" runat="server" Text="Buscar" OnClick="btnFiltro_Click" />
              </td>
              <td>
                  <asp:Label ID="lblFiltrar" runat="server" Text="Filtrar por: "></asp:Label>
              </td>
              <td style="width: 120px">
                   <asp:DropDownList ID="cbFiltro" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="cbFiltro_SelectedIndexChanged">
                   </asp:DropDownList>
              </td>
          </tr>
      </table>
    <br />
    <table>
             <tr>
                 <td style="width: 400px;" ><asp:Label align="center" ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label></td>
             </tr>
         </table>
    
    <%--<asp:GridView ID="GridView2" runat="server"></asp:GridView>--%>

    <asp:GridView ID="GridSolicitudes" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridSolicitudes_SelectedIndexChanged" Width="1118px" EnableSortingAndPaging="True" CellPadding="4" OnPageIndexChanging="PageIndexChanged_GridSolicitud">
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
        <td style="width: 971px" align="left">
            <h3>&nbsp;&nbsp;
                <asp:Label ID="lblTitulo1" runat="server" Text="INFORMACIÓN CLIENTE :" Style="font-weight: 700"></asp:Label>

            </h3>
        </td>
    </table>

    <hr />
    <div class="container">

        <div style="width: 764px">
            <table style="width: 225%; text-align: left">
                <tr>
                    <td style="width: 10px; height: 25px;">
                        <br />
                        <asp:Label ID="lblIdentificacion" runat="server" Text="Cédula:"></asp:Label>
                        &nbsp;</td>
                    <td style="height: 25px; width: 74px;">
                        <br />
                        <asp:TextBox ID="txtIdentificacion" runat="server" Width="140px" onkeypress="EjecutarBotonBuscar(event);"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtIdentificacion" ErrorMessage="*solo números"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>

                    </td>
                    <td style="width: 4px">
                        <asp:Button ID="btnBuscar" runat="server" Text="buscar" Width="58px" OnClick="btnBuscar_Click1" />
                    </td>

                    <td style="width: 108px">
                        <asp:Label ID="lblMensajes" runat="server" Text="" Style="font-weight: 700" Visible="false" ForeColor="Red"></asp:Label>

                    </td>


                </tr>
                <tr>
                    <td style="width: 10px">
                        <br />
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td style="width: 74px">
                        <asp:TextBox ID="txtNombre1" runat="server" ToolTip="Primer Nombre" Width="135px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="Valida_txtNombre1" runat="server"
                            ControlToValidate="txtNombre1"
                            ErrorMessage="Primer Nombre"
                            ForeColor="Red"
                            display="None"
                            ValidationGroup="valida"> </asp:RequiredFieldValidator>

                        <br />
                    </td>
                    <td style="width: 4px">
                        <asp:TextBox ID="txtNombre2" runat="server" ToolTip="Segundo Nombre" Width="135px"></asp:TextBox>

                    </td>
                    <td style="width: 108px">
                        <asp:TextBox ID="txtApellido1" runat="server" ToolTip="Primer Apellido" Width="176px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valida_txtApellido1" runat="server"
                            ControlToValidate="txtApellido1"
                            ErrorMessage="Primer Apellido"
                            ForeColor="Red"
                            display="None"
                            ValidationGroup="valida"> </asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 42px">
                        <asp:TextBox ID="txtApellido2" runat="server" ToolTip="Segundo Apellido" Width="187px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="valida_txtApellido2" runat="server"
                            ControlToValidate="txtApellido2"
                            ErrorMessage="Segundo Apellido"
                            ForeColor="Red"
                            Display="None"
                            ValidationGroup="valida"> </asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

            </table>


            <table>
                <tr>
                    <td style="width: 163px">
                        <br />
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Nacimiento:"></asp:Label>
                        <br />
                        <input id="dtFechaNacimiento" type="date" name="dtFechaNacimiento" runat="server">
                        <%--<asp:TextBox ID="txtNacimiento" Format="yyyy-MM-dd" runat="server" Width="136px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNacimiento" Format="yyyy-MM-dd" />--%>
                        <asp:RequiredFieldValidator ID="valida_dtNacimiento" runat="server"
                            ControlToValidate="dtFechaNacimiento"
                            ErrorMessage="Fecha Nacimiento"
                            ForeColor="Red"
                            display="None"
                            ValidationGroup="valida"> </asp:RequiredFieldValidator>

                    </td>
                    <td style="height: 25px; width: 688px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                        &nbsp;
                    <asp:Label ID="lblVencimiento" runat="server" Text="Ced.Vence:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblEstadoCivil0" runat="server" Text="EstadoCivil:"></asp:Label>
                        <br />
                        <input id="dtFechaVencimientoCedula" type="date" name="dtFechaVencimientoCedula" runat="server">
                        <%--<asp:TextBox ID="txtVencimientoCedula" runat="server" Width="135px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtVencimientoCedula_CalendarExtender" runat="server" TargetControlID="txtVencimientoCedula" Format="yyyy-MM-dd" />--%>
                        <asp:RequiredFieldValidator ID="valida_dtFechaVencimientoCedula" runat="server"
                            ControlToValidate="dtFechaVencimientoCedula"
                            ErrorMessage="Vencimiento Cédula"
                            ForeColor="Red"
                            display="None"
                            ValidationGroup="valida"> </asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cbSexo" runat="server" AutoPostBack="False">
                    </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                      <asp:DropDownList ID="cbEstadoCivil" runat="server">
                      </asp:DropDownList>
                        &nbsp;&nbsp;
                    </td>

                </tr>

            </table>

        </div>


        <hr />
        <table>
            <td style="width: 971px" align="left">
                <h3>
                    <asp:Label ID="lblTitulo2" runat="server" Text="INFORMACIÓN CONTACTO :" Style="font-weight: 700"></asp:Label>
                </h3>
            </td>
        </table>

        <hr />
        <table style="width: 97%; text-align: left">
            <tr>

                <td style="width: 495px">
                    <asp:Label ID="txtTelefonos" runat="server" Text="Teléfonos:"></asp:Label>
                    &nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <%--<asp:RequiredFieldValidator ID="valida_txtTelefonoFijo" runat="server"
                        ControlToValidate="txtTelefonoFijo"
                        ErrorMessage="Teléfono es querido"
                        ForeColor="Red"
                           display="None"
                        ValidationGroup="valida"> </asp:RequiredFieldValidator>--%>
                    <asp:TextBox ID="txtTelefonoFijo" runat="server" ToolTip="Teléfono Fijo"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="msktxtTelefonoFijo" runat="server" ClearMaskOnLostFocus="true"
                                    ClearTextOnInvalid="true" Mask="9999-9999" TargetControlID="txtTelefonoFijo" 
                                    InputDirection="LeftToRight" AcceptNegative="None" MaskType="Number" AutoComplete="false">
                                </ajaxToolkit:MaskedEditExtender>
                                <asp:CustomValidator SkinID="Texto-Error" ID="cvtxtTelefonoFijo" runat="server"
                                    ControlToValidate="txtTelefonoFijo" ErrorMessage="El tamaño del número telefónico es incorrecto." 
                                    ValidationGroup="AgregarTelefonoTomador">*</asp:CustomValidator>
                                <asp:CustomValidator SkinID="Texto-Error" ID="cvtxtTelefonoFijonoRep" runat="server"
                                    ControlToValidate="txtTelefonoFijo" ValidationGroup="AgregarTelefonoTomador" 
                                    ErrorMessage="No puede repetir el número de teléfono">*</asp:CustomValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                        ControlToValidate="txtTelefonoFijo" ErrorMessage="*solo números"
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>
                 
                    &nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTelefonoCel" runat="server" ToolTip="Teléfono Celular"></asp:TextBox>
                     <ajaxToolkit:MaskedEditExtender ID="msktxtTelefonoCel" runat="server" ClearMaskOnLostFocus="true"
                                    ClearTextOnInvalid="true" Mask="9999-9999" TargetControlID="txtTelefonoCel" 
                                    InputDirection="LeftToRight" AcceptNegative="None" MaskType="Number" AutoComplete="false">
                                </ajaxToolkit:MaskedEditExtender>
                                <asp:CustomValidator SkinID="Texto-Error" ID="cvtxtTelefonoCel" runat="server"
                                    ControlToValidate="txtTelefonoCel" ErrorMessage="El tamaño del número telefónico es incorrecto." 
                                    ValidationGroup="AgregarTelefonoTomador">*</asp:CustomValidator>
                                <asp:CustomValidator SkinID="Texto-Error" ID="txtTelefonoCelnorepetido" runat="server"
                                    ControlToValidate="txtTelefonoCel" ValidationGroup="AgregarTelefonoTomador" 
                                    ErrorMessage="No puede repetir el número de teléfono">*</asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                        ControlToValidate="txtTelefonoCel" ErrorMessage="*solo números"
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*"
                        ValidationGroup="valida"> </asp:RegularExpressionValidator>
                    &nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTelefonoLaboral" runat="server" ToolTip="Teléfono Laboral"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="msktxtTelefonoLaboral" runat="server" ClearMaskOnLostFocus="true"
                                    ClearTextOnInvalid="true" Mask="9999-9999" TargetControlID="txtTelefonoLaboral" 
                                    InputDirection="LeftToRight" AcceptNegative="None" MaskType="Number" AutoComplete="false">
                                </ajaxToolkit:MaskedEditExtender>
                                <asp:CustomValidator SkinID="Texto-Error" ID="cvtxtTelefonoLaboral" runat="server"
                                    ControlToValidate="txtTelefonoLaboral" ErrorMessage="El tamaño del número telefónico es incorrecto." 
                                    ValidationGroup="AgregarTelefonoTomador">*</asp:CustomValidator>
                                <asp:CustomValidator SkinID="Texto-Error" ID="cvtxtTelefonoLaboralNoRep" runat="server"
                                    ControlToValidate="txtTelefonoLaboral" ValidationGroup="AgregarTelefonoTomador" 
                                    ErrorMessage="No puede repetir el número de teléfono">*</asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                        ControlToValidate="txtTelefonoLaboral" ErrorMessage="*solo números"
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*"
                        ValidationGroup="valida"> </asp:RegularExpressionValidator>
                    &nbsp;<br />
                    <br />
                    <asp:Label ID="lblEmail1" runat="server" Text="Email 1:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmail1" runat="server" Width="259px"></asp:TextBox>
                      <ajaxToolkit:FilteredTextBoxExtender ID="ftbeEmail1" runat="server" TargetControlID="txtEmail1"
                                    FilterType="Custom, Numbers, LowercaseLetters" ValidChars="._-@" >
                      </ajaxToolkit:FilteredTextBoxExtender>
                     
                      <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail1"
                                    ErrorMessage="Correo Electrónico Inválido." Text="*" ValidationGroup="DatosTomador"
                                    ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"> </asp:RegularExpressionValidator>
                      <asp:CheckBox ID="chkisDeclaracionSaludTomador" runat="server" Visible="false"/>
                    
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="txtEmail1" ErrorMessage="Email incorrecto" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    &nbsp;
            
              

                    <br />


                    <asp:Label ID="lblEmail3" runat="server" Text="Email 2:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmail2" runat="server" Width="259px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbeEmail2" runat="server" TargetControlID="txtEmail2"
                                    FilterType="Custom, Numbers, LowercaseLetters" ValidChars="._-@" >
                      </ajaxToolkit:FilteredTextBoxExtender>
                     
                      <asp:RegularExpressionValidator ID="revEmai2" runat="server" ControlToValidate="txtEmail2"
                                    ErrorMessage="Correo Electrónico Inválido." Text="*" ValidationGroup="DatosTomador"
                                    ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"> </asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                        ControlToValidate="txtEmail2" ErrorMessage="Email incorrecto" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <br />
                    <asp:Label ID="lblStatusOrdenPatronal" runat="server" Text="Orden Patronal: "></asp:Label>
                    <asp:CheckBox ID="cbOrdenPatronal" runat="server" />
                    </strong>

               
                </td>


            </tr>
            <tr>

                <td style="width: 495px">&nbsp;</td>


            </tr>
        </table>
        <br />

        <hr />
        <table>
            <td style="width: 971px" align="left">
                <h3>
                    <asp:Label ID="Label2" runat="server" Text="INFORMACIÓN PRODUCTO :" Style="font-weight: 700"></asp:Label>
                </h3>
            </td>
        </table>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                    &nbsp;&nbsp;
                </td>
                <td>&nbsp;<asp:DropDownList ID="cbProducto" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                </td>

                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblUsoCredito" runat="server" Text="Uso del crédito:"></asp:Label>
                    </td>
                    <td>&nbsp;&nbsp;
                        <br />

                        <asp:TextBox ID="txtUsoCredito" runat="server" Width="259px"></asp:TextBox>

                    </td>

                </tr>
        </table>

        <hr />

        <table>
            <td style="width: 971px" align="left">
                <h3>
                    <asp:Label ID="Label4" runat="server" Text="INFORMACIÓN BANCARIA :" Style="font-weight: 700"></asp:Label>
                </h3>
            </td>
        </table>
        <hr />
        <%--<table style="width: 97%; text-align: left">
            <td style="width: 424px">
                <asp:Label ID="lblBanco1" runat="server" Text="Banco 1:"></asp:Label>
                &nbsp;<asp:DropDownList ID="cbBancos1" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;<br />
                <br />
                &nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="valida_txtCuentaBco1" runat="server"
                         ControlToValidate="txtCuentaBco1"
                         ErrorMessage="Cuenta Bancaria requerida"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida">                            
                     </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCuentaBco1" runat="server" ToolTip="Cuenta Banco" Width="190px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                    ControlToValidate="txtCuentaBco1" ErrorMessage="*solo números"
                    ForeColor="Red"
                    ValidationExpression="^[0-9]*"
                    ValidationGroup="valida">
                </asp:RegularExpressionValidator>


                &nbsp;
                <br />
                &nbsp;&nbsp;
                  <asp:RequiredFieldValidator ID="valida_txtCuentaSinpeBco1" runat="server"
                      ControlToValidate="txtCuentaSinpeBco1"
                      ErrorMessage="Cuenta Sinpe requerida"
                      ForeColor="Red"
                      display="None"
                      ValidationGroup="valida">                            
                  </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCuentaSinpeBco1" runat="server" ToolTip="Cuenta Sinpe" Width="190px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                    ControlToValidate="txtCuentaSinpeBco1" ErrorMessage="*solo números"
                    ForeColor="Red"
                    ValidationExpression="^[0-9]*">
                </asp:RegularExpressionValidator>

                <td>

                    <asp:Label ID="lblBanco2" runat="server" Text="Banco 2:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="cbBancos2" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp; 
                           <br />
                    <br />
                    <asp:TextBox ID="txtCuentaBco2" runat="server" ToolTip="Cuenta Banco" Width="190px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                        ControlToValidate="txtCuentaBco2" ErrorMessage="*solo números"
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*">
                    </asp:RegularExpressionValidator>
                    <br />
                    <asp:TextBox ID="txtCuentaSinpeBco2" runat="server" ToolTip="Cuenta Sinpe" Width="190px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                        ControlToValidate="txtCuentaSinpeBco2" ErrorMessage="*solo números"
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*">
                    </asp:RegularExpressionValidator>
                </td>
            </td>
           
        </table>--%>

<%--        <hr />--%>
        <table style="width: 97%; text-align: left">
            <td style="width: 424px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                     BackColor="White" BorderColor="#CC9966" BorderStyle="None"
                     BorderWidth="1px" CellPadding="4" Width="993px" OnRowCommand="GridView1_RowCommand"
                     OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="Id" EmptyDataText="&quot;No se encuentran Cuentas relacionadas al Cliente, por favor ingresar una cuenta al cliente.&quot;" 
                    GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
                    OnRowUpdating="GridView1_RowUpdating" 
                    ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Id_Gv" SortExpression="Id_gv" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdPersona" SortExpression="IdPersona" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("IdPersona") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Predeterminado" SortExpression="Predeterminado">
                            <EditItemTemplate>
                                <asp:CheckBox ID="cbxPredeterminado" runat="server" checked='<%# Bind("Predeterminado") %>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="cbxNewPredeterminado" runat="server" checked='<%# Bind("Predeterminado") %>' Visible="False" />                     
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" checked='<%# Bind("Predeterminado") %>' Enabled="False" />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" Width="100px" />
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdBanco" SortExpression="IdBanco" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("IdBanco") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Banco" SortExpression="Descripcion">
                            <EditItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="drp_NewBanco" runat="server" Visible="False">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cuenta Banco" SortExpression="Cuenta">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_CuentaBanco" runat="server" Height="19px" Width="362px" Text='<%# Bind("Cuenta") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                 <div style="text-align: right;">
                                     <br />
                                <asp:TextBox ID="txt_NewCuentaBanco" runat="server" Width="362px" Visible="False" Height="19px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqNewCuentaBanco" runat="server" ControlToValidate="txt_NewCuentaBanco" ErrorMessage="Digite la Nueva Cuenta de Banco" ValidationGroup="Guardar" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("Cuenta") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Justify" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cuenta Sinpe" SortExpression="CuentaSinpe">
                            <EditItemTemplate>
                                <asp:TextBox ID="Txt_CuentaSinpe" runat="server" Height="19px" Width="362px" Text='<%# Bind("CuentaSinpe") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                 <div style="text-align: right;">
                                <asp:TextBox ID="txt_NewCuentaSinpe" runat="server" Width="362px" Visible="False" Height="19px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rqNewCuentaSinpe" runat="server" ControlToValidate="txt_NewCuentaSinpe" ErrorMessage="Digite la Nueva Cuenta Sinpe" ValidationGroup="Guardar" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
                                 </div>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("CuentaSinpe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" HeaderText="Cuenta Iban" SortExpression="CuentaIban" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_CuentaIban" runat="server" Height="19px" Width="362px" Text='<%# Bind("CuentaSinpe") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_NewCuentaIban" runat="server" Visible="False" Width="362px" Height="19px"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("CuentaSinpe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="btn_actualizar" runat="server" CommandName="Update" Height="35px" ImageUrl="~/Icon/Actualizar.jpg" Width="40px"/>
                                <ajaxToolkit:ConfirmButtonExtender ID="cbeActualizar" runat="server" 
                                    ConfirmText="¿Está seguro(a) que desea actualizar el registro?" 
                                    TargetControlID="btn_actualizar" />
                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" Height="26px" ImageUrl="~/Icon/Cancel.png" Width="28px" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="btnNuevo" runat="server" CommandName="ShowNew" Height="27px" ImageUrl="~/Icon/add.jpg" Width="29px" />
                                <asp:ImageButton ID="btnGuardargv" runat="server" CommandName="AddNew" Visible="False" Height="24px" ImageUrl="~/Icon/save.jpg" Width="25px" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbeGuardar" runat="server" 
                                    ConfirmText="¿Está seguro(a) que desea agregar un nuevo registro?" 
                                    TargetControlID="btnGuardargv" />
                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" Visible="False" Height="24px" ImageUrl="~/Icon/Cancel.png" Width="30px" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEditar" runat="server" Height="26px" ImageUrl="~/Icon/Edtitar.jpg" Width="24px" CommandName="Edit"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnEliminar" runat="server" CommandName="Delete" Height="27px" ImageUrl="~/Icon/delete.png" Width="33px" />
                                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmEliminar" runat="server" 
                                    ConfirmText="¿Está seguro(a) que desea eliminar el registro?" 
                                    TargetControlID="BtnEliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Justify" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

            </td>

        </table>

        <hr />


        <table>
            <td style="width: 971px" align="left">
                <h3>
                    <asp:Label ID="Label5" runat="server" Text="INFORMACIÓN DOMICILIO :" Style="font-weight: 700"></asp:Label>
                </h3>
            </td>
        </table>
        </strong>
        <table style="width: 102%; text-align: left">
            <tr>
                <td style="width: 88px; height: 25px;">
                    <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio:"></asp:Label>
                </td>
                <td style="width: 109px">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>


                    <asp:DropDownList ID="cbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td style="width: 120px">
                    <asp:Label ID="lblCanton" runat="server" Text="Canton:"></asp:Label>
                    <asp:DropDownList ID="cbCanton" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbCanton_SelectedIndexChanged">
                    </asp:DropDownList>

                </td>
                <td style="width: 110px">
                    <asp:Label ID="lblDistrito" runat="server" Text="Distrito:"></asp:Label>


                    <asp:DropDownList ID="cbDistrito" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>

                <td>
                    <br />
                    <asp:Label ID="lblOtrasSenas" runat="server" Text="Detalle Dirección:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine" Width="390px" Height="42px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="valida_txtDireccion" runat="server"
                         ControlToValidate="txtDireccion"
                         ErrorMessage="Detalle Dirección"
                         ForeColor="Red"
                         display="None"
                         ValidationGroup="valida"> </asp:RequiredFieldValidator>

                </td>


            </tr>

        </table>


        <br />
        <asp:validationsummary id="valida" ValidationGroup="valida"  HeaderText="*Campos requeridos*" ForeColor="Red" runat="Server" showmessagebox="true" cssclass="validation-summary-errors" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Solicitud" ValidationGroup="valida" ValidateRequestMode="Enabled"  OnClick="btnGuardar_Click" />

        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Campos" OnClick="btnLimpiar_Click" />
        <asp:Button ID="btnCargar" runat="server" AutoPostBack="false" Text="Cargar Solicitudes" OnClick="btnSolicitudes_Click" />

       

        <%--  --%>
        <br />
        <asp:Label ID="lblMensaje2" runat="server" Text="" Style="font-weight: 700" Visible="false" ForeColor="Red"></asp:Label>
        

        <%-- <div style="height: 99%">
            <div class="col-md-2" style="float: left">
                <asp:CheckBox runat="server" ID="chbBlackListIN" Text="Ingresar BlackList" OnCheckedChanged="chbBlackListIN_CheckedChanged" AutoPostBack="true" />
            </div>
            <div class="col-md-2" style="margin-left: 24%; margin-right: 24%">
                <asp:CheckBox runat="server" ID="chbBajaTodo" Text="Dar de baja de todo" OnCheckedChanged="chbBajaTodo_CheckedChanged" AutoPostBack="true" />
            </div>
            <div class="col-md-2" style="float: right">
                <asp:CheckBox runat="server" ID="chbBlackListOUT" Text="Sacar de BlackList" OnCheckedChanged="chbBlackListOUT_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>--%>
        <br />
        <asp:HiddenField ID="hdfIdPersona" runat="server" />
        <asp:Label ID="LblValidaCuentaPred" runat="server" Text="" Style="font-weight: 700" Visible="false" ForeColor="Red"></asp:Label>
        

    </div>

    </strong>
  
</asp:Content>
