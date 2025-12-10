using FluentValidation;

namespace ContactManager.Features.Contacts.GetById;

public class GetContactByIdRequestValidator : AbstractValidator<GetContactByIdRequest>
{
    public GetContactByIdRequestValidator()
    {

        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}

