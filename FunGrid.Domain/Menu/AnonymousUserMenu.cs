using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class AnonymousUserMenu:UserMenu
    {
        public AnonymousUserMenu()
        {
            NavbarLeft.Add(
                new Menu
                {
                    Id = 7,
                    Text = "Donate",
                    HRef = "/Project/Donate",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                });

            NavbarRight = new List<Menu>
            {
                new Menu
                {
                    Id = 5,
                    Text = "Register",
                    HRef = "/Account/Register",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                },
                new Menu
                {
                    Id = 5,
                    Text = "Login",
                    HRef = "/Account/Login",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                }
            };

            Sidebar.Insert(1,
                new Menu
                {
                    Id = 7,
                    Text = "Donate",
                    HRef = "/Project/Donate",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                });
        }
    }
}
