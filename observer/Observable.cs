using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.observer
{
    // I want E to extend IEvent
    public interface Observable<E> where E : IEvent
    {
        void addObserver(Observer<E> o);
        void removeObserver(Observer<E> o);
        void notifyObservers(E t);
    }
}
