using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Jaroszek.ProofOfConcept.SqlTableDependency
{
    class Program
    {
        private static string _con =
            @"Data Source=(local);Initial Catalog=test;Integrated Security=True";

        static void Main(string[] args)
        {
            var mapper = new ModelToTableMapper<Customer>();

            using (var dep = new SqlTableDependency<Customer>(_con, "Customer"))
            {
                dep.OnChanged += thaydoi;
                dep.Start();

                Console.WriteLine("đang kiểm tra");
                Console.ReadKey();

                dep.Stop();
            }

        }


        public static void thaydoi(object sender, RecordChangedEventArgs<Customer> e)
        {
            var changedEntity = e.Entity;

            Console.WriteLine("DML operation: " + e.ChangeType);
            Console.WriteLine("ID: " + changedEntity.Id);
            Console.WriteLine("Name: " + changedEntity.Name);
            Console.WriteLine("Surname: " + changedEntity.Surname);
        }



    }
}