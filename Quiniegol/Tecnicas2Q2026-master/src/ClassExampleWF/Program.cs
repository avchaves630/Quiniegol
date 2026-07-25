using ClassExampleController;
using ClassExampleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassExampleWF
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var userController = new UserController(new FileHandler<User>());
            var controller = new LoginController(userController);
            var loginFrm = new LoginFrm(controller);
            Application.Run(loginFrm);
        }
    }
}
