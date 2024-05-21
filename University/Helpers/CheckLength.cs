using University.Data;
using University.Redirects;
using University.Services;
using University.Services.Interfaces;

namespace University.Helpers
{
    internal static class CheckLength
    {
        public static void InputLenthNotLongerThanFifty(string input)
        {
            IShowContent showContent = new ShowContentService();

            if (input.Length > 50)
            {
                showContent.PrintContent(DataContent.ErrorData.InputTooLong);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }
    }
}
