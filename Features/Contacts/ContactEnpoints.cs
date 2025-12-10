

using ContactManager.Features.Contacts.Create;
using ContactManager.Features.Contacts.Delete;
using ContactManager.Features.Contacts.GetAll;
using ContactManager.Features.Contacts.GetById;
using ContactManager.Features.Contacts.Update;

namespace ContactManager.Features.Contacts;

public class ContactEnpoints : ICarterModule
{
    private const string ActionEndpointRoute = "/api/contact-manager/contact";
    private const string ActionEndpointTag = "contact-manager";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
          .MapGroup(ActionEndpointRoute)
          .WithTags(ActionEndpointTag);

        group.MapHttpPost<CreateContactRequest, CreateContactResponse>("/create", () =>
            new MapHttpConfiguration
            {
                AllowAnonymous = true,
            });

        group.MapHttpPut<UpdateContactRequest, UpdateContactResponse>("/update", () =>
            new MapHttpConfiguration
            {
                AllowAnonymous = true,
            });


        group.MapHttpGet<GetContactByIdRequest, GetContactByIdResponse>("/getbyid", () =>
            new MapHttpConfiguration
            {
                AllowAnonymous = true,
            });


        group.MapHttpGet<GetAllContactsRequest, GetAllContactsResponse>("/getall", () =>
            new MapHttpConfiguration
            {
                AllowAnonymous = true,
            });


        group.MapHttpDelete<DeleteContactRequest, DeleteContactResponse>("/delete", () =>
            new MapHttpConfiguration
            {
                AllowAnonymous = true,
            });
    }
}
