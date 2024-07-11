﻿using ForkliftDirectory.Server.Entities;

namespace ForkliftDirectory.Server.Extensions
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(this ForkliftDirectoryDbContext dbContext)
        {
            if (dbContext == null)
            {
                return;
            }

            try
            {
                dbContext.Users.AddRange(GenerateUsers(dbContext));
                dbContext.Forklifts.AddRange(GenerateForklifts(dbContext));
                dbContext.Malfunctions.AddRange(GenerateMalfunctions(dbContext));
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Forklift> GenerateForklifts(ForkliftDirectoryDbContext? dbContext)
        {
            List<Forklift> forklifts = new List<Forklift> {
                new Forklift { 
                    ForkliftId = 1,
                    Model = "Амкадор",
                    Number ="45-65-PH-1",
                    LiftCapacity = 5,
                    UserId = 1
                },
                new Forklift {
                    ForkliftId = 2,
                    Model = "CAT",
                    Number ="22-33-JH-2",
                    LiftCapacity = 6,
                    UserId = 2
                },
                new Forklift {
                    ForkliftId = 3,
                    Model = "Tesla",
                    Number ="55-66-LS-3",
                    LiftCapacity = 7,
                    UserId = 3
                }
            };

            return forklifts;
        }

        public static List<Malfunction> GenerateMalfunctions(ForkliftDirectoryDbContext? dbContext)
        {
            List<Malfunction> malfunctions = new List<Malfunction> {
                new Malfunction {
                    MalfunctionId = 1,
                    ForkliftId = 1,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 2,
                    ForkliftId = 1,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 3,
                    ForkliftId = 1,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 4,
                    ForkliftId = 2,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 5,
                    ForkliftId = 2,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 6,
                    ForkliftId = 2,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 7,
                    ForkliftId = 2,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 8,
                    ForkliftId = 3,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
                new Malfunction {
                    MalfunctionId = 9,
                    ForkliftId = 3,
                    StartTime = new DateTime(2024, 7, 10, 10, 00, 00),
                    EndTime = new DateTime(2024, 7, 10, 12, 00, 00),
                    TimeSpan = "2:00:00",
                    Describtion ="сломался"
                },
            };

            return malfunctions;
        }

        public static List<User> GenerateUsers(ForkliftDirectoryDbContext? dbContext)
        {
            List<User> users = new List<User>() { 
                new User { 
                    UserId = 1,
                    UserName = "Иванов И.И."
                },
                new User {
                    UserId = 2,
                    UserName = "Петров П.П."
                },
                new User {
                    UserId = 3,
                    UserName = "Сидоров С.С."
                },
            };

            return users;
        }
    }
}
