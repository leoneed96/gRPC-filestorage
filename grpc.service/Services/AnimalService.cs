using grpc.types;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpc.service.Services
{
    public class AnimalService: Animal.AnimalBase
    {
        public override async Task<AnimalResponse> GetData(AnimalRequest request, ServerCallContext context)
        {
            switch (request.Title.ToLower())
            {
                case "dog":
                    return new AnimalResponse()
                    {
                        Sound = "waff",
                        Weight = 10
                    };
                case "cat":
                    return new AnimalResponse()
                    {
                        Sound = "mew!",
                        Weight = 5
                    };
                default:
                    return new AnimalResponse()
                    {
                        Sound = "unknown",
                        Weight = 0
                    };
            }
        }
    }
}
