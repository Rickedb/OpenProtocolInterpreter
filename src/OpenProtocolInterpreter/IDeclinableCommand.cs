using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    public interface IDeclinableCommand
    {
        IEnumerable<Error> PossibleErrors { get; }
    }
}
