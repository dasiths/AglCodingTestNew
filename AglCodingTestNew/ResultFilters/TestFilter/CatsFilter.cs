using System.Collections.Generic;
using System.Linq;
using AglCodingTest.Core.Domain;
using AglCodingTest.Web.Models;

namespace AglCodingTest.Web.ResultFilters.TestFilter
{
    public class CatsFilter : ICatsFilter
    {
        public IEnumerable<TestViewModel> GetFilteredResult(IEnumerable<TestViewModel> input)
        {
            return input.Select(m => new TestViewModel()
            {
                Gender = m.Gender,
                Pets = m.Pets.Where(pet => pet.Type == PetKind.Cat).ToArray()
            });
        }
    }
}