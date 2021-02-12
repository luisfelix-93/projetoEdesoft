using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoE.Models
{
    public class dono
    {
        [Key]
        public int ID_Dono { get; set; }
        public string Nome { get; set; }
    }
}