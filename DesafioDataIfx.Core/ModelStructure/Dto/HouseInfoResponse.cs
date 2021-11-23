using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioDataIfx.Core.ModelStructure.Dto
{
    public class HouseInfoResponse
    {
        public int IdRequest { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public string House { get; set; }
        public string State { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
