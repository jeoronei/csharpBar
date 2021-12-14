using System;

namespace Domain
{
    public class Bar : BaseClass
    {
        public Bar(string name) {
            Name = name;
        }

        public string Name { get; set; }
    }
}
