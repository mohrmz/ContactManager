namespace ContactManager.Base.Responses.Abstractions;

public interface INullablePagedQuery
{
    int? PageNumber { get; }
    int? PageSize { get; }
}
