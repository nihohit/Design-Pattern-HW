using System;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class ChangeStatePage : ConsoleAppPage
    {
        #region private members
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;
        private int m_NumberOfStates;

        #endregion private members
        #region properties
        #region override
        protected override string Title
        {
            get
            {
                return "Change Vehicle State";
            }
        }

        protected override string BodyText
        {
            get
            {
                return m_BodyText;
            }
        }

        protected override string ActionText
        {
            get
            {
                return m_ActionText;
            }
        }

        #endregion override
        #region private
        private string vehicleLicence
        {
            get;
            set;
        }

        #endregion private
        #endregion properties
        #region contractor
        public ChangeStatePage()
        {
            this.resetPageValues();
        }

        #endregion contractor
        #region override methods
        protected override void TakeAction(string i_Input)
        {
            if (i_Input == k_CancelActionString || m_Finished)
            {
                this.exitPage();
            }
            else
            {
                if (string.IsNullOrEmpty(this.vehicleLicence))
                {
                    this.vehicleLicenceAction(i_Input);
                }
                else
                {
                    this.setVehicleState(i_Input);
                    this.setFinishWorkingOnPage();
                }
            }
        }

        #endregion override methods
        #region private methods
        private void resetPageValues()
        {
            m_Finished = false;
            this.vehicleLicence = string.Empty;
            m_BodyText = string.Format("Good job on changing a vehcile state. (to cancel enter '{0}')", k_CancelActionString);
            m_ActionText = k_VehicleLicenceNumberActionText;
        }

        private void updateStatesText()
        {
            m_ActionText = "Choose state:";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("States:");
            m_NumberOfStates = 0;
            stringBuilder.Append(GetAsChoicesListTexts(GarageObject.GetVehiclesStates(), 1, out m_NumberOfStates));
            m_BodyText = stringBuilder.ToString();
        }

        private void vehicleLicenceAction(string i_Input)
        {
            string errorMsg;
            bool isVehicleInGarage = IsVehicleInGarage(i_Input, out errorMsg);
            if (string.IsNullOrEmpty(errorMsg))
            {
                if (!isVehicleInGarage)
                {
                    m_BodyText = string.Format(k_CannotFindVehicleErrorTextFormat, i_Input);
                }
                else
                {
                    this.vehicleLicence = i_Input;
                    this.updateStatesText();
                }
            }
            else
            {
                m_BodyText = errorMsg;
            }
        }

        private void setVehicleState(string i_Input)
        {
            string stateChoice = i_Input;
            int stateChoiceNumber;
            if (int.TryParse(i_Input, out stateChoiceNumber) &&
                stateChoiceNumber > 1 && stateChoiceNumber - 1 < m_NumberOfStates)
            {
                stateChoice = GarageObject.GetVehiclesStates().ElementAt(stateChoiceNumber - 1);
            }

            try
            {
                GarageObject.SetVehicleState(this.vehicleLicence, stateChoice);
                m_BodyText = string.Format("Vehicle state was successfully changed to '{0}'", stateChoice);
            }
            catch (Exception exception)
            {
                m_BodyText = GetExceptionMessage(exception);
            }
        }

        private void setFinishWorkingOnPage()
        {
            m_ActionText = k_ReturnToMenuActionText;
            m_Finished = true;
        }

        private void exitPage()
        {
            ShouldExitPage = true;
            this.resetPageValues();
        }

        #endregion private methods
    }
}