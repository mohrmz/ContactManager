using ContactManager.Data.Abstractions;
using ContactManager.Domains.Exceptions;
using MediatR;

namespace ContactManager.Features.Contacts.Delete;

public class DeleteContactRequestHandler(
    IContactRepository repository
) : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
{

    public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken ct)
    {
        var exists = await repository.Exists(request.Id, ct);
        if (!exists)
            throw new NotFoundException();

        await repository.Delete(request.Id, ct);

        return new DeleteContactResponse { Id = request.Id };
    }
}