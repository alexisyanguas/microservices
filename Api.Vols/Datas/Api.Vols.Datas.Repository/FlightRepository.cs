
using Api.Vols.Datas.Context;
using Api.Vols.Datas.Entities;
using LiteDB;

namespace Api.Vols.Datas.Repository
{
    public class FlightRepository : IFlightRepository
    {
        /// <summary>
        /// The lite database context
        /// </summary>
        private readonly ILiteDbContext _liteDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRepository"/> class.
        /// </summary>
        /// <param name="liteDbContext">The lite database context.</param>
        public FlightRepository(ILiteDbContext liteDbContext)
        {
            _liteDbContext = liteDbContext;
        }

        /// <summary>
        /// Cette méthode permet de créer un vol
        /// </summary>
        /// <param name="flight">les informations du vol</param>
        /// <returns></returns>
        public Flight CreateFlight(Flight flight)
        {
            var flights = _liteDbContext.Database.GetCollection<Flight>("flights");
            flights.Insert(flight);
            return flight;
        }

        /// <summary>
        /// Cette méthode de supprimer un vol
        /// </summary>
        /// <param name="id">L'identifiant du vol</param>
        /// <returns></returns>
        public bool DeleteFlight(ObjectId id)
        {
            return _liteDbContext.Database.GetCollection<Flight>("flights")
                .Delete(id);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un vol par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant du vol</param>
        /// <returns></returns>
        public Flight GetFlightById(ObjectId id)
        {
            return _liteDbContext.Database.GetCollection<Flight>("flights")
                .FindById(id);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des vols
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetFlights()
        {
            var flights =  _liteDbContext.Database.GetCollection<Flight>("flights")
                .FindAll().ToList();
            foreach(var flight in flights)
            {
                flight.IdToString = flight.Id.ToString();
            }

            return flights;
        }

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un siege d'un vol
        /// </summary>
        /// <param name="numeroVol">Le numéro du vol.</param>
        /// <param name="nomSiege">Le nom du siege.</param>
        /// <returns></returns>
        public Seat? GetSeatStatus(string numeroVol, string nomSiege)
        {
            var flight = GetFlights().Find(v => v.FlightNumber == numeroVol);
            return flight?.Sieges.Find(s => s.Name == nomSiege);
        }

        /// <summary>
        /// Cette méthode permet de modifier le statut d'un siege
        /// </summary>
        /// <param name="numeroVol">Le numéro du vol.</param>
        /// <param name="nomSiege">Le nom du siege.</param>
        /// <param name="status">Le status souhaité.</param>
        /// <returns></returns>
        public Seat? UpdateSeat(string numeroVol, Seat seat)
        {
            var flight = GetFlights().Find(v => v.FlightNumber == numeroVol);
            var seat = flight?.Sieges.Find(s => s.Name == nomSiege);
            seat.Status = status;
            return seat;
        }

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un vol
        /// </summary>
        /// <param name="flight">les nouvelles données du vol</param>
        /// <returns></returns>
        public Flight UpdateFlight(Flight flight)
        {
            var flights = _liteDbContext.Database.GetCollection<Flight>("flights");
            flights.Update(flight);
            return flight;
        }
    }
}
