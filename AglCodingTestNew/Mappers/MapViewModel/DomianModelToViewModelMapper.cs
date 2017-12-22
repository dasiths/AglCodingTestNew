using System;
using System.Collections.Generic;
using System.Linq;
using AglCodingTestNew.Domain;
using AglCodingTestNew.Models;

namespace AglCodingTestNew.Mappers.MapViewModel
{
    public class DomianModelToViewModelMapper : IDomianModelToViewModelMapper
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
                    Pets = genderGroup.SelectMany(person => person.Pets).ToArray()

                });

            return viewModels;
        }
    }
}