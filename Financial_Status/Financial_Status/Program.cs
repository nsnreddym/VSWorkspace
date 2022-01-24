using Globals;
namespace Financial_Status
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            if (args.Length > 0)
            {
                if (args[0] == "bypass")
                {
                    GlobalVar.logrequired = false;
                }
                else
                {
                    GlobalVar.logrequired = true;
                }
            }
            else
            {
                GlobalVar.logrequired = true;
            }
            Application.Run(new MainForm());
        }
    }
}