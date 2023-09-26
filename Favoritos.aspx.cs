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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloRegistro articuloRegistro = new ArticuloRegistro();


            try
            {

                if (!IsPostBack)
                {


                    Usuario usuario = (Usuario)Session["Usuario"];
                    if (usuario != null)
                    {
                        RepeaterArticulos.DataSource = articuloRegistro.listarFavoritos(usuario.Id.ToString());
                        RepeaterArticulos.DataBind();
                    }
                }
            }

            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void CheckBoxFavoritos_CheckedChanged(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Articulo articulo = new Articulo();
            FavoritoRegistro favoritoRegistro = new FavoritoRegistro();

            try
            {

                usuario = (Usuario)Session["Usuario"];
                CheckBox checkBox = (CheckBox)sender;
                articulo.Id = int.Parse(checkBox.Attributes["idArticulo"]);

                favoritoRegistro.eliminarFavorito(articulo, usuario);


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ButtonEjemplo_Click(object sender, EventArgs e)
        {

        }
    }
}