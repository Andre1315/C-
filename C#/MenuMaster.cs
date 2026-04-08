using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class SortMaster
    {
        public int quantity { get; set; }
        public SortMaster() { }
        public void start(MenuMaster menuMaster)
        {
            for (int i = 0; i < quantity; i++)
            {
                Bubble_sort sort = new Bubble_sort();
                sort.Start(menuMaster.current.get_current().index1);
                menuMaster.current.description += sort.get_string();
            }
        }
    }
    internal class MenuMaster
    {
        public Menu current { get; set; }
        public Menu gen_menu { get; set; }
        public MenuMaster() { }
        public void open_menu(Menu menu)
        {
            current = menu;
        }
        public void sel()
        {
            if (current.get_current().visual_cursor == "+ ")
            {
                current.get_current().index += 1;
            }
            else
            {
                if (current.get_current().index > 0)
                {
                    current.get_current().index -= 1;
                }
            }
        }
        public void unwrap()
        {
            if (current.get_current().visual_cursor == "> ")
            {
                current.description += "\nпока ничего нет";
                current.get_current().visual_cursor = ("< ");
            }
            else
            {
                current.get_current().visual_cursor = ("> ");
            }
        }
    }
}
