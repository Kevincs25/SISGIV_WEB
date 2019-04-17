<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Casa.aspx.cs" Inherits="Presentación.Casa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css"/>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">  <h4><i class="fas fa-binoculars"></i> Vigilancia <span class="caret"></span></h4></a>
          <ul class="dropdown-menu">
            <li><a href="Vigilante.aspx">Vigilante</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Programación Vigilancia</a></li>
            <li><a href="#">Servicio de Vigilancia</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Recurso</a></li>
            <li role="separator" class="divider"></li>
          </ul>
        </li>

         <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><h4><i class="fas fa-map-marked-alt"></i> Area <span class="caret"></span></h4></a>
              <ul class="dropdown-menu">
                  <li><a href="Residente.aspx">Residente</a></li>
              </ul>
         </li>

          <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><h4><i class="fas fa-dollar-sign"></i> Pago de Servicio de Vigilancia <span class="caret"></span></h4></a>
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

<!-- Fin de la barra de navegacion -->
<!-- Inicio del formulario -->

        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel-primary panel panel-default">
                    
                    <div class="panel-heading">
                        <h4><i class="fas fa-home"></i> Casa</h4>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>

                    <div class="panel-body">
                           
                        <div class="row">

                            <br />

                            <div class="col-md-1"></div>

                             <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label1" runat="server" Text="Residente:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbNombresResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                    <div class="input-group-btn">
                                    <asp:LinkButton ID="BtBuscarResidente" CssClass="btn btn-primary form-control" runat="server" OnClick="BtBuscarResidente_Click"><i class="fas fa-search-plus"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label2" runat="server" Text="Código:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbCodResidente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                               <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label3" runat="server" Text="Telefono:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbCasaTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label7" runat="server" Text="Area:"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="DdArea" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="SEL">Selecionar</asp:ListItem>
                                        <asp:ListItem Value="FP">Frente al parque</asp:ListItem>
                                        <asp:ListItem Value="CC">Calle Central</asp:ListItem>
                                        <asp:ListItem Value="CE">Calle Este</asp:ListItem>
                                        <asp:ListItem Value="CO">Calle Oeste</asp:ListItem>
                                        <asp:ListItem Value="CN">Calle Norte</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                    <div class="col-md-1"></div>
                            </div>

                            <br />
                            <br />
                            <br />

                        </div>

                        <div class="row">

                           <div class="col-md-1"></div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label4" runat="server" Text="Letra"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbLetra" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label5" runat="server" Text="Habitantes"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbHabitantes" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label8" runat="server" Text="Estado:"></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="DdEstadoResidente" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="SEL">Selecionar</asp:ListItem>
                                        <asp:ListItem Value="ACT">Activo</asp:ListItem>
                                        <asp:ListItem Value="INA">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                                <div class="col-md-1"></div>
                        </div>

                        <hr />

                            <asp:GridView ID="GvCasas" runat="server" CssClass="table table-hover table-bordered" AllowPaging="true" OnPageIndexChanging="GvCasas_PageIndexChanging" PageSize="6">
                            <HeaderStyle CssClass="bg-primary" />
                            <RowStyle />
                            <PagerStyle HorizontalAlign="Center" />
                            <PagerSettings PageButtonCount="10" Mode="NumericFirstLast" />

                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtGv" CssClass="btn-lg" runat="server" CommandArgument='<%# Eval("Código") %>'><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                       
                    </div>

                    <div class="panel-footer">

                         <div class="row">
                                <div class="col-md-9"></div>
                                <div class="col-md-1">
                                    <asp:LinkButton ID="BtNuevoResidente" CssClass="btn btn-warning form-control" runat="server">Nuevo <i class="fas fa-plus"></i></asp:LinkButton>
                                </div>

                                <div class="col-md-1">
                                    <asp:LinkButton ID="BtGuardarResidente" CssClass="btn btn-primary form-control" runat="server">Guardar <i class="fas fa-save"></i></asp:LinkButton>
                                </div>
                                
                                <div class="col-md-1">
                                    <asp:LinkButton ID="BtCalcelar" CssClass="btn btn-danger form-control" runat="server">Cancelar <i class="fas fa-times"></i></asp:LinkButton>
                                </div> 
                        </div>

                    </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>

            </div>
            <div class="col-md-1"></div>
        </div>

<!-- Fin del formulario -->

        <div class="modal fade bs-example-modal-lg" id="ModalCasas" tabindex="-1" role="document" aria-labelledby="myModallabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">

                    <div class="modal-header bg-primary" >
                        <h4><i class="fas fa-user-tie"></i> Residentes</h4>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                    <div class="modal-body">
                                
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

                    <div class="modal-footer">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:Label ID="Label9" runat="server" Text="Filtrar Por Código:"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="TbBuscarCodigo" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BtBuscarCodigo" CssClass="btn btn-primary" runat="server" OnClick="BtBuscarCodigo_Click" ><i class="fas fa-search"></i></asp:LinkButton>
                                    </div>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="TbBuscarCodigo" ErrorMessage="Los datos ingresados en el campo de texto son invalidos" ValidationExpression="^\d+(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-6"></div>

                             <div class="col-md-2">
                                 <asp:LinkButton ID="BtCerrarModal" CssClass="btn btn-danger form-control" runat="server" OnClick="BtCerrarModal_Click">Cerrar <i class="fas fa-ban"></i></asp:LinkButton>
                             </div>
                        </div>
                    </div>

                            </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>

<!-- Fin Modal Casa Residente -->
    </form>
</body>
</html>
