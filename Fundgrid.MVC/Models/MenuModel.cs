using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FunGrid.Domain;
using System.Collections;

namespace Fundgrid.MVC.Models
{
    public class MenuModel{
        public List<Menu> navbarLeft { get; set; }
        public List<Menu> navbarRight { get; set; }
        public List<Menu> sidebar { get; set; }
        public List<Menu> navPills { get; set; }

        public MenuModel(){
            //var menu = new AnonymousUserMenu();
            var menu = new AdminUserMenu();
            this.navbarLeft = menu.NavbarLeft;
            this.navbarRight = menu.NavbarRight;
            this.sidebar = menu.Sidebar;
            this.navPills = menu.NavPills;
        }
    }
}