
namespace Api.Reservation.Datas.Repository
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Reservation>> GetReservationsAsync();

        /// <summary>
        /// Cette méthode permet de recupérer les reservations par numéro de vol
        /// </summary>
        /// <param name="numeroVol">le numéro du vol.</param>
        /// <returns></returns>
        Task<List<Entities.Reservation>> GetReservationsByNumeroVolAsync(string numeroVol);

        /// <summary>
        /// Cette méthode permet de recupérer les reservations par le nom de l'utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">The nom utilisateur.</param>
        /// <returns></returns>
        Task<List<Entities.Reservation>> GetReservationsByUtilisateurAsync(string nomUtilisateur);

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'une reservation par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de la reservation</param>
        /// <returns></returns>
        Task<Entities.Reservation> GetReservationByIdAsync(int id);

        /// <summary>
        /// Cette methode permet de créer une nouvelle reservation.
        /// </summary>
        /// <param name="reservation">Les informations de la nouvelle reservation</param>
        /// <returns></returns>
        Task<Entities.Reservation> CreateReservationAsync(Entities.Reservation reservation);

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'une reservation
        /// </summary>
        /// <param name="reservation">les informations modifié d'une reservation.</param>
        Task UpdateReservation(Entities.Reservation reservation);

        /// <summary>
        /// Cette méthode permet de supprimer une reservation
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteReservationAsync(int id);
    }
}
