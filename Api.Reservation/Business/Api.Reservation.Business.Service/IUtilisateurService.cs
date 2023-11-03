using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Service
{
    public interface IUtilisateurService
    {
          /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync();


     /// <summary>
        /// Cette méthode permet de recupérer un utilisateur grace à son id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="utilisateur">The user.</param>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de mettre à jour un utilisateur
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="utilisateur">The user.</param>
        /// <returns></returns>
        Task UpdateUtilisateurAsync(int id, Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// Quand on supprime un utilisateur, on supprime aussi toutes ses reservations (et on libère les sieges)
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteUtilisateurAsync(int id);
        
    }

        
}
