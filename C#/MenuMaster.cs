using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class SortMaster
    {
        public int quantity_bubble_Sort { get; set; }
        public SortMaster() { }
        public void start(MenuMaster menuMaster)
        {
            for (int i = 0; i < quantity_bubble_Sort; i++)
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
        public void open_menu(Menu menu, Buttons.Modes modes)
        {
            current = menu;
            menu.get_current().mode = modes;
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
