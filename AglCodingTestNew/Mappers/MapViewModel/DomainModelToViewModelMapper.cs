using System.Collections.Generic;
using System.Linq;
using AglCodingTest.Core.Domain;
using AglCodingTest.Web.Models;

namespace AglCodingTest.Web.Mappers.MapViewModel
{
    public class DomainModelToViewModelMapper : IDomianModelToViewModelMapper
    {
        
        public TestViewModel[] Map(Person[] param)
        {
            return GetGenderGroup(param).ToArray();
        }

        public static IEnumerable<TestViewModel> GetGenderGroup(Person[] people)
        {
            var viewModels = people
                .Where(person => person.Pets != null)
                .GroupBy(person => person.Gender)
                .Select(genderGroup => new TestViewModel()
                {
                    Gender = genderGroup.Key,
                    Pets = genderGroup
                    .SelectMany(person => person.Pets)
                    .OrderBy(pet => pet.Name)
                    .ToArray()

                });

            return viewModels;
        }
    }
}