using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioDataIfx.Core.ModelStructure.App
{
    public class HouseUpdateRequest
    {
        [Required]
        public int Request { get; set; }
        [Required]
        public HouseRequest HouseRequest { get; set; }
    }
}
