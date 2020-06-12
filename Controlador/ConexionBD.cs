using System.Data;
using Npgsql;

namespace Preparcial.Controlador
{
    public static class ConexionBD
    
    //Commit 1 - RobertoHer
    
    {
        private static string cadenaC = "Server=127.0.0.1;" +
                                        "Port=5432;" +
                                        "User Id=postgres;" +
                                        "Password=uca;" +
                                        "Database=preparcial;";

        public static DataTable EjecutarConsulta(string consulta)
        {
            var conn = new NpgsqlConnection(cadenaC);
            var ds = new DataSet();

            conn.Open();
            var da = new NpgsqlDataAdapter(consulta, conn);
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }

        public static void EjecutarComando(string comando)
        {
            var conn = new NpgsqlConnection(cadenaC);

            conn.Open();
            var comm = new NpgsqlCommand(comando, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}