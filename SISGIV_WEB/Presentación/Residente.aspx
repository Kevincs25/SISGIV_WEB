<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Residente.aspx.cs" Inherits="Presentación.Residente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css"/>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>

    <script>
        function ALertGuardado()
        {
            Swal.fire({
                type: 'success',
                title: 'Residente Agregado Exitosamente',
                showConfirmButton: false,
                timer: 1500
            })
        }

        function ALertActualizado() {
            Swal.fire({
                type: 'success',
                title: 'Residente Actualizado Exitosamente',
                showConfirmButton: false,
                timer: 1500
            })
        }

        function AlertCamposIncompletos()
        {
            Swal.fire({
                type: 'error',
                title: 'Campos Incompletos',
                text: 'Complete los campos para realizar la acción!',
                footer: 'Te pica el culo?'
            })
        }

        function AlertSeleccionarEstado()
        {
            Swal.fire
            ({
                title: 'No ha seleccionado el estado',
                type: 'info',
                html: 'Seleciones el estado del residente',
            })
        }

        function AlertCodigoInvalido() {
            Swal.fire
            ({
                title: 'Codigo no invalido',
                type: 'info',
                html: 'Ingrese un nuevo codigo',
            })
        }


        function AlertNombreInvalido() {
            Swal.fire
            ({
                title: 'No se econtraron registros',
                type: 'info',
                html: 'Verifique el nombre del residente',
            })
        }

        function AlertApellidoInvalido() {
            Swal.fire
            ({
                title: 'No se econtraron registros',
                type: 'info',
                html: 'Verifique el apellido del residente',
            })
        }

        function AlertGuardarExistente() {
            Swal.fire({
                type: 'error',
                title: 'Este registro ya existe',
            })
        }

        function AlertActualizarNoExistente() {
            Swal.fire({
                type: 'error',
                title: 'Este registro no existe',
            })
        }

        function AlertErroEnElSistema() {
            Swal.fire({
                type: 'error',
                title: 'Error en el sistema',
            })
        }
       
    </script>
    

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
<!-- Banner -->
        <div class="row bg-primary">
            <center>
                 <h1> <i class="fas fa-shield-alt"></i> SISGIV </h1>
                 <h4>Sistema de Gestion de Vigilancia</h4>
            </center>
        </div>
<!-- Fin Banner -->

<!-- Barra de navegacion -->
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluit">

                <div class="navbar-header">

                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>

                    <a class="navbar-brand" href="PrincipalAdministrador.aspx">
                        <h4><i class="fas fa-home"></i> Inicio</h4>
                    </a>

                </div>

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">

                    <ul class="nav navbar-nav">

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <h4><i class="fas fa-binoculars"></i> Vigilancia <span class="caret"></span></h4>
                            </a>
                            <ul class="dropdown-menu">
                                <li><a href="Vigilante.aspx">Vigilante</a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="#">Programación Vigilancia</a></li>
                                <li><a href="#">Servicio de Vigilancia</a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="Recurso.aspx">Recurso</a></li>
                                <li role="separator" class="divider"></li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <h4><i class="fas fa-map-marked-alt"></i> Area <span class="caret"></span></h4>
                            </a>
                            <ul class="dropdown-menu">
                                <li><a href="casa.aspx">Casa </a></li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <h4><i class="fas fa-dollar-sign"></i> Pago de Servicio de Vigilancia <span class="caret"></span></h4>
                            </a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Facturación</a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="ServicioDeCorreo.aspx">Servicio de Correo</a></li>
                            </ul>
                        </li>

                    </ul>

                    <div class="pull-right">
                        <h3>Login <i class="fas fa-user-circle"></i></h3>
                    </div>
                </div>
            </div>
        </nav>

<!-- Fin Barra de navegacion -->

<!-- Formulario  -->

        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel-primary panel panel-default">

                    <div class="panel-heading">
                        <h4><i class="fas fa-user-tie"></i> Residente</h4>
                    </div>

                    <div class="panel-body">

                            <div class="row">
                            <br />
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label1" runat="server" Text="Nombres:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbNombresResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbNombresResidente" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                            </div>

                              <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label2" runat="server" Text="Apellidos:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbResidenteApellidos" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbResidenteApellidos" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-2">
                                 <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label3" runat="server" Text="Edad:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbEdadResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbEdadResidente" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^\d+(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>
                            </div>
                             <div class="col-md-1"></div>
                            <br />
                            <br />
                            <br />

                        </div>

                        <div class="row">
                             <div class="col-md-1"></div>
                             <div class="col-md-2">
                                 <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label6" runat="server" Text="Cedula:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbCedulaResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label4" runat="server" Text="Teléfono:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbTelefonoResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbTelefonoResidente" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^\d+(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label5" runat="server" Text="Correo Electronico:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbCorreoResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label7" runat="server" Text="Estado:"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="DdEstadoResidente" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="SEL">Selecionar</asp:ListItem>
                                        <asp:ListItem Value="ACT">Activo</asp:ListItem>
                                        <asp:ListItem Value="INA">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-1"></div>

                            <br />
                            <br />

                        </div>

                        <hr />

                        <asp:GridView ID="GvResidentes" runat="server" CssClass="table table-hover table-bordered" AllowPaging="true" OnPageIndexChanging="GvResidentes_PageIndexChanging" PageSize="6">
                            <HeaderStyle CssClass="bg-primary" />
                            <RowStyle />
                            <PagerStyle HorizontalAlign="Center" />
                            <PagerSettings PageButtonCount="10" Mode="NumericFirstLast" />

                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtGv" CssClass="btn-lg" runat="server" OnCommand="BtGv_Command" CommandArgument='<%# Eval("Código") %>'><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>

                    <div class="panel-footer">

                        <div class="row">

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label8" runat="server" Text="Filtrar por:"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="DdBuscarPor" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DdBuscarPor_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="NOM">Nombre</asp:ListItem>
                                        <asp:ListItem Value="APE">Apellido</asp:ListItem>
                                        <asp:ListItem Value="COD">C&#243;digo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:TextBox ID="TbBuscarNombre" CssClass="form-control" Visible="true" runat="server" AutoPostBack="true"></asp:TextBox>
                                    <asp:TextBox ID="TbBuscarApellido" CssClass="form-control" Visible="false" runat="server" AutoPostBack="true"></asp:TextBox>
                                    <asp:TextBox ID="TbBuscarCodigo" CssClass="form-control" Visible="false" runat="server" AutoPostBack="true"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-search"></i></asp:LinkButton>
                                    </div>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbBuscarNombre" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbBuscarApellido" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbBuscarCodigo" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^\d+(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-4"></div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="BtGuardarResidente" CssClass="btn btn-primary form-control" runat="server" OnClick="BtGuardarResidente_Click">Nuevo <i class="fas fa-user-check"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="BtActualizarResidente" CssClass="btn btn-warning form-control" runat="server" OnClick="BtActualizarResidente_Click">Actualizar <i class="fas fa-user-cog"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="BtCalcelar" CssClass="btn btn-danger form-control" runat="server" OnClick="BtCalcelar_Click">Cancelar <i class="fas fa-user-times"></i></asp:LinkButton>
                            </div>

                        </div>


                    </div>

                </div>

            </div>
            <div class="col-md-1"></div>
        </div>
 <%--  Fin del formulario--%>

    </form>
</body>
</html>
