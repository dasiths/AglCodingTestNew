﻿using System.Collections.Generic;

namespace AglCodingTestNew.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
