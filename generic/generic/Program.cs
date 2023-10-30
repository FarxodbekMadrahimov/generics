
using generic;
using System.Data.SqlClient;


string tablename = "Fruits";
string database = "Tree";
string query = $"WHERE name = 'apple'";
List<InsertModel> lst = new List<InsertModel>()
{
    new InsertModel()
    {
        ColumnName ="mame",
        Value1 = "apple",
    },
    new InsertModel()
    {
        ColumnName ="name",
        Value1 = "peach",
    },

};

Services.UpdateTable(tablename, database, lst, query);
Services.GetAll(tablename, database, query);

