using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVanillaJs.Models.Request
{
    public class AutomovilEditRequest
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public int Valor { get; set; }
        public string Imagen { get; set; }
    }
}
