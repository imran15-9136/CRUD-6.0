using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Repository.Abstraction.Auth;
using CRUD.Repository.Base;
using Database.Database;
using Models.Entity;

namespace CRUD.Repository.Auth
{
    public class AuthRepository:Repository<UserInfo>, IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthRepository(ApplicationDbContext dbcontext):base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
