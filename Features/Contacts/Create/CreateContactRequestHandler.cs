using ContactManager.Data.Abstractions;
using ContactManager.Domains;
using Mapster;
using MediatR;

namespace ContactManager.Features.Contacts.Create;

public class CreateContactRequestHandler(
    IContactRepository contactRepository
) : IRequestHandler<CreateContactRequest, CreateContactResponse>
{
    public async Task<CreateContactResponse> Handle(CreateContactRequest request,
        CancellationToken cancellationToken)
    {
        var contact = request.Adapt<Contact>();
        await contactRepository.Create(contact, cancellationToken);

        return contact.Adapt<CreateContactResponse>();
    }
}
