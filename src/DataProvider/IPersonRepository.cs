using System;
using System.Collections.Generic;

namespace DataProvider
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(Guid personId);
        Person Create(string firstName, string lastName, int age);
        Person Update(Guid personId, string firstName, string lastName, int age);
        bool Delete(Guid personId);
    }
}
