using System;
using System.Linq;
using AglCodingTest.Core.Domain;
using AglCodingTest.Core.Exceptions;
using Person = AglCodingTest.Core.Queries.GetJson.Dtos.Person;
using Pet = AglCodingTest.Core.Queries.GetJson.Dtos.Pet;

namespace AglCodingTest.Core.Mappers.MapDomain
{
    public class JsonDtoToDomainMapper : IJsonDtoToDomainMapper
    {
        public Domain.Person[] Map(Person[] param)
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

        public static Domain.Person MapToDomainModel(Person person)
        {
            var parsed = Enum.TryParse<Gender>(person.Gender, out var genderType);

            return new Domain.Person()
            {
                Age = person.Age,
                Gender = parsed ? genderType : Gender.Unspecified,
                Name = person.Name,
                Pets = person.Pets?.Select(MapToDomainModel).ToList()
            };
        }

        public static Domain.Pet MapToDomainModel(Pet pet)
        {
            var parsed = Enum.TryParse<PetKind>(pet.Type, out var petType);

            return new Domain.Pet()
            {
                Name = pet.Name,
                Type = parsed ? petType : PetKind.Unknown
            };
        }
    }
}