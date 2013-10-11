using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionServerWebSession;

namespace FunGrid.Domain
{
    public class AdminUserMenu:UserMenu
    {
        public AdminUserMenu()
        {
            NavbarLeft.Add(            
                new Menu{
                    Id = 8,
                    Text = "Mange Projects",
                    HRef = "/Project/Index",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                });

            NavbarRight = new List<Menu>
            {
                new Menu
                {
                    Text = "You are logged in as: "+UserSession.LoggedInUser.UserName
                },
                new Menu
                {
                    Id = 5,
                    Text = "Logoff",
                    HRef = "/Account/Logoff",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };

            Sidebar.Insert(1,
                new Menu
                {
                    Id = 8,
                    Text = "Mange Projects",
                    HRef = "/Project/Index",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                });

        }
    }
}
