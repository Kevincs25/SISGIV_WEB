using Negocio.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Entities;


namespace Presentación
{
    public partial class Residente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                this.LlenarGV();

                TbBuscarNombre.Visible = true;
                TbBuscarApellido.Visible = false;
                TbBuscarCodigo.Visible = false;
            }

        }

        public void LlenarGV()
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            ResidenteBL ServicioBL = new ResidenteBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Estado");
            Grid.Columns.Add("Nombres");
            Grid.Columns.Add("Apellidos");
            Grid.Columns.Add("Edad");
            Grid.Columns.Add("Teléfono");
            Grid.Columns.Add("Email");
            Grid.Columns.Add("Cedula");

            foreach (var Residentes in ServicioBL.GetResidenteBL())
            {
                Fila = Grid.NewRow();

                Fila["Código"] = Residentes.IdResidente;
                Fila["Estado"] = Residentes.Estado;
                Fila["Nombres"] = Residentes.Nombres;
                Fila["Apellidos"] = Residentes.Apellidos;
                Fila["Edad"] = Residentes.Edad;
                Fila["Teléfono"] = Residentes.Telefono;
                Fila["Email"] = Residentes.Correo;
                Fila["Cedula"] = Residentes.Cedula;

                Grid.Rows.Add(Fila);
            }

            GvResidentes.DataSource = Grid;
            GvResidentes.DataBind();

        }



        public void LlenarGVPorCodigo()
        {
            ResidenteBL Servicio = new ResidenteBL();
            Entities.Entities.Residente Residente = new Entities.Entities.Residente();

            if (TbBuscarCodigo.Text.Trim() == "")
            {
                this.LlenarGV();
            }
            else 
            {
                Residente = Servicio.GetResidentePorIDBL(Convert.ToInt32(TbBuscarCodigo.Text));

                if (Residente == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", " AlertCodigoInvalido()", true);
                    TbBuscarCodigo.Text = "";
                    this.LlenarGV();
                }
                else
                {
                    DataTable Grid = new DataTable();
                    DataRow Fila;
                    ResidenteBL ServicioBL = new ResidenteBL();

                    Grid.Columns.Add("Código");
                    Grid.Columns.Add("Estado");
                    Grid.Columns.Add("Nombres");
                    Grid.Columns.Add("Apellidos");
                    Grid.Columns.Add("Edad");
                    Grid.Columns.Add("Teléfono");
                    Grid.Columns.Add("Email");
                    Grid.Columns.Add("Cedula");

                    Fila = Grid.NewRow();

                    Fila["Código"] = Residente.IdResidente;
                    Fila["Estado"] = Residente.Estado;
                    Fila["Nombres"] = Residente.Nombres;
                    Fila["Apellidos"] = Residente.Apellidos;
                    Fila["Edad"] = Residente.Edad;
                    Fila["Teléfono"] = Residente.Telefono;
                    Fila["Email"] = Residente.Correo;
                    Fila["Cedula"] = Residente.Cedula;

                    Grid.Rows.Add(Fila);

                    GvResidentes.DataSource = Grid;
                    GvResidentes.DataBind();
                }
            }
        }



        public void LlenarGVPorNombres()
        {
            ResidenteBL Servicio = new ResidenteBL();
            List<Entities.Entities.Residente> Residentes = new List<Entities.Entities.Residente>();

            if (TbBuscarNombre.Text.Trim() == "")
            {
                this.LlenarGV();
            }
            else
            {
                Residentes = Servicio.GetResidentesPorNombreBL(TbBuscarNombre.Text);

                if (Residentes.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", " AlertNombreInvalido()", true);
                    TbBuscarNombre.Text = "";
                    this.LlenarGV();
                }
                else
                {
                    DataTable Grid = new DataTable();
                    DataRow Fila;
                    ResidenteBL ServicioBL = new ResidenteBL();

                    Grid.Columns.Add("Código");
                    Grid.Columns.Add("Estado");
                    Grid.Columns.Add("Nombres");
                    Grid.Columns.Add("Apellidos");
                    Grid.Columns.Add("Edad");
                    Grid.Columns.Add("Teléfono");
                    Grid.Columns.Add("Email");
                    Grid.Columns.Add("Cedula");

                    foreach (var Residente in Residentes)
                    {
                        Fila = Grid.NewRow();

                        Fila["Código"] = Residente.IdResidente;
                        Fila["Estado"] = Residente.Estado;
                        Fila["Nombres"] = Residente.Nombres;
                        Fila["Apellidos"] = Residente.Apellidos;
                        Fila["Edad"] = Residente.Edad;
                        Fila["Teléfono"] = Residente.Telefono;
                        Fila["Email"] = Residente.Correo;
                        Fila["Cedula"] = Residente.Cedula;

                        Grid.Rows.Add(Fila);
                    }
                    

                    GvResidentes.DataSource = Grid;
                    GvResidentes.DataBind();
                }
            }
        }



        public void LlenarGVPorApellidos()
        {
            ResidenteBL Servicio = new ResidenteBL();
            List<Entities.Entities.Residente> Residentes = new List<Entities.Entities.Residente>();

            if (TbBuscarApellido.Text.Trim() == "")
            {
                this.LlenarGV();
            }
            else
            {
                Residentes = Servicio.GetResidentesPorApellidoBL(TbBuscarApellido.Text);

                if (Residentes.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", " AlertApellidoInvalido()", true);
                    TbBuscarApellido.Text = "";
                    this.LlenarGV();
                }
                else
                {
                    DataTable Grid = new DataTable();
                    DataRow Fila;
                    ResidenteBL ServicioBL = new ResidenteBL();

                    Grid.Columns.Add("Código");
                    Grid.Columns.Add("Estado");
                    Grid.Columns.Add("Nombres");
                    Grid.Columns.Add("Apellidos");
                    Grid.Columns.Add("Edad");
                    Grid.Columns.Add("Teléfono");
                    Grid.Columns.Add("Email");
                    Grid.Columns.Add("Cedula");

                    foreach (var Residente in Residentes)
                    {
                        Fila = Grid.NewRow();

                        Fila["Código"] = Residente.IdResidente;
                        Fila["Estado"] = Residente.Estado;
                        Fila["Nombres"] = Residente.Nombres;
                        Fila["Apellidos"] = Residente.Apellidos;
                        Fila["Edad"] = Residente.Edad;
                        Fila["Teléfono"] = Residente.Telefono;
                        Fila["Email"] = Residente.Correo;
                        Fila["Cedula"] = Residente.Cedula;

                        Grid.Rows.Add(Fila);
                    }


                    GvResidentes.DataSource = Grid;
                    GvResidentes.DataBind();
                }
            }
        }



        public void LimpiarCampos()
        {
            TbNombresResidente.Text = "";
            TbResidenteApellidos.Text = "";
            TbEdadResidente.Text = "";
            TbCedulaResidente.Text = "";
            TbTelefonoResidente.Text = "";
            TbCorreoResidente.Text = "";
            DdEstadoResidente.SelectedIndex = 0;

            Session.RemoveAll();
        }



        protected void BtGuardarResidente_Click(object sender, EventArgs e)
        {
            int Opc = new int();

            if (Session["Update"] == null)
            {
                Opc = 0;
            }
            else
            {
                Opc = (int)Session["Update"];
            }
            
            if (Opc == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertGuardarExistente()", true);
            }
            else 
            {
                if (Page.IsValid == true)
                {
                    if (TbNombresResidente.Text.Trim() == "" || TbResidenteApellidos.Text.Trim() == "" || TbEdadResidente.Text.Trim() == "" ||
                        TbCedulaResidente.Text.Trim() == "" || TbTelefonoResidente.Text.Trim() == "" || TbCorreoResidente.Text.Trim() == "" ||
                        DdEstadoResidente.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertCamposIncompletos()", true);
                    }
                    else
                    {
                        if (DdEstadoResidente.SelectedValue == "SEL")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertSeleccionarEstado()", true);
                        }
                        else
                        {
                            Entities.Entities.Residente NewResidente = new Entities.Entities.Residente();
                            ResidenteBL ServicioBL = new ResidenteBL();
                            bool Resultado = new bool();

                            NewResidente.Nombres = TbNombresResidente.Text;
                            NewResidente.Apellidos = TbResidenteApellidos.Text;
                            NewResidente.Edad = Convert.ToInt32(TbEdadResidente.Text);
                            NewResidente.Telefono = TbTelefonoResidente.Text;
                            NewResidente.Correo = TbCorreoResidente.Text;
                            NewResidente.Estado = DdEstadoResidente.SelectedValue;
                            NewResidente.Cedula = TbCedulaResidente.Text;

                            Resultado = ServicioBL.SetResidenteBL(NewResidente);

                            if (Resultado == true)
                            {
                                this.LlenarGV();
                                this.LimpiarCampos();

                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "ALertGuardado()", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertErroEnElSistema()", true);
                            }
                        }
                    }
                }
            }
        }



        protected void BtCalcelar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }



        protected void GvResidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvResidentes.PageIndex = e.NewPageIndex;
            this.LlenarGV();
        }



        protected void BtGv_Command(object sender, CommandEventArgs e)
        {
            string Codigo = e.CommandArgument.ToString();

            ResidenteBL Servicio = new ResidenteBL();
            Entities.Entities.Residente Residente = new Entities.Entities.Residente();

            Residente = Servicio.GetResidentePorIDBL(Convert.ToInt32(Codigo));

            TbNombresResidente.Text = Residente.Nombres;
            TbResidenteApellidos.Text = Residente.Apellidos;
            TbEdadResidente.Text = Convert.ToString(Residente.Edad);
            TbCedulaResidente.Text = Residente.Cedula;
            TbTelefonoResidente.Text = Residente.Telefono;
            TbCorreoResidente.Text = Residente.Correo;

            if (Residente.Estado == "ACT")
            {
                DdEstadoResidente.SelectedIndex = 1;
            }
            else
            {
                DdEstadoResidente.SelectedIndex = 2;
            }


            Session["Update"] = 1;

            Session["CodigoResidente"] = Convert.ToInt32(Codigo);
         
         }



        protected void BtActualizarResidente_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                if (TbNombresResidente.Text.Trim() == "" || TbResidenteApellidos.Text.Trim() == "" || TbEdadResidente.Text.Trim() == "" || TbCedulaResidente.Text.Trim() == "" || TbTelefonoResidente.Text.Trim() == "" || TbCorreoResidente.Text.Trim() == "" || DdEstadoResidente.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertCamposIncompletos()", true);
                }
                else
                {
                    int Opc = new int();

                    if (Session["Update"] == null)
                    {
                        Opc = 0;
                    }
                    else
	                {
                        Opc = (int)Session["Update"]; 
	                }

                    if (Opc == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertActualizarNoExistente()", true);
                    }
                    else
                    {
                        Entities.Entities.Residente UpdateResidente = new Entities.Entities.Residente();
                        ResidenteBL Servicio = new ResidenteBL();

                        bool Resultado = false;
                        int IdUpdate = (int)Session["CodigoResidente"];


                        UpdateResidente.Nombres = TbNombresResidente.Text;
                        UpdateResidente.Apellidos = TbResidenteApellidos.Text;
                        UpdateResidente.Edad = Convert.ToInt32(TbEdadResidente.Text);
                        UpdateResidente.Telefono = TbTelefonoResidente.Text;
                        UpdateResidente.Correo = TbCorreoResidente.Text;
                        UpdateResidente.Estado = DdEstadoResidente.SelectedValue;
                        UpdateResidente.Cedula = TbCedulaResidente.Text;

                        Resultado = Servicio.UpdateResidenteBL(IdUpdate, UpdateResidente);

                        if (Resultado == true)
                        {
                            this.LlenarGV();
                            this.LimpiarCampos();

                            Session.RemoveAll();

                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "ALertActualizado()", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertErroEnElSistema()", true);
                        }
                    }
                }
            }
        }



        protected void DdBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdBuscarPor.SelectedValue == "NOM")
            {
                TbBuscarNombre.Visible = true;
                TbBuscarApellido.Visible = false;
                TbBuscarCodigo.Visible = false;
            }
            else if (DdBuscarPor.SelectedValue == "APE")
            {
                TbBuscarNombre.Visible = false;
                TbBuscarApellido.Visible = true;
                TbBuscarCodigo.Visible = false;
            }
            else if (DdBuscarPor.SelectedValue == "COD")
            {
                TbBuscarNombre.Visible = false;
                TbBuscarApellido.Visible = false;
                TbBuscarCodigo.Visible = true;
            }
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (DdBuscarPor.SelectedValue == "NOM")
            {
                this.LlenarGVPorNombres();
            }
            else if (DdBuscarPor.SelectedValue == "APE")
            {
                this.LlenarGVPorApellidos();
            }
            else if (DdBuscarPor.SelectedValue == "COD")
            {
                this.LlenarGVPorCodigo();
            }
        }



    }
}