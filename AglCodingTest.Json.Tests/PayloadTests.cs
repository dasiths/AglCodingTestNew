using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AglCodingTest.Core.Exceptions;
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

            Assert.Equal(5, result.Length);
        }

        [Fact]
        public async Task EmptyPayloadIsHandled()
        {
            var payload = File.ReadAllText("sample_empty.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Empty(result);
        }

        [Fact]
        public async Task UnknownGenderIsHandled()
        {
            var payload = File.ReadAllText("sample_unknown_gender.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Equal(5, result.Length);
        }

        [Fact]
        public async Task UnknownPetTypeIsHandled()
        {
            var payload = File.ReadAllText("sample_unknown_pet_type.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Equal(5, result.Length);
        }

        [Fact]
        public async Task NullPetsAreHandled()
        {
            var payload = File.ReadAllText("sample_null_pets.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            var result = await outputQuery.QueryAsync(payload);

            Assert.Equal(6, result.Count(p => p.Pets != null));
        }

        [Fact]
        public async Task InvalidAgeThrowsException()
        {
            var payload = File.ReadAllText("sample_invalid_age.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            await Assert.ThrowsAsync<InvalidModelStateException>(() => outputQuery.QueryAsync(payload));
        }

        [Fact]
        public async Task InvalidNameThrowsException()
        {
            var payload = File.ReadAllText("sample_invalid_person_name.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            await Assert.ThrowsAsync<InvalidModelStateException>(() => outputQuery.QueryAsync(payload));
        }

        [Fact]
        public async Task InvalidPetThrowsException()
        {
            var payload = File.ReadAllText("sample_invalid_pet.json");
            var outputQuery = new GetAglJsonOutputQuery(new AglJsonModelMapper());

            await Assert.ThrowsAsync<InvalidModelStateException>(() => outputQuery.QueryAsync(payload));
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
