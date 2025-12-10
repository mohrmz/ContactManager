using ContactManager.Data.Abstractions;
using Mapster;
using MediatR;

namespace ContactManager.Features.Contacts.GetAll;

public class GetAllContactsRequestHandler(
    IContactRepository repository
) : IRequestHandler<GetAllContactsRequest, GetAllContactsResponse>
{

    public async Task<GetAllContactsResponse> Handle(GetAllContactsRequest request, CancellationToken ct)
    {
        var data = await repository.GetAll(request.PageNumber, request.PageSize, ct);
        if (data is null || data.Any() == false)
            return new GetAllContactsResponse(new List<GetAllContactsData>());

        var dtos = data.Adapt<List<GetAllContactsData>>();

        return new GetAllContactsResponse(dtos);
    }
}