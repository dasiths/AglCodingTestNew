using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AglCodingTestNew.Mappers.MapDomain;
using AglCodingTestNew.Mappers.MapJson;
using AglCodingTestNew.Queries.GetDomainModel;
using AglCodingTestNew.Queries.GetJson;
using AglCodingTestNew.Queries.GetJson.Dtos;
using Xunit;

namespace AglCodingTestNew.Test
{
    public class PyaloadTests
    {
        [Fact]
        public async Task CorrectPayloadSizeIsRetreived()
        {
            var payload = File.ReadAllText("sample.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Equal(6, result.Length);
        }

        [Fact]
        public async Task IsMappedToCorrectDomainModels()
        {

            var result = new Person[] {
                new Person()
                {
                    Age = 15,
                    Gender = "Male",
                    Name = "Guy",
                    Pets = new List<Pet>() {new Pet()
                    {
                        Name = "some_pet_name",
                        Type = "Cat"
                    } }
                },
                new Person()
                {
                    Age = 16,
                    Gender = "Female",
                    Name = "Girl",
                    Pets = new List<Pet>() {new Pet()
                    {
                        Name = "some_pet_name1",
                        Type = "Cat"
                    } }
                },
                new Person()
                {
                    Age = 15,
                    Gender = "Male",
                    Name = "Guy2",
                    Pets = null
                }
            };

            // Map result to domian model
            var getDomainModelsFromDtosQuery = new GetDomainModelsFromDtosQuery(new JsonDtoToDomainMapper());
            var persons = await getDomainModelsFromDtosQuery.QueryAsync(result);

            Assert.Equal(3, persons.Length);
            Assert.Equal(1, persons.Single(p => p.Name == "Guy").Pets.Count);
        }
    }
}
