using MediatR;

namespace FamilyLoan.Utilities.MediatRHelper
{
    public interface IQuery<T>:IRequest<T>
    {
    }
}
