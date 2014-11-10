using System;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class ChangeStatePage : ConsoleAppPage
    {
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;
        private int m_NumberOfStates;

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

        private string vehicleLicence { get; set; }

        public ChangeStatePage()
        {
            this.resetPageValues();
        }

        private void resetPageValues()
        {
            m_Finished = false;
            this.vehicleLicence = string.Empty;
            m_BodyText = string.Format("Good job on changing a vehcile state. (to cancel enter '{0}')", k_CancelActionString);
            m_ActionText = k_EnterVehicleLicenceNumberActionText;
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

        protected override void TakeAction(string i_Input)
        {
            if (i_Input == k_CancelActionString || m_Finished)
            {
                ShouldExitPage = true;
                this.resetPageValues();
            }
            else
            {
                if (string.IsNullOrEmpty(this.vehicleLicence))
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
                else
                {
                    string filterChoice = i_Input;
                    int filterChoiceNumber;
                    if (int.TryParse(i_Input, out filterChoiceNumber) &&
                        filterChoiceNumber > 1 && filterChoiceNumber - 1 < m_NumberOfStates)
                    {
                        filterChoice = GarageObject.GetVehiclesStates().ElementAt(filterChoiceNumber - 1);
                    }

                    try
                    {
                        GarageObject.SetVehicleState(this.vehicleLicence, filterChoice);
                        m_BodyText = string.Format("Vehicle state was successfully changed to '{0}'", filterChoice);
                    }
                    catch (Exception ex)
                    {
                        m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                    }

                    m_ActionText = k_ReturnToMenuActionText;
                    m_Finished = true;
                }
            }
        }
    }
}