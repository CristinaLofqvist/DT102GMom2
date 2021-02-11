using System;
using System.ComponentModel.DataAnnotations;

namespace DT102GMom2.Models
{
    public class HorseModel
    {
        [Required]
        public float Lance { get; set; }
        [Required]
        public float Height { get; set; }
        public float Weight { get; set; }
        public HorseModel()
        {
        }
    }
}
