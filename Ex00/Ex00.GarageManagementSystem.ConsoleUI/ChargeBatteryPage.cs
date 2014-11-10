using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class ChargeBatteryPage : ConsoleAppPage
    {
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;

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

        private string m_LicenseNumber;

        public ChargeBatteryPage()
        {
            this.resetPageValues();
        }

        private void resetPageValues()
        {
            m_BodyText = string.Format("Charging vehicle (to cancel enter '{0}')", k_CancelActionString);
            m_CurActionIndex = 0;
            ResetActionTexts();
        }

        protected void ResetActionTexts()
        {
            string[] actionTexts = { k_EnterVehicleLicenceNumberActionText, "Enter amount (minutes): " };
            m_ActionTexts = actionTexts;
        }

        protected override void TakeAction(string i_Input)
        {
            if (i_Input == k_CancelActionString)
            {
                ShouldExitPage = true;
                this.resetPageValues();
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
                                ShouldExitPage = true;
                                this.resetPageValues();
                            }
                            else
                            {
                                m_BodyText = string.Format(k_GeneralErrorTextFormat, "Input corrupted");
                                m_CurActionIndex = -1;
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
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
            try
            {
                float amount = float.Parse(i_Input, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                GarageObject.ChargeEngine(m_LicenseNumber, amount / 60);
                m_CurActionIndex = -1;
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(k_InvalidInputGeneralErrorTextFormat, "amount", ex.Message);
                m_CurActionIndex = -1;
            }
        }
    }
}