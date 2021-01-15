using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static grpc.types.Animal;

namespace grpc.client.Controllers
{
    [Route("info")]
    public class InfoController: ControllerBase
    {
        [HttpGet]
        [Route("animal")]
        public async Task<IActionResult> GetAninalInfoFromGrpc([FromQuery]string name)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new AnimalClient(channel);
            var reply = await client.GetDataAsync(
                              new types.AnimalRequest { Title = name });

            return Ok(reply);
        }
    }
}
