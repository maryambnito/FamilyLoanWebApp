using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Accounts
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountViewModel>
    {
        public CreateAccountValidator()
        {
            RuleFor(model => model.CustomerId).NotNull().WithMessage("مشتری را انتخاب کنید");
            RuleFor(model => model.CreateAccountDate).NotNull().WithMessage("تاریخ را انتخاب کنید");
            RuleFor(model => model.Description).MaximumLength(350);
        }
    }
}
