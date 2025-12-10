using ContactManager.Middlewares;

namespace ContactManager.Domains.Exceptions;

public class NotFoundException : KnownException
{
    public NotFoundException()
        : base("entity not found")
    {
    }
    public override int StatusCode => 204;

    public override bool IsMessageSensitive => false;
}
