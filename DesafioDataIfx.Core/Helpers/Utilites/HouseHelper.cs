using DesafioDataIfx.Core.ModelStructure.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioDataIfx.Core.Helpers.Utilites
{
    public static class HouseHelper
    {
        /// <summary>
        /// Retorna el id de una casa dependiendo su nombre
        /// </summary>
        /// <param name="houseName"></param>
        /// <returns></returns>
        public static int GetHouseId(string houseName) => (int) Enum.Parse(typeof(EnumHouses), houseName); 
    }
}
