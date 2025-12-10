using ContactManager.Data.Abstractions;
using ContactManager.Domains.Exceptions;
using Mapster;
using MediatR;

namespace ContactManager.Features.Contacts.GetById;

public class GetContactByIdRequestHandler(
    IContactRepository repository
) : IRequestHandler<GetContactByIdRequest, GetContactByIdResponse>
{

    public async Task<GetContactByIdResponse?> Handle(GetContactByIdRequest request, CancellationToken ct)
    {
        var contact = await repository.GetById(request.Id, ct);
        if (contact is null)
            throw new NotFoundException();

        return contact.Adapt<GetContactByIdResponse>();
    }
}