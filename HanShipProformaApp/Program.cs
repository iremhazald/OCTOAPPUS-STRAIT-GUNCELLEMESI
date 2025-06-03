namespace HanShipProformaApp
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
            //Application.Run(new ResultPanel("deneme", "emir", "Turkey", 12315, 24066, 182.50, 32.20, 12.66, "Marmara OPET", "Turkey", "Turkey", "Turkey", 35.51, 1.03, 123456, 44995, "Loading",2, "Crude oil and petroleum products",23000));
            Application.Run(new BeginningPanel());
        }
    }
}