using University.Data;
using University.Redirects;
using University.Services;
using University.Services.Interfaces;

namespace University.Helpers
{
    internal static class CheckInputHelper
    {
        public static void CheckInput(out int newInput)
        {
            IShowContent showContent = new ShowContentService();
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                showContent.PrintContent(DataContent.ErrorData.WrongInput);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            if (String.IsNullOrWhiteSpace(input))
            {
                showContent.PrintContent(DataContent.ErrorData.WrongInput);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            newInput = ConvertInputToInt(input);
        }
        private static int ConvertInputToInt(string input)
        {
            IShowContent showContent = new ShowContentService();
            bool succConvertedToInt = int.TryParse(input, out int convertedNumber);

            if (!succConvertedToInt)
            {
                showContent.PrintContent(DataContent.ErrorData.WrongInput);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            return convertedNumber;
        }
    }
}
