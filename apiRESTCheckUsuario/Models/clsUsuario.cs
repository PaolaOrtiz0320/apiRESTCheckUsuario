using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace apiRESTCheckUsuario.Models
{
    public class clsUsuario
    {

        // Definición de atributos
        public string cve { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string ruta { get; set; }
        public string tipo { get; set; }
        // Metodos y atributos de funcionalidad y seguridad
        string cadConn = ConfigurationManager.ConnectionStrings["Control_Acceso"].ConnectionString;
        //Constructores
  
        public clsUsuario(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contrasena = contraseña;
        }
        public clsUsuario(string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string contraseña, string ruta, string tipo)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.usuario = usuario;
            this.contrasena = contraseña;
            this.ruta = ruta;
            this.tipo = tipo;
        }

        public clsUsuario()
        {
        }

        //metodo para la ejecucion spinsusuario
        public DataSet spInUsuario()
        {
            string cadSq = "CALL spInsUsuario('" + this.nombre + "', '" + this.apellidoPaterno +
                "', '" + this.apellidoMaterno + "', '" + this.usuario +
                "', '" + this.contrasena + "', '" + this.ruta +
                "', " + this.tipo + ")";
            // Coniguracion de los objetos
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSq, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spInUsuario");
            //retorna  los datos recibidos
            return ds;

        }
        // Proceso de validación de usuarios (spValidarAcceso)
        public DataSet spValidarAcceso()
        {
            // Crear el comando SQL
            string cadSQL = "";
            cadSQL = "call spValidarAcceso('" + this.usuario + "','"
                                              + this.contrasena + "');";
            // Configuración de objetos de conexión
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            // Ejecución y salida
            da.Fill(ds, "spValidarAcceso");
            return ds;
        }
        public DataSet vwRptUsuario(string filtro)
        {
            // Crear el comando SQL
            string cadSQL = "";
            cadSQL = "SELECT * FROM vwRptUsuario WHERE Usuario LIKE '%" + filtro + "%'";
            // Configuración de objetos de conexión
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            // Ejecución y salida
            da.Fill(ds, "vwRptUsuario");
            return ds;
        }
        //----------------------------------------------------------------------------------------------------------------------
        public DataSet vwTipoUsuario()
        {
            // Crear el comando SQL
            string cadSQL = "";
            cadSQL = "SELECT * FROM vwTipoUsuario";
            // Configuración de objetos de conexión
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            // Ejecución y salida
            da.Fill(ds, "vwRpTipoUsuario");
            return ds;
        }
        //-----------------------------------------------------------------------------------------------------------------
 
    }
}