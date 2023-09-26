using Dominio;
using Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Articulo articulo = new Articulo();
            ArticuloRegistro articuloRegistro = new ArticuloRegistro();
            List<Articulo> list = new List<Articulo>();
            
            try
			{
                string id = Request.QueryString["id"].ToString();
                list = articuloRegistro.listar(id);

                articulo = list[0];

                LabelCategoria.Text = articulo.Categoria.Descripcion;
                LabelMarca.Text = articulo.Marca.Descripcion;
                LabelNombre.Text = articulo.Nombre;
                LabelDascripcion.Text = articulo.Descripcion;
                LabelPrecio.Text = articulo.Precio.ToString("N2");

                ImageDetalle.ImageUrl = articulo.ImagenUrl;



			}
			catch (Exception ex)
			{
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}