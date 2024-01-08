using FamilyLoan.Utilities.Results;
using MediatR;

namespace FamilyLoan.Utilities.MediatRHelper
{
    public interface ICommand:IRequest<Result>
    {
    }
    public interface ICommand<T> : IRequest<Result<T>>
    {
    }
}
