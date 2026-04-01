using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sort
{
    class Buttons
    {
        private string name;
        private string name_focus;
        private string name_real;
        public Buttons(string name_)
        {
            name = name_;
            name_real = name_;
            name_focus = name_ + " <--";
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
    }
    class Menu
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
        public void AddButton(string name, int index)
        {
            Buttons button = new Buttons(name);
            array[index] = button;
        }
        public void cursor_down()
        {
            array[cursor].focus();
            if (cursor == array.Length - 1) cursor = 0;
            else cursor++;
            array[cursor].focus();
            render();
        }
        public void cursor_up()
        {
            array[cursor].focus();
            if (cursor == 0) cursor = array.Length - 1;
            else cursor--;
            array[cursor].focus();
            render();
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
    };
    class MenuMaster
    {
        private Menu[] menus;
        private int index_selected_menu;
        public MenuMaster(int max_menu)
        {
            menus = new Menu[max_menu];
            index_selected_menu = 0;
        }
        public void AddMenu(Menu menu, int index)
        {
            menus[index] = menu;
        }
        public void cursor_up_master()
        {
            menus[index_selected_menu].cursor_up();
        }
        public void cursor_down_master()
        {
            menus[index_selected_menu].cursor_down();
        }
        public void enter()
        {
            int cursor = menus[index_selected_menu].cursor_get() + 1;
            menus[cursor].render();
            index_selected_menu = cursor;
        }
        public void esc(ref bool bool_)
        {
            if (index_selected_menu == 0) bool_ = false;
            else
            {
                index_selected_menu = 0;
                menus[index_selected_menu].render();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Menu menu = new Menu("Бенчмарк сортировок на C#.\nДля выхода нажмите ESC.\n", 2);
            menu.AddButton("Начать", 0);
            menu.AddButton("История", 1);
            menu.render();

            Menu start = new Menu("Выбор сортировок для тестирования\n", 3);
            start.AddButton("Сортировка пузырьком", 0);
            start.AddButton("Рекурсивная сортировка", 1);
            start.AddButton("Быстрая сортировка", 2);

            Menu history = new Menu("История результатов тестирований\n", 5);
            for (int i = 0; i < 5; i++) history.AddButton($"Результат {i}", i);

            MenuMaster menu_master = new MenuMaster(3);
            menu_master.AddMenu(menu, 0);
            menu_master.AddMenu(start, 1);
            menu_master.AddMenu(history, 2);

            bool bool_ = true;
            while (bool_)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow) menu_master.cursor_up_master();
                else if (keyInfo.Key == ConsoleKey.DownArrow) menu_master.cursor_down_master();

                else if (keyInfo.Key == ConsoleKey.Enter) menu_master.enter();

                else if (keyInfo.Key == ConsoleKey.Escape) menu_master.esc(ref bool_);
            }
        }
    };
}