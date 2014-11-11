using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console page in which the application user fills up to max air presure vehicle wheels.
    /// </summary>
    public class FillVehicleWheelsPage : ConsoleAppPage
    {
        #region members
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;

        #endregion members
        #region override protected properties
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

        #endregion override protected properties
        #region contractor
        public FillVehicleWheelsPage()
        {
            resetPageValues();
        }

        #endregion contractor
        #region override protected methods
        protected override void TakeAction(string i_Input)
        {
            if (i_Input == k_CancelActionString || m_Finished)
            {
                exitPage();
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
                        catch (Exception exception)
                        {
                            m_BodyText = GetExceptionMessage(exception);
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

        private void exitPage()
        {
            ShouldExitPage = true;
            resetPageValues();
        }

        #endregion override protected methods
        #region private methods
        private void resetPageValues()
        {
            m_Finished = false;
            m_BodyText = string.Format("Lets fill up the tires. (to cancel enter '{0}')", k_CancelActionString);
            m_ActionText = k_VehicleLicenceNumberActionText;
        }
        #endregion private methods
    }
}