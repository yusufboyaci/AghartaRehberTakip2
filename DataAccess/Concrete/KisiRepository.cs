using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class KisiRepository : IKisiRepository
    {
        private readonly AppDbContext _context;
        public KisiRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Kisi> Kisiler => _context.Kisiler;

        public Kisi GetirKisiIdIle(int id)
        {

            return _context.Kisiler.Find(id);
        }

        public bool KisiEkle(Kisi kisi)
        {
            _context.Kisiler.Add(kisi);
            return _context.SaveChanges() > 0;
        }

        public bool KisiGuncelle(Kisi kisi)
        {
            _context.Kisiler.Update(kisi);
            return _context.SaveChanges() > 0;
        }

        public bool KisiSil(int id)
        {
            _context.Kisiler.Remove(GetirKisiIdIle(id));
            return _context.SaveChanges() > 0;
        }
    }
}
