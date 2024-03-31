using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_project.domain;
using mpp_project.observer;
using mpp_project.repository;

namespace mpp_project.service
{
    public class ZborService : Observable<ZborChangeEvent>
    {
        private ZborRepository zborRepository;
        private List<Observer<ZborChangeEvent>> observers = new List<Observer<ZborChangeEvent>>();

        public ZborService(ZborRepository zborRepository)
        {
            this.zborRepository = zborRepository;
        }

        public void addObserver(Observer<ZborChangeEvent> o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer<ZborChangeEvent> o)
        {
            observers.Remove(o);
        }

        public void notifyObservers(ZborChangeEvent t)
        {
            observers.ForEach(observer => observer.update(t));
        }

        public void Save(Zbor zbor)
        {
            zborRepository.Save(zbor);
        }

        public void Update(Zbor zbor)
        {
            zborRepository.Update(zbor);
        }

        public void Delete(int id)
        {
            zborRepository.Delete(id);
        }

        public Zbor FindOne(int id)
        {
            return zborRepository.FindOne(id);
        }

        public IEnumerable<Zbor> FindAll()
        {
            return zborRepository.FindAll();
        }

        public IEnumerable<Zbor> FindZboruriByDestinatieAndData(string destinatie, DateTime data)
        {
            return zborRepository.FindZboruriByDestinatieAndData(destinatie, data);
        }

        public void cumparaBilete(Zbor zbor, int nrLocuri)
        {
            zborRepository.cumparaBilete(zbor, nrLocuri);
            notifyObservers(new ZborChangeEvent(zbor, ChangeEventEnum.UPDATE));
        }
    }
}
