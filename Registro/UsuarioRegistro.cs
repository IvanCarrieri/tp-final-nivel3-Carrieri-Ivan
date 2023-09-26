using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Registro
{
    public class UsuarioRegistro
    {
        public void Actualizar(Usuario objUsuario)

        { 
            AccesoSQLRegistro objAcceso = new AccesoSQLRegistro();
            try
            {
               
               
                objAcceso.setearConsulta("Update USERS set urlImagenPerfil=@imagen , email=@email, nombre=@nom, apellido=@ap where Id=@id");  
                objAcceso.setearParametros("@imagen", objUsuario.ImagenPerfil != null ? objUsuario.ImagenPerfil : (object)DBNull.Value);
                objAcceso.setearParametros("@nom",objUsuario.Nombre);
                objAcceso.setearParametros("@ap",objUsuario.Apellido);
                objAcceso.setearParametros("@email", objUsuario.Email);
                objAcceso.setearParametros("@id", objUsuario.Id);
                objAcceso.ejecutarAccion();


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

       

        public int insertarNuevo(Usuario nuevo)
        {

            AccesoSQLRegistro objAR = new AccesoSQLRegistro();
            try
            {
                objAR.setearConsulta("insert into USERS (email, pass) values (@email, @pass)");
                objAR.setearParametros("@email", nuevo.Email);
                objAR.setearParametros("@pass", nuevo.Pass);

                return objAR.ejecutarAccionScalar();

                

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objAR.cerrarConexion();
            }
        }

        public bool Login(Usuario usuario)
        {

            AccesoSQLRegistro objAR= new AccesoSQLRegistro();
            try
            {
                objAR.setearConsulta("select Id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
                objAR.setearParametros("@email", usuario.Email);
                objAR.setearParametros("@pass", usuario.Pass);
                
                objAR.ejecutarLectura();

                if(objAR.lector.Read()==true) {

                    usuario.Id = (int)objAR.lector["Id"];
                    usuario.Admin = (bool)objAR.lector["admin"];
                    usuario.Email= (string)objAR.lector["email"];
                    usuario.Pass= (string)objAR.lector["pass"];

                    if(!(objAR.lector["UrlImagenPerfil"] is DBNull))
                    {
                        usuario.ImagenPerfil = (string)objAR.lector["UrlImagenPerfil"];
                    }
                    if (!(objAR.lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)objAR.lector["nombre"];
                    }
                    if (!(objAR.lector["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)objAR.lector["apellido"];
                    }
                   

                    return true;
                
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                objAR.cerrarConexion();
            }
        }
    }
}
