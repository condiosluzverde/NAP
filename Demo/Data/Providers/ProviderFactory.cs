using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    public static class ProviderFactory
    {
        public static IUserAccountProvider GetSimpleUserAccountProvider()
        {
            return new SimpleUserAccountProvider() as IUserAccountProvider;
        }
        public static IUserAccountProvider GetEFUserAccountProvider()
        {
            return new EFUserAccountProvider() as IUserAccountProvider; 
        }
    }
}
