using System;
using System.Linq;
using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Exceptions;
using Person = AglCodingTest.Json.Queries.GetJson.Dtos.Person;
using Pet = AglCodingTest.Json.Queries.GetJson.Dtos.Pet;

namespace AglCodingTest.Json.Mappers.MapDomain
{
    public class JsonDtoToDomainMapper : IJsonDtoToDomainMapper
    {
        public Core.Domain.Person[] Map(Person[] param)
        {
            try
            {
                return param.Select(MapToDomainModel).ToArray();
            }
            catch (Exception e)
            {
                throw new MappingException(e.Message);
            }
        }

        public static Core.Domain.Person MapToDomainModel(Person person)
        {
            var parsed = Enum.TryParse<Gender>(person.Gender, out var genderType);

            return new Core.Domain.Person()
            {
                Age = person.Age,
                Gender = parsed ? genderType : Gender.Unspecified,
                Name = person.Name,
                Pets = person.Pets?.Select(MapToDomainModel).ToList()
            };
        }

        public static Core.Domain.Pet MapToDomainModel(Pet pet)
        {
            var parsed = Enum.TryParse<PetKind>(pet.Type, out var petType);

            return new Core.Domain.Pet()
            {
                Name = pet.Name,
                Type = parsed ? petType : PetKind.Unknown
            };
        }
    }
}