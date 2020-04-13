using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projekat.Models
{
    /// <summary>
    /// MaterijalContext class
    /// </summary>
    /// <seealso cref="Projekat.Models.ApplicationDbContext" />
    /// <seealso cref="Projekat.Models.IMaterijalContext" />
    public class MaterijalContext : ApplicationDbContext, IMaterijalContext
    {
        /// <summary>
        /// Gets the queryable data source for materijali.
        /// </summary>
        /// <value>
        /// Queryable selection of MaterijalModel Classes.
        /// </value>
        public DbSet<MaterijalModel> materijali { get; set; }

        /// <summary>
        /// Gets the queryable data source for predmeti.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetModelClasses.
        /// </value>
        public DbSet<PredmetModel> predmeti { get; set; }

        /// <summary>
        /// Gets the queryable data source for smerovi.
        /// </summary>
        /// <value>
        /// The queryable selection of SmerModel Classes.
        /// </value>
        public DbSet<SmerModel> smerovi { get; set; }

        /// <summary>
        /// Gets the queryable data source for NamenaMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of NamenaMaterijalaModel Classes.
        /// </value>
        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        /// <summary>
        /// Gets the queryable data source for PredmetiPoSmeru.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetPoSmeru Classes.
        /// </value>
        public DbSet<PredmetPoSmeru> predmetiPoSmeru { get; set; }

        /// <summary>
        /// Gets the queryable data source for TipMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of TipMaterijala Classes.
        /// </value>
        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }

        public DbSet<SkolaModel> Skole { get; set; }
        public DbSet<Forum_Post> Forum { get; set; }
        public DbSet<Forum_Message> Message { get; set; }
        //public DbSet<AspNetUser> Users { get; set; }
        //public DbSet<MaterijalProfesorModel> Profesormaterijali { get; set; }

        public DbSet<ModulModel> moduli { get; set; }

        IQueryable<TipMaterijalModel> IMaterijalContext.tipMaterijala
        {
            get { return tipMaterijala; }
        }

        IQueryable<PredmetModel> IMaterijalContext.predmeti
        {
            get { return predmeti; }
        }

        IQueryable<SmerModel> IMaterijalContext.smerovi
        {
            get { return smerovi; }
        }

        IQueryable<PredmetPoSmeru> IMaterijalContext.predmetiPoSmeru
        {
            get { return predmetiPoSmeru; }
        }

        IQueryable<NamenaMaterijalaModel> IMaterijalContext.nameneMaterijala
        {
            get { return nameneMaterijala; }
        }

        IQueryable<MaterijalModel> IMaterijalContext.materijali => throw new NotImplementedException();

        T IMaterijalContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IMaterijalContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoId(int id)
        {
            return Set<MaterijalModel>().Find(id);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoNazivu(string naziv)
        {
            MaterijalModel materijal = (from m in Set<MaterijalModel>()
                                        where m.materijalNaziv == naziv
                                        select m).FirstOrDefault();
            return materijal;
        }

        int IMaterijalContext.SaveChanges()
        {
            return SaveChanges();
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.poPredmetu(int? predmetId)
        {
            IQueryable<OsiromaseniMaterijali> materijali;
            materijali = this.materijali.Where(m => m.predmetId == predmetId && m.odobreno != null).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaMaterijalaId,
                materijalId = m.materijalId,
                ekstenzija = m.materijalEkstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalId,
                predmetId = m.predmetId
            });

            return materijali;
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.nacekanju()
        {
            IQueryable<OsiromaseniMaterijali> materijali;
            materijali = this.materijali.Where(m => m.odobreno == null).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaMaterijalaId,
                materijalId = m.materijalId,
                ekstenzija = m.materijalEkstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalId,
                predmetId = m.predmetId
            });
            return materijali;
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int? predmetId, int namenaID)//Dodati parametre
        {
            // && (a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId)

            IMaterijalContext context = new MaterijalContext();
            var queriable = context.poPredmetu(predmetId);
            queriable = poNameni(namenaID, queriable);

            if (ekstenzije != null && tipoviMaterijalaIds != null)
            {
                queriable = queriable.
                   Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                queriable = queriable.
                    Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                return queriable;
            }
            else if (ekstenzije == null && tipoviMaterijalaIds != null)
            {
                queriable = queriable.
                Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                return queriable;
            }
            else if (ekstenzije != null && tipoviMaterijalaIds == null)
            {
                queriable = queriable.
                Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                return queriable;
            }
            else
                return queriable;
        }

        public IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali)
        {
            materijali = materijali.Where(m => m.namenaID == namenaID).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaID,
                materijalId = m.materijalId,
                ekstenzija = m.ekstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalaId,
                predmetId = m.predmetId
            });

            return materijali;
        }
    }
}