using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ITO_Test.Models
{
    public class Dependencia
    {
        [Key]
        [Required(ErrorMessage ="El campo dependenciaId es requerido.")]
        public int  dependeciaId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="El campo dependenciaName es requerido")]
        public string dependenciaName { get; set; }
    }
}
