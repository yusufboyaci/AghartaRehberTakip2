using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IKisiRepository
    {
        IQueryable<Kisi> Kisiler { get; }
        Kisi GetirKisiIdIle(int id);
        bool KisiEkle(Kisi kisi);
        bool KisiGuncelle(Kisi kisi);
        bool KisiSil(int id);
    }
}
