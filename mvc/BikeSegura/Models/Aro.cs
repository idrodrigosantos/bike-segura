using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Aro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Medida do Aro")]
        [MaxLength(10)]
        public string Medida { get; set; }
    }
}