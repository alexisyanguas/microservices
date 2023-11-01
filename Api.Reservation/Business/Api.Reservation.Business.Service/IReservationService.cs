
using Api.Reservation.Business.Models;

namespace Api.Reservation.Business.Service
{
    public interface IReservationService
    {
        /// <summary>
        /// Cette méthode permet de faire un appel Http vers l'API des vols pour
        /// recupérer les informations d'un siege
        /// </summary>
        /// <param name="numeroVol">Le numéro du vol.</param>
        /// <param name="nomSiege">Le nom du siege</param>
        /// <returns></returns>
        Task<Seat> GetSiegeStatusAsync(string numeroVol, string nomSiege);

        /// <summary>
        /// Creates the reservation asynchronous.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
        Task<Datas.Entities.Reservation> CreateReservationAsync(Datas.Entities.Reservation reservation);

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Reservation>> GetReservationsAsync();

    }
}
