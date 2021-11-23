using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioDataIfx.Core.ModelStructure.App
{
    public class HouseChangeStateRequest
    {
        [Required]
        public int IdRequest { get; set; }
        [Required]
        public bool Accept { get; set; }
    }
}
