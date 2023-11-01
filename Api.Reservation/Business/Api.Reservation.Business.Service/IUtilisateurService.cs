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
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

          /// <summary>
        /// Cette methode permet de créer un utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations de l'utilisateur</param>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur);
    }

        
}
