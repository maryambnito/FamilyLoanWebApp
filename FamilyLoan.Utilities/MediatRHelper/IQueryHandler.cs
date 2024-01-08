using MediatR;

namespace FamilyLoan.Utilities.MediatRHelper
{
    public interface IQueryHandler<TInput, TOutput> : IRequestHandler<TInput, TOutput>
        where TInput : IQuery<TOutput>
    {
    }
}
