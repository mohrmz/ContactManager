using ContactManager.Features.Contacts.Create;
using FluentValidation;

namespace ContactManager.Features.Contacts.Delete;

public class DeleteContactRequestValidator : AbstractValidator<DeleteContactRequest>
{
    public DeleteContactRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
