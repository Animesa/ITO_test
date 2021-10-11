using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ITO_Test.Models
{
    public class Empleado
    {
        [Key]
        [Required(ErrorMessage ="El campo empleadoId es requerido")]
        public int empleadoId { get; set; }
        public string empleadoName { get; set; }
        public string empleadoLast { get; set; }

        public int dependenciaid { get; set; }

        public Dependencia Dependencia { get; set; }
    }
}
