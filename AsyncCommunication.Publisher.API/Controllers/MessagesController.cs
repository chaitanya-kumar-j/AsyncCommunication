using AsyncCommunication.Publisher.API.Data;
using AsyncCommunication.Publisher.API.Entities;
using AsyncCommunication.Publisher.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncCommunication.Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IPublisherServices _publisherServices;
        private readonly PublisherDbContext _publisherDbContext;
        private readonly IEventBus _eventBus;

        public MessagesController(IPublisherServices publisherServices,PublisherDbContext publisherDbContext, IEventBus eventBus)
        {
            _publisherServices = publisherServices;
            _publisherDbContext = publisherDbContext;
            _eventBus = eventBus;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            try
            {
                var data = await _publisherServices.GetMessagesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"==> could not get all messages : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Message>> GetMessageById(int messageId)
        {
            try
            {
                var data = await _publisherServices.GetMessageByIdAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"==> could not get message by Id : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Message>> CreateMessage(Message newMessage)
        {
            try
            {
                var data = await _publisherServices.CreateMessageAsync(newMessage);
                return Ok(data);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"==> could not create message : {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
