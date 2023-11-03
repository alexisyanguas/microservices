
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
        /// Creates the reservation asynchronous
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : L'utilisateur n'existe pas.</exception>
        Task<Datas.Entities.Reservation> CreateReservationAsync(Datas.Entities.Reservation reservation);
  
        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Reservation>> GetReservationsAsync();
  
        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations grace au nom de l'utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">The nom utilisateur.</param>
        /// <returns></returns>
        Task<List<Datas.Entities.Reservation>> GetReservationsByUtilisateurAsync(string nomUtilisateur);

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations grace au numero de vol
        /// </summary>
        /// <param name="numeroVol">The numero vol.</param>
        /// <returns></returns>
        Task<List<Datas.Entities.Reservation>> GetReservationsByNumeroVolAsync(string numeroVol);

         /// <summary>
        /// Cette méthode permet de supprimer une reservation, et de libérer le siège
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteReservationAsync(int id);

           /// <summary>
        /// Cette méthode permet de recupérer une reservation grace à son id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Datas.Entities.Reservation> GetReservationByIdAsync(int id);
    }
}
