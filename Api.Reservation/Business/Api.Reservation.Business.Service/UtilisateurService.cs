
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Api.Reservation.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Business.Service
{
    public class UtilisateurService : IUtilisateurService
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
        /// Initializes a new instance of the <see cref="UtilisateurService"/> class.
        /// </summary>
        /// <param name="reservationRepository">The reservation repository.</param>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        /// <param name="flightsApi">The flights API.</param>
        public UtilisateurService(IUtilisateurRepository utilisateurRepository, IReservationRepository reservationRepository, IFlightsApi flightsApi)
        {
            _reservationRepository = reservationRepository;
            _utilisateurRepository = utilisateurRepository;
            _flightsApi = flightsApi;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync()
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur grace à son id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _utilisateurRepository.GetUtilisateurByIdAsync(id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="utilisateur">The user.</param>
        /// <returns></returns>
        public async Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur)
        {
            List<Datas.Entities.Utilisateur> utilisateurs = await GetUtilisateursAsync();
            foreach (Datas.Entities.Utilisateur user in utilisateurs)
            {
                if (user.Email == utilisateur.Email)
                {
                    throw new BusinessException("Echec de création d'un utilisateur : L'utilisateur existe déjà.");
                }
            }

            return await _utilisateurRepository.CreateUtilisateurAsync(utilisateur).ConfigureAwait(false);

        }

        /// <summary>
        /// Cette méthode permet de mettre à jour un utilisateur
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="utilisateur">The user.</param>
        /// <returns></returns>
        public async Task UpdateUtilisateurAsync(int id, Datas.Entities.Utilisateur utilisateur)
        {
            List<Datas.Entities.Utilisateur> utilisateurs = await GetUtilisateursAsync();
            Datas.Entities.Utilisateur userSelected = await GetUtilisateurByIdAsync(id);
            foreach (Datas.Entities.Utilisateur user in utilisateurs)
            {
                // Il faut vérifier si le nouvel email est déjà pris, cependant il faut pas envoyer d'erreur si l'email est le même que l'utilisateur que l'on veut
                if (user.Email == utilisateur.Email && user != userSelected)
                {
                    throw new BusinessException("Echec de création d'un utilisateur : L'utilisateur existe déjà.");
                }
            }
            await _utilisateurRepository.UpdateUtilisateurAsync(id, utilisateur).ConfigureAwait(false);

        }


        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// Quand on supprime un utilisateur, on supprime aussi toutes ses reservations (et on libère les sieges)
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 
        public async Task DeleteUtilisateurAsync(int id)
        {                
            Datas.Entities.Utilisateur utilisateur = await GetUtilisateurByIdAsync(id);

            List<Datas.Entities.Reservation> reservations = await _reservationRepository.GetReservationsByUtilisateurAsync(utilisateur.Nom).ConfigureAwait(false);
            if (reservations == null)
            {
                throw new BusinessException("Echec de suppression d'une reservation : La reservation n'existe pas.");
            }

            Seat seat = new Seat
            {
                Status = "Disponible"
            };

            foreach (Datas.Entities.Reservation reservation in reservations)
            {
                await _flightsApi.UpdateSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege, seat);
            }

            await _utilisateurRepository.DeleteUtilisateurAsync(id).ConfigureAwait(false);
        }


    }
}
