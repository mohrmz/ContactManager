using MediatR;

namespace ContactManager.Features.Contacts.GetById;

public class GetContactByIdRequest : IRequest<GetContactByIdResponse>
{
    public int Id { get; set; }
}
