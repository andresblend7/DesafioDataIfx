using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioDataIfx.Core.ModelStructure.App
{
    /// <summary>
    /// Por seguridad se solicitan idRequest y idUser
    /// </summary>
    public class HouseDeleteRequest
    {
        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdRequest { get; set; }
    }
}
