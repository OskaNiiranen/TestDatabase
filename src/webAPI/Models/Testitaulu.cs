﻿using System;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public partial class Testitaulu
    {
        [Key]

        public int PersonId { get; set; }
        public string? Etunimi { get; set; }
        public string? Sukunimi { get; set; }
        public int? Age { get; set; }
    }
}
