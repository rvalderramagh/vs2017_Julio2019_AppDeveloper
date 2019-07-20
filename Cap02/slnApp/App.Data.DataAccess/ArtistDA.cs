using App.Entities_Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    //Hereda lo de BaseDA
    public class ArtistDA : BaseDA
    {
        /// <summary>
        /// Obtiene la cantidad de registros
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;

            //para fines didacticos puso try pero sugiere ponerlo en otros niveles
            try
            {
                //1.- Consulta SQL
                var sql = "SELECT COUNT(ArtistId) FROM Artist";

                //Se reemplaza por la nueva clase creada
                //var cnxString = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";

                // 2.- Crear el objeto connection
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la base de datos
                    cnx.Open();

                    //3.- Creando un objeto command
                    var cmd = cnx.CreateCommand();

                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    result = (int)cmd.ExecuteScalar();
                }
            }

            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }

        //<>guardo el tipo de dato
        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "select * from artist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                var indice = 0;

                var reader = cmd.ExecuteReader(); //trae un conjunto de filas

                while (reader.Read())
                {
                    var artist = new Artist();

                    //direcciona por la posicion del campo
                    artist.ArtistId = reader.GetInt32(0); //recupera el campo int y la funcion GetInt32 lo convierte directamente
                    artist.Name = reader.GetString(1);

                    //para obtener el indice y colocar los campos por su nombre
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);


                    result.Add(artist);
                }

            }

            return result;
        }

        //concepto sobre carga hay otro que se llama igual
        public List<Artist> GetArtists(string filtroPorNombre)
        {
            var result = new List<Artist>();

            var sql = "usp_GetArtist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                //configurando los parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre)
                    );


                var indice = 0;

                var reader = cmd.ExecuteReader(); //trae un conjunto de filas

                while (reader.Read())
                {
                    var artist = new Artist();

                    //direcciona por la posicion del campo
                    artist.ArtistId = reader.GetInt32(0); //recupera el campo int y la funcion GetInt32 lo convierte directamente
                    artist.Name = reader.GetString(1);

                    //para obtener el indice y colocar los campos por su nombre
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);


                    result.Add(artist);
                }
                return result;
            }
        }
    }
}
