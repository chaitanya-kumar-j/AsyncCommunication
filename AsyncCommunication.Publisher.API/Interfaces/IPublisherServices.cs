using AsyncCommunication.Publisher.API.Entities;

namespace AsyncCommunication.Publisher.API.Interfaces;
public interface IPublisherServices
{
    Task<Message> CreateMessageAsync(Message newMessage);
    Task<IEnumerable<Message>> GetMessagesAsync();
    Task<Message> GetMessageByIdAsync();
}
