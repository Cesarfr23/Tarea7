using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tarea7
{
    class Conexion
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;

        public Conexion()
        {
            try
            {
                sqlConnection = new SqlConnection("Data Source=DESKTOP-4ECK98H\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
                sqlConnection.Open();
                MessageBox.Show("Conestado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se conecto con la Base de Datos"+ ex.ToString());
            }
        }

        public string insertar(string nombre, string clave)
        {
            string salida = "Si se inserto";

            try
            {
                sqlCommand = new SqlCommand("insert into usuario(nombre, clave) value('"+nombre+"','"+clave+"')",sqlConnection);
                sqlCommand.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                string salida = "No se Conecto" + ex.ToString();
            }
            return salida;
        }

        public string PersonaRegistrada(string nombre)
        {
            int contador = 0;
            try
            {
                sqlCommand = new SqlCommand("Select * from usuario where nombre="+nombre+"",sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while(sqlDataReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                string salida = "No se Conecto" + ex.ToString();
            }
            return salida;
        }
    }
}
