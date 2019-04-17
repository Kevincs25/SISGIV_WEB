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
    public partial class ServicioDeCorreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                this.LlenarGVModal();
            }

        }



        public void LlenarGVModal() 
        {
            DataTable Grid = new DataTable();
            DataRow Fila;
            ResidenteBL ServicioBL = new ResidenteBL();

            Grid.Columns.Add("Código");
            Grid.Columns.Add("Nombres");
            Grid.Columns.Add("Apellidos");
            Grid.Columns.Add("Email");

            foreach (var Residentes in ServicioBL.GetResidenteBL())
            {
                Fila = Grid.NewRow();

                Fila["Código"] = Residentes.IdResidente;
                Fila["Nombres"] = Residentes.Nombres;
                Fila["Apellidos"] = Residentes.Apellidos;
                Fila["Email"] = Residentes.Correo;
   
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
                this.LlenarGVModal();
            }
            else
            {
                Residente = Servicio.GetResidentePorIDBL(Convert.ToInt32(TbBuscarCodigo.Text));

                if (Residente == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", " AlertCodigoInvalido()", true);
                    TbBuscarCodigo.Text = "";
                    this.LlenarGVModal();;
                }
                else
                {
                    DataTable Grid = new DataTable();
                    DataRow Fila;
                    ResidenteBL ServicioBL = new ResidenteBL();

                    Grid.Columns.Add("Código");
                    Grid.Columns.Add("Nombres");
                    Grid.Columns.Add("Apellidos");
                    Grid.Columns.Add("Email");

                    Fila = Grid.NewRow();

                    Fila["Código"] = Residente.IdResidente;
                    Fila["Nombres"] = Residente.Nombres;
                    Fila["Apellidos"] = Residente.Apellidos;
                    Fila["Email"] = Residente.Correo;
   

                    Grid.Rows.Add(Fila);

                    GvResidentes.DataSource = Grid;
                    GvResidentes.DataBind();
                }
            }
        }




        public void Limpiar() 
        {
            TbDestinoDeCorreo.Text = "";
            TbAsuntoDelCorreo.Text = "";
            TbMensaje.Text = "";
        }
    


        protected void BtBuscarCorrep_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCorreos').modal('show')", true);
        }




        protected void GvResidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvResidentes.PageIndex = e.NewPageIndex;
            this.LlenarGVModal();
        }



        protected void BtGv_Command(object sender, CommandEventArgs e)
        {
            string Codigo = e.CommandArgument.ToString();

            ResidenteBL Servicio = new ResidenteBL();
            Entities.Entities.Residente Residente = new Entities.Entities.Residente();

            Residente = Servicio.GetResidentePorIDBL(Convert.ToInt32(Codigo));

            TbDestinoDeCorreo.Text = Residente.Nombres + " " + Residente.Apellidos + " / " + Residente.Correo;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCorreos').modal('hide')", true);
        }




        protected void BtEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (TbDestinoDeCorreo.Text.Trim() == "" || TbAsuntoDelCorreo.Text.Trim() == "" || TbMensaje.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertCamposIncompletos()", true);
            }
            else 
            {
                string[] Correo = TbDestinoDeCorreo.Text.Split('/');

                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                //Direccion de correo electronico a la que queremos enviar el mensaje
                mmsg.To.Add(Correo[1]);
                mmsg.Subject = TbAsuntoDelCorreo.Text;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Cuerpo del Mensaje
                mmsg.Body = TbMensaje.Text;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = false; 

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new System.Net.Mail.MailAddress("********");


                /*-------------------------CLIENTE DE CORREO----------------------*/

                //Creamos un objeto de cliente de correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                //Hay que crear las credenciales del correo emisor
                cliente.Credentials = new System.Net.NetworkCredential("*****", "******");

                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";


                /*-------------------------ENVIO DE CORREO----------------------*/

                try
                {
                    cliente.Send(mmsg);
                    this.Limpiar();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "ALertEnviado()", true);
                }
                catch (System.Net.Mail.SmtpException)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "AlertErroAlEnviarCorreo()", true);
                }
            }
         }



        protected void BtCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }




        protected void BtCerrarModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jskeys", "$('#ModalCorreos').modal('hide')", true);
        }





        protected void BtBuscarCodigo_Click(object sender, EventArgs e)
        {
            this.LlenarGVPorCodigo();
        }




        }

    }
