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
        /// Creates the reservation asynchronous
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : L'utilisateur n'existe pas.</exception>
        public async Task<Datas.Entities.Reservation> CreateReservationAsync(Datas.Entities.Reservation reservation)
        {
            Datas.Entities.Utilisateur userSelected = await _utilisateurRepository.GetUtilisateurByIdAsync(reservation.UtilisateurId);
            if (userSelected == null)
            {
                throw new BusinessException("Echec de création d'une reservation : L'utilisateur n'existe pas.");
            }

            var siegeStatus = await GetSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege);

            if (siegeStatus?.Status != "Disponible")
            {
                throw new BusinessException("Echec de création d'une reservation : Le siège n'est pas disponible.");
            }

            Seat seat = new Seat
            {
                Status = "Reserve"
            };

            await _flightsApi.UpdateSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege, seat);
            // Le siège est disponible, procédez à la création de la réservation
            return await _reservationRepository.CreateReservationAsync(reservation)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Reservation>> GetReservationsAsync()
        {
            return await _reservationRepository.GetReservationsAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations grace au nom de l'utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">The nom utilisateur.</param>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Reservation>> GetReservationsByUtilisateurAsync(string nomUtilisateur)
        {
            return await _reservationRepository.GetReservationsByUtilisateurAsync(nomUtilisateur).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations grace au numero de vol
        /// </summary>
        /// <param name="numeroVol">The numero vol.</param>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Reservation>> GetReservationsByNumeroVolAsync(string numeroVol)
        {
            return await _reservationRepository.GetReservationsByNumeroVolAsync(numeroVol).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de supprimer une reservation, et de libérer le siège
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task DeleteReservationAsync(int id)
        {
            Datas.Entities.Reservation reservation = await _reservationRepository.GetReservationByIdAsync(id).ConfigureAwait(false);
            if (reservation == null)
            {
                throw new BusinessException("Echec de suppression d'une reservation : La reservation n'existe pas.");
            }

            Seat seat = new Seat
            {
                Status = "Disponible"
            };
            _flightsApi.UpdateSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege, seat);
            await _reservationRepository.DeleteReservationAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer une reservation grace à son id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 
        public async Task<Datas.Entities.Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetReservationByIdAsync(id).ConfigureAwait(false);
        }
    }
}
