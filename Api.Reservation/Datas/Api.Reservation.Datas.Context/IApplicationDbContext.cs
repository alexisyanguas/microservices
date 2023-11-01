using Api.Reservation.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Context
{
    public interface IApplicationDbContext: IDbContext
    {
        DbSet<Utilisateur> Utilisateurs { get; set; }

        DbSet<Entities.Reservation> Reservations { get; set; }
    }
}
