using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.ViewModels;

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
        /// <param name="predmetId">Id of subject.</param>
        /// <returns>
        /// Queryable selection of OsirommaseniMaterijaliModel Classes.
        /// </returns>
        IQueryable<OsiromaseniMaterijali> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int? predmetId,int namena);

        /// <summary>
        /// Gets the queryable data source for PoPredmetu.
        /// </summary>
        /// <param name="predmetId">The predmet identifier.</param>
        /// <returns>
        /// Queryable selection of OsirommaseniMaterijaliModel Classes.
        /// </returns>
        IQueryable<OsiromaseniMaterijali> poPredmetu(int? predmetId);
        IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali);




    }
}
