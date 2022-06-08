using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract which every <see cref="Mid"/> message that can be declined with <see cref="Communication.Mid0004"/> implements.
    /// </summary>
    public interface IDeclinableCommand
    {
        IEnumerable<Error> PossibleErrors { get; }
    }
}
