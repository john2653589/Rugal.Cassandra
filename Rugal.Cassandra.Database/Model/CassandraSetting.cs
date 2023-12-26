
namespace Rugal.Cassandra.Database.Model
{
    public class CassandraSetting
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public string Keyspace { get; init; }
    }
}
