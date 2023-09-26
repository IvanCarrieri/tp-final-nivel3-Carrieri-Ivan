using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id {  get; set; }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if(value != null || value != "")
                {
                   email = value;

                }
                else
                {
                    throw new Exception("Email vacío");
                }
            }
        }


        private string pass;
        public string Pass 
        {
            get
            {
                return pass;
            }
            set
            {
                if(value != null || value != "")
                {
                    pass = value;
                }
                else
                {
                    throw new Exception("Pass vacío");
                }
            }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ImagenPerfil { get; set; }
        public bool Admin { get; set; }
    }
}
