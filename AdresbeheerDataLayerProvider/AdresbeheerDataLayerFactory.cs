using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDataLayerProvider
{
    public static class AdresbeheerDataLayerFactory
    {
        public static AdresbeheerRepositories GeefRepositories(string connectionString,RepositoryType repositoryType)
        {
            return new AdresbeheerRepositories(connectionString, repositoryType);
        }
    }
}
