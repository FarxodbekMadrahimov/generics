using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace generic
{
    public class Services
    {
        public static void GetAll(string TableName, string DatabaseName, string d)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {
                connect.Open();

                string query = $"select * from {TableName} {d};";

                SqlCommand sqlCommand = new SqlCommand(query, connect);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    //int i = 0;
                    while (reader.Read())
                    {
                        for (int j = 0; j < count; j++)
                        {
                            Console.Write($"{reader[j]} \t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }



        public static void insertInto(string TableName, string DatabaseName, List<InsertModel> columns)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {


                connect.Open();

                //string ustunlar = String.Empty;

                //string linq = String.Join(",", columns.Select(x => x.Name + " " + x.Typelari).ToList());

                //string query = $"create table {TableName}(Id int not null, " +
                //                                        $"Name varchar(30)," +
                //                                        $"Age int not null)";


                string query = $"insert into {TableName}({String.Join(",", columns.Select(x => x.ColumnName).ToList())} )" +
                    $"Values" +
                    $"({String.Join(",", Shart(columns.Select(x => x.Value1).ToList()))});";



                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Succesfully insert ");

            }
        }


        public static List<string> Shart(List<string> lst)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < lst.Count; i++)
            {
                int num;
                var isnum = int.TryParse(lst[i], out num);

                if (isnum)
                {
                    s.Add(lst[i]);
                }

                else
                {
                    s.Add($"\'{lst[i]}\'");
                }
            }
            return s;
        }






        public static void UpdateTable(string TableName, string DatabaseName, List<InsertModel> columns, string querys)
        {
            using (SqlConnection connect = new SqlConnection($"Server=.;Database={DatabaseName};Trusted_Connection=True;"))
            {


                connect.Open();

                //string ustunlar = String.Empty;

                //string linq = String.Join(",", columns.Select(x => x.Name + " " + x.Typelari).ToList());

                //string query = $"create table {TableName}(Id int not null, " +
                //                                        $"Name varchar(30)," +
                //                                        $"Age int not null)";


                string query = $"Update {TableName} " +
                                $"Set {String.Join(",", columns.Select(x => x.ColumnName + " = " + x.Value1).ToList())}" +
                                $" {querys} ;";



                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Succesfully insert ");

            }


        }
    }
}
