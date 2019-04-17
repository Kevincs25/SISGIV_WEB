<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vigilante.aspx.cs" Inherits="Presentación.Vigilante" %>

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
            <li><a href="#">Programación Vigilancia</a></li>
            <li><a href="#">Servicio de Vigilancia</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="Recurso.aspx">Recurso</a></li>
            <li role="separator" class="divider"></li>
          </ul>
        </li>

         <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><h4><i class="fas fa-map-marked-alt"></i> Area <span class="caret"></span></h4></a>
              <ul class="dropdown-menu">
                  <li><a href="Residente.aspx">Residente</a></li>
                  <li role="separator" class="divider"></li>
                  <li><a href="Casa.aspx">Casa </a></li>
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

 <!-- Fin Barra de navegacion -->
 
<!-- Formulario  -->

        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel-primary panel panel-default">

                    <div class="panel-heading">
                        <h4><i class="fas fa-user-shield"></i> Vigilante</h4>
                    </div>

                    <div class="panel-body">
                           
                    </div>

                    <div class="panel-footer">
                        <br />
                    </div>
                </div>

            </div>
            <div class="col-md-1"></div>
        </div>
   
    </form>
</body>
</html>
