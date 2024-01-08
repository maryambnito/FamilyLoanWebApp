using FamilyLoan.Utilities.Results;
using MediatR;

namespace FamilyLoan.Utilities.MediatRHelper
{
    public interface ICommandHandler<TInput,TOutput>:IRequestHandler<TInput,Result<TOutput>>
    where  TInput:ICommand<TOutput>
    {
    }
    public interface ICommandHandler<TInput> : IRequestHandler<TInput, Result>
      where TInput : ICommand
    {
    }
}
