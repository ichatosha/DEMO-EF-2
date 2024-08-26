using DEMO_EF_2.Contexts;
using DEMO_EF_2.Entities;

namespace DEMO_EF_2
{
    class Program
    {
        static void Main()
        {
           // using AppDbContext context = new AppDbContext();


           //try
           // {
           //     //code
           // }
           // finally
           // {
           //     context.Dispose();
           // }

            //syntax sugar :
            using AppDbContext context = new AppDbContext();

            var employee1 = new Employee()
            {
                Name = "hesham",
                Description = "backEnd Dev.",
                Salary = 15000,
                Age = 26

            };

            #region Create
            context.Add(employee1);
            context.SaveChanges();
            #endregion

            #region Read

             var result2 = context.Employees.Where(E => E.Id == 45).FirstOrDefault();
             var result1 = context.Employees.ToList();


            foreach (var item in result1)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(result2?.Name);
            Console.WriteLine(result2?.Id);

            #endregion


            #region Update

            employee1.Name = "ahmed";
            context.SaveChanges();

            #endregion

        }
    }
}