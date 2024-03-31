﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.observer
{
    public interface Observer<E>
    {
        public void update(E t);
    }
}