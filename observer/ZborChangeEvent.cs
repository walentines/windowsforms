using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_project.domain;


namespace mpp_project.observer
{
    public class ZborChangeEvent : IEvent
    {
        private Zbor zbor;
        private ChangeEventEnum type;

        public ZborChangeEvent(Zbor zbor, ChangeEventEnum type)
        {
            this.zbor = zbor;
            this.type = type;
        }

        public Zbor getZbor()
        {
            return zbor;
        }

        public ChangeEventEnum getType()
        {
            return type;
        }
    }
}
