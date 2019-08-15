using System;
using System.Collections.Generic;
using System.Text;

namespace SavingsPlanner.Models
{
    public enum MenuItemType
    {
        Budget,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
