using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaTakipSistemi.Entites
{
    [Table("Cars")]
    public class Araba
    {
        [Key]
        [Column("CarID")]
        [MaxLength(50)]

        public string Kod { get; set; }

        [Column("CarBrand")]
        [MaxLength(50)]

        public string Marka { get; set; }


        [Column("CarModel")]
        [MaxLength(50)]

        public string Model { get; set; }


        [Column("CarYear")]
        [MaxLength(4)]
        public string Yıl { get; set; }

        [Column("CarFuel (Dizel-Bensin)")]
        [MaxLength(50)]
        public string Yakıt { get; set; }

        [Column("CarPrice")]
        
        public int Fiyat { get; set; }


        public Kullanici kullanici { get; set; }
    }
}
