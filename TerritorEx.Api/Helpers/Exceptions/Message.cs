namespace TerritorEx.Api.Helpers.Exceptions;

public abstract class Message
{
    public class MessageError
    {
        public string Error { get; set; }
    }

    public class MessageInfo
    {
        public string Info { get; set; }
    }
}