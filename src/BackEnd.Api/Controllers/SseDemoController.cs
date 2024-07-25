using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SseController: ControllerBase
    {
        [HttpGet("stream")]
        public async Task Stream()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            for (int i = 0; i < 10; i++)
            {
                await Response.WriteAsync($"data: Message {i}\n\n");
                await Response.Body.FlushAsync();
                await Task.Delay(10000);
            }
        }
    }
}