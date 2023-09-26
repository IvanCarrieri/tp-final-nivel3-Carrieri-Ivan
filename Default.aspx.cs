
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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public bool validarPrecio { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloRegistro ObjRegistro = new ArticuloRegistro();
            Seguridad seguridad = new Seguridad();

            listaArticulos = ObjRegistro.listar();


            try
            {
                if (IsPostBack == false)
                {

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

                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["Usuario"];




                    RepeaterArticulos.DataSource = listaArticulos;
                    RepeaterArticulos.DataBind();


                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void ButtonEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }


        protected void CheckBoxFavoritos_CheckedChanged1(object sender, EventArgs e)
        {

            Seguridad seguridad = new Seguridad();
            Usuario usuario = new Usuario();
            Articulo articulo = new Articulo();
            Favorito favorito = new Favorito();
            FavoritoRegistro favoritoRegistro = new FavoritoRegistro();


            try
            {

                if (seguridad.sesionActiva(Session["Usuario"]))
                {

                    //capturo el id del checkbox:

                    CheckBox checkBox = (CheckBox)sender;
                    int idArticulo = int.Parse(checkBox.Attributes["idArticulo"]);

                    usuario = (Usuario)Session["Usuario"];

                    favorito.IdUser = usuario.Id;
                    favorito.IdArticulo = idArticulo;


                    favoritoRegistro.agregarFavorito(favorito);

                }
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }


        }


        protected void ButtonBuscarFiltroAvanzado_Click(object sender, EventArgs e)

        {
            ArticuloRegistro articuloRegistro = new ArticuloRegistro();

            try


            {

                if (DropDownListPrecio.SelectedItem.ToString() == "Todos")
                {
                    validarPrecio = false;

                }
                else
                {
                    validarPrecio = true;
                    Page.Validate();
                    if (!Page.IsValid) { return; }

                }

                string c = DropDownListCategoria.SelectedItem.ToString();
                string m = DropDownListMarca.SelectedItem.ToString();
                string p = DropDownListPrecio.SelectedItem.ToString();
                string n = TextBoxPrecio.Text;




                listaArticulos = articuloRegistro.filtrar(c, m, p, n);
                RepeaterArticulos.DataSource = listaArticulos;
                RepeaterArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }


    }

}

