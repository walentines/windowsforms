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
    public class ClientRepository : IRepository<long, Client>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Save(Client client)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO clienti (nume) VALUES (@numeClient)";
                    command.Parameters.AddWithValue("@numeClient", client.GetNumeClient());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Saved client {0}", client.GetNumeClient()));
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
                    command.CommandText = "DELETE FROM clienti WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Deleted client with id {0}", id));
                }
            }
        }

        public void Update(Client client)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE clienti SET nume = @numeClient WHERE id = @id";
                    command.Parameters.AddWithValue("@numeClient", client.GetNumeClient());
                    command.Parameters.AddWithValue("@id", client.GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Updated client with id {0}", client.GetId()));
                }
            }
        }

        public Client FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, nume FROM clienti WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client(reader.GetString(1));
                            client.SetId(reader.GetInt64(0));
                            logger.Info(String.Format("Found client {0}", client.GetNumeClient()));
                            return client;
                        }
                        else
                        {
                            logger.Info(String.Format("Client with id {0} not found", id));
                            return null;
                        }
                    }
                }
            }
        }

        public IEnumerable<Client> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, nume FROM clienti";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Client> clients = new List<Client>();
                        while (reader.Read())
                        {
                            Client client = new Client(reader.GetString(1));
                            client.SetId(reader.GetInt64(0));
                            clients.Add(client);
                        }
                        return clients;
                    }
                }
            }
        }

        public Client FindLastClientInDatabase()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, nume FROM clienti ORDER BY id DESC LIMIT 1";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client(reader.GetString(1));
                            client.SetId(reader.GetInt64(0));
                            logger.Info(String.Format("Found last client in database {0}", client.GetNumeClient()));
                            return client;
                        }
                        else
                        {
                            logger.Info("No clients found in database");
                            return null;
                        }
                    }

                }

            }
        }
    }
}
