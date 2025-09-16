namespace CustomerManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (Properties.Settings.Default.IsFirstRun)
            {
                ResetDatabase(); // Clean/reset your LocalDB
                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }

            Application.Run(new MainForm());
        }

        static void ResetDatabase()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.mdf");
            string freshDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FreshDatabase.mdf");

            try
            {
                // Delete existing DB
                if (File.Exists(dbPath))
                {
                    File.Delete(dbPath);
                }

                // Copy clean DB
                if (File.Exists(freshDbPath))
                {
                    File.Copy(freshDbPath, dbPath);
                }
                else
                {
                    MessageBox.Show("Fresh database file not found at: " + freshDbPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to reset database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}