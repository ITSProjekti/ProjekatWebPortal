using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class PrikazVestiViewModel
    {
        public string Naslov { get; set; }
        public string KratakOpis { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public string TeloVesti { get; set; }
    }
}