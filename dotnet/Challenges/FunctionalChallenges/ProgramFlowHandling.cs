using System.Text.Json;

namespace Challenges;

/// <summary>
/// Suggestion: Use functional programming principles to handle program flow.
/// ErrorOr? https://github.com/amantinband/error-or
/// OneOf? https://github.com/mcintyre321/OneOf
/// Language-ext? https://github.com/louthy/language-ext
/// </summary>
public static class ProgramFlowHandling
{
    public static string CreatePersonDescription(string jsonInput)
    {
        try
        {
            var person = JsonSerializer.Deserialize<Person>(jsonInput);
            var personDescription = GetPersonDescription(person);
            
            return personDescription;
        }
        catch (JsonException)
        {
            return "Invalid JSON format";
        }
        catch (DomainException ex)
        {
            return ex.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private static string GetPersonDescription(Person? person)
    {
        ArgumentNullException.ThrowIfNull(person);
        return $"Hello {person.FirstName} {person.LastName}, you are {person.Age} years old.";
    }

    private record Person(string FirstName, string LastName, int Age)
    {
        public string FirstName { get; init; } = string.IsNullOrEmpty(FirstName) ? throw new DomainException("Firstname is not present") : FirstName;
        public string LastName { get; init; } = string.IsNullOrEmpty(LastName) ? throw new DomainException("Lastname is not present") : LastName;
        public int Age { get; init; } = Age > 18 ? Age : throw new DomainException("Age must be greater than 18");
    }
}

public class DomainException(string message) : Exception(message);
