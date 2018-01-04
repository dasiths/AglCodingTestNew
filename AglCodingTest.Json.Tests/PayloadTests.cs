using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AglCodingTest.Json.Mappers.MapDomain;
using AglCodingTest.Json.Mappers.MapJson;
using AglCodingTest.Json.Queries.GetDomainModel;
using AglCodingTest.Json.Queries.GetJson;
using AglCodingTest.Json.Queries.GetJson.Dtos;
using Xunit;

namespace AglCodingTest.Json.Tests
{
    public class PayloadTests
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
