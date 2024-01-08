using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class AddInstallmentValidator : AbstractValidator<AddInstallmentViewModel>
    {
        public AddInstallmentValidator()
        {
        RuleFor(model => model.InstallmentDate).NotNull().WithMessage("تاریخ را انتخاب کنید");
        RuleFor(model => model.InstallmentAmount).NotNull().WithMessage("مبلغ را وارد کنید");

        }
    }
}
