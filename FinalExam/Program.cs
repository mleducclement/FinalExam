using FinalExam.Business.Services;

namespace FinalExam {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            MainService.GetInstance().LaunchApp();
        }
    }
}