using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityMap;
using BizCare.Repository;

namespace BizCare.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DialogResult result;

            var registry = new RepositoryRegistry();
            registry.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new LoginUI())
                result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Run(new MainUI());
            }

            //Application.Run(new MainUI());

        }
    }
}
