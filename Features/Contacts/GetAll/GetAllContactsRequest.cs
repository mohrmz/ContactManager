using ContactManager.Base.Responses.Abstractions;
using MediatR;

namespace ContactManager.Features.Contacts.GetAll;

public class GetAllContactsRequest : IRequest<GetAllContactsResponse>, IPagedQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
