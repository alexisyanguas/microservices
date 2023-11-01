using Api.Reservation.Business.Models;
using Api.Reservation.Datas.Entities;
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Refit;

namespace Api.Reservation.Business.Service
{
    public class ReservationService : IReservationService
    {
        /// <summary>
        /// The reservation repository
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// The utilisateur repository
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        /// <summary>
        /// The flights API
        /// </summary>
        private readonly IFlightsApi _flightsApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="reservationRepository">The reservation repository.</param>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        /// <param name="flightsApi">The flights API.</param>
        public ReservationService(IReservationRepository reservationRepository, IUtilisateurRepository utilisateurRepository, IFlightsApi flightsApi)
        {
            _reservationRepository = reservationRepository;
            _utilisateurRepository = utilisateurRepository;
            _flightsApi = flightsApi;
        }

        /// <summary>
        /// Cette méthode permet de faire un appel Http vers l'API des vols pour
        /// recupérer les informations d'un siege
        /// </summary>
        /// <param name="numeroVol">Le numéro du vol.</param>
        /// <param name="nomSiege">Le nom du siege</param>
        /// <returns></returns>
        public async Task<Seat> GetSiegeStatusAsync(string numeroVol, string nomSiege)
        {
            return await _flightsApi.GetSiegeStatusAsync(numeroVol, nomSiege)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates the reservation asynchronous.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
        public async Task<Datas.Entities.Reservation> CreateReservationAsync(Datas.Entities.Reservation reservation)
        {
            // Vérifier l'existence de l'utilisateur ,sinon levez une exception
            //TODO

            var siegeStatus = await GetSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege);

            if (siegeStatus?.Status != "Disponible")
            {
                throw new BusinessException("Echec de création d'une reservation : Le siège n'est pas disponible.");
            }

            // Le siège est disponible, procédez à la création de la réservation
            return await _reservationRepository.CreateReservationAsync(reservation)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        public async Task <List<Datas.Entities.Reservation>> GetReservationsAsync()
        {
            return await _reservationRepository.GetReservationsAsync()
                .ConfigureAwait(false);
        }
    }
}
