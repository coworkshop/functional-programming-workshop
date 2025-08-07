namespace Challenges;
using static MonsterExperience;
using static ScaryLevel;

public static class MonsterIncMatrix
{
    public static IEnumerable<IMonsterRole> GetQualifiedRoles(MonsterExperience monsterExperience, ScaryLevel scaryLevel)
    {
        if (monsterExperience == None)
        {
            if (scaryLevel >= Medium)
            {
                yield return new ScarerTrainee();
            }
        }
        
        if (monsterExperience >= None)
        {
            if (scaryLevel >= Low)
            {
                yield return new Janitor();
                yield return new Receptionist();
                yield return new DoorShredder();
            }
        }

        if (monsterExperience >= Intermediate)
        {
            if (scaryLevel >= Low)
            {
                yield return new ScareAssistant();
                yield return new ChildDetectionAgent();
            }

            if (scaryLevel == High)
            {
                yield return new Scarer();
            }
        }

        if (monsterExperience == Experienced)
        {
            if (scaryLevel >= Medium)
            {
                yield return new ScreamCanDesigner();
                yield return new ScreamCanTechnician();
            }

            if (scaryLevel == High)
            {
                yield return new Chairman();
            }
        }
    }
}

public interface IMonsterRole;

public record Janitor : IMonsterRole;
public record Receptionist : IMonsterRole;
public record DoorShredder : IMonsterRole;
public record ScarerTrainee : IMonsterRole;

public record Scarer : IMonsterRole;
public record ScareAssistant : IMonsterRole;

public record ChildDetectionAgent : IMonsterRole;
public record ScreamCanDesigner : IMonsterRole;
public record ScreamCanTechnician : IMonsterRole;

public record Chairman : IMonsterRole;

public enum ScaryLevel
{
    Low,
    Medium,
    High
}

public enum MonsterExperience
{
    None,
    Intermediate,
    Experienced
}