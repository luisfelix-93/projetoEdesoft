using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjetoE.Models
{
    public class raca
    {
        [Key]
        public int ID_raca { get; set; }
        public string Nome { get; set; }
    }
}