using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;
using Registro;


namespace Registro
{
    public class ArticuloRegistro
    {

        public List<Articulo> listarFavoritos(string idUsuario)
        {

            List<Articulo> list = new List<Articulo>();
            AccesoSQLRegistro accesoSQLRegistro = new AccesoSQLRegistro();

            try
            {

                string consulta = "SELECT DISTINCT A.Id, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN FAVORITOS F ON F.IdArticulo = A.Id INNER JOIN USERS U ON U.Id = F.IdUser WHERE F.IdUser = ";

                consulta = consulta + idUsuario;

                accesoSQLRegistro.setearConsulta(consulta);
                accesoSQLRegistro.ejecutarLectura();


                while (accesoSQLRegistro.lector.Read())
                {
                    Articulo objArticulo = new Articulo();

                    objArticulo.Id = (int)accesoSQLRegistro.lector["Id"];
                    objArticulo.Nombre = (string)accesoSQLRegistro.lector["Nombre"];
                    objArticulo.Descripcion = (string)accesoSQLRegistro.lector["Descripcion"];
                    
                    objArticulo.Marca = new Marca();
                    objArticulo.Marca.Descripcion = (string)accesoSQLRegistro.lector["Marca"];

                    objArticulo.Categoria = new Categoria();
                    objArticulo.Categoria.Descripcion = (string)accesoSQLRegistro.lector["Categoria"];

                    if (accesoSQLRegistro.lector["ImagenUrl"] != DBNull.Value)
                    {
                        objArticulo.ImagenUrl = (string)accesoSQLRegistro.lector["ImagenUrl"];
                    }

                    objArticulo.Precio = (decimal)accesoSQLRegistro.lector["Precio"];



                    list.Add(objArticulo);

                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoSQLRegistro.cerrarConexion();
            }


        }


        public List<Articulo> listar()
        {
            List<Articulo> objLista = new List<Articulo>();
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();

            try
            {
                            
                  
                  objAcceso.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                  objAcceso.ejecutarLectura();

                
               

                while (objAcceso.lector.Read())
                {
                    Articulo objArticulo = new Articulo();

                    objArticulo.Id = (int)objAcceso.lector["Id"];
                    objArticulo.Codigo = (string)objAcceso.lector["Codigo"];
                    objArticulo.Nombre = (string)objAcceso.lector["Nombre"];
                    objArticulo.Descripcion = (string)objAcceso.lector["Descripcion"];
                    objArticulo.Marca = new Marca();
                    objArticulo.Marca.Descripcion = (string)objAcceso.lector["Marca"];

                    objArticulo.Categoria = new Categoria();
                    objArticulo.Categoria.Descripcion = (string)objAcceso.lector["Categoria"];

                    if (objAcceso.lector["ImagenUrl"] != DBNull.Value)
                    {
                        objArticulo.ImagenUrl = (string)objAcceso.lector["ImagenUrl"];
                    }

                    objArticulo.Precio = (decimal)objAcceso.lector["Precio"];

                    

                    objLista.Add(objArticulo);

                }
                return objLista;
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

        public List<Articulo> listar(String id = "")
        {
            List<Articulo> objLista = new List<Articulo>();
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();

            try
            {

                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria ";
                if (id != "")
                {
                    consulta = consulta + " and A.Id = " + id;
                }
                objAcceso.setearConsulta(consulta);
                objAcceso.ejecutarLectura();

                while (objAcceso.lector.Read())
                {
                    Articulo objArticulo = new Articulo();

                    objArticulo.Id = (int)objAcceso.lector["Id"];
                    objArticulo.Codigo = (string)objAcceso.lector["Codigo"];
                    objArticulo.Nombre = (string)objAcceso.lector["Nombre"];
                    objArticulo.Descripcion = (string)objAcceso.lector["Descripcion"];
                    

                    objArticulo.Marca = new Marca();
                    objArticulo.Marca.Descripcion = (string)objAcceso.lector["Marca"];

                    objArticulo.Categoria = new Categoria();
                    objArticulo.Categoria.Descripcion = (string)objAcceso.lector["Categoria"];

                    if (objAcceso.lector["ImagenUrl"] != DBNull.Value)
                    {
                        objArticulo.ImagenUrl = (string)objAcceso.lector["ImagenUrl"];
                    }

                    objArticulo.Precio = (decimal)objAcceso.lector["Precio"];

                    objLista.Add(objArticulo);

                }

                return objLista;

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

        public List<Articulo> filtrar(string cat, string mar, string pre, string num)

        {
            List<Articulo> objListaFiltrada = new List<Articulo>();
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();
            string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria ";
            string consultaC = "and A.IdCategoria = ";
            string consultaM = "and A.IdMarca = ";
            string precio = "and A.Precio";
            

            try
            {
                switch (cat)
                {
                    case "Celulares":
                        consultaC += "1";
                        break;
                    case "Televisores":
                        consultaC += "2";
                        break;
                    case "Media":
                        consultaC += "3";
                        break;
                    case "Audio":
                        consultaC += "4";
                        break;
                    default:
                        consultaC = "";
                        break;
                }

                switch (mar)
                {
                    case "Samsung":
                        consultaM += "1";
                        break;
                    case "Apple":
                        consultaM += "2";
                        break;
                    case "Sony":
                        consultaM += "3";
                        break;
                    case "Huawei":
                        consultaM += "4";
                        break;
                    case "Motorola":
                        consultaM += "5";
                        break;
                    default:
                        consultaM = "";
                        break;
                }

                switch (pre)
                {
                    case "Mayor a":
                        precio += " > " + num;
                        break;
                    case "Menor a":
                        precio += " < " + num;
                        break;
                    default:
                        precio = "";
                        break;
                }

              




                objAcceso.setearConsulta(consulta += consultaC + consultaM + precio);
                objAcceso.ejecutarLectura();

                while (objAcceso.lector.Read())
                {
                    Articulo objArticulo = new Articulo();

                    objArticulo.Id = (int)objAcceso.lector["Id"];
                    objArticulo.Codigo = (string)objAcceso.lector["Codigo"];
                    objArticulo.Nombre = (string)objAcceso.lector["Nombre"];
                    objArticulo.Descripcion = (string)objAcceso.lector["Descripcion"];

                    objArticulo.Marca = new Marca();
                    objArticulo.Marca.Descripcion = (string)objAcceso.lector["Marca"];

                    objArticulo.Categoria = new Categoria();
                    objArticulo.Categoria.Descripcion = (string)objAcceso.lector["Categoria"];

                    if (objAcceso.lector["ImagenUrl"] != DBNull.Value)
                    {
                        objArticulo.ImagenUrl = (string)objAcceso.lector["ImagenUrl"];
                    }

                    objArticulo.Precio = (decimal)objAcceso.lector["Precio"];
                    


                    objListaFiltrada.Add(objArticulo);
                }

                return objListaFiltrada;
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

        public void agregar(Articulo obj)
        {

            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();
            try
            {
                objAcceso.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdCategoria, @IdMarca, @ImagenUrl, @Precio)");
                objAcceso.setearParametros("@Codigo", obj.Codigo);
                objAcceso.setearParametros("@Nombre", obj.Nombre);
                objAcceso.setearParametros("@Descripcion", obj.Descripcion);
                objAcceso.setearParametros("@IdCategoria", obj.Categoria.Id);
                objAcceso.setearParametros("@IdMarca", obj.Marca.Id);
                objAcceso.setearParametros("@ImagenUrl", obj.ImagenUrl);
                objAcceso.setearParametros("@Precio", obj.Precio);
                

                objAcceso.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objAcceso.cerrarConexion();
            }
        }

        public void modificar(Articulo obj)
        {
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();
            try
            {
                objAcceso.setearConsulta("update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdCategoria=@IdCategoria, IdMarca=@IdMarca, ImagenUrl=@ImagenUrl, Precio=@Precio where Id=@Id");
                objAcceso.setearParametros("@Codigo", obj.Codigo);
                objAcceso.setearParametros("@Nombre", obj.Nombre);
                objAcceso.setearParametros("@Descripcion", obj.Descripcion);
                objAcceso.setearParametros("@IdCategoria", obj.Categoria.Id);
                objAcceso.setearParametros("@IdMarca", obj.Marca.Id);
                objAcceso.setearParametros("@ImagenUrl", obj.ImagenUrl);
                objAcceso.setearParametros("@Precio", obj.Precio);
                objAcceso.setearParametros("@Id", obj.Id);
                

                objAcceso.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objAcceso.cerrarConexion();
            }
        }

       


        public void eliminar(int Id)
        {
            AccesoSQLRegistro objAccesoRegistro = new AccesoSQLRegistro();

            try
            {
                objAccesoRegistro.setearConsulta("Delete from ARTICULOS where Id=@Id");
                objAccesoRegistro.setearParametros("@Id", Id);
                objAccesoRegistro.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objAccesoRegistro.cerrarConexion();
            }
        }

        

    }
}





