using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_project.domain;
using mpp_project.repository;

namespace mpp_project.service
{
    public class RezervareService
    {
        private RezervareRepository rezervareRepository;

        public RezervareService(RezervareRepository rezervareRepository)
        {
            this.rezervareRepository = rezervareRepository;
        }

        public void Save(Rezervare rezervare)
        {
            rezervareRepository.Save(rezervare);
        }

        public void Update(Rezervare rezervare)
        {
            rezervareRepository.Update(rezervare);
        }

        public void Delete(int id)
        {
            rezervareRepository.Delete(id);
        }

        public Rezervare FindOne(int id)
        {
            return rezervareRepository.FindOne(id);
        }

        public IEnumerable<Rezervare> FindAll()
        {
            return rezervareRepository.FindAll();
        }

        public Rezervare FindLastRezervare()
        {
            return rezervareRepository.FindLastRezervareInDatabase();
        }
    }
}
