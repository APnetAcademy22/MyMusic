using MyMusic.Models;
using System.Data.SqlClient;

namespace MyMusic.DbHelper
{
    public class BranoConnector
    {
        public List<BranoViewModel> GetAllBrani()
        {
            List<BranoViewModel> list = new List<BranoViewModel>();
            var query = @"SELECT IdBrano, Brano.Titolo, Brano.IdBand, brano.IdAlbum, Brano.Anno, brano.Durata, brano.Genere, band.Nome as NomeBand, album.Nome as NomeAlbum FROM brano 
                            left join Band on brano.idband = band.idband
                            left join Album on brano.idAlbum = album.idalbum; ";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new BranoViewModel()
                {
                    IdBrano = int.Parse(reader["IdBrano"].ToString()),
                    Titolo = reader["Titolo"].ToString(),
                    IdBand = int.Parse(reader["IdBand"].ToString()),
                    IdAlbum = int.Parse(reader["IdAlbum"].ToString()),
                    Anno = int.Parse(reader["Anno"].ToString()),
                    Genere = reader["Genere"].ToString(),
                    Durata = decimal.Parse(reader["Durata"].ToString()),
                    NomeAlbum = reader["NomeAlbum"].ToString(),
                    NomeBand = reader["NomeBand"].ToString()
                }) ;
            }
            return list;
        }


        public int AddBrano(BranoViewModel brano)
        {
            string sql = @"insert into Brano (titolo, IdBand, IdAlbum, Anno, Durata, Genere)
                            values(@titolo , @IdBand ,  @IdAlbum , @Anno , @Durata , @Genere) ;";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Titolo", brano.Titolo);
                command.Parameters.AddWithValue("@IdBand", brano.IdBand);
                command.Parameters.AddWithValue("@IdAlbum", brano.IdAlbum);
                command.Parameters.AddWithValue("@Anno", brano.Anno);
                command.Parameters.AddWithValue("@Durata", brano.Durata);
                command.Parameters.AddWithValue("@Genere", brano.Genere);

            return command.ExecuteNonQuery();
        }

    }
}
