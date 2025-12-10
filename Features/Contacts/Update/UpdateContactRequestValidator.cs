using FluentValidation;

namespace ContactManager.Features.Contacts.Update;

public class UpdateContactRequestValidator : AbstractValidator<UpdateContactRequest>
{
    public UpdateContactRequestValidator()
    {

        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");

        RuleFor(x => x.Email)
            .MaximumLength(150).WithMessage("Email cannot exceed 150 characters.")
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Phone)
            .MaximumLength(50).WithMessage("Phone cannot exceed 50 characters.");

        RuleFor(x => x.Address)
            .MaximumLength(300).WithMessage("Address cannot exceed 300 characters.");

        RuleFor(x => x.City)
            .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

        RuleFor(x => x.State)
            .MaximumLength(100).WithMessage("State cannot exceed 100 characters.");

        RuleFor(x => x.Country)
            .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");

        RuleFor(x => x.ZipCode)
            .MaximumLength(20).WithMessage("ZipCode cannot exceed 20 characters.");

        RuleFor(x => x.CurrencyCode)
            .MaximumLength(10).WithMessage("CurrencyCode cannot exceed 10 characters.");

        RuleFor(x => x.Reference)
            .MaximumLength(100).WithMessage("Reference cannot exceed 100 characters.");

        RuleFor(x => x.FileNumber)
            .MaximumLength(50).WithMessage("FileNumber cannot exceed 50 characters.");

        RuleFor(x => x.CreatedFrom)
            .MaximumLength(50).WithMessage("CreatedFrom cannot exceed 50 characters.");

        RuleFor(x => x.Front)
            .MaximumLength(200).WithMessage("Front cannot exceed 200 characters.");
        RuleFor(x => x.Back)
            .MaximumLength(200).WithMessage("Back cannot exceed 200 characters.");

        RuleFor(x => x.Type)
            .MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");
    }
}

