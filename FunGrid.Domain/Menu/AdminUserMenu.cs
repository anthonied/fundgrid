using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class AdminUserMenu
    {
        public List<Menu> NavbarLeft { get; set; }
        public List<Menu> NavbarRight { get; set; }
        public List<Menu> Sidebar { get; set; }
        public List<Menu> NavPills { get; set; }
        public AdminUserMenu()
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
                    Id= 8,
                    Text = "Mange Projects",
                    HRef = "/Project/Index",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                }
            };
        }
    }
}
