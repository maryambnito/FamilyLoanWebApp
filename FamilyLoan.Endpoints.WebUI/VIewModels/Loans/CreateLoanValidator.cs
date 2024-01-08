using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Loans
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanVIewModel>
    {
        public CreateLoanValidator()
        {RuleFor(model=>model.LoanDateStart).NotEmpty().WithMessage("وارد کردن تاریخ الزامیست");
            RuleFor(model => model.Description).MaximumLength(350);
            RuleFor(model => model.LoanAmount).NotNull().WithMessage("وارد کردن مبلغ الزامیست");
            RuleFor(model => model.CustomerId).NotNull().WithMessage("وارد کردن مشتری الزامیست");
        }
    }
}
