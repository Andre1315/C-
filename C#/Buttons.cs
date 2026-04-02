using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Buttons
    {
        private string name;
        private string name_static;
        private string name_focus;
        private string name_real;
        public string visual_cursor { get; set; }
        public int index { get; set; }
        private Action command { get; set; }
        private void name_set()
        {
            name_real = name;
            name_focus = name + visual_cursor;
        }
        public Buttons(string name_, string visual_cursor_, Action command_)
        {
            name = name_;
            command = command_;
            visual_cursor = visual_cursor_;
            name_set();
            index = 0;
            name_static = name_;
        }
        public void focus()
        {
            if (name == name_real) name = name_focus;
            else name = name_real;
        }
        public void render()
        {
            Console.WriteLine(name);
        }
        public void press()
        {
            command?.Invoke();
        }
        public void rename(string name_)
        {
            name = name_;
            name_set();
        }
        public string get_name_static()
        {
            return name_static;
        }
        public string get_name_real()
        {
            return name_real;
        }
        public void visual_cursor_set(string visual_cursor_)
        {
            visual_cursor = visual_cursor_;
            name_set();
        }
    }
}
