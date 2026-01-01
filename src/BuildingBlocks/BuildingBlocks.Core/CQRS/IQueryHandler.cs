using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.CQRS;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
