using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class AnonymousUserMenu
    {
        public List<Menu> NavbarLeft { get; set; }
        public List<Menu> NavbarRight { get; set; }
        public List<Menu> Sidebar { get; set; }
        public List<Menu> NavPills { get; set; }
        public AnonymousUserMenu()
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
                    Id = 4,
                    Text = "Register",
                    HRef = "/Account/Register",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };

            Sidebar = new List<Menu>
            {
                new Menu{
                    Id= 7,
                    Text = "Donate",
                    HRef = "/Project/Donate",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                }
            };
        }
    }
}
