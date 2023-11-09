using AdresbeheerADOlayer.Repositories;
using AdresbeheerDomain.Interfaces;
using AdresbeheerEFlayer.Repositories;

namespace AdresbeheerDataLayerProvider
{
    public class AdresbeheerRepositories
    {
        public AdresbeheerRepositories(string connectionString,RepositoryType repositoryType)
        {
            try
            {
                switch(repositoryType)
                {
                    case RepositoryType.ADO:
                        GemeenteRepository = new GemeenteRepositoryADO(connectionString);
                        StraatRepository = new StraatRepositoryADO(connectionString);
                        AdresRepository = new AdresRepositoryADO(connectionString);
                        break;
                    case RepositoryType.EFCore:
                        GemeenteRepository = new GemeenteRepositoryEF(connectionString);
                        StraatRepository = new StraatRepositoryEF(connectionString);
                        AdresRepository = new AdresRepositoryEF(connectionString); 
                        break;
                    default:throw new AdresbeheerDataLayerFactoryException("geefrepos");
                }
            }
            catch(Exception ex)
            {
                throw new AdresbeheerDataLayerFactoryException("Geefrepos", ex);
            }
        }
        public IAdresRepository AdresRepository { get; }
        public IStraatRepository StraatRepository { get; }
        public IGemeenteRepository GemeenteRepository { get; }
    }
}
