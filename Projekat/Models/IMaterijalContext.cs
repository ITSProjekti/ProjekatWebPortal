using Projekat.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Projekat.Models
{
    /// <summary>
    /// ImaterijalContext interfejs
    /// </summary>
    public interface IMaterijalContext
    {
        /// <summary>
        /// Gets the queryable data source for materijali.
        /// </summary>
        /// <value>
        /// Queryable selection of MaterijalModel Classes.
        /// </value>
        IQueryable<MaterijalModel> materijali { get; }

        /// <summary>
        /// Gets the queryable data source for moduli.
        /// </summary>
        /// <value>
        /// Queryable selection of ModulModel Classes.
        /// </value>
        IQueryable<ModulModel> moduli { get; }

        /// <summary>
        /// Gets the queryable data source for predmeti.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetModelClasses.
        /// </value>
        IQueryable<PredmetModel> predmeti { get; }

        /// <summary>
        /// Gets the queryable data source for smerovi.
        /// </summary>
        /// <value>
        /// The queryable selection of SmerModel Classes.
        /// </value>
        IQueryable<SmerModel> smerovi { get; }

        /// <summary>
        /// Gets the queryable data source for NamenaMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of NamenaMaterijalaModel Classes.
        /// </value>
        IQueryable<NamenaMaterijalaModel> nameneMaterijala { get; }

        /// <summary>
        /// Gets the queryable data source for PredmetiPoSmeru.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetPoSmeru Classes.
        /// </value>
        IQueryable<PredmetPoSmeru> predmetiPoSmeru { get; }

        /// <summary>
        /// Gets the queryable data source for TipMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of TipMaterijala Classes.
        /// </value>
        IQueryable<TipMaterijalModel> tipMaterijala { get; }

        /// <summary>
        /// Gets the queryable data source for TipPredmeta.
        /// </summary>
        /// <value>
        /// The queryable selection of TipPredmeta Classes.
        /// </value>
        IQueryable<TipPredmetaModel> tipPredmeta { get; }

        /// <summary>
        /// Gets the queryable data source for MaterijalPoModulu.
        /// </summary>
        /// <value>
        /// The queryable selection of MaterijalPoModulu Classes.
        /// </value>
        IQueryable<MaterijalPoModulu> materijalPoModulu { get; }

        /// <summary>
        /// Gets the queryable data source for GlobalniZahtevi.
        /// </summary>
        /// <value>
        /// The queryable selection of GlobalniZahtevi Classes.
        /// </value>
        IQueryable<GlobalniZahteviModel> globalniZahtevi { get; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Add<T>(T entity) where T : class;

        /// <summary>
        /// Searches material by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        MaterijalModel pronadjiMaterijalPoId(int id);

        /// <summary>
        /// Searches material by name.
        /// </summary>
        /// <param name="naziv">The naziv.</param>
        /// <returns></returns>
        MaterijalModel pronadjiMaterijalPoNazivu(string naziv);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Delete<T>(T entity) where T : class;

        /// <summary>
        /// Gets the queryable data source for NaprednaPretraga.
        /// </summary>
        /// <param name="ekstenzije">Extension.</param>
        /// <param name="tipoviMaterijalaIds">Id of material type.</param>
        /// <param name="modelId">Id of module.</param>
        /// <returns>
        /// Queryable selection of OsirommaseniMaterijaliModel Classes.
        /// </returns>
        IQueryable<OsiromaseniMaterijali> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int? modelId, int namena);

        /// <summary>
        /// Gets the queryable data source for PoModulu.
        /// </summary>
        /// <param name="modulId">The modul identifier.</param>
        /// <returns>
        /// Queryable selection of OsirommaseniMaterijaliModel Classes.
        /// </returns>
        IQueryable<OsiromaseniMaterijali> poModulu(int? modulId);

        IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali);

        IQueryable<OsiromaseniMaterijali> nacekanju();
    }
}