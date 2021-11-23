using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DesafioDataIfx.Infraestructure.Providers.SqlServer.DataBase
{
    public partial class Dic_Houses
    {
        public Dic_Houses()
        {
            Tra_HouseRequest = new HashSet<Tra_HouseRequest>();
        }

        public int hou_Id { get; set; }
        public string hou_Name { get; set; }
        public bool hou_Status { get; set; }

        public virtual ICollection<Tra_HouseRequest> Tra_HouseRequest { get; set; }
    }
}
