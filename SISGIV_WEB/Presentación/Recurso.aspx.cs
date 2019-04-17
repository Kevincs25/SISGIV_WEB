using Negocio.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación
{
    public partial class Recurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            this.LlenarGV();
        }

        public void LlenarGV() 
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            RecursoBL ServicioBL = new RecursoBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Estado");
            Grid.Columns.Add("Nombre");
            Grid.Columns.Add("Tipo");
          
            foreach (var Recursos in ServicioBL.GetRecursoBL())
            {
                Fila = Grid.NewRow();

                Fila["Código"] = Recursos.IdRecurso;
                Fila["Estado"] = Recursos.Estado;
                Fila["Nombre"] = Recursos.Nombre;
                Fila["Tipo"] = Recursos.Tipo;
         
                Grid.Rows.Add(Fila);
            }

            GvRecurso.DataSource = Grid;
            GvRecurso.DataBind();
        }




        public void LlenarGvPorCodigo()
        {
            RecursoBL ServicioBL = new RecursoBL();
            Entities.Entities.Recurso Recurso = new Entities.Entities.Recurso();

            if (TbBuscar.Text.Trim() == "")
            {
                this.LlenarGV();
            }
            else
            {
                Recurso = ServicioBL.GetRecursoPorIDBL(Convert.ToInt32(TbBuscar.Text));

                if (Recurso == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertCodigoInvalido()", true);
                    TbBuscar.Text = "";
                    this.LlenarGV();
                }
                else
                {
                    DataTable Grid = new DataTable();
                    DataRow Fila;


                    Grid.Columns.Add("Código");
                    Grid.Columns.Add("Estado");
                    Grid.Columns.Add("Nombre");
                    Grid.Columns.Add("Tipo");

                    Fila = Grid.NewRow();

                    Fila["Código"] = Recurso.IdRecurso;
                    Fila["Estado"] = Recurso.Estado;
                    Fila["Nombre"] = Recurso.Nombre;
                    Fila["Tipo"] = Recurso.Tipo;
                    Grid.Rows.Add(Fila);

                    GvRecurso.DataSource = Grid;
                    GvRecurso.DataBind();
                }
            }
        }



        public void LimpiarCampos() 
        {
            TbNombreRecurso.Text = "";
            DdTipo.SelectedIndex = 0;
            DdEstado.SelectedIndex = 0;

            Session.RemoveAll();
        }



        protected void GvRecurso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRecurso.PageIndex = e.NewPageIndex;
            this.LlenarGV();
        }



        protected void BtGv_Command(object sender, CommandEventArgs e)
        {
            string Codigo = e.CommandArgument.ToString();

            RecursoBL ServicioBL = new RecursoBL();
            Entities.Entities.Recurso Recurso = new Entities.Entities.Recurso();

            Recurso = ServicioBL.GetRecursoPorIDBL(Convert.ToInt32(Codigo));

            TbNombreRecurso.Text = Recurso.Nombre;
            DdTipo.SelectedValue = Recurso.Tipo;
            DdEstado.SelectedValue = Recurso.Estado;

            Session["Update"] = 1;

            Session["CodigoResidente"] = Convert.ToInt32(Codigo);
        }



        protected void BtNuevoRecurso_Click(object sender, EventArgs e)
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
                    if (TbNombreRecurso.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertCamposIncompletos()", true);
                    }
                    else
                    {
                        if (DdTipo.SelectedValue == "SEL")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertSeleccionarTipo()", true);
                        }
                        else if (DdEstado.SelectedValue != "SEL")
                        {
                            Entities.Entities.Recurso NewRecurso = new Entities.Entities.Recurso();
                            RecursoBL ServicioBL = new RecursoBL();
                            bool Resultado = new bool();

                            NewRecurso.Nombre = TbNombreRecurso.Text;
                            NewRecurso.Tipo = DdTipo.SelectedValue.ToString();
                            NewRecurso.Estado = DdEstado.SelectedValue.ToString();

                            Resultado = ServicioBL.SetRecursoBL(NewRecurso);

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
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertSeleccionarEstado()", true);
                        }
                    }
                }
            }
        }



        protected void BtActualizarRecurso_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                if (TbNombreRecurso.Text.Trim() == "" || DdTipo.SelectedValue == "SEL" || DdEstado.SelectedValue == "SEL")
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
                        Entities.Entities.Recurso UpdateRecurso = new Entities.Entities.Recurso();
                        RecursoBL ServicioBL = new RecursoBL();

                        bool Resultado = false;
                        int IdUpdate = (int)Session["CodigoResidente"];


                        UpdateRecurso.Nombre = TbNombreRecurso.Text;
                        UpdateRecurso.Tipo = DdTipo.SelectedValue;
                        UpdateRecurso.Estado = DdEstado.SelectedValue;

                        Resultado = ServicioBL.UpdateRecursoBL(IdUpdate, UpdateRecurso);

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



        protected void BtCalcelar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }



        protected void btBuscar_Click(object sender, EventArgs e)
        {
            this.LlenarGvPorCodigo();
            this.LimpiarCampos();
        }
    }
}