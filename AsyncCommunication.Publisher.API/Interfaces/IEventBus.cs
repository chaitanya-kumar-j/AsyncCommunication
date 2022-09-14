using AsyncCommunication.Publisher.API.DTOs;

namespace AsyncCommunication.Publisher.API.Interfaces;
public interface IEventBus
{
    void PublishNewMessage(PubToSubMessage pubToSubMessage);
}
