using System.Data.Common;
using System.Data.SqlClient;

namespace Tools
{
    public class SqlCmd : DbCmd
    {
        public override DbProviderFactory dbProvierFactory
        {
            get
            {
                return SqlClientFactory.Instance;
            }
        }
    }
}
