using log4net;
using Microsoft.Data.Sqlite;
using mpp_project.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.repository
{
    public class AeroportRepository : IRepository<long, Aeroport>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AeroportRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Save(Aeroport aeroport)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO aeroporturi (nume) VALUES (@nume)";
                    command.Parameters.AddWithValue("@nume", aeroport.GetNume());
                    command.ExecuteNonQuery();
                }

                logger.Info(String.Format("Saved aeroport {0}", aeroport.GetNume()));
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM aeroporturi WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                logger.Info(String.Format("Deleted aeroport with id {0}", id));
            }
        }

        public void Update(Aeroport aeroport)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE aeroporturi SET nume = @nume WHERE id = @id";
                    command.Parameters.AddWithValue("@nume", aeroport.GetNume());
                    command.Parameters.AddWithValue("@id", aeroport.GetId());
                    command.ExecuteNonQuery();
                }

                logger.Info(String.Format("Updated aeroport with id {0}", aeroport.GetId()));
            }
        }

        public Aeroport FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, nume FROM aeroporturi WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Aeroport aeroport = new Aeroport(reader.GetString(1));
                            aeroport.SetId(reader.GetInt64(0));

                            logger.Info(String.Format("Found aeroport {0}", aeroport.GetNume()));
                            return aeroport;
                        }
                        logger.Info(String.Format("Aeroport with id {0} not found", id));
                        return null;
                    }
                }
            }
        }


        public IEnumerable<Aeroport> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, nume FROM aeroporturi";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Aeroport> aeroportList = new List<Aeroport>();
                        while (reader.Read())
                        {
                            Aeroport aeroport = new Aeroport(reader.GetString(1));
                            aeroport.SetId(reader.GetInt64(0));
                            aeroportList.Add(aeroport);
                        }

                        logger.Info("Found all aeroports");
                        return aeroportList;
                    }
                }
            }
        }
    }
}
