using FluentValidation;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Moeins
{
    public class AddMoeinValidator : AbstractValidator<AddMoeinViewModel>
    {
        public AddMoeinValidator()
        {
            RuleFor(model => model.Description).NotNull().WithMessage("توضیحات نباید خالی باشد!");
            RuleFor(model => model.Date).NotNull().WithMessage("تاریخ نباید خالی باشد!");
        }
    }
}
