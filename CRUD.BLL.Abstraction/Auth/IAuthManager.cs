using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.BLL.Abstraction.Base;
using Models.Entity;

namespace CRUD.BLL.Abstraction.Auth
{
    public interface IAuthManager:IManager<UserInfo>
    {
        Task<UserInfo> GetUser(string email);
    }
}
