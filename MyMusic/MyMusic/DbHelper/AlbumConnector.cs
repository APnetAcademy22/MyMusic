using MyMusic.Models;
using System.Data.SqlClient;

namespace MyMusic.DbHelper
{
    public class AlbumConnector
    {
        public List<AlbumViewModel> GetAllAlbums()
        {
            List<AlbumViewModel> list = new List<AlbumViewModel>();
            var query = @"select IdAlbum, Idband, Nome, Anno FROM album";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AlbumViewModel()
                {
                    IdAlbum = int.Parse(reader["IdAlbum"].ToString()),
                    IdBand = int.Parse(reader["IdBand"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Anno = int.Parse(reader["Anno"].ToString())
                });
            }
            return list;
        }


        public int AddAlbum(AlbumViewModel album)
        {
            string sql = @"insert into Album (Idband, Nome, Anno)
                            values(@Idband, @Nome, @Anno) ;";
            using var connection = new SqlConnection(Constants.ConnectionString);
                connection.Open();
            using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@IdBand", album.IdBand);
                command.Parameters.AddWithValue("@Nome", album.Nome);
                command.Parameters.AddWithValue("@Anno", album.Anno);

            return command.ExecuteNonQuery();
        }
    }
}
