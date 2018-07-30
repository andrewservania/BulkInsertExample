using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkInsertProofOfConcept
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The database is created first and seperately
            // so it doesn affect the execution times of
            // data insertion.
            CreateDatabase();

            TimedExecution(Insert10000ItemsUsingEntityFramework);

            TimedExecution(Insert10000ItemsUsingEntityFrameworkAddRange);

            TimedExecution(BulkInsert10000ItemsUsingEntityFrameWorkExtensions);

            TimedExecution(BulkInsert10000ItemsUsingSqlBulkCopy);

            Console.ReadKey();
        }

        /// <summary>
        /// Create the test database.
        /// </summary>
        public static void CreateDatabase()
        {
            using (var context = new SampleDbContext())
            {
                context.Database.CreateIfNotExists();
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Loop 10 000 times and add an entity to the context.
        /// </summary>
        public static void Insert10000ItemsUsingEntityFramework()
        {
            using (var context = new SampleDbContext())
            {
                for (int i = 0; i < 10000; i++)
                {
                    context.ExampleEntities.Add(
                        new ExampleEntity()
                        {
                            SomeOtherValue = "Hello World" + i
                        });
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Loop 10 000 times and add an entity to the context using AddRange.
        /// </summary>
        public static void Insert10000ItemsUsingEntityFrameworkAddRange()
        {
            using (var context = new SampleDbContext())
            {
                var entitiesToInsert = new List<ExampleEntity>();

                for (int i = 0; i < 10000; i++)
                {
                    entitiesToInsert.Add(
                        new ExampleEntity()
                        {
                            SomeOtherValue = "Hello World" + i
                        });
                }

                context.ExampleEntities.AddRange(entitiesToInsert);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// BulkInsert 10 000 items using the paid z.EntityFramework.Extensions NuGet package.
        /// </summary>
        public static void BulkInsert10000ItemsUsingEntityFrameWorkExtensions()
        {
            using (var context = new SampleDbContext())
            {
                var entitiesToInsert = new List<ExampleEntity>();

                for (int i = 0; i < 10000; i++)
                {
                    entitiesToInsert.Add(
                        new ExampleEntity()
                        {
                            SomeOtherValue = "Hello World" + i
                        });
                }

                context.BulkInsert(entitiesToInsert);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Bulk insert 10 000 items with a basic implementation using SqlBulkCopy.
        /// </summary>
        public static void BulkInsert10000ItemsUsingSqlBulkCopy()
        {
            var entitiesToInsert = new List<ExampleEntity>();

            for (int i = 0; i < 10000; i++)
            {
                entitiesToInsert.Add(
                    new ExampleEntity()
                    {
                        SomeOtherValue = "Hello World" + i
                    });
            }

            string connectionString = ConfigurationManager.ConnectionStrings["SampleDbContext"].ConnectionString;

            var bulkInsert = new BulkInserter(connectionString);

            bulkInsert.Insert("ExampleEntities", entitiesToInsert);
        }

        /// <summary>
        /// Measure the time it took to execute a give method.
        /// </summary>
        /// <param name="methodToExecute">The method to measure its execution time.</param>
        public static void TimedExecution(Action methodToExecute)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            methodToExecute();

            stopwatch.Stop();

            Console.WriteLine(
                "Executed [{0}] in [{1}] milliseconds",
                methodToExecute.Method.Name,
                stopwatch.Elapsed.TotalMilliseconds);
        }
        
    }
}
