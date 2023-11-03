
namespace Api.Reservation.Datas.Repository
{
    public interface IUtilisateurRepository
    {
        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Cette methode permet de créer un utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations de l'utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur);

    
        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un utilisateur
        /// </summary>
        /// <param name = "utilisateur" > les informations modifié d'un utilisateur.</param>
        Task UpdateUtilisateurAsync(int id, Entities.Utilisateur utilisateur);

        // / <summary>
        // / Cette méthode permet de supprimer un utilisateur
        // / </summary>
        // / <param name="id">The identifier.</param>
        Task DeleteUtilisateurAsync(int id);
    }
}
