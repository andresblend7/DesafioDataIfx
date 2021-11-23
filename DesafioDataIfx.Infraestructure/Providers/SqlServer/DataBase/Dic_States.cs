using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DesafioDataIfx.Infraestructure.Providers.SqlServer.DataBase
{
    public partial class Dic_States
    {
        public Dic_States()
        {
            Tra_HouseRequest = new HashSet<Tra_HouseRequest>();
        }

        public int sta_Id { get; set; }
        public string sta_Name { get; set; }
        public bool sta_Status { get; set; }

        public virtual ICollection<Tra_HouseRequest> Tra_HouseRequest { get; set; }
    }
}
