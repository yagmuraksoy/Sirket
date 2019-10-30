using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirket.Models;

namespace Sirket.Services
{
    public class InMemorySiparisRepository :ISiparisRepository
    {
        private readonly SiparisAPIContext c;

        public InMemorySiparisRepository(SiparisAPIContext context)
        {
            c = context;
        }


        public Siparis Add(Siparis s)
        {
            var addedSiparis = c.Add(s);
            c.SaveChanges();
            s.Id = addedSiparis.Entity.Id;
            
            return s;
        }


        public void Delete(Siparis s)
        {
            c.Remove(s);
            c.SaveChanges();
        }


        public IEnumerable<Siparis> GetAll()
        {
            return c.Sipariss.ToList();
        }


        public Siparis GetById(int id)
        {
            return c.Sipariss.SingleOrDefault(x => x.Id == id);
        }


        public void Update(Siparis s)
        {
            var siparisToUpdate = GetById(s.Id);
            siparisToUpdate.UrunKodu = s.UrunKodu;
            siparisToUpdate.Tarih = s.Tarih;
            c.Update(siparisToUpdate);
            c.SaveChanges();
        }
    }
}
