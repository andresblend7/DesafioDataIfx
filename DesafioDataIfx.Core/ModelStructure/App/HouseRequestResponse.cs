using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioDataIfx.Core.ModelStructure.App
{
    public class HouseRequestResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int RequestId { get; set; }
    }
}
