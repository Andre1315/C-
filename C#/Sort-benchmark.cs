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
        static private Menu current_menu;
        static private Menu gen_menu;
        static void open(Menu menu)
        {
            current_menu = menu;
        }
        static void sel()
        {
            string name = current_menu.get_name() + $" ({current_menu.get_index()})";
            current_menu.rename(name);
            int i = current_menu.get_index();
            current_menu.set_index(i += 1);
            current_menu.cursor_set();
        }
        static void Main()
        {
            Menu start = new Menu("Выбор сортировок для тестирования\n", 3);
            start.AddButton("Сортировка пузырьком", 0, " +", sel);
            start.AddButton("Рекурсивная сортировка", 1, " +", sel);
            start.AddButton("Быстрая сортировка", 2, " +", sel);
            start.cursor_set();

            Menu history = new Menu("История результатов тестирований\n", 5);
            for (int i = 0; i < 5; i++) history.AddButton($"Результат {i}", i, " <- развернуть", () => Console.WriteLine($"пока ничего нет"));
            history.cursor_set();

            Menu menu = new Menu("Бенчмарк сортировок на C#.\nДля выхода нажмите ESC.\n", 2);
            menu.AddButton("Начать", 0, " <--", () => open(start));
            menu.AddButton("История", 1, " <--", () => open(history));
            menu.render();
            menu.cursor_set();

            current_menu = menu;
            gen_menu = menu;

            bool bool_ = true;
            while (bool_)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow) current_menu.cursor_up();
                else if (keyInfo.Key == ConsoleKey.DownArrow) current_menu.cursor_down();

                else if (keyInfo.Key == ConsoleKey.Enter) current_menu.press();

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (current_menu == gen_menu) break;
                    else
                    {
                        current_menu = gen_menu;
                    }
                }
                current_menu.render();
            }
        }
    };
}