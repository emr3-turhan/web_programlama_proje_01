﻿using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class AnaBilimDali
    {
        [Key]
        public int AnaBilimDaliId { get; set; }

        public string Name { get; set; }

        public List<Poliklinik> Poliklinikler { get; set; }
    }
}
