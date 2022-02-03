using Globals;
namespace Financial_Status
{
    internal static class Program
    {
        static public void Settings_Read()
        {
            StreamReader sw;
            int index;
            int index2;
            string str;
            sw = File.OpenText(".\\Settings.ini");
            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.Length - index - 1;
            GlobalVar.DataBasePath = str.Substring(index + 1, index2);
            sw.Close();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            string path = @".\Settings.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Settings File not exist");
                return;
            }
            Settings_Read();

            if (!File.Exists(GlobalVar.DataBasePath))
            {
                MessageBox.Show("Database File not exist");
                return;
            }

            if (args.Length > 0)
            {
                if (args[0] == "bypass")
                {
                    GlobalVar.logrequired = false;
                    Application.Run(new MainForm());
                }
                else
                {
                    GlobalVar.logrequired = true;
                    Application.Run(new Login());
                }
            }
            else
            {
                GlobalVar.logrequired = true;
                Application.Run(new Login());
            }
            
        }
    }
}