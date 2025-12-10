namespace ContactManager.Base.Domain;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}
