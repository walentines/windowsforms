using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Client : Entity<long>
    {
        private string NumeClient { get; set; }

        public Client(string numeClient)
        {
            this.NumeClient = numeClient;
        }

        public string GetNumeClient()
        {
            return this.NumeClient;
        }

        public void SetNumeClient(string numeClient)
        {
            this.NumeClient = numeClient;
        }
    }
}
