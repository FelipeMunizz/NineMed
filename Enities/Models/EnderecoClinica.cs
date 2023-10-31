using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class EnderecoClinica : Endereco
    {
        public int Id { get; set; }
        [ForeignKey("Clinica")]
        public int IdClinica { get; set; }
        public virtual Clinica Clinica { get; set; }
    }
}
