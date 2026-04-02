using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Menu
    {
        private Buttons[] array;
        private string name;
        private int cursor;
        private string description;
        public Menu(string name_, int max_buttons_, string description_)
        {
            name = name_;
            array = new Buttons[max_buttons_];
            cursor = 0;
            description = description_;
        }
        public void AddButton(string name, int index, string visual_cursor, Action command)
        {
            Buttons button = new Buttons(name, visual_cursor, command);
            array[index] = button;
        }
        public void cursor_down()
        {
            array[cursor].focus();
            if (cursor == array.Length - 1) cursor = 0;
            else cursor++;
            array[cursor].focus();
        }
        public void cursor_up()
        {
            array[cursor].focus();
            if (cursor == 0) cursor = array.Length - 1;
            else cursor--;
            array[cursor].focus();
        }
        public void render()
        {
            Console.Clear();
            Console.WriteLine(name);
            for (int i = 0; i < array.Length; i++)
            {
                array[i].render();
            }
            Console.WriteLine(description);
        }
        public Buttons get_current()
        {
            return array[cursor];
        }
    }
}
