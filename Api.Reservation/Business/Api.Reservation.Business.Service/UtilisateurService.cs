
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Business.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        /// <summary>
        /// The utilisateur repository
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="reservationRepository">The reservation repository.</param>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        /// <param name="flightsApi">The flights API.</param>
        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
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
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
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
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
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



    }
}
