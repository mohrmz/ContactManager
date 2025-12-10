namespace ContactManager.Base.Responses.Abstractions;

public interface IPagedQuery
{
    int PageNumber { get; }
    int PageSize { get; }
}
