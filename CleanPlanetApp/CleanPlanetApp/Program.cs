using System;
using System.Windows.Forms;

namespace CleanPlanetApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Создаем и настраиваем форму
            MainForm mainForm = new MainForm();

            // Обработчик закрытия формы
            mainForm.FormClosed += (s, args) =>
            {
                Application.Exit();
            };

            // Показываем форму
            mainForm.Show();

            //Запускаем цикл сообщений
            Application.Run();
        }
    }
}