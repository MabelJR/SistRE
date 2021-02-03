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

        [Display(Name = "Fecha de creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)] //Formato Fecha ano/mes/dia
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }

        [Display(Name = "Fecha de actualizacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)] //Formato Fecha ano/mes/dia
        public Nullable<System.DateTime> FechaActualizo { get; set; }

        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
    }
}
