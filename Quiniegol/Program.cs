using Quiniegol.Controllers;
using Quiniegol.Models;
using Quiniegol.Views;
using System;
using System.IO;
using System.Windows.Forms;

namespace Quiniegol
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "Data"));

            if (!Directory.Exists(dataDir))
            {
                dataDir = Path.Combine(baseDir, "Data");
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }
            }

            string usersFile = Path.Combine(dataDir, "users.csv");
            string teamsFile = Path.Combine(dataDir, "teams.csv");
            string matchesFile = Path.Combine(dataDir, "matches.csv");
            string predictionsFile = Path.Combine(dataDir, "predictions.csv");
            string quinielasFile = Path.Combine(dataDir, "quinielas.csv");

            var userHandler = new FileHandler<User>();
            var teamHandler = new FileHandler<Team>();
            var matchHandler = new FileHandler<Match>();
            var predHandler = new FileHandler<Prediction>();
            var quinielaHandler = new FileHandler<Quiniela>();

            var userController = new UserController(userHandler, usersFile);
            var matchController = new MatchController(matchHandler, teamHandler, matchesFile, teamsFile);
            var predictionController = new PredictionController(predHandler, predictionsFile);
            var quinielaController = new QuinielaController(quinielaHandler, quinielasFile);
            var loginController = new LoginController(userController);

            Application.Run(new LoginFrm(loginController, matchController, predictionController, quinielaController));
        }
    }
}
