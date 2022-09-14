namespace AsyncCommunication.Publisher.API.Entities;
public class Message
{
    public int MessageId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DateCreated { get; set; }
        
    public DateTime DateUpdated { get; set; }
}
