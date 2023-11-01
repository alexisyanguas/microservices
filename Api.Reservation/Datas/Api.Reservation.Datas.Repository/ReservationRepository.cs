using Api.Reservation.Datas.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entities.Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Utilisateur)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les reservations par numéro de vol
        /// </summary>
        /// <param name="numeroVol">le numéro du vol.</param>
        /// <returns></returns>
        public async Task<List<Entities.Reservation>> GetReservationsByNumeroVolAsync(string numeroVol)
        {
            return await _context.Reservations
                .Where(r => r.NumeroVol == numeroVol)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les reservations par le nom de l'utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">The nom utilisateur.</param>
        /// <returns></returns>
        public async Task<List<Entities.Reservation>> GetReservationsByUtilisateurAsync(string nomUtilisateur)
        {
            return await _context.Reservations
                .Where(r => r.Utilisateur.Nom == nomUtilisateur)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'une reservation par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de la reservation</param>
        /// <returns></returns>
        public async Task<Entities.Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Utilisateur)
                .FirstOrDefaultAsync(r => r.Id == id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet de créer une nouvelle reservation.
        /// </summary>
        /// <param name="reservation">Les informations de la nouvelle reservation</param>
        /// <returns></returns>
        public async Task<Entities.Reservation> CreateReservationAsync(Entities.Reservation reservation)
        {
           await _context.Reservations.AddAsync(reservation);
           await _context.SaveChangesAsync();
            return reservation;
        }

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'une reservation
        /// </summary>
        /// <param name="reservation">les informations modifié d'une reservation.</param>
        public async Task UpdateReservation(Entities.Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cette méthode permet de supprimer une reservation
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

    }
}
