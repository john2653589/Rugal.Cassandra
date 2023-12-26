using Cassandra;
using Rugal.Cassandra.Database.Model;

namespace Rugal.Cassandra.Database.Service
{
    public class CassandraServer : IDisposable
    {
        public CassandraSetting Setting { get; private set; }
        public Cluster Cluster { get; private set; }
        public CassandraServer(CassandraSetting _Setting)
        {
            Setting = _Setting;
            Init();
        }
        private void Init()
        {
            var Builder = Cluster.Builder()
                 .AddContactPoints(Setting.Host)
                 .WithPort(Setting.Port);

            if (!string.IsNullOrWhiteSpace(Setting.UserName) &&
                !string.IsNullOrWhiteSpace(Setting.Password))
                Builder = Builder
                    .WithAuthProvider(new PlainTextAuthProvider(Setting.UserName, Setting.Password));

            Cluster = Builder.Build();
        }
        public void Dispose()
        {
            Cluster?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    public class CassandraStore : IDisposable
    {
        protected readonly CassandraServer Server;
        protected CassandraSetting Setting => Server.Setting;
        
        public ISession Session { get; private set; }
        public CassandraStore(CassandraServer _Server)
        {
            Server = _Server;
            Init();
        }
        private void Init()
        {
            Session = Server.Cluster.Connect(Setting.Keyspace);
        }
        public void Dispose()
        {
            if (!Session.IsDisposed)
                Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}