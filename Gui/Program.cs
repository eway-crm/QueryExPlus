using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QueryExPlus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (DisplayHelpIfNeeded(args))
                    return;
            }
            if (QueryExPlus.Properties.Settings.Default.IsFirstRun)
            {
                QueryExPlus.Properties.Settings.Default.Upgrade();
                QueryExPlus.Properties.Settings.Default.IsFirstRun = false;
                QueryExPlus.Properties.Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }

        static void Default_SettingsSaving(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private static bool DisplayHelpIfNeeded(string[] args)
        {
            CommandLineParams cmdLine = new CommandLineParams(args);
            if (cmdLine["?"] != null ||cmdLine["help"] != null)
            {
                System.Console.WriteLine(string.Format("{0} - {1}", 
                                             AboutForm.AssemblyTitle, 
                                             AboutForm.AssemblyVersion));
                System.Console.WriteLine("-------------------------------------------------------------");
                System.Console.WriteLine("Command Line Arguments");
                System.Console.WriteLine("   -?, -help : Help");
                System.Console.WriteLine("   -cn [connection_name] : Load connection by name");
                System.Console.WriteLine("   -s [SQL_Server_Name] : Connect to SQL Server by Name");
                System.Console.WriteLine("   -os [Oracle_Data_Source] : Connect to Oracle by Data Source Name");
                System.Console.WriteLine("   -e : Use Trusted Connection");
                System.Console.WriteLine("   -u [User_Name] : User Name");
                System.Console.WriteLine("   -p [Password] : Password");
                System.Console.WriteLine("   -i [FileName] : Open SQL File");
                return true;
            }
            return false;
        }
    }
}