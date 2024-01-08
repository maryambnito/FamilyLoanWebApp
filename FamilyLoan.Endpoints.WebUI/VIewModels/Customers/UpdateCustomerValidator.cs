using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{

    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerViewModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(model => model.FirstName)
                .NotNull().WithMessage("وارد کردن نام الزامی است").MinimumLength(2).MaximumLength(50);
            RuleFor(model => model.LastName).NotNull().WithMessage("وارد کردن نام خانوادگی الزامی است")
                .NotEqual(c => c.FirstName).WithMessage("نمیتواند مشابه نام  باشد").MinimumLength(2).MaximumLength(50);
            RuleFor(model => model.Description).MaximumLength(350);
        }
    }
}
