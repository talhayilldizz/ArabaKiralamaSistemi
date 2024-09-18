using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaTakipSistemi.Entites
{
    [Table("Customers")]
    public class Kullanici
    {
        [Key]
        [Column("CustomerID")]
        public string Kod { get; set; }


        [Column("CustomerName")]
        [MaxLength(50)]
        public string Ad { get; set; }


        [Column("CustomerNick")]
        [MaxLength(50)]
        public string KullanicAdi { get; set; }


        [Column("CustomerPass")]
        [MaxLength(50)]
        public string Sifre { get; set; }

        [Column("CustomerCity")]
        [MaxLength(50)]
        public string Şehir { get; set; }

        [Column("CustomerJob")]
        [MaxLength(50)]
        public string Meslek { get; set; }


        public List<Araba> Arabalar { get; set; }
    }
}
