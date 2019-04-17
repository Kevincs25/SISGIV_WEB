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
    public partial class Casa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                this.LlenarGv();
                this.LlenarGvModal();
            }
        }




        protected void BtBuscarResidente_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCasas').modal('show')",true);
        }



        public void LlenarGv() 
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            CasaBL ServicioBL = new CasaBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Código Area");
            Grid.Columns.Add("Código Residente");
            Grid.Columns.Add("Habitantes");
            Grid.Columns.Add("Teléfono");
            Grid.Columns.Add("Descripción");
            Grid.Columns.Add("Letra");
            Grid.Columns.Add("Estado");
            
            foreach (var Casas in ServicioBL.GetCasaBL())
            {
                Fila = Grid.NewRow();

                Fila["Código"] = Casas.IdCasa;
                Fila["Código Area"] = Casas.IdArea;
                Fila["Código Residente"] = Casas.IdResidente;
                Fila["Habitantes"] = Casas.NumeroDeHabitantes;
                Fila["Teléfono"] = Casas.Telefono;
                Fila["Descripción"] = Casas.Descripcion;
                Fila["Letra"] = Casas.Letra;
                Fila["Estado"] = Casas.Estado;
 
                Grid.Rows.Add(Fila);
            }

            GvCasas.DataSource = Grid;
            GvCasas.DataBind();
        }




        public void LlenarGvModal()
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            CasaBL ServicioBL = new CasaBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Residente");

            foreach (var Residentes in ServicioBL.GetResidenteBL())
            {
                Fila = Grid.NewRow();

                Fila["Código"] = Residentes.IdResidente;
                Fila["Residente"] = Residentes.Nombres + " " + Residentes.Apellidos;
           
                Grid.Rows.Add(Fila);
            }

            GvResidentes.DataSource = Grid;
            GvResidentes.DataBind();
        }



        public void LlenarGvModalPorID()
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            CasaBL ServicioBL = new CasaBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Residente");

            var Resi = ServicioBL.GetResidentePorIDBL(Convert.ToInt32(TbBuscarCodigo.Text));
            
            Fila = Grid.NewRow();

            Fila["Código"] = Resi.IdResidente;
            Fila["Residente"] = Resi.Nombres + " " + Resi.Apellidos;

            Grid.Rows.Add(Fila);
          
            GvResidentes.DataSource = Grid;
            GvResidentes.DataBind();
        }



        protected void GvCasas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCasas.PageIndex = e.NewPageIndex;
            this.LlenarGv();
        }



        protected void GvResidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvResidentes.PageIndex = e.NewPageIndex;
            this.LlenarGvModal();
        }



        protected void BtGv_Command(object sender, CommandEventArgs e)
        {
            string Codigo = e.CommandArgument.ToString();

            CasaBL ServicioBL = new CasaBL();
            Entities.Entities.Residente Resi = new Entities.Entities.Residente();

            Resi = ServicioBL.GetResidentePorIDBL(Convert.ToInt32(Codigo));

            TbNombresResidente.Text = Resi.IdResidente +" - "+ Resi.Nombres +" "+ Resi.Apellidos;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCasas').modal('hide')", true);
        }



        protected void BtCerrarModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCasas').modal('hide')", true);
        }



        protected void BtBuscarCodigo_Click(object sender, EventArgs e)
        {
           
        }

    }
}