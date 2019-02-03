using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeridianTest.Intefaces
{
    public interface IClient
    {
        Task<String> Send(String command);
    }
}
