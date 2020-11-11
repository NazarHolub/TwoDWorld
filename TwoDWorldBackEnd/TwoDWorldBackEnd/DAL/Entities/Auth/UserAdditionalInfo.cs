using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TwoDWorldBackEnd.DAL.Entities.Auth
{
    public class UserAdditionalInfo
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Image { get; set; }

        public DateTime DateOfBirth { get; set; }

        public User User { get; set; }


        public List<Title> Favorites { get; set; }
        public List<Title> PlanToWatch { get; set; }
        public List<Title> Watched { get; set; }
        public List<Title> Watching { get; set; }
    }
}
