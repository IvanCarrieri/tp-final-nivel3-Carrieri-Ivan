using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Registro;

namespace WebFinal
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistro_Click(object sender, EventArgs e)
        {

                Usuario objUsuario = new Usuario();
                UsuarioRegistro objUR = new UsuarioRegistro();
                ServicioEmail ObjservicioEmail = new ServicioEmail();


            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxPass.Text))
                {
                    Session.Add("Error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                    return;
                }


                if (!TextBoxEmail.Text.Contains('@'))

                {
                    Session.Add("Error", "Debes ingresar una dirección de email válida");
                    Response.Redirect("Error.aspx");
                    return;
                }



                objUsuario.Email = TextBoxEmail.Text;
                objUsuario.Pass = TextBoxPass.Text;


                objUsuario.Id = objUR.insertarNuevo(objUsuario);

                Session.Add("Usuario", objUsuario);

                ObjservicioEmail.armarCorreo(objUsuario.Email, "Bienvenido/a a la web MercadoValen", "Podras comprar tecnologia al mejor precio y servicio");
                ObjservicioEmail.enviarEmail();
                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}