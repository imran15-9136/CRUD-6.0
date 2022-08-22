using CRUD.BLL.Abstraction.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _auth;
        public AuthController(IAuthManager auth)
        {
            _auth = auth;
        }
        public async Task<IActionResult> Post([FromBody]UserInfo userInfo)
        {
            if (userInfo != null && userInfo.Email != null && userInfo.Password!=null)
            {
                var user = _auth.Authenticate(userInfo);
                return Ok(user);
            }

            return Ok();
        }

        
    }
}
