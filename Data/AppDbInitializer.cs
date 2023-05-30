using System;
using TaskPlanner.Models;

namespace TaskPlanner.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context != null)
                {
                    context.Database.EnsureCreated();

                    // Developer
                    if (!context.Tasks.Any())
                    {
                        context.Tasks.AddRange(new List<TaskItem>()
                        {
                                new TaskItem()
                                {
                                    UnitCode = "SIT223",
                                    Name = "Task 6.1D",
                                    Comments = "1/4 completed",
                                    DueDate = new DateTime(2023, 05, 29)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT223",
                                    Name = "Task 2.3HD",
                                    Comments = "Not started",
                                    DueDate = new DateTime(2023, 06, 10)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT232",
                                    Name = "1.3D",
                                    Comments = "Need to record video",
                                    DueDate = new DateTime(2023, 06, 15)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT216",
                                    Name = "Assessment Task 3",
                                    Comments = "1/2 completed",
                                    DueDate = new DateTime(2023, 06, 01)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT151",
                                    Name = "Assessment 4",
                                    Comments = "Make last component/feature",
                                    DueDate = new DateTime(2023, 05, 31)
                                },
                            });
                        context.SaveChanges();

                    }               
                }
            }
        }
    }
}
