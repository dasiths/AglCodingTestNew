using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AglCodingTest.Core.Domain;
using AglCodingTest.Web.Models;
using AglCodingTest.Web.ResultFilters.TestFilter;
using Xunit;

namespace AglCodingTest.Core.Tests
{
    public class FilterTests
    {
        [Fact]
        public async Task CatFilterWorks()
        {
            var persons = new List<TestViewModel>()
            {
                new TestViewModel()
                {
                    Gender = Gender.Male,
                    Pets = new Pet[]
                    {
                        new Pet()
                        {
                            Name = "Dog1",
                            Type = PetKind.Dog
                        },
                        new Pet()
                        {
                            Name = "Cat1",
                            Type = PetKind.Cat
                        },
                        new Pet()
                        {
                            Name = "Fish1",
                            Type = PetKind.Fish
                        },
                    }
                },
                new TestViewModel()
                {
                    Gender = Gender.Male,
                    Pets = new Pet[]
                    {
                        new Pet()
                        {
                            Name = "Dog2",
                            Type = PetKind.Dog
                        },
                        new Pet()
                        {
                            Name = "Fish2",
                            Type = PetKind.Fish
                        },
                    }
                },
                new TestViewModel()
                {
                    Gender = Gender.Female,
                    Pets = new Pet[]
                    {
                        new Pet()
                        {
                            Name = "Dog3",
                            Type = PetKind.Dog
                        },
                        new Pet()
                        {
                            Name = "Cat3",
                            Type = PetKind.Cat
                        },
                        new Pet()
                        {
                            Name = "Fish3",
                            Type = PetKind.Fish
                        },
                    }
                }
            };

            var filter = new CatsFilter();

            var result = filter.GetFilteredResult(persons);

            Assert.Equal(2, result.Count(p => p.Pets.Length > 0));
        }
    }
}
