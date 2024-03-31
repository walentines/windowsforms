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
    public class BiletRepository : IRepository<long, Bilet>
    {
        private string connectionString;
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private RezervareRepository rezervareRepository;
        private ClientRepository clientRepository;

        public BiletRepository(string connectionString, RezervareRepository rezervareRepository, ClientRepository clientRepository)
        {
            this.connectionString = connectionString;
            this.rezervareRepository = rezervareRepository;
            this.clientRepository = clientRepository;
        }

        public void Save(Bilet bilet)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO bilete (idRezervare, idClient) VALUES (@idRezervare, @idClient)";
                    command.Parameters.AddWithValue("@idRezervare", bilet.GetRezervare().GetId());
                    command.Parameters.AddWithValue("@idClient", bilet.GetClient().GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Saved bilet {0}", bilet.GetId()));
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
                    command.CommandText = "DELETE FROM bilete WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Deleted bilet with id {0}", id));
                }
            }
        }

        public void Update(Bilet bilet)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE bilete SET idRezervare = @idRezervare, idClient = @idClient WHERE id = @id";
                    command.Parameters.AddWithValue("@idRezervare", bilet.GetRezervare().GetId());
                    command.Parameters.AddWithValue("@idClient", bilet.GetClient().GetId());
                    command.Parameters.AddWithValue("@id", bilet.GetId());
                    command.ExecuteNonQuery();
                    logger.Info(String.Format("Updated bilet with id {0}", bilet.GetId()));
                }
            }
        }

        public Bilet FindOne(long id)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT idRezervare, idClient FROM bilete WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long idRezervare = reader.GetInt64(0);
                            long idClient = reader.GetInt64(1);
                            Rezervare rezervare = rezervareRepository.FindOne(idRezervare);
                            Client client = clientRepository.FindOne(idClient);
                            Bilet bilet = new Bilet(rezervare, client);
                            bilet.SetId(id);
                            logger.Info(String.Format("Found bilet {0}", id));
                            return bilet;
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Bilet> FindAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, idRezervare, idClient FROM bilete";
                    using (var reader = command.ExecuteReader())
                    {
                        List<Bilet> bilete = new List<Bilet>();
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            long idRezervare = reader.GetInt64(1);
                            long idClient = reader.GetInt64(2);
                            Rezervare rezervare = rezervareRepository.FindOne(idRezervare);
                            Client client = clientRepository.FindOne(idClient);
                            Bilet bilet = new Bilet(rezervare, client);
                            bilet.SetId(id);
                            bilete.Add(bilet);
                        }
                        logger.Info("Found all entities");
                        return bilete;
                    }
                }
            }
        }
    }
}
