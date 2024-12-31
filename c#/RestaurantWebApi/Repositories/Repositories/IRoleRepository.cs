using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IRoleRepository
    {
        string checkRoleCodeByEmployeePassword(int password);
    List<Roles> GetRoles();
    }
}
