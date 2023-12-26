using Cassandra.Mapping;
using Cassandra.Mapping.Attributes;
using Rugal.Cassandra.Database.Service;

 

public class DtvlStore : CassandraStore
{
    public ColumnFamily<User> Users { get; set; }
    public DtvlStore(CassandraServer _Server) : base(_Server)
    {
       
    }
}

[PrimaryKey(nameof(UserId))]
public class User
{
    [PartitionKey]
    public Guid UserId { get; set; }
}