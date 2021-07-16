using System.Collections.Generic;
using System.Linq;

namespace NetCoreXUnitTests
{
    public interface IPeople
    {
        Person Get(int id);

        void Add(
            int id,
            string name
        );
    }

    public class People : IPeople
    {
        private IList<Person> people;

        public People()
        {
            people = new List<Person>();
        }

        public Person Get(int id)
        {
            return people
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Add(
            int id,
            string name
        )
        {
            people.Add(
                new Person
                {
                    Id = id,
                    Name = name
                }
            );
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}