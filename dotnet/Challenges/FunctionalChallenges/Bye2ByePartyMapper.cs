namespace Challenges;

public static class Bye2ByePartyMapper
{
    public static IBye2ByeParty MapFrom(string bingorgMembershipType, string bingorgMembershipStatus)
    {
        var bingorgMember = BingorgMember.Unknown;

        if (bingorgMembershipType == "ordinary")
        {
            if (bingorgMembershipStatus == "active")
            {
                bingorgMember = BingorgMember.ActiveOrdinary;
            }

            if (bingorgMembershipStatus == "non active")
            {
                bingorgMember = BingorgMember.NonActiveOrdinary;
            }
        }
        else if (bingorgMembershipType == "student")
        {
            bingorgMember = BingorgMember.ActiveStudent;
        }
        else if (bingorgMembershipType == "employee")
        {
            bingorgMember = BingorgMember.ActiveEmployee;
        }

        if (bingorgMember == BingorgMember.ActiveOrdinary)
        {
            return new RegularParty();
        }

        if (bingorgMember == BingorgMember.NonActiveOrdinary)
        {
            return new InactiveParty();
        }

        if (bingorgMember == BingorgMember.ActiveStudent)
        {
            return new StudentParty();
        }

        if (bingorgMember == BingorgMember.ActiveEmployee)
        {
            return new InternallyEmployedParty();
        }

        throw new Exception($"Unable to map {bingorgMembershipType} {bingorgMembershipStatus} to Bye2ByeParty");
    }
}

public interface IBye2ByeParty;
public record RegularParty: IBye2ByeParty;
public record InactiveParty: IBye2ByeParty;
public record StudentParty : IBye2ByeParty;
public record InternallyEmployedParty: IBye2ByeParty;

public enum BingorgMember
{
    Unknown,
    ActiveOrdinary,
    NonActiveOrdinary,
    ActiveStudent,
    ActiveEmployee
}