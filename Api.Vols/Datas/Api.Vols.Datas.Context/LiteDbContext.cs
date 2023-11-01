using Api.Vols.Generals.Common;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Api.Vols.Datas.Context
{
    public class LiteDbContext : ILiteDbContext
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public LiteDatabase Database { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public LiteDbContext(IOptions<AppSettings> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}
