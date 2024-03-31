using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Zbor : Entity<long>
    {
        private string Destinatie { get; set; }
        private DateTime Data { get; set; }
        private Aeroport aeroport { get; set; }
        private int NrLocuri { get; set; }

        public Zbor(string destinatie, DateTime data, Aeroport aeroport, int nrLocuri)
        {
            this.Destinatie = destinatie;
            this.Data = data;
            this.aeroport = aeroport;
            this.NrLocuri = nrLocuri;

        }

        public string GetDestinatie()
        {
            return this.Destinatie;
        }

        public void SetDestinatie(string destinatie)
        {
            this.Destinatie = destinatie;
        }

        public DateTime GetData()
        {
            return this.Data;
        }

        public void SetData(DateTime data)
        {
            this.Data = data;
        }

        public Aeroport getAeroport()
        {
            return this.aeroport;
        }

        public void setAeroport(Aeroport aeroport)
        {
            this.aeroport = aeroport;
        }

        public int GetNrLocuri()
        {
            return this.NrLocuri;
        }

        public void SetNrLocuri(int nrLocuri)
        {
            this.NrLocuri = nrLocuri;
        }

        public override string ToString()
        {
            return "Zbor{" +
                    "id=" + this.GetId() +
                    ", destinatie='" + Destinatie + '\'' +
                    ", data=" + Data +
                    ", aeroport=" + aeroport +
                    ", nrLocuri=" + NrLocuri +
                    '}';
        }
    }
}
