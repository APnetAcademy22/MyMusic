using MyMusic.Models;
using System.Data.SqlClient;
namespace MyMusic.DbHelper
{
    public class BranoRetriever
    {
        public List<BranoViewModel> GetAllBrani()
        {
            List<BranoViewModel> list = new List<BranoViewModel>();
            var query = @"SELECT IdBrano, Brano.Titolo, Brano.IdBand, brano.IdAlbum, Brano.Anno, brano.Durata, brano.Genere, band.Nome as NomeBand, album.Nome as NomeAlbum FROM brano 
                            left join Band on brano.idband = band.idband
                            left join Album on brano.idAlbum = album.idalbum; ";
            using var connection = new SqlConnection("data source=ACADEMYNETPD07\\SQLEXPRESS;" +
                            "database = MyMusic;" +
                            "Integrated Security = true;" +
                            "Connection timeout = 3600;");
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
    }
}
