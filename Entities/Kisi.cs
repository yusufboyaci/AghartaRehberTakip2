using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kisi : BaseEntity
    {
        [MaxLength(50)]
        public string Ad { get; set; }
        [MaxLength(50)]
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public virtual IEnumerable<AdresDefteri> AdresDefteri { get; set; }
    }
}
