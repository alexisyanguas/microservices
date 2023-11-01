using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Models
{
    public class CreateReservationDto
    {
        public int UtilisateurId { get; set; }
        public string NumeroVol { get; set; }
        public string NumeroSiege { get; set; }
    }
}
