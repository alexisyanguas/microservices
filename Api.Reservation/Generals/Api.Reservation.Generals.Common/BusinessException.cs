using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Generals.Common
{
    /// <summary>
    /// Represent business Exception
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class BusinessException: ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        public BusinessException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public BusinessException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BusinessException(string message, Exception exception) : base(message, exception) { }

    }
}
