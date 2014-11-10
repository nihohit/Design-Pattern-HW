using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class FillVehicleWheelsPage : ConsoleAppPage
    {
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;

        protected override string Title
        {
            get
            {
                return "Fill Vehicle Tires";
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

        public FillVehicleWheelsPage()
        {
            this.resetPageValues();
        }

        private void resetPageValues()
        {
            m_Finished = false;
            m_BodyText = string.Format("Lets fill up the tires. (to cancel enter '{0}')", k_CancelActionString);
            m_ActionText = k_EnterVehicleLicenceNumberActionText;
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
                        try
                        {
                            m_BodyText = "Tires filled up :)";
                            GarageObject.FillWheelsToMax(i_Input);
                            m_ActionText = k_ReturnToMenuActionText;
                        }
                        catch (Exception ex)
                        {
                            m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                            m_ActionText = k_ReturnToMenuActionText;
                        }

                        m_Finished = true;
                    }
                }
                else
                {
                    m_BodyText = errorMsg;
                }
            }
        }
    }
}