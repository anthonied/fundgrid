using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class UserMenu
    {
        public List<Menu> NavbarLeft { get; set; }
        public List<Menu> NavbarRight { get; set; }
        public List<Menu> Sidebar { get; set; }
        public List<Menu> NavPills { get; set; }
        public UserMenu()
        {
            NavbarLeft = new List<Menu>
            {
                new Menu{
                    Id = 1,
                    Text = "Home",
                    HRef = "/",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };

            NavbarRight = new List<Menu>
            {
                new Menu{
                    Id = 5,
                    Text = "Login",
                    HRef = "/Account/Login",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };

            Sidebar = new List<Menu>
            {
                new Menu{
                    Id= 6,
                    Text = "SIDEBAR",
                    HRef = "",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = true
                },
                new Menu{
                    Id= 0,
                    Text = "PAGE NAVIGATION",
                    HRef = "",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = true
                },
                new Menu{
                    Id = 1,
                    Text = "Home",
                    HRef = "/",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };
        }
    }
}
