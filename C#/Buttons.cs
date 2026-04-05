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
        public string visual_cursor { get; set; }
        private string visual_cursor_no_focus;
        public int index { get; set; }
        public int index1 { get; set; }
        public Action command { get; set; }
        public enum Modes
        {
            only_button,
            button_and_index
        }
        public Modes mode { get; set; }
        private void name_set(string visual_cursor_)
        {
            if (mode == Modes.button_and_index)
            {
                name = visual_cursor_ + name_static + $" ({index}раз) " + index1;
            }
            else if (mode == Modes.only_button)
            {
                name = visual_cursor_ + name_static;
            }
        }
        public Buttons(string name_, string visual_cursor_, Action command_)
        {
            visual_cursor_no_focus = "  ";
            name_static = name_;
            command = command_;
            visual_cursor = visual_cursor_;
            name_set(visual_cursor_no_focus);
            index = 0;
            index1 = 0;
            mode = Modes.only_button;
        }
        public void focus()
        {
            name_set(visual_cursor);
        }
        public void no_focus()
        {
            name_set(visual_cursor_no_focus);
        }
        public void render()
        {
            Console.WriteLine(name);
        }
        public void press()
        {
            command?.Invoke();
        }
        public string get_name_static()
        {
            return name_static;
        }
    }
}
