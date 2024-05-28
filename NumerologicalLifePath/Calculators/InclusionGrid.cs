using NumerologicalLifePath.Sdk.Abstractions;
using NumerologicalLifePath.Sdk.Commands.InclusionGrid;

namespace NumerologicalLifePath.Sdk.Calculators;

public sealed class InclusionGrid : ShortsArrayCalculator
{
    public InclusionGrid() :
        base(new InclusionGridCommand())
    { }

    public short[] Calculate(Client clt)
    {
        SetClient(clt);
        return Results;
    }
}
