using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    public class FavoritoRegistro
    {
        public void agregarFavorito(Favorito obj)
        {
            AccesoSQLRegistro accesoSQLRegistro = new AccesoSQLRegistro();

            try
            {
                accesoSQLRegistro.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArticulo)");

                
                accesoSQLRegistro.setearParametros("@IdUser", obj.IdUser);
                accesoSQLRegistro.setearParametros("@IdArticulo", obj.IdArticulo);

                accesoSQLRegistro.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoSQLRegistro.cerrarConexion();
            }
        }

        public List<Favorito> listarFavoritos()
        {
            AccesoSQLRegistro accesoSQLRegistro = new AccesoSQLRegistro();
            List<Favorito> listFavoritos = new List<Favorito>();

            try
            {
                accesoSQLRegistro.setearConsulta("select * from FAVORITOS");
                accesoSQLRegistro.ejecutarLectura();


                while (accesoSQLRegistro.lector.Read())
                {
                    Favorito objFavorito = new Favorito();

                    objFavorito.Id = (int)accesoSQLRegistro.lector["Id"];
                    objFavorito.IdUser = (int)accesoSQLRegistro.lector["IdUser"];
                    objFavorito.IdArticulo = (int)accesoSQLRegistro.lector["IdArticulo"];

                    listFavoritos.Add(objFavorito);
                }   

                return listFavoritos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoSQLRegistro.cerrarConexion();
            }



        }

        public void eliminarFavorito(Articulo art, Usuario user)
        {

            AccesoSQLRegistro accesoSQLRegistro = new AccesoSQLRegistro();

            try
            {

                accesoSQLRegistro.setearConsulta("delete from FAVORITOS where IdArticulo=@IdArticulo and IdUser=@IdUser");
                accesoSQLRegistro.setearParametros("@IdArticulo", art.Id);
                accesoSQLRegistro.setearParametros("@IdUser", user.Id);
                accesoSQLRegistro.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoSQLRegistro.cerrarConexion();
            }

        }


    }
}
