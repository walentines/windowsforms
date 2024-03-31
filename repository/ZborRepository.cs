using log4net;
using Microsoft.Data.Sqlite;
using mpp_project.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace mpp_project.repository
{
    public class ZborRepository : IRepository<long, Zbor>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AeroportRepository aeroportRepository;

        public ZborRepository(string connectionString, AeroportRepository aeroportRepository)
        {
            this.connectionString = connectionString;
            this.aeroportRepository = aeroportRepository;
        }

        public void Save(Zbor zbor)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO zboruri (destinatie, data, idAeroport, locuriDisponibile) VALUES (@Destinatie, @Data, @IdAeroport, @NrLocuri)";
                    command.Parameters.AddWithValue("@Destinatie", zbor.GetDestinatie());
                    command.Parameters.AddWithValue("@Data", zbor.GetData());
                    command.Parameters.AddWithValue("@IdAeroport", zbor.getAeroport().GetId());
                    command.Parameters.AddWithValue("@NrLocuri", zbor.GetNrLocuri());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Saved zbor {0}", zbor.GetDestinatie()));
                }
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM zboruri WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Deleted zbor with id {0}", id));
                }
            }
        }

        public void Update(Zbor zbor)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE zboruri SET destinatie = @Destinatie, data = @Data, idAeroport = @IdAeroport, locuriDisponibile = @NrLocuri WHERE id = @id";
                    command.Parameters.AddWithValue("@Destinatie", zbor.GetDestinatie());
                    command.Parameters.AddWithValue("@Data", zbor.GetData());
                    command.Parameters.AddWithValue("@IdAeroport", zbor.getAeroport().GetId());
                    command.Parameters.AddWithValue("@NrLocuri", zbor.GetNrLocuri());
                    command.Parameters.AddWithValue("@id", zbor.GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Updated zbor with id {0}", zbor.GetId()));
                }
            }
        }

        public Zbor FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, destinatie, data, idAeroport, locuriDisponibile FROM zboruri WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Zbor zbor = new Zbor(reader.GetString(1), reader.GetDateTime(2), aeroportRepository.FindOne(reader.GetInt64(3)), reader.GetInt16(4));
                            zbor.SetId(reader.GetInt64(0));
                            logger.Info(String.Format("Found zbor {0}", zbor.GetDestinatie()));
                            return zbor;
                        }
                        logger.Info(String.Format("No zbor found with id {0}", id));
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Zbor> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, destinatie, data, idAeroport, locuriDisponibile FROM zboruri";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Zbor> zborList = new List<Zbor>();
                        while (reader.Read())
                        {
                            Zbor zbor = new Zbor(reader.GetString(1), reader.GetDateTime(2), aeroportRepository.FindOne(reader.GetInt64(3)), reader.GetInt16(4));
                            zbor.SetId(reader.GetInt64(0));
                            zborList.Add(zbor);
                        }
                        logger.Info(String.Format("Found all zboruri"));
                        return zborList;
                    }
                }
            }
        }

        public IEnumerable<Zbor> FindZboruriByDestinatieAndData(string destinatie, DateTime data)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, destinatie, data, idAeroport, locuriDisponibile FROM zboruri WHERE destinatie = @destinatie AND data >= @data1 AND data <= @data2";
                    command.Parameters.AddWithValue("@destinatie", destinatie);
                    command.Parameters.AddWithValue("@data1", data);
                    command.Parameters.AddWithValue("@data2", data.AddDays(1));
                    using (var reader = command.ExecuteReader())
                    {
                        List<Zbor> zborList = new List<Zbor>();
                        while (reader.Read())
                        {
                            Zbor zbor = new Zbor(reader.GetString(1), reader.GetDateTime(2), aeroportRepository.FindOne(reader.GetInt64(3)), reader.GetInt16(4));
                            zbor.SetId(reader.GetInt64(0));
                            zborList.Add(zbor);
                        }
                        logger.Info(String.Format("Found zboruri with destinatie {0} and data {1}", destinatie, data));
                        return zborList;
                    }
                }
            }
        }

        public void cumparaBilete(Zbor zbor, int nrLocuri)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE zboruri set locuriDisponibile=locuriDisponibile-@nrLocuri WHERE id=@id";
                    command.Parameters.AddWithValue("@nrLocuri", nrLocuri);
                    command.Parameters.AddWithValue("@id", zbor.GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Cumparare bilete pentru zborul {0}", zbor.GetDestinatie()));
                }
            }
        }
    }
}
