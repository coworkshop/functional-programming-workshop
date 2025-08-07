namespace Challenges.Tests;

public class Bye2ByePartyMapperTests
{
    [Fact]
    public void OrdinaryActive_RegularParty()
    {
        var bye2ByeParty = Bye2ByePartyMapper.MapFrom("ordinary", "active");
        
        Assert.True(bye2ByeParty is RegularParty);
    }
    
    [Fact]
    public void OrdinaryNonActive_InactiveParty()
    {
        var bye2ByeParty = Bye2ByePartyMapper.MapFrom("ordinary", "non active");
        
        Assert.True(bye2ByeParty is InactiveParty);
    }
    
    [Fact]
    public void Student_StudentParty()
    {
        var bye2ByeParty = Bye2ByePartyMapper.MapFrom("student", string.Empty);
        
        Assert.True(bye2ByeParty is StudentParty);
    }
    
    [Fact]
    public void Employee_InternallyEmployedParty()
    {
        var bye2ByeParty = Bye2ByePartyMapper.MapFrom("employee", string.Empty);
        
        Assert.True(bye2ByeParty is InternallyEmployedParty);
    }
}