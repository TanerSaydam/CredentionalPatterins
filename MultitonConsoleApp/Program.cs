
using System.Data.Common;

var sql = Database.GetInstance("Sql");
sql.ConnectionString("Sql connection string");
sql.Connection();
Database.GetInstance("Sql");
Database.GetInstance("Oracle");
Database.GetInstance("PostreSql");
Database.GetInstance("MongoDb");

class Database
{
    private Database()
    {
        Console.WriteLine($"{nameof(Database)} nesnesi üretildi.");
    }

    static Dictionary<string, Database> _databases = new Dictionary<string, Database>();
    public static Database GetInstance(string key)
    {
        if (!_databases.ContainsKey(key))
            _databases[key] = new Database();

        return _databases[key];
    }

    string connectionString = "";
    public static Database GetInstance(string key, string connectionString)
    {
        Database database = GetInstance(key);
        database.ConnectionString(connectionString);
        return database;
    }

    public void Connection()
    {
        Console.WriteLine("Connected");
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnect");
    }

    public void ConnectionString(string connectionString)
    {

    }
}