using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Aeroport : Entity<long>
    {
        private string Nume { get; set; }

        public Aeroport(string nume)
        {
            this.Nume = nume;
        }

        public string GetNume()
        {
            return this.Nume;
        }

        public void SetNume(string nume)
        {
            this.Nume = nume;
        }
    }
}
