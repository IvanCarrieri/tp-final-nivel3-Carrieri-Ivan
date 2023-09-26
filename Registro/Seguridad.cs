using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;


namespace Registro
{
    public class Seguridad
    {
        public bool sesionActiva(object usuario)
        {
            Usuario objUsuario = new Usuario();

            if (usuario != null)
            {
                objUsuario = (Usuario)usuario;

            }
            else
            {
                objUsuario = null;
            }
           
            
            if (objUsuario != null)

            {
                return true;
            }
            return false;
        }

        public bool esAdmin(object usuario)
        {
            Usuario objUsuario = new Usuario();

            if (usuario != null)
            {
                objUsuario = (Usuario)usuario;
                return objUsuario.Admin;

            }
            else
            {
                return false;
                
            }

         
        }

    }
 }
