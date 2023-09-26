using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Registro;


namespace WebFinal
{
    public partial class MiPerfil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (IsPostBack == false)
                {
                    Seguridad seguridad = new Seguridad();

                    if (seguridad.sesionActiva(Session["Usuario"]))
                    {

                        Usuario objUsuario = (Usuario)Session["Usuario"];

                        TextBoxNombre.Text = objUsuario.Nombre;
                        TextBoxApellido.Text = objUsuario.Apellido;
                        TextBoxEmail.Text = objUsuario.Email;
                        TextBoxEmail.ReadOnly = true;


                        if (!string.IsNullOrEmpty(objUsuario.ImagenPerfil))
                        {
                            ImagePerfil.ImageUrl = "~/Imagenes/" + objUsuario.ImagenPerfil;

                        }

                       

                    }


                }
            }
            catch (Exception ex)
            {
                
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {

            try
            {
               Page.Validate();
                 if (!Page.IsValid) 
                {
                    return; 
                }

                Usuario objUsuario = (Usuario)Session["Usuario"];
                UsuarioRegistro objUR = new UsuarioRegistro();
                //escribir imagen

                if (TextBoxImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    TextBoxImagen.PostedFile.SaveAs(ruta + "perfil-" + objUsuario.Id.ToString()  + ".jpg");
                    objUsuario.ImagenPerfil = "perfil-" + objUsuario.Id.ToString() + ".jpg";

                }



                objUsuario.Nombre = TextBoxNombre.Text;
                objUsuario.Apellido = TextBoxApellido.Text;
                objUsuario.Email = TextBoxEmail.Text;
               

                objUR.Actualizar(objUsuario);

                //leer imagen

                Image imagen = (Image)Master.FindControl("ImagenPerfil");
                imagen.ImageUrl = "~/Imagenes/" + objUsuario.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx", false);
            }
            catch (Exception ex)
            {

                
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}