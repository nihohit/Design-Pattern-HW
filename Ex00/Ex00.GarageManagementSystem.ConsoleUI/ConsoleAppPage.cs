using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using Ex00.GarageLogic;

    /// <summary>
    /// Console page base.ALL console pages should inherit it.
    /// Holds the lyout logic, general messages format, openpage logic etc...
    /// </summary>
    public abstract class ConsoleAppPage
    {
        #region action text consts
        protected const string k_VehicleLicenceNumberActionText = "Vehicle licence number: ";
        protected const string k_CancelActionString = "cancel";
        protected const string k_ReturnToMenuActionText = "Press 'Enter' to return to menu";
        protected const string k_TryAgainActionText = "Try again or enter '" + k_CancelActionString + "'";

        #endregion action text consts
        #region body text consts
        protected const string k_ActionDescriptionFormat = "{0}) {1}";

        #endregion consts
        #region error consts
        protected const string k_GeneralErrorTextFormat = "Error: {0}";
        protected const string k_CannotFindVehicleErrorTextFormat = "Could not find vehicle {0} in the garage records.";
        protected const string k_ActionOutOfActionListErrorTextFormat = "Must choose action from the list above";
        protected const string k_FormatExceptionTextFormat = "Format Error: {0}";
        protected const string k_ArgumentExceptionTextFormat = "Argument Error: {0}";
        protected const string k_ValueOutOfRangeExceptionTextFormat = "Out of Range Error: {0}";

        #endregion error consts
        #region properties
        #region protected
        #region abstract
        /// <summary>
        /// The page title
        /// </summary>
        protected abstract string Title { get; }

        /// <summary>
        /// Text shown on the screen above the action text. 
        /// The text is to give the user information and not to ask for information.
        /// The opposite to the action text
        /// </summary>
        protected abstract string BodyText { get; }

        /// <summary>
        /// Text shown on the screen and informs the user what to do.
        /// It is for asking for information from the user.
        /// The opposite to BodyText
        /// </summary>
        protected abstract string ActionText { get; }

        #endregion abstract

        /// <summary>
        /// line to be shown under the title. its size is as the text of the title
        /// </summary>
        protected string TitleLine
        {
            get
            {
                return new string('-', Title.Count());
            }
        }
        
        /// <summary>
        /// Holds the data and logic of garage
        /// </summary>
        protected ICommunicateWithConsole GarageObject { get; private set; }

        /// <summary>
        /// used in OpenPage method to detrmine that the page should be closed.
        /// </summary>
        protected bool ShouldExitPage { get; set; }
        
        /// <summary>
        /// used in OpenPage method to detrmine that the console should be cleared before current BodyText and ActionText are printed to the console.
        /// </summary>
        protected bool ShouldClearPageText { get; set; }

        #endregion protected
        #endregion properties
        #region constractor
        protected ConsoleAppPage()
        {
            ShouldClearPageText = true;
        }

        #endregion constractor        
        #region Methods
        #region public
        /// <summary>
        /// Open the page on the console.
        /// Garage object that contain all the logic and data is given and updated in this method
        /// </summary>
        /// <param name="i_GarageObject">object that contain all the logic and data of garage</param>
        public void OpenPage(ICommunicateWithConsole i_GarageObject)
        {
            GarageObject = i_GarageObject;

            while (!ShouldExitPage)
            {
                if (ShouldClearPageText)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(Title);
                    Console.WriteLine(TitleLine);
                    Console.WriteLine();

                    ShouldClearPageText = false;
                }

                bool shouldReadLine = false;
                if (!string.IsNullOrWhiteSpace(BodyText))
                {
                    Console.WriteLine(BodyText);
                    Console.WriteLine();
                }

                if (!string.IsNullOrWhiteSpace(ActionText))
                {
                    Console.Write(ActionText);
                    shouldReadLine = true;
                }

                string input = shouldReadLine ? Console.ReadLine() : string.Empty;
                if (shouldReadLine)
                {
                    Console.WriteLine();
                }

                TakeAction(input.Trim());
            }

            ShouldExitPage = false;
            ShouldClearPageText = true;
            GarageObject = null;
        }

        #endregion public
        #region abstract (protected)
        /// <summary>
        /// Do the action the user choose to do
        /// This is called from OpenPage method in parent
        /// </summary>
        /// <param name="i_Input">user input</param>
        protected abstract void TakeAction(string i_Input);

        #endregion abstract (protected)
        #region protected
        /// <summary>
        /// Checks if vehicle is in garage object, all pages that handle a vehicle should use this method
        /// </summary>
        /// <param name="i_Input">user input after asked for licence number of vehicle</param>
        /// <param name="o_ErrorMsg"></param>
        /// <returns></returns>
        protected bool IsVehicleInGarage(string i_Input, out string o_ErrorMsg)
        {
            bool isVehicleInGarage = false;
            o_ErrorMsg = null;
            try
            {
                isVehicleInGarage = GarageObject.IsVehicleInGarage(i_Input);
            }
            catch (Exception exception)
            {
                o_ErrorMsg = GetExceptionMessage(exception);
            }

            return isVehicleInGarage;
        }

        /// <summary>
        /// Should allways use this method inorder to show choices to the user in the same format for all pages
        /// It will be easier to change the format if needed this way :)
        /// </summary>
        /// <param name="i_Choices">choices strings</param>
        /// <param name="i_StartIndex">what will be the first index in this choices list</param>
        /// <param name="o_NumberOfChoices"></param>
        /// <returns></returns>
        protected string GetAsChoicesListTexts(IEnumerable<string> i_Choices, int i_StartIndex, out int o_NumberOfChoices)
        {
            StringBuilder stringBuilder = new StringBuilder();
            o_NumberOfChoices = 0;
            foreach (string choice in i_Choices)
            {
                stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, o_NumberOfChoices + i_StartIndex, choice));
                o_NumberOfChoices++;
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Should allways use this method inorder to have the same exception message format for all pages
        /// if the exception should not make the user leave the page use GetTryAgainWithExceptionMsgBodyText
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>exception error message to show on the page</returns>
        protected string GetExceptionMessage(Exception exception)
        {
            string errorMsg = string.Empty;
            if (exception is FormatException)
            {
                errorMsg = k_FormatExceptionTextFormat.FormatWith(exception.Message);
            }
            else if (exception is ArgumentException)
            {
                errorMsg = k_ArgumentExceptionTextFormat.FormatWith(exception.Message);
            }
            else if (exception is ValueOutOfRangeException)
            {
                errorMsg = k_ValueOutOfRangeExceptionTextFormat.FormatWith(exception.Message);
            }
            else
            {
                errorMsg = k_GeneralErrorTextFormat.FormatWith(exception.Message);
            }

            return errorMsg;
        }

        /// <summary>
        /// Get the message to show the user if an exception occured, but the user can stay in the page and try again
        /// Should allways use this method when exception should not close the page to have the same format message in all pages
        /// Uses GetExceptionMessage inorder to have the same exception message format for all pages
        /// </summary>
        /// <param name="i_Choices"></param>
        /// <param name="i_StartIndex"></param>
        /// <param name="o_NumberOfChoices"></param>
        /// <returns></returns>
        protected string GetTryAgainWithExceptionMsgBodyText(Exception exception)
        {
            string bodyText = "-----------------------------------------------\n";
            bodyText += GetExceptionMessage(exception);
            bodyText += "\n\n" + k_TryAgainActionText;
            return bodyText;
        }

        #endregion protected
        #endregion Methods
    }
}