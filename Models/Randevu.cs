﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class Randevu
    {

        [Key]
        public int RandevuId { get; set; }

        public DateTime Tarih { get; set; }
        public bool Onaylandi { get; set; }

        [ForeignKey("Doktor")]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        [ForeignKey("Hasta")]
        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }
    }
}
