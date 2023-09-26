using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Registro
{
    public class CategoriaRegistro
    {
        public List<Categoria> listarConSP()
        {
            List<Categoria> objCategorias = new List<Categoria>();
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();

            try
            {
                objAcceso.setearConsulta("Select Id, Descripcion from CATEGORIAS");
                objAcceso.ejecutarLectura();

                while (objAcceso.lector.Read())
                {
                    Categoria objCategoria = new Categoria();

                    objCategoria.Id = (int)objAcceso.lector["Id"];
                    objCategoria.Descripcion = (string)objAcceso.lector["Descripcion"];

                    objCategorias.Add(objCategoria);
                }

                return objCategorias;
            }
            catch (Exception)
            {

                throw ;
            }
            finally
            {
                objAcceso.cerrarConexion();
            }
        }
    }
}

