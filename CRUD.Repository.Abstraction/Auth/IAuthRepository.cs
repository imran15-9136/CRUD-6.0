using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Repository.Abstraction.Base;
using Models.Entity;

namespace CRUD.Repository.Abstraction.Auth
{
    public interface IAuthRepository : IRepository<UserInfo>
    {
    }
}
