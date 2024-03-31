using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_project.domain;
using mpp_project.repository;

namespace mpp_project.service
{
    public class BiletService
    {
        private BiletRepository biletRepository;

        public BiletService(BiletRepository biletRepository)
        {
            this.biletRepository = biletRepository;
        }

        public void Save(Bilet bilet)
        {
            biletRepository.Save(bilet);
        }

        public void Update(Bilet bilet)
        {
            biletRepository.Update(bilet);
        }

        public void Delete(int id)
        {
            biletRepository.Delete(id);
        }

        public Bilet FindOne(int id)
        {
            return biletRepository.FindOne(id);
        }

        public IEnumerable<Bilet> FindAll()
        {
            return biletRepository.FindAll();
        }
    }
}
