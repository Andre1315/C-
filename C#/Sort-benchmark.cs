using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void set(MenuMaster menuMaster, int i)
        {
            menuMaster.current.get_current().index1 *= 10;
            menuMaster.current.get_current().index1 += i;
        }
        static void Main()
        {
            MenuMaster menuMaster = new MenuMaster();
            SortMaster sortMaster = new SortMaster();

            Menu start = new Menu("Выбор сортировок для тестирования.\n", 3, "\nУправление:\n- ESC для возвращения в главное меню.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.\n- '+' и '-' для выбора типа курсора.\n- SPACEBAR для старта.\n\nСтарт:\n");
            start.AddButton("Сортировка пузырьком", 0, "+ ", menuMaster.sel, Buttons.Modes.button_and_index);
            start.AddButton("Рекурсивная сортировка", 1, "+ ", menuMaster.sel, Buttons.Modes.button_and_index);
            start.AddButton("Быстрая сортировка", 2, "+ ", menuMaster.sel, Buttons.Modes.button_and_index);
            start.get_current().focus();

            Menu history = new Menu("История результатов тестирований\n", 5, "\nУправление:\n- ESC для возвращения в главное меню.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.");
            for (int i = 0; i < 5; i++) history.AddButton($"Результат {i}", i, "> ", menuMaster.unwrap, Buttons.Modes.only_button);
            history.get_current().focus();

            Menu menu = new Menu("Бенчмарк сортировок на C#.\n", 2, "\nУправление:\n- Для выхода нажмите ESC.\n- Стрелки вверх и вниз для перемещения.\n- ENTER для выбора.");
            menu.AddButton("Начать", 0, "> ", () => menuMaster.open_menu(start), Buttons.Modes.only_button);
            menu.AddButton("История", 1, "> ", () => menuMaster.open_menu(history), Buttons.Modes.only_button);
            menu.render();

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
                    menuMaster.current.get_current().visual_cursor = ("+ ");
                }

                else if (menuMaster.current == start && keyInfo.Key == ConsoleKey.OemMinus)
                {
                    menuMaster.current.get_current().visual_cursor = ("- ");
                }

                else if (keyInfo.Key == ConsoleKey.Spacebar && menuMaster.current == start)
                {
                    sortMaster.quantity = menuMaster.current.get_current().index;
                    sortMaster.start(menuMaster);
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (menuMaster.current == menuMaster.gen_menu) break;
                    else
                    {
                        menuMaster.current = menuMaster.gen_menu;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Backspace && menuMaster.current == start)
                {
                    menuMaster.current.get_current().index1 /= 10;
                }

                else if (keyInfo.Key == ConsoleKey.D0 && menuMaster.current == start)
                {
                    set(menuMaster, 0);
                }
                else if (keyInfo.Key == ConsoleKey.D1 && menuMaster.current == start)
                {
                    set(menuMaster, 1);

                }
                else if (keyInfo.Key == ConsoleKey.D2 && menuMaster.current == start)
                {
                    set(menuMaster, 2);
                }
                else if (keyInfo.Key == ConsoleKey.D3 && menuMaster.current == start)
                {
                    set(menuMaster, 3);
                }
                else if (keyInfo.Key == ConsoleKey.D4 && menuMaster.current == start)
                {
                    set(menuMaster, 4);
                }
                else if (keyInfo.Key == ConsoleKey.D5 && menuMaster.current == start)
                {
                    set(menuMaster, 5);
                }
                else if (keyInfo.Key == ConsoleKey.D6 && menuMaster.current == start)
                {
                    set(menuMaster, 6);
                }
                else if (keyInfo.Key == ConsoleKey.D7 && menuMaster.current == start)
                {
                    set(menuMaster, 7);
                }
                else if (keyInfo.Key == ConsoleKey.D8 && menuMaster.current == start)
                {
                    set(menuMaster, 8);
                }
                else if (keyInfo.Key == ConsoleKey.D9 && menuMaster.current == start)
                {
                    set(menuMaster, 9);
                }

                menuMaster.current.render();
            }
        }
    };
}