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
    public class AdresRepository : IAdresRepository
    {
        private readonly AppDbContext _context;
        public AdresRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<AdresDefteri> AdresDefteriler => _context.AdresDefteriler;

        public AdresDefteri GetirAdresDefteriIdIle(int id)
        {
            return _context.AdresDefteriler.Find(id);
        }

        public bool AdresDefteriEkle(AdresDefteri adresDefteri)
        {
            if (adresDefteri != null)
            {
                _context.AdresDefteriler.Add(adresDefteri);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool AdresDefteriGuncelle(AdresDefteri adresDefteri)
        {
            if (adresDefteri != null)
            {
                _context.AdresDefteriler.Update(adresDefteri);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool AdresDefteriSil(int id)
        {
            _context.AdresDefteriler.Remove(GetirAdresDefteriIdIle(id));
            return _context.SaveChanges() > 0;
        }

    }
}
