using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirket.Models;

namespace Sirket.Services
{
    public interface ISiparisRepository
    {
        Siparis Add(Siparis s);
        IEnumerable<Siparis> GetAll();
        Siparis GetById(int id);
        void Delete(Siparis s);
        void Update(Siparis s);
    }
}
