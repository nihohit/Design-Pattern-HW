using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console page in which the application user fills vehicle fuel tank. 
    /// </summary>
    public class FillFuelPage : ConsoleAppPage
    {
        #region members
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;
        private string m_LicenseNumber;
        private string m_FuelType;

        #endregion members
        #region protected override properties
        protected override string Title
        {
            get
            {
                return "Fill Vehicle Fuel";
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

        #endregion protected override properties
        #region contractor
        public FillFuelPage()
        {
            this.resetPageValues();
        }

        #endregion contractor
        #region override protected methods
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
                            licenceNumberAction(i_Input);
                            break;

                        case 1:
                            fuelTypeAction(i_Input);
                            break;

                        case 2:
                            amountAction(i_Input);
                            break;

                        default:
                            if (m_CurActionIndex == -1)
                            {
                                exitPage();
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

        #endregion override protected methods
        #region private methods
        private void resetPageValues()
        {
            m_BodyText = string.Format("Filling vehicle fuel (to cancel enter '{0}')", k_CancelActionString);
            m_CurActionIndex = 0;
            resetActionTexts();
        }

        private void resetActionTexts()
        {
            string[] actionTexts = { k_VehicleLicenceNumberActionText, "Fuel type: ", "Amount (liters): " };
            m_ActionTexts = actionTexts;
        }

        private void licenceNumberAction(string i_Input)
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
                    m_LicenseNumber = i_Input;
                    m_BodyText = string.Empty;
                    m_CurActionIndex++;
                }
            }
            else
            {
                m_BodyText = errorMsg;
                m_CurActionIndex = -1;
            }
        }

        private void fuelTypeAction(string i_Input)
        {
            m_BodyText = string.Empty;
            m_FuelType = i_Input;
            m_CurActionIndex++;
        }

        private void amountAction(string i_Input)
        {
            m_BodyText = string.Empty;
            float amount = float.Parse(i_Input, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            GarageObject.FillFuel(m_LicenseNumber, m_FuelType, amount);
            m_BodyText = string.Format("Filled {0} liters :)", amount);
            m_CurActionIndex = -1;
        }

        private void exitPage()
        {
            ShouldExitPage = true;
            this.resetPageValues();
        }

        #endregion private methods
    }
}