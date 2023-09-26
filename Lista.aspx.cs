using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Registro;
using Dominio;
using System.Text.RegularExpressions;


namespace WebFinal
{
    public partial class Lista : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Seguridad objSeguridad = new Seguridad();

            try
            {


                if (IsPostBack == false)
                {



                    ArticuloRegistro articuloRegistro = new ArticuloRegistro();
                    GridViewArticulos.DataSource = articuloRegistro.listar();
                    GridViewArticulos.DataBind();
                    Session.Add("listaArticulos", articuloRegistro.listar());


                    CategoriaRegistro categoriaRegistro = new CategoriaRegistro();
                    DropDownListCategoria.DataSource = categoriaRegistro.listarConSP();
                    DropDownListCategoria.DataTextField = "Descripcion";
                    DropDownListCategoria.DataValueField = "Descripcion";
                    DropDownListCategoria.DataBind();
                    DropDownListCategoria.Items.Insert(0, "Todos");


                    MarcaRegistro marcaRegistro = new MarcaRegistro();
                    DropDownListMarca.DataSource = marcaRegistro.listarConSP();
                    DropDownListMarca.DataTextField = "Descripcion";
                    DropDownListMarca.DataValueField = "Descripcion";
                    DropDownListMarca.DataBind();
                    DropDownListMarca.Items.Insert(0, "Todos");

                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

            if (objSeguridad.esAdmin(Session["Usuario"]) == false)
            {
                Session.Add("Error", "Se requieren permisos de Admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void GridViewArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridViewArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void GridViewArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewArticulos.PageIndex = e.NewPageIndex;
            GridViewArticulos.DataBind();

        }

        /* protected void DropDownListCategoria_SelectedIndexChanged(object sender, EventArgs e)
         {


             // int id = int.Parse(DropDownListCategoria.SelectedItem.Value);
             string d = DropDownListCategoria.SelectedItem.Value;

            ArticuloRegistro articuloRegistro = new ArticuloRegistro();


             DropDownListMarca.DataSource = articuloRegistro.ListarConSP().FindAll(x => x.Categoria.Descripcion == d);
             DropDownListMarca.DataTextField = "Marca";
             DropDownListMarca.DataBind();


         }*/

        protected void TextBoxBuscarPorNombre_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> objArticulosLista = (List<Articulo>)Session["listaArticulos"];

            List<Articulo> objArticulosListaFiltrada = objArticulosLista.FindAll(x => x.Nombre.ToUpper().Contains(TextBoxBuscarPorNombre.Text.ToUpper()));

            GridViewArticulos.DataSource = objArticulosListaFiltrada;
            GridViewArticulos.DataBind();

        }

        protected void CheckBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {



            TextBoxBuscarPorNombre.Enabled = !CheckBoxFiltroAvanzado.Checked; // recordar si quiero igualare al contrario del bool va !

        }

        protected void ButtonBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloRegistro ObjAR = new ArticuloRegistro();
                string cat = DropDownListCategoria.SelectedItem.ToString();
                string mar = DropDownListMarca.SelectedItem.ToString();
                string pre = DropDownListPrecio.SelectedItem.ToString();
                string num = TextBoxPrecio.Text;
                string est = DropDownListEstado.SelectedItem.ToString();

                GridViewArticulos.DataSource = ObjAR.filtrar(cat, mar, pre, num);
                GridViewArticulos.DataBind();

               

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());

            }
        }


    }
}