using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class AddPaymentValidator : AbstractValidator<AddPaymentViewModel>
    {
        public AddPaymentValidator()
        {
            RuleFor(model => model.PaymentDate).NotNull().WithMessage("تاریخ را انتخاب کنید");
            RuleFor(model => model.PaymentAmount).NotNull().WithMessage("مبلغ را وارد کنید");

        }
    }
}