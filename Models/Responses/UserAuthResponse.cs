using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class UserAuthResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string EmailVefificationtoken { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string EmailVerificatinToken { get; set; }
        public JwtSecurityToken JwtSecurityToken { get; set; }
    }
}
