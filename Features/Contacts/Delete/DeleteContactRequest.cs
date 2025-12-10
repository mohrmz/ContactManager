using MediatR;

namespace ContactManager.Features.Contacts.Delete;

public class DeleteContactRequest: IRequest<DeleteContactResponse>
{
    public int Id { get; set; } 
}
