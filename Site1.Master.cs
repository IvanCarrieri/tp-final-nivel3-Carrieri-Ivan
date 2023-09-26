using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Registro;
using Dominio;

namespace WebFinal
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        public bool login { get; set; }
        public string email { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            try
            {

                if (!(Page is Login || Page is Default || Page is Registro || Page is Error || Page is Detalle))
                {


                    if (seguridad.sesionActiva(Session["Usuario"]) != true)
                    {

                        Response.Redirect("Login.aspx", false);
                    }


                }

                if (seguridad.sesionActiva(Session["Usuario"]) != true)
                {
                    login = false;
                }
                else
                {

                    Usuario user = (Usuario)Session["Usuario"];

                    LabelEmail.Text = user.Email;


                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        ImagenPerfil.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;
                    }
                    else
                    {
                        ImagenPerfil.ImageUrl = "https://img.icons8.com/fluency/48/test-account.png";
                    }

                    login = true;

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


            // que deje acceder al default y a registrarse


        }



        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void ImagenPerfil_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}