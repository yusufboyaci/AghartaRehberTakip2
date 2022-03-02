using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAdresRepository
    {
        IQueryable<AdresDefteri> AdresDefteriler { get; }
        AdresDefteri GetirAdresDefteriIdIle(int id);
        bool AdresDefteriEkle(AdresDefteri adresDefteri);
        bool AdresDefteriGuncelle(AdresDefteri adresDefteri);
        bool AdresDefteriSil(int id);
    }
}
