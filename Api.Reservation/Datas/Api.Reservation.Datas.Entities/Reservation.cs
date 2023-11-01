using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Datas.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public string NumeroVol { get; set; }
        public string NumeroSiege { get; set; }
        public StatutReservation Statut { get; set; }
        public DateTime Changement { get; set; }
    }
}
