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
    public class RezervareRepository : IRepository<long, Rezervare>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ZborRepository zborRepository;
        private ClientRepository clientRepository;

        public RezervareRepository(string connectionString, ZborRepository zborRepository, ClientRepository clientRepository)
        {
            this.connectionString = connectionString;
            this.zborRepository = zborRepository;
            this.clientRepository = clientRepository;
        }

        public void Save(Rezervare rezervare)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO rezervari (idClient, idZbor, adresaClient, nrLocuri) VALUES (@idZbor, @idClient, @adresaClient, @nrLocuri)";
                    command.Parameters.AddWithValue("@idClient", rezervare.GetClient().GetId());
                    command.Parameters.AddWithValue("@idZbor", rezervare.GetZbor().GetId());
                    command.Parameters.AddWithValue("@nrLocuri", rezervare.GetNrLocuri());
                    command.Parameters.AddWithValue("@adresaClient", rezervare.GetAdresaClient());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Saved rezervare {0}", rezervare.GetClient().GetId()));
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
                    command.CommandText = "DELETE FROM rezervari WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Deleted rezervare with id {0}", id));
                }
            }
        }

        public void Update(Rezervare rezervare)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "UPDATE rezervari SET idZbor = @idZbor, idClient = @idClient, adresaClient = @adresaClient, nrLocuri = @nrLocuri WHERE Id = @id";
                    command.Parameters.AddWithValue("@idZbor", rezervare.GetZbor().GetId());
                    command.Parameters.AddWithValue("@idClient", rezervare.GetClient().GetId());
                    command.Parameters.AddWithValue("@adresaClient", rezervare.GetAdresaClient());
                    command.Parameters.AddWithValue("@nrLocuri", rezervare.GetNrLocuri());
                    command.Parameters.AddWithValue("@id", rezervare.GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Updated rezervare with id {0}", rezervare.GetId()));
                }
            }
        }

        public Rezervare FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, idZbor, idClient, adresaClient, nrLocuri FROM rezervari WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Rezervare rezervare = new Rezervare(zborRepository.FindOne(reader.GetInt64(1)), clientRepository.FindOne(reader.GetInt64(2)), reader.GetString(3),
                                reader.GetInt32(4));
                            rezervare.SetId(reader.GetInt64(0));
                            logger.Info(String.Format("Found rezervare {0}", rezervare.GetId()));
                            return rezervare;
                        }
                        else
                        {
                            logger.Info(String.Format("No rezervare found with id {0}", id));
                            return null;
                        }
                    }
                }
            }
        }

        public IEnumerable<Rezervare> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, idZbor, idClient, adresaClient, nrLocuri FROM rezervari";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Rezervare> rezervari = new List<Rezervare>();
                        while (reader.Read())
                        {
                            Rezervare rezervare = new Rezervare(zborRepository.FindOne(reader.GetInt64(1)), clientRepository.FindOne(reader.GetInt64(2)), reader.GetString(3),
                                reader.GetInt32(4));
                            rezervare.SetId(reader.GetInt64(0));
                            rezervari.Add(rezervare);
                        }
                        return rezervari;
                    }
                }
            }
        }

        public Rezervare FindLastRezervareInDatabase()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, idZbor, idClient, adresaClient, nrLocuri FROM rezervari ORDER BY id DESC LIMIT 1";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Rezervare rezervare = new Rezervare(zborRepository.FindOne(reader.GetInt64(1)), clientRepository.FindOne(reader.GetInt64(2)), reader.GetString(3),
                                                               reader.GetInt32(4));
                            rezervare.SetId(reader.GetInt64(0));
                            return rezervare;
                        }
                        return null;
                    }
                }
            }
        }
    }
}
