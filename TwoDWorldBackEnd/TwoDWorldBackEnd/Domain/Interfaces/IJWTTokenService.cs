using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoDWorldBackEnd.DAL.Entities.Auth;

namespace TwoDWorldBackEnd.Domain.Interfaces
{
    public interface IJWTTokenService
    {
        public string CreateToken(User user);
    }
}
