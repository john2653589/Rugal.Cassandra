using Rugal.Cassandra.Database.Interface;
using Rugal.DatabaseWorker.Cassandra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugal.Cassandra.Database.Service
{
    public class ColumnFamily<T>
    {
        public CassandraWorker Worker { get; private set; }
        public void SetWorker(CassandraWorker _Worker)
        {
            Worker = _Worker;
            return this;
        }

    }
}
