namespace ContactManager.Base.Responses.Abstractions;

public interface ICanonicalResult
{
    public bool? IsSuccess { get; }

    public bool? IsFailure { get; }

    public ErrorModel? Error { get; }

    public int? PageIndex { get; }

    public int? PageSize { get; }
}

public interface ICanonicalResult<out T> : ICanonicalResult
{
    public T? Value { get; }
}
