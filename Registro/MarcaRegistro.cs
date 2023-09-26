using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Registro
{
    public class MarcaRegistro
    {
        public List<Marca> listarConSP()
        {
            List<Marca> objMarcas = new List<Marca>();
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();

            try
            {
                objAcceso.setearConsulta("select Id, Descripcion from MARCAS");
                objAcceso.ejecutarLectura();

                while (objAcceso.lector.Read())
                {
                    Marca objMarca = new Marca();

                    objMarca.Id = (int)objAcceso.lector["Id"];
                    objMarca.Descripcion = (string)objAcceso.lector["Descripcion"];

                    objMarcas.Add(objMarca);
                }

                return objMarcas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objAcceso.cerrarConexion();
            }
        }

        
    }
}


