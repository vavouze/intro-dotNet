using System;

namespace DataProvider
{
    public record Person (Guid PersonId, string FirstName, string LastName, int Age);
}
