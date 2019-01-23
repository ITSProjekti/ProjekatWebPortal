using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Projekat.Migrations.VestiContext
{
    internal sealed class VestiConfiguration : DbMigrationsConfiguration<Projekat.Models.VestiContext>
    {
        public VestiConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\VestiContext";
        }
        protected override void Seed(Projekat.Models.VestiContext context)
        {

        }
    }
}