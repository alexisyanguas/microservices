
using Api.Reservation.Datas.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UtilisateurRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _context.Utilisateurs
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _context.Utilisateurs
                .FirstOrDefaultAsync(r => r.Id == id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet de créer un utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur)
        {
            await _context.Utilisateurs.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        /// <summary>
        /// Cette methode permet de créer un utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations de l'utilisateur</param>
        /// <returns></returns>
        public async Task UpdateUtilisateurAsync(int id, Entities.Utilisateur utilisateur)
        {
            Entities.Utilisateur u = _context.Utilisateurs.Find(id);
            u.Nom = utilisateur.Nom;
            u.Prenom = utilisateur.Prenom;
            u.Email = utilisateur.Email;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>

        public async Task DeleteUtilisateurAsync(int id)
        {
            Entities.Utilisateur u = _context.Utilisateurs.Find(id);
            _context.Utilisateurs.Remove(u);
            await _context.SaveChangesAsync();
        }
    }
}
