using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.DataAccess
{
    public class ArtistDA : BaseDA
    {
        //Al usar /// automaticamente se replica
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;
            try
            {
                //1er paso:Consulta SQL
                var sql = "select count(ArtistId) from Artist";


                //2o paso: crear instancia de sqlconnection
                //Internamente se abre una conexion a la bd
                //using(crea instanca de objeto)
                //Idbconection
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la base de datos
                    cnx.Open();
                    //3,. Creando un objeto command
                    var cmd = cnx.CreateCommand();
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

        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "SELECT * FROM ARTIST";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                //var indice = 0;
                // cmd.CommandType Por defecto es select.
                var reader = cmd.ExecuteReader();//Devuelve un conjunto de filas y columnas(o sea 1 tabla)
                while (reader.Read())//Read lee regstro x registro hasta fin de archivo.
                {
                    var artist = new Artist();//artist con minuscula es variable y Artist es un objeto
                    //artist.ArtistId = reader.GetInt32(0);//metodo mas optimo//0:columna 1, xq 32, si el resultado es int(artistid), es int Campo del objeto artist o atabla artist, entonces debe ser getint32.
                    //indice=reader.GetOrdinal("ArtistId");
                    //artist.ArtistId = reader.GetInt32(indice);//Consume mas recursos del procesador
                    artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);//Consume + mas recursos del procesador No recomendable
                                                                          //artist.Name = reader.GetString(1);//Cde
                                                                          // indice=reader.GetOrdinal("Name");
                                                                          // artist.Name = reader.GetString(indice);//Consume mas recursos del procesador
                    artist.Name = Convert.ToString(reader["Name"]);//Consume + mas recursos del procesador No recomendable 
                    result.Add(artist);
                }
            }
            return result;
        }

        public List<Artist> GetArtists(String filtroPorNombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                //Configurando los parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre)
                );
                var indice = 0;
                // cmd.CommandType Por defecto es select.
                var reader = cmd.ExecuteReader();//Devuelve un conjunto de filas y columnas(o sea 1 tabla)
                while (reader.Read())//Read lee regstro x registro hasta fin de archivo.
                {
                    var artist = new Artist();//artist con minuscula es variable y Artist es un objeto
                    //artist.ArtistId = reader.GetInt32(0);//metodo mas optimo//0:columna 1, xq 32, si el resultado es int(artistid), es int Campo del objeto artist o atabla artist, entonces debe ser getint32.
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);//Consume mas recursos del procesador
                                                              //artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);//Consume + mas recursos del procesador No recomendable
                                                              //artist.Name = reader.GetString(1);//Cde
                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);//Consume mas recursos del procesador
                    //artist.Name = Convert.ToString(reader["Name"]);//Consume + mas recursos del procesador No recomendable 
                    result.Add(artist);
                }
            }
            return result;
        }

    }
}
