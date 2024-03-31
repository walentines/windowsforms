using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Rezervare : Entity<long>
    {
        private Zbor zbor { get; set; }
        private Client client { get; set; }
        private string AdresaClient { get; set; }
        private int NrLocuri { get; set; }

        public Rezervare(Zbor zbor, Client client, string adresaClient, int nrLocuri)
        {
            this.zbor = zbor;
            this.client = client;
            this.AdresaClient = adresaClient;
            this.NrLocuri = nrLocuri;
        }

        public Zbor GetZbor()
        {
            return this.zbor;
        }

        public void SetZbor(Zbor zbor)
        {
            this.zbor = zbor;
        }

        public Client GetClient()
        {
            return this.client;
        }

        public void SetClient(Client client)
        {
            this.client = client;
        }

        public string GetAdresaClient()
        {
            return this.AdresaClient;
        }

        public void SetAdresaClient(string adresaClient)
        {
            this.AdresaClient = adresaClient;
        }

        public int GetNrLocuri()
        {
            return this.NrLocuri;
        }

        public void SetNrLocuri(int nrLocuri)
        {
            this.NrLocuri = nrLocuri;
        }
    }
}
