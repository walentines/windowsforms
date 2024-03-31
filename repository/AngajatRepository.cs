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
    public class AngajatRepository : IRepository<long, Angajat>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AngajatRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Save(Angajat angajat)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO angajati (username, password) VALUES (@username, @password)";
                    command.Parameters.AddWithValue("@username", angajat.GetUsername());
                    command.Parameters.AddWithValue("@password", angajat.GetPassword());
                    command.ExecuteNonQuery();
                }
                logger.Info(String.Format("Saved angajat {0}", angajat.GetUsername()));
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM angajati WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                logger.Info(String.Format("Deleted angajat with id {0}", id));
            }
        }

        public void Update(Angajat angajat)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE angajati SET username = @username, password = @password WHERE Id = @id";
                    command.Parameters.AddWithValue("@username", angajat.GetUsername());
                    command.Parameters.AddWithValue("@password", angajat.GetPassword());
                    command.Parameters.AddWithValue("@id", angajat.GetId());
                    command.ExecuteNonQuery();

                    logger.Info(String.Format("Updated angajat {0}", angajat.GetUsername()));
                }
            }
        }

        public Angajat FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, password FROM angajati WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Angajat angajat = new Angajat(reader.GetString(1), reader.GetString(2));
                            angajat.SetId(reader.GetInt64(0));
                            logger.Info("Found angajat with id " + id);
                            return angajat;
                        }
                        logger.Info("No angajat found with id " + id);
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Angajat> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, password FROM angajati";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Angajat> angajati = new List<Angajat>();
                        while (reader.Read())
                        {
                            Angajat angajat = new Angajat(reader.GetString(1), reader.GetString(2));
                            angajat.SetId(reader.GetInt64(0));
                            angajati.Add(angajat);
                        }
                        logger.Info("Found all angajati");
                        return angajati;
                    }
                }
            }
        }

        public Angajat FindAngajatByUsernameAndPassword(string username, string password)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, password FROM angajati WHERE username = @username AND password = @password";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Angajat angajat = new Angajat(reader.GetString(1), reader.GetString(2));
                            angajat.SetId(reader.GetInt64(0));
                            logger.Info("Found angajat with username " + username);
                            return angajat;
                        }
                        logger.Info("No angajat found with username " + username);
                        return null;
                    }
                }
            }
        }
    }
}
