using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Projekat.Models
{
    /// <summary>
    /// Materijali sharing initializer class
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseAlways{Projekat.Models.MaterijalContext}" />
    public class MaterijalSharingInitializer : DropCreateDatabaseAlways<MaterijalContext>
    {
        /// <summary>
        /// Seeds the database context
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(MaterijalContext context)
        {
            base.Seed(context);
        }


        /// <summary>
        /// Reads the bytes from specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Bztes of selected file</returns>
        private byte[] procitajBajtove(string path)
        {
            FileStream fajlNaDisku = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] bajtoviFajla;
            using (BinaryReader br = new BinaryReader(fajlNaDisku))
            {
                bajtoviFajla = br.ReadBytes((int)fajlNaDisku.Length);
            }
            return bajtoviFajla;
        }
    }
}