using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class MenuMaster
    {
        public Menu current {  get; set; }
        public Menu gen_menu { get; set; }
        public MenuMaster() { }
        public void open_menu(Menu menu)
        {
            current = menu;
            menu.render();
        }
        public void sel()
        {
            if (current.get_current().visual_cursor == " +")
            {
                current.get_current().index += 1;
                string name = current.get_current().get_name_static();
                current.get_current().rename(name += $" ({current.get_current().index} раз)");
                current.get_current().focus();
            }
            else
            {
                if (current.get_current().index > 0)
                {
                    current.get_current().index -= 1;
                    string name = current.get_current().get_name_static();
                    current.get_current().rename(name += $" ({current.get_current().index} раз)");
                    current.get_current().focus();
                }
                else
                {
                    string name = current.get_current().get_name_static();
                    current.get_current().rename(name);
                    current.get_current().focus();
                }
            }
        }
        public void unwrap()
        {
            if (current.get_current().visual_cursor == " <- развернуть")
            {
                string name = current.get_current().get_name_static();
                current.get_current().rename(name += $"\nПока ничего нет");
                current.get_current().visual_cursor_set(" <- свернуть");
                current.get_current().focus();
            }
            else
            {
                string name = current.get_current().get_name_static();
                current.get_current().rename(name);
                current.get_current().visual_cursor_set(" <- развернуть");
                current.get_current().focus();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            MenuMaster menuMaster = new MenuMaster();

            Menu start = new Menu("Выбор сортировок для тестирования.\n", 3, "\nУправление:\n- ESC для возвращения в главное меню.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.\n- '+' и '-' для выбора типа курсора.");
            start.AddButton("Сортировка пузырьком", 0, " +", menuMaster.sel);
            start.AddButton("Рекурсивная сортировка", 1, " +", menuMaster.sel);
            start.AddButton("Быстрая сортировка", 2, " +", menuMaster.sel);
            Buttons btn1 = start.get_current();
            btn1.focus();

            Menu history = new Menu("История результатов тестирований\n", 5, "\nУправление:\n- ESC для возвращения в главное меню.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.");
            for (int i = 0; i < 5; i++) history.AddButton($"Результат {i}", i, " <- развернуть", menuMaster.unwrap);
            Buttons btn2 = history.get_current();
            btn2.focus();

            Menu menu = new Menu("Бенчмарк сортировок на C#.\n", 2, "\nУправление:\n- Для выхода нажмите ESC.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.");
            menu.AddButton("Начать", 0, " <--", () => menuMaster.open_menu(start));
            menu.AddButton("История", 1, " <--", () => menuMaster.open_menu(history));
            menu.render();
            Buttons btn3 = menu.get_current();
            btn3.focus();

            menuMaster.current = menu;
            menuMaster.gen_menu = menu;

            bool bool_ = true;
            while (bool_)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow) menuMaster.current.cursor_up();
                else if (keyInfo.Key == ConsoleKey.DownArrow) menuMaster.current.cursor_down();

                else if (keyInfo.Key == ConsoleKey.Enter) menuMaster.current.get_current().press();

                else if (menuMaster.current == start && keyInfo.Key == ConsoleKey.OemPlus)
                {
                    string name = menuMaster.current.get_current().get_name_real();
                    menuMaster.current.get_current().rename(name);
                    menuMaster.current.get_current().visual_cursor_set(" +");
                    menuMaster.current.get_current().focus();
                }

                else if (menuMaster.current == start && keyInfo.Key == ConsoleKey.OemMinus)
                {
                    string name = menuMaster.current.get_current().get_name_real();
                    menuMaster.current.get_current().rename(name);
                    menuMaster.current.get_current().visual_cursor_set(" -");
                    menuMaster.current.get_current().focus();
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (menuMaster.current == menuMaster.gen_menu) break;
                    else
                    {
                        menuMaster.current = menuMaster.gen_menu;
                    }
                }
                menuMaster.current.render();
            }
        }
    };
}