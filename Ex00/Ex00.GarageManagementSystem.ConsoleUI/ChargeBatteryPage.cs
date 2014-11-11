using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console page in which the application user charge an electric vehicle 
    /// </summary>
    public class ChargeBatteryPage : ConsoleAppPage
    {
        #region private members
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;
        private string m_LicenseNumber;

        #endregion private members
        #region properties
        #region override
        protected override string Title
        {
            get
            {
                return "Charge Vehicle Battery";
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
                if (m_CurActionIndex < 0)
                {
                    return k_ReturnToMenuActionText;
                }

                return m_ActionTexts[m_CurActionIndex];
            }
        }

        #endregion override
        #endregion properties
        #region contractor
        public ChargeBatteryPage()
        {
            this.resetPageValues();
        }
        
        #endregion contractor
        #region override methods
        protected override void TakeAction(string i_Input)
        {
            if (i_Input == k_CancelActionString)
            {
                this.exitPage();
            }
            else
            {
                try
                {
                    switch (m_CurActionIndex)
                    {
                        case 0:
                            this.licenceNumberAction(i_Input);
                            break;

                        case 1:
                            this.amountAction(i_Input);
                            break;

                        default:
                            if (m_CurActionIndex == -1)
                            {
                                this.exitPage();
                            }
                            else
                            {
                                // should never get here (by code logic)! if got here something gone really wrong :(
                                throw new Exception("Unknown action");
                            }

                            break;
                    }
                }
                catch (Exception exception)
                {
                    m_BodyText = GetTryAgainWithExceptionMsgBodyText(exception);
                    m_CurActionIndex = 0;
                }
            }
        }

        #endregion override methods
        #region private methods
        private void exitPage()
        {
            ShouldExitPage = true;
            this.resetPageValues();
        }

        private void resetPageValues()
        {
            m_BodyText = string.Format("Charging vehicle (to cancel enter '{0}')", k_CancelActionString);
            m_CurActionIndex = 0;
            resetActionTexts();
        }

        private void resetActionTexts()
        {
            string[] actionTexts = { k_VehicleLicenceNumberActionText, "Enter amount (minutes): " };
            m_ActionTexts = actionTexts;
        }
        
        private void licenceNumberAction(string i_Input)
        {
            m_BodyText = string.Empty;
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
                    m_LicenseNumber = i_Input;
                    m_CurActionIndex++;
                }
            }
            else
            {
                m_BodyText = errorMsg;
                m_CurActionIndex = -1;
            }
        }

        private void amountAction(string i_Input)
        {
            m_BodyText = string.Empty;
            float amount = float.Parse(i_Input, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            GarageObject.ChargeEngine(m_LicenseNumber, amount);
            m_CurActionIndex = -1;
        }

        #endregion private methods
    }
}