using System;
using System.Windows.Forms;

namespace SpaceJourney
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 1280;
            form.Height = 768;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);

        }
    }
}
