using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoE.Models
{
    public class cao
    {
        [Key]
        public int ID_cao { get; set; }
        public string Nome { get; set; }
        public int ID_raca { get; set; }

        public virtual string Nome_Raca { get; set; }
    }
}