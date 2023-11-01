using Api.Reservation.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the utilisateurs.
        /// </summary>
        /// <value>
        /// The utilisateurs.
        /// </value>
        public virtual DbSet<Entities.Utilisateur> Utilisateurs { get; set; }

        /// <summary>
        /// Gets or sets the reservations.
        /// </summary>
        /// <value>
        /// The reservations.
        /// </value>
        public virtual DbSet<Entities.Reservation> Reservations { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insertion de données par défaut

            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur
                {
                    Id = 1,
                    Nom = "Doe",
                    Prenom = "John",
                    Email = "john.doe@example.com",
                    DateNaissance = new DateTime(1985, 5, 20)
                }
            // Ajoutez d'autres utilisateurs ici si nécessaire
            );

            // Insertion de réservation par défaut
            modelBuilder.Entity<Entities.Reservation>().HasData(
                new Entities.Reservation
                {
                    Id = 1,
                    UtilisateurId = 1,
                    NumeroVol = "AV123",
                    NumeroSiege = "A1",
                    Statut = StatutReservation.Active,
                    Changement = DateTime.Now,
                }
            // Ajoutez d'autres réservations ici si nécessaire
            );
        }
    }
}
