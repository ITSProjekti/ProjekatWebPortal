using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.ViewModels
{
    public class GlobalniZahtevViewModel
    {
        public MaterijalModel materijal { get; set; }

        public GlobalniZahteviModel globalni { get;set; }
    }
}