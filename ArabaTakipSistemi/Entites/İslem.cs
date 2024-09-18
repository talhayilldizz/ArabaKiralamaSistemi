using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaTakipSistemi.Entites
{
    [Table("Process")]
    public class İslem
    {
        [Key]
        [Column("ProcessID")]
        [MaxLength(50)]
        public string kod { get; set; }


        [Column("CustomerName")]
        [MaxLength(50)]
        public string Ad { get; set; }

        [Column("CarBrand")]
        [MaxLength(50)]
        public string Marka { get; set; }


        [Column("CarModel")]
        [MaxLength(50)]
        public string Model { get; set; }


        [Column("ProcessDate")]
        public DateTime Tarih { get; set; }
    }
}
