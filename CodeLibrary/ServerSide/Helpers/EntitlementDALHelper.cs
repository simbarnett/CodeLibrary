using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitlementDAL;
using EntitlementDAL.Repositories;
using EntitlementDAL.Repositories.Interfaces;
using System.Configuration;

namespace CodeLibrary.ServerSide.Helpers
{
  public class EntitlementDALHelper
  {
    private RepositoryProduct EntitlementDALRepositories
    {
      get
      {
        return new EntitlementDAL.RepositoryContext().GetRepositories(EntitlementDAL.RepositoryTypes.EntityFramework);
      }
    }

    private string ConnectionString
    {
      get
      {
        return ConfigHelper.GetConnectionString("ConnectionString");
      }
    }

    public IUserRepository GetUserRepository()
    {
      return EntitlementDALRepositories.GetUserRepository(ConnectionString);
    }

    public IKeyValueRepository GetEntitlementKeys()
    {
      return EntitlementDALRepositories.GetKeyValueRepository(ConnectionString);      
    }
  }
}
