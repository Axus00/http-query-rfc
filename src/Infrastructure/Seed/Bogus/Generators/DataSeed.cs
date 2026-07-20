using Bogus;
using http_query_rfc.src.Application.DTOs;

namespace http_query_rfc.src.Infrastructure.Seed.Bogus.Generators;
public class DataSeed
{
    public static List<UserDto> GenerateUserData(int userCount = 5)
    {
        var userFakeData = new Faker<UserDto>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Age, f => f.Random.Int(18, 80))
            .RuleFor(
                u => u.Email,
                (f, user) => f.Internet.Email(user.Name, user.LastName)
            )
            .RuleFor(
                u => u.CreatedAt,
                (f, _) => f.Date.RecentDateOnly()
            )
            .RuleFor(
                u => u.UpdatedAt,
                (f, user) => f.Date.BetweenDateOnly(
                    user.CreatedAt,
                    DateOnly.FromDateTime(DateTime.Today)
                )
            );

        return userFakeData.Generate(userCount);
    }
}