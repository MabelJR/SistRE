using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
  public  class BeTipoDroga
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Droga")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }

        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
    }
}
