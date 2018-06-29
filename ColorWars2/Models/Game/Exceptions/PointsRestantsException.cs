using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorWars2.Models.Game.Exceptions
{
    /// <summary>
    /// Exception lancée lorsqu'il manque des points répartis dans les stats lors de la
    /// création et lors du lvl up.
    /// </summary>
    public class PointsRestantsException : Exception
    {
        public PointsRestantsException() { }
        public PointsRestantsException(string message) : base(message) { }
        public PointsRestantsException(string message, Exception inner) : base(message, inner) { }
    }
}
