﻿using System.ComponentModel.DataAnnotations;

namespace autocomplete.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}