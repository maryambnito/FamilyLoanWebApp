using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerViewModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(model => model.FirstName)
                .NotNull().WithMessage("وارد کردن نام الزامی است").MinimumLength(2).MaximumLength(50)   ;
            RuleFor(model => model.LastName).NotNull().WithMessage("وارد کردن نام خانوادگی الزامی است")
                .NotEqual(c => c.FirstName).WithMessage("نام و نام خانوادگی نمیتواند مشابه نام  باشد").MinimumLength(2).MaximumLength(50);
            RuleFor(model => model.Description).MaximumLength(350);
            RuleFor(model => model.Password).NotNull().WithMessage("وارد کردن کلمه عبور الزامی است");
            RuleFor(model => model.Passwordconfirm).NotNull().WithMessage("وارد کردن کلمه عبور الزامی است").Equal(c => c.Password)
                .WithMessage("کلمه عبور یکسان نیست ") ;
              
        }
    }
}
