using Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.ComponentModel;

namespace WebFinal
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //confirguracion inicial de la pantalla(Formulario)

                if (IsPostBack == false)
                {
                    MarcaRegistro objMR = new MarcaRegistro();
                    List<Marca> listaMarca = objMR.listarConSP();

                    DropDownListMarca.DataSource = listaMarca;
                    DropDownListMarca.DataValueField = "Id";
                    DropDownListMarca.DataTextField = "Descripcion";
                    DropDownListMarca.DataBind();

                    CategoriaRegistro objCR = new CategoriaRegistro();
                    List<Categoria> listaCategoria = objCR.listarConSP();

                    DropDownListCategoria.DataSource = listaCategoria;
                    DropDownListCategoria.DataValueField = "Id";
                    DropDownListCategoria.DataTextField = "Descripcion";
                    DropDownListCategoria.DataBind();
                }

                //Configuracion si estamos modificando
                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    string id = Request.QueryString["id"].ToString();
                    ArticuloRegistro objAR = new ArticuloRegistro();
                    List<Articulo> lista = objAR.listar(id);

                    //la lista es como un vector y guardo el primer y unico elemento [0]  
                    Articulo objArticuloSeleccionado = lista[0];

                    //Guardo obj articulo en session
                    Session.Add("ariculoSeleccionado", objArticuloSeleccionado);

                    TextBoxId.Text = id;
                    TextBoxCodigo.Text = objArticuloSeleccionado.Codigo;
                    TextBoxNombre.Text = objArticuloSeleccionado.Nombre;
                    TextBoxPrecio.Text = objArticuloSeleccionado.Precio.ToString("N2");
                    TextBoxUrlImagen.Text = objArticuloSeleccionado.ImagenUrl;
                    TextBoxDescripcion.Text = objArticuloSeleccionado.Descripcion;

                    DropDownListMarca.SelectedValue = objArticuloSeleccionado.Marca.Id.ToString();
                    DropDownListCategoria.SelectedValue = objArticuloSeleccionado.Categoria.Id.ToString();

                    if (!string.IsNullOrEmpty(objArticuloSeleccionado.ImagenUrl))
                    {
                        ImageArticulo.ImageUrl = TextBoxUrlImagen.Text;
                    }

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);


            }
        }
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Articulo objArticulo = new Articulo();
                ArticuloRegistro objAR = new ArticuloRegistro();

                objArticulo.Codigo = TextBoxCodigo.Text;
                objArticulo.Nombre = TextBoxNombre.Text;
                objArticulo.Precio = decimal.Parse(TextBoxPrecio.Text);
                objArticulo.Descripcion = TextBoxDescripcion.Text;
                objArticulo.ImagenUrl = TextBoxUrlImagen.Text;

                objArticulo.Marca = new Marca();
                objArticulo.Marca.Id = int.Parse(DropDownListMarca.SelectedValue);

                objArticulo.Categoria = new Categoria();
                objArticulo.Categoria.Id = int.Parse(DropDownListCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    objArticulo.Id = int.Parse(TextBoxId.Text);
                    objAR.modificar(objArticulo);
                }
                else
                {
                    objAR.agregar(objArticulo);

                }

                Response.Redirect("Lista.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void TextBoxUrlImagen_TextChanged(object sender, EventArgs e)
        {
            ImageArticulo.ImageUrl = TextBoxUrlImagen.Text;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void ButtonConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckBoxEliminar.Checked == true)
                {
                    ArticuloRegistro objAR = new ArticuloRegistro();


                    objAR.eliminar(int.Parse(TextBoxId.Text));
                    Response.Redirect("Lista.aspx", false);

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
      
    }
}