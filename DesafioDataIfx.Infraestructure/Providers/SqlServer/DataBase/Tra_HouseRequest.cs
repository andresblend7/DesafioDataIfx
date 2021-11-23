using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DesafioDataIfx.Infraestructure.Providers.SqlServer.DataBase
{
    public partial class Tra_HouseRequest
    {
        public int hre_Id { get; set; }
        public string hre_Name { get; set; }
        public string hre_LastName { get; set; }
        public int hre_Identification { get; set; }
        public int hre_Age { get; set; }
        public int hre_IdHouseFk { get; set; }
        public int hre_IdStateFk { get; set; }
        public bool hre_Status { get; set; }
        public DateTime hre_CreationDate { get; set; }

        public virtual Dic_Houses hre_IdHouseFkNavigation { get; set; }
        public virtual Dic_States hre_IdStateFkNavigation { get; set; }
    }
}
