using MediatR;

namespace ContactManager.Features.Contacts.Update;

public class UpdateContactResponse 
{
    public int Id { get; set; }
    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public object? TaxNumber { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public object? Website { get; set; }
    public string? CurrencyCode { get; set; }
    public string? Reference { get; set; }
    public string? CreatedFrom { get; set; }
    public int? CreatedBy { get; set; }
    public string? FileNumber { get; set; }
    public string? Front { get; set; }
    public string? Back { get; set; }
}