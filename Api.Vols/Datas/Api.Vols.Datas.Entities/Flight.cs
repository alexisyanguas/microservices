using LiteDB;

namespace Api.Vols.Datas.Entities
{
    public class Flight
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier in string format
        /// </summary>
        /// <value>
        /// The identifier
        /// </value>
        public string IdToString { get; set; }


        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        /// <value>
        /// The flight number.
        /// </value>
        public string? FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public string? Origin { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public string? Destination { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the sieges.
        /// </summary>
        /// <value>
        /// The sieges.
        /// </value>
        public List<Seat> Sieges { get; set; } = new List<Seat>();

        /// <summary>
        /// Gets or sets the information aeroplane.
        /// </summary>
        /// <value>
        /// The information aeroplane.
        /// </value>
        public InformationAeroplane InformationAeroplane { get; set; }
    }
}
