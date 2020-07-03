using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuth.Services.Dto
{
    public class AuthenticationModelDto {
        public string Token { get; set; }
        public int MinutesToExpiration { get; set; }
        public DateTime TokenDate { get; set; }
        public UserLoggedDto UserLogged { get; set; }
    }
}
