using Projekat.Models;
using System.Collections.Generic;

namespace Projekat.ViewModels
{
    public class GlobalniZahtevViewModel
    {
        public MaterijalModel materijal { get; set; }

        public GlobalniZahteviModel globalni { get; set; }

        public int modulId { get; set; }
        public List<ModulModel> ModuliPoPredmetu { get; set; }
        public List<ModulModel> Moduli { get; set; }
        public int predmetId { get; set; }
        public List<PredmetModel> Predmeti { get; set; }
    }
}