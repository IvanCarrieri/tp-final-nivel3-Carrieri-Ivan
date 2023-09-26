using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Configuration;
using System.Net.Sockets;

namespace Registro
{
    public class AccesoSQLRegistro
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        public SqlDataReader lector { set; get; }

        


        public AccesoSQLRegistro()
        {
           // conexion = new SqlConnection("server=.\\SQLEXPRESS; database=BD_Catalogo; integrated security=true");
            conexion = new SqlConnection("workstation id = BD_Catalogo.mssql.somee.com; packet size = 4096; user id = navimax_SQLLogin_3; pwd = w4fgddgo5e; data source = BD_Catalogo.mssql.somee.com; persist security info = False; initial catalog = BD_Catalogo");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        public void ejecutarLectura()
        {
            
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarAccion()
        {
            
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ejecutarAccionScalar()
        {

            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }

            conexion.Close();
        }

    }
}
