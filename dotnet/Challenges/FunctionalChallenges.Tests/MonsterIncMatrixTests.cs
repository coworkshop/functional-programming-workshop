namespace Challenges.Tests;

using static MonsterExperience;
using static ScaryLevel;

public class MonsterIncMatrixTests
{
    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void ExperienceAndScaryLevel_GetQualifiedRoles_AllQualifiedRolesReturned(
        MonsterExperience monsterExperience, ScaryLevel scaryLevel, HashSet<IMonsterRole> expectedQualifiedRoles)
    {
        var actualQualifiedRoles = MonsterIncMatrix.GetQualifiedRoles(monsterExperience, scaryLevel);

        Assert.Equal([..actualQualifiedRoles], expectedQualifiedRoles);
    }
    
    public static IEnumerable<object[]> GetTestCases()
    {
        yield return [None, Low, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder()
        }];
        yield return [None, Medium, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new ScarerTrainee()
        }];
        yield return [None, High, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new ScarerTrainee()
        }];
        
        yield return [Intermediate, Low, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new ScareAssistant(), 
            new ChildDetectionAgent()
        }];
        yield return [Intermediate, Medium, new HashSet<IMonsterRole>
        {
            new Janitor(), 
            new Receptionist(),
            new DoorShredder(),
            new ScareAssistant(),
            new ChildDetectionAgent()
        }];
        yield return [Intermediate, High, new HashSet<IMonsterRole>
        {
            new Janitor(), 
            new Receptionist(),
            new DoorShredder(),
            new Scarer(),
            new ScareAssistant(),
            new ChildDetectionAgent()
        }];
        
        yield return [Experienced, Low, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new ScareAssistant(),
            new ChildDetectionAgent()
        }];
        yield return [Experienced, Medium, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new ScareAssistant(),
            new ChildDetectionAgent(),
            new ScreamCanDesigner(),
            new ScreamCanTechnician()
        }];
        yield return [Experienced, High, new HashSet<IMonsterRole>
        {
            new Janitor(),
            new Receptionist(),
            new DoorShredder(),
            new Scarer(),
            new ScareAssistant(),
            new ChildDetectionAgent(),
            new ScreamCanDesigner(),
            new ScreamCanTechnician(),
            new Chairman()
        }];
    }
}