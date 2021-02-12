using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjetoE.Models
{
    public class cao_dono
    {
        [Key]
        public int ID_cao_dono { get; set; }
        public int ID_dono { get; set; }
        public int ID_cao { get; set; }

        public virtual string Nome_Dono { get; set; }
        public virtual string Nome_Cao { get; set; }
        public virtual string Nome_Raca { get; set; }
    }
}