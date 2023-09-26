using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Newtonsoft.Json.Linq;
using Registro;


namespace WebFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            Usuario objUsuario = new Usuario();
            UsuarioRegistro objUsuarioRegistro = new UsuarioRegistro();
           
            
            
            try
            {
                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxPass.Text))
                {
                    Session.Add("Error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                    return;

                }


                objUsuario.Email = TextBoxEmail.Text;
                objUsuario.Pass = TextBoxPass.Text;


                if (objUsuarioRegistro.Login(objUsuario) == true)
                {
                    Session.Add("Usuario", objUsuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Email o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}