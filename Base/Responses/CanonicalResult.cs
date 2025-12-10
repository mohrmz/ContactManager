using ContactManager.Base.Responses.Abstractions;
using System.Reflection;

namespace ContactManager.Base.Responses;

public class CanonicalResult<T> : ICanonicalResult<T>
{
    public bool? IsSuccess { get; set; }

    public bool? IsFailure { get; set; }

    public ErrorModel? Error { get; set; }

    public int? PageNumber { get; set; }

    public int? PageIndex
    {
        get => PageNumber;
        set => PageNumber = value;
    }

    public int? PageSize { get; set; }

    public T? Value { get; set; }

    public static CanonicalResult<T> FromValue(T? value, object? request = null)
    {
        int? pageNumber = null;
        int? pageSize = null;

        if (request is IPagedQuery pagedQuery)
        {
            pageNumber = pagedQuery.PageNumber;
            pageSize = pagedQuery.PageSize;
        }

        if (request is INullablePagedQuery pagedQuery1)
        {
            pageNumber = pagedQuery1.PageNumber;
            pageSize = pagedQuery1.PageSize;
        }

        if (pageSize is null)
        {
            var pageSizeProperty = typeof(T).GetProperty(
                "PageSize", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            if (pageSizeProperty is not null)
            {
                var val = pageSizeProperty.GetValue(value);
                if (val is int pageSizeInt)
                {
                    pageSize = pageSizeInt;
                }
                else if (val is long pageSizeLng)
                {
                    unchecked
                    {
                        pageSize = (int)pageSizeLng;
                    }
                }
            }
        }

        return new CanonicalResult<T>
        {
            IsSuccess = true,
            IsFailure = false,
            Error = null,
            Value = value,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
    }
}