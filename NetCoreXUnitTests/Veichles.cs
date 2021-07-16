using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreXUnitTests
{
    public interface IVeichles
    {
        VeichlePerson GetFromPerson(
            int personId
        );
    }

    public class Veichles : IVeichles
    {
        private readonly IPeople _people;
        private readonly IList<Veichle> _veichles;

        public Veichles(IPeople people)
        {
            _people = people;
            _veichles = new List<Veichle>();
        }

        public VeichlePerson GetFromPerson(
            int personId
        )
        {
            var person = _people.Get(personId);
            if (person == null)
                throw new Exception("Pessoa não encontrada");

            var veichles = _veichles
                .Where(x => x.PersonId == personId)
                .ToList();

            return new VeichlePerson
            {
                Person = person,
                Veichles = veichles
            };
        }
    }

    public class VeichlePerson
    {
        public Person Person { get; set; }
        public List<Veichle> Veichles { get; set; }
    }

    public class Veichle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int PersonId { get; set; }
    }
}