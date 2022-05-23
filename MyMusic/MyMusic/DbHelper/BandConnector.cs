using MyMusic.Models;
using System.Data.SqlClient;

namespace MyMusic.DbHelper
{
    public class BandConnector
    {
        public List<BandViewModel> GetAllBands()
        {
            List<BandViewModel> list = new List<BandViewModel>();
            var query = @"select Idband, Nome, Immagine FROM band";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new BandViewModel()
                {
                    IdBand = int.Parse(reader["IdBand"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Immagine = reader["Immagine"].ToString()
                }) ;
            }
            return list;
        }


        public int AddBand(BandViewModel band)
        {
            string sql = @"insert into Band (Nome, Immagine)
                            values(@Nome, @Immagine) ;";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nome", band.Nome);
                command.Parameters.AddWithValue("@Immagine", band.Immagine);

            return command.ExecuteNonQuery();
        }

    }
}
