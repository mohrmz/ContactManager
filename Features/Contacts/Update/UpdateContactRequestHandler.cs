using ContactManager.Data.Abstractions;
using ContactManager.Domains.Exceptions;
using Mapster;
using MediatR;

namespace ContactManager.Features.Contacts.Update;

public class UpdateContactRequestHandler(
    IContactRepository repository
) : IRequestHandler<UpdateContactRequest, UpdateContactResponse>
{

    public async Task<UpdateContactResponse> Handle(UpdateContactRequest request, CancellationToken ct)
    {
        var contact = await repository.GetById(request.Id, ct);
        if (contact is null)
            throw new NotFoundException();

        var update = request.Adapt(contact);
        var updated = await repository.Update(update, ct);

        return updated.Adapt<UpdateContactResponse>();
    }
}