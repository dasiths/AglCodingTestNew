using System;
using System.Linq;
using AglCodingTestNew.Domain;
using AglCodingTestNew.Exceptions;
using Person = AglCodingTestNew.Queries.GetJson.Dtos.Person;
using Pet = AglCodingTestNew.Queries.GetJson.Dtos.Pet;

namespace AglCodingTestNew.Mappers.MapDomain
{
    class JsonDtoToDomainMapper : IJsonDtoToDomainMapper
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