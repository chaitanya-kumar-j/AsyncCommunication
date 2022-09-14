namespace AsyncCommunication.Publisher.API.DTOs;
public class PubToSubMessage
{
    public string MessageTitle { get; set; }
    public string MessageBody { get; set; }

    public DateTime DateUpdated { get; set; }
}
