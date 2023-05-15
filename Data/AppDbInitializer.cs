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
                                    TaskName = "Task 6.1D",
                                    TaskComments = "1/4 completed",
                                    TaskDueDate = new DateTime(2023, 05, 29)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT223",
                                    TaskName = "Task 2.3HD",
                                    TaskComments = "Not started",
                                    TaskDueDate = new DateTime(2023, 06, 10)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT232",
                                    TaskName = "1.3D",
                                    TaskComments = "Need to record video",
                                    TaskDueDate = new DateTime(2023, 06, 15)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT216",
                                    TaskName = "Assessment Task 3",
                                    TaskComments = "1/2 completed",
                                    TaskDueDate = new DateTime(2023, 06, 01)
                                },
                                new TaskItem()
                                {
                                    UnitCode = "SIT151",
                                    TaskName = "Assessment 4",
                                    TaskComments = "Make last component/feature",
                                    TaskDueDate = new DateTime(2023, 05, 31)
                                },
                            });
                        context.SaveChanges();

                    }               
                }
            }
        }
    }
}
