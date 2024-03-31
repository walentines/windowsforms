using mpp_project.repository;
using mpp_project.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.service
{
    public class AngajatService
    {
        private AngajatRepository angajatRepository;

        public AngajatService(AngajatRepository angajatRepository)
        {
            this.angajatRepository = angajatRepository;
        }

        public void Save(Angajat angajat)
        {
            angajatRepository.Save(angajat);
        }

        public void Update(Angajat angajat)
        {
            angajatRepository.Update(angajat);
        }

        public void Delete(int id)
        {
            angajatRepository.Delete(id);
        }

        public Angajat FindOne(int id)
        {
            return angajatRepository.FindOne(id);
        }

        public IEnumerable<Angajat> FindAll()
        {
            return angajatRepository.FindAll();
        }

        public Angajat FindAngajatByUsernameAndPassword(string username, string password)
        {
            return angajatRepository.FindAngajatByUsernameAndPassword(username, password);
        }
    }
}
