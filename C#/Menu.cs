using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Menu
    {
        private Buttons[] array;
        private string name;
        private int cursor;
        public Menu(string name_, int max_buttons_)
        {
            name = name_;
            array = new Buttons[max_buttons_];
            cursor = 0;
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
        }
        public void cursor_set()
        {
            array[cursor].focus();
        }
        public int cursor_get()
        {
            return cursor;
        }
        public void press()
        {
            array[cursor].press();
        }
        public void visual_cursor_set(string visual_cursor_)
        {
            array[cursor].visual_cursor_set(visual_cursor_);
        }
        public void rename(string newName)
        {
            array[cursor].rename(newName);
        }
        public string get_name()
        {
            return array[cursor].get_name();
        }
        public int get_index()
        {
            return array[cursor].get_index();
        }
        public void set_index(int index)
        {
            array[cursor].set_index(index);
        }
    }
}
