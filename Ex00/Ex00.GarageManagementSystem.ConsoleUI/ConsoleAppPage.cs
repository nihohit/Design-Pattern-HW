using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using Ex00.GarageLogic;

    public abstract class ConsoleAppPage
    {
        #region consts

        protected const string k_EnterVehicleLicenceNumberActionText = "Enter vehicle licence number: ";
        protected const string k_CancelActionString = "cancel";
        protected const string k_ReturnToMenuActionText = "Press 'Enter' to return to menu";
        protected const string k_GeneralErrorTextFormat = "Something went wrong (ERROR: {0})";
        protected const string k_CannotFindVehicleErrorTextFormat = "Could not find vehicle {0} in the garage records.";
        protected const string k_InvalidActionNumErrorTextFormat = "Invalid {0}! Should choose {1} from list. (ERROR: {2})";
        protected const string k_InvalidInputGeneralErrorTextFormat = "Invalid {0}! (ERROR: {1})";
        protected const string k_ActionDescriptionFormat = "{0}) {1}";

        #endregion consts

        #region properties

        #region protected

        #region abstract

        protected abstract string Title { get; }

        protected abstract string BodyText { get; }

        protected abstract string ActionText { get; }

        #endregion abstract

        protected string TitleLine
        {
            get
            {
                return new string('-', Title.Count());
            }
        }

        protected Garage GarageObject { get; private set; }

        // default value set at the member
        protected bool ShouldExitPage { get; set; }

        // default value set at the member
        protected bool ShouldClearPageText { get; set; }

        #endregion protected

        #endregion properties

        #region Methods

        #region public

        public void OpenPage(Garage i_GarageObject)
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
                    shouldReadLine = true;
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

                TakeAction(input);
            }

            ShouldExitPage = false;
            ShouldClearPageText = true;
        }

        #endregion public

        #region protected

        protected ConsoleAppPage()
        {
            ShouldClearPageText = true;
        }

        #region abstract

        protected abstract void TakeAction(string i_Input);

        #endregion abstract

        protected bool IsVehicleInGarage(string i_Input, out string o_ErrorMsg)
        {
            bool isVehicleInGarage = false;
            o_ErrorMsg = null;
            try
            {
                isVehicleInGarage = GarageObject.IsVehicleInGarage(i_Input);
            }
            catch (Exception ex)
            {
                o_ErrorMsg = string.Format(k_InvalidInputGeneralErrorTextFormat, "licence number", ex.Message);
            }

            return isVehicleInGarage;
        }

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

        #endregion protected

        #endregion Methods
    }
}