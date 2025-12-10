namespace ContactManager.Features.Contacts.GetAll;

public record GetAllContactsResponse(
    IEnumerable<GetAllContactsData> Data
);