using Faker;
using signalr_poc.Domain.Entities;

namespace signalr_poc.Domain;

public class DbSeedData
{
    public static void Seed(PocDbContext db)
    {
        if (db.Dummies.Any()) return;

        for (var i = 0; i < 500000; i++)
        {
            RandomNumber.Next(i, i);
            db.Dummies.Add(new Dummy
            {
                Label = Name.FullName(),
                Description = Lorem.Paragraph()
            });
        }
    }
}