using Diverse;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProvider
{
    public class PersonRepository : IPersonRepository
    {
        private static readonly Fuzzer _fuzzer;
        static PersonRepository()
        {
            Fuzzer.Log = Console.WriteLine;
            _fuzzer = new Fuzzer();
            for (var i = 0; i < 25; i++)
            {
                var fuzzerPerson = _fuzzer.GeneratePerson();
                var personId = Guid.NewGuid();
                _allPeople.Add(personId,
                    new Person(personId, fuzzerPerson.FirstName, fuzzerPerson.LastName, fuzzerPerson.Age)
                    );
            }
        }
        private static readonly Dictionary<Guid, Person> _allPeople = new Dictionary<Guid, Person>();

        public Person Create(string firstName, string lastName, int age)
        {
            var personId = Guid.NewGuid();
            var newPerson = new Person(personId, firstName, lastName, age);
            _allPeople.Add(personId,
                newPerson
                );
            return newPerson;
        }

        public bool Delete(Guid personId)
        {
            return _allPeople.Remove(personId);
        }

        public Person Get(Guid personId)
        {
            return _allPeople.TryGetValue(personId, out var person) ? person : null;
        }

        public IEnumerable<Person> GetAll() => _allPeople.Values.AsEnumerable();

        public Person Update(Guid personId, string firstName, string lastName, int age)
        {
            var person = Get(personId) ?? throw new ArgumentException($"Aucune personne avec l'ID '{ personId }' n'a été trouvée.");
            var updatedPerson = person with { FirstName = firstName, LastName = lastName, Age = age };
            _allPeople[personId] = updatedPerson;
            return updatedPerson;
        }
    }
}
