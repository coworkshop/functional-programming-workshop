namespace Challenges.Tests;

public class ProgramFlowHandlingTests
{
    [Theory]
    [InlineData("Invalid JSON")]
    [InlineData("{InvalidJson}")]
    [InlineData("{ \"FirstName\": \"John\", \"LastName: \"Doe\", \"Age: \"twenty\" ")]
    public void AnyInvalidJson_DoManyOperations_InvalidJSON(string invalidJson)
    {
        var response = ProgramFlowHandling.CreatePersonDescription(invalidJson);
        Assert.Equal("Invalid JSON format", response);
    }
    
    [Theory]
    [InlineData("{\"FirstName\": \"John\", \"LastName\": \"Doe\", \"Age\": 20}", "Hello John Doe, you are 20 years old.")]
    [InlineData("{\"FirstName\": \"Jane\", \"LastName\": \"Smith\", \"Age\": 25}", "Hello Jane Smith, you are 25 years old.")]
    public void ValidJson_CreatePersonDescription_ReturnsCorrectDescription(string validJson, string expectedDescription)
    {
        var response = ProgramFlowHandling.CreatePersonDescription(validJson);
        Assert.Equal(expectedDescription, response);
    }

    [Theory]
    [InlineData("{\"FirstName\": \"\", \"LastName\": \"Doe\", \"Age\": 20}", "Firstname is not present")]
    [InlineData("{\"FirstName\": \"John\", \"LastName\": \"\", \"Age\": 20}", "Lastname is not present")]
    [InlineData("{\"FirstName\": \"John\", \"LastName\": \"Doe\", \"Age\": 17}", "Age must be greater than 18")]
    public void InvalidJson_CreatePersonDescription_ThrowsDomainException(string invalidJson, string expectedMessage)
    {
        var response = ProgramFlowHandling.CreatePersonDescription(invalidJson);
        Assert.Equal(expectedMessage, response);
    }
    
    [Fact]
    public void NullJson_CreatePersonDescription_ThrowsArgumentNullException()
    {
        var response = ProgramFlowHandling.CreatePersonDescription(null!);
        Assert.Equal("Value cannot be null. (Parameter 'json')", response);
    }
}