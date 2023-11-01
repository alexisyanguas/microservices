using Api.Reservation.Business.Models;
using Api.Reservation.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        /// <summary>
        /// The reservation service
        /// </summary>
        private readonly IReservationService _reservationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationsController"/> class.
        /// </summary>
        /// <param name="reservationService">The reservation service.</param>
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // POST api/Reservations
        [HttpPost]
        [ProducesResponseType(typeof(Datas.Entities.Reservation), 200)]
        public async Task<IActionResult> CreateReservationAsync([FromBody] CreateReservationDto reservation)
        {
            try
            {
                var reservationToCreate = new Datas.Entities.Reservation()
                {
                    UtilisateurId = reservation.UtilisateurId,
                    NumeroVol = reservation.NumeroVol,
                    NumeroSiege = reservation.NumeroSiege,
                    Statut = Datas.Entities.StatutReservation.Active,
                    Changement = DateTime.Now
                };

                return Ok(await _reservationService.CreateReservationAsync(reservationToCreate));
            }
            catch (Exception e) { return Problem(e.Message, e.StackTrace); }
        }

        // GET: api/Reservations
        [HttpGet]
        [ProducesResponseType(typeof(List<Datas.Entities.Reservation>), 200)]
        public async Task<IActionResult> GetReservationsAsync()
        {
            return Ok(await _reservationService.GetReservationsAsync());
        }

    }
}
