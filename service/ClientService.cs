using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_project.domain;
using mpp_project.repository;

namespace mpp_project.service
{
    public class ClientService
    {

        private ClientRepository clientRepository;
        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public void Save(Client client)
        {
            clientRepository.Save(client);
        }

        public Client FindLastClient()
        {
            return clientRepository.FindLastClientInDatabase();
        }
    }
}
