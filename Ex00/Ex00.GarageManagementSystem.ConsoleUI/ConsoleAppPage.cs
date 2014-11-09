using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public abstract class ConsoleAppPage
    {
        #region consts
        protected const string c_EnterVehicleLicenceNumberActionText = "Enter vehicle licence number: "; 
        protected const string c_CancelActionString = "cancel"; 
        protected const string c_ReturnToMenuActionText = "Press 'Enter' to return to menu";
        protected const string c_GeneralErrorTextFormat = "Something went wrong (ERROR: {0})";
        protected const string c_CannotFindVehicleErrorTextFormat = "Could not find vehicle {0} in the garage records.";
        protected const string c_InvalidActionNumErrorTextFormat = "Invalid {0}! Should choose {1} from list. (ERROR: {2})";
        protected const string c_InvalidInputGeneralErrorTextFormat = "Invalid {0}! (ERROR: {1})";
        protected const string ActionDescriptionFormat = "{0}) {1}"; 

        #endregion consts

        #region members

        private bool m_ShouldExitPage = false;
        private bool m_ShouldClearPageText = true;
        
        #endregion members

        #region properties

        #region protected

        #region abstract
        protected abstract string Title { get; }
        protected abstract string BodyText { get; }
        protected abstract string ActionText { get; }
        #endregion abstract

        protected string TitleLine { get { return new String('-', Title.Count()); } }
        protected Ex00.GarageLogic.Garage GarageObject { get; private set; }

        //default value set at the member
        protected bool ShouldExitPage { get { return m_ShouldExitPage; } set { m_ShouldExitPage = value; } }
        //default value set at the member
        protected bool ShouldClearPageText { get { return m_ShouldClearPageText; } set { m_ShouldClearPageText = value; } }
        
       #endregion protected
        

        #endregion properties

        #region Methods
        #region public

        public void OpenPage(Ex00.GarageLogic.Garage i_GarageObject)
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

                bool l_ShouldReadLine = false;
                if (!string.IsNullOrWhiteSpace(BodyText))
                {
                    Console.WriteLine(BodyText);
                    Console.WriteLine();
                    l_ShouldReadLine = true;
                }
                if (!string.IsNullOrWhiteSpace(ActionText))
                {
                    Console.Write(ActionText);
                    l_ShouldReadLine = true;
                }

                string l_Input = l_ShouldReadLine ? Console.ReadLine() : "";
                if (l_ShouldReadLine)
                    Console.WriteLine();

                TakeAction(l_Input);
            }

            ShouldExitPage = false;
            ShouldClearPageText = true;
        }
        
        #endregion public
        #region protected
        #region abstract
        protected abstract void TakeAction(string i_Input);

        #endregion abstract
        
        protected bool IsVehicleInGarage(string i_Input, out string o_ErrorMsg)
        {
            bool l_IsVehicleInGarage = false;
            o_ErrorMsg = null;
            try
            {
                l_IsVehicleInGarage = GarageObject.IsVehicleInGarage(i_Input);
            }
            catch (Exception ex)
            {
                o_ErrorMsg = string.Format(c_InvalidInputGeneralErrorTextFormat, "licence number", ex.Message);
            }
            return l_IsVehicleInGarage;
        }

        
        protected string GetAsChoicesListTexts(IEnumerable<string> i_choices, int i_StartIndex, out int o_NumberOfChoices)
        {
            StringBuilder l_sb = new StringBuilder();
            o_NumberOfChoices = 0;
            foreach (string choice in i_choices)
            {
                l_sb.AppendLine(string.Format(ActionDescriptionFormat, o_NumberOfChoices + i_StartIndex, choice));
                o_NumberOfChoices++;
            }
            return l_sb.ToString();
        }
        
        #endregion protected
        #endregion Methods

    }
}
