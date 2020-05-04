using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Clean_Login_System_template.Models.ApplicationUser;

namespace Clean_Login_System_template.Models
{
    public class RoleViewModel
    {

        //constructor
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;

        }
        public RoleViewModel() { }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}