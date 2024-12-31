using Repositories.Models;
using System.Collections.Generic;

namespace ServiceBL
{
    public interface IRoleService
    {
     string checkRoleCodeByEmployeePassword(int password);
     List<Roles> GetRoles();
    }
}

