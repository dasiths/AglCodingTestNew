using System.Collections.Generic;
using System.Linq;
using AglCodingTest.Core.Exceptions;
using AglCodingTest.Json.Queries.GetJson.Dtos;
using Newtonsoft.Json;

namespace AglCodingTest.Json.Mappers.MapJson
{
    public  class AglJsonModelMapper : IAglJsonModelMapper
    {
        public Person[] Map(string param)
        {
            var result =  JsonConvert.DeserializeObject<Person[]>(param);

            // Handle empty payload
            if (result == null)
            {
                return new Person[] {};
            }

            // Handle null as empty list
            foreach (var person in result)
            {
                if (person.Pets == null)
                {
                    person.Pets = new List<Pet>();
                }
            }

            if (result.Any(p => p.IsValid() == false))
            {
                throw new InvalidModelStateException("Invalid data was received and can't be mapped");
            }
            
            return result;
        }
    }
}