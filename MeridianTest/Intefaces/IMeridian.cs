using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeridianTest.Intefaces
{
    public interface IMeridian
    {
        Task<Double> Get();
    }
}
