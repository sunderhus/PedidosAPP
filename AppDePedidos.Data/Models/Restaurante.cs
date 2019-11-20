using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDePedidos.Data.Models
{
    public class Restaurante
    {
        
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Tipo de Cozinha")]
        public TipoDeCozinha  Tipo { get; set; }
    }
}
