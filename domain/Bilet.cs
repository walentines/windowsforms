using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Bilet : Entity<long>
    {
        private Rezervare rezervare { get; set; }
        private Client client { get; set; }

        public Bilet(Rezervare rezervare, Client client)
        {
            this.rezervare = rezervare;
            this.client = client;
        }

        // getters and setters
        public Rezervare GetRezervare()
        {
            return this.rezervare;
        }

        public void SetRezervare(Rezervare rezervare)
        {
            this.rezervare = rezervare;
        }

        public Client GetClient()
        {
            return this.client;
        }

        public void SetClient(Client client)
        {
            this.client = client;
        }

        public override string ToString()
        {
            return "Bilet{" +
                   "id=" + this.GetId() +
                   ", rezervare=" + this.rezervare +
                   ", client=" + this.client +
                   '}';
        }
    }
}
