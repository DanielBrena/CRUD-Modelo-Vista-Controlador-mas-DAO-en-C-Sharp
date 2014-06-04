using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO_ORDINARIO
{
    public class DataSource
    {
        private string cadenaConexion;
        private MySqlConnection conexion;

        /**
         * |Constructor del Data Source|
         * Se inicializa la conexion al servidor y a la base de datos.
         * 
         * */
        public DataSource()
        {
            this.cadenaConexion = "Server=127.0.0.1; Database=ordinario; Uid=root; Pwd=danielbrena2";
            this.conexion = new MySqlConnection(this.cadenaConexion);
            this.conexion.ConnectionString = this.cadenaConexion;
            this.conexion.Open();
        }

        /**
         *|Ejecuta las consultas DDL|
         *Metodo que ejecutara la consulta  para regresar una tabla con todos lo registros.
         *@param sql Consulta a ejecutar.
         */
        public DataTable ejecutarConsulta(string sql)
        {
            MySqlCommand comando = this.conexion.CreateCommand();
            comando.CommandText = sql;
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(lector);
            this.conexion.Close();
            return dt;


        }

        /**
         * |Ejecuta las consultas DML|
         * Metodo que que regresa el numero de filas afectadas.
         * @param sql Consulta  a ejecutar.
         */
        public int ejecutarActualizacion(string sql)
        {
            try
            {
                MySqlCommand comando = this.conexion.CreateCommand();
                comando.CommandText = sql;
                MySqlDataReader lector = comando.ExecuteReader();
                int resultado = lector.RecordsAffected;
                this.conexion.Close();
                return resultado;
            }
            catch (MySqlException e)
            {
                return 0;
            }
        }
    }
}
