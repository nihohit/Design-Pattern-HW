using Ex00.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class ChangeStatePage: ConsoleAppPage
    {
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;
        private int m_NumberOfStates;
        protected override string Title { get { return "Change Vehicle State"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return m_ActionText;} }
        private string VehicleLicence { get; set; }

        public ChangeStatePage()
            : base()
        {
            ResetPageValues();
        }

        private void ResetPageValues()
        {
            m_Finished = false;
            VehicleLicence = "";
            m_BodyText = string.Format("Good job on changing a vehcile state. (to cancel enter '{0}')", c_CancelActionString);
            m_ActionText = c_EnterVehicleLicenceNumberActionText;
        }

        private void UpdateStatesText()
        {
            m_ActionText = "Choose state:";
            StringBuilder l_sb = new StringBuilder();
            l_sb.AppendLine("States:");
            m_NumberOfStates = 0;
            l_sb.Append(GetEnumActionTexts(typeof(eVehicleState), 1, out m_NumberOfStates));
            m_BodyText = l_sb.ToString();
        
        }
        protected override void TakeAction(string i_Input)
        {
            if (i_Input == c_CancelActionString || m_Finished)
            {
                ShouldExitPage = true;
                ResetPageValues();
            }
            else 
            {
                if (string.IsNullOrEmpty(VehicleLicence))
                {
                    string l_ErrorMsg;
                    bool l_IsVehicleInGarage = IsVehicleInGarage(i_Input, out l_ErrorMsg);
                    if (string.IsNullOrEmpty(l_ErrorMsg))
                    {
                        if (!l_IsVehicleInGarage)
                        {
                            m_BodyText = string.Format(c_CannotFindVehicleErrorTextFormat, i_Input);
                        }
                        else
                        {
                            VehicleLicence = i_Input;
                            UpdateStatesText();
                        }
                    }
                    else
                    {
                        m_BodyText = l_ErrorMsg;
                    }
                }
                else
                {
                    try
                    {
                        eVehicleState l_FilterChoice = (eVehicleState)Convert.ToInt32(i_Input);
                        try
                        {
                            GarageObject.SetVehicleState(VehicleLicence, l_FilterChoice);
                            m_BodyText = string.Format("Vehicle state was successfully changed to {0}", l_FilterChoice);
                        }
                        catch (Exception ex)
                        {
                            m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                        }
                        m_ActionText = c_ReturnToMenuActionText;
                        m_Finished = true;
                    }
                    catch (Exception ex)
                    {
                        m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "state", "state", ex.Message, m_NumberOfStates);
                        m_ActionText = "Choose state:";
                    }
                }
            }
        }
    }
}
