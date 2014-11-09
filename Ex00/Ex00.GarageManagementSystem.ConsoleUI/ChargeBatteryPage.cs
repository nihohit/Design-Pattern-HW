using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class ChargeBatteryPage: ConsoleAppPage
    {
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;

        protected override string Title { get { return "Charge Vehicle Battery"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText
        {
            get
            {
                if (m_CurActionIndex < 0)
                    return c_ReturnToMenuActionText;

                return m_ActionTexts[m_CurActionIndex];
            }
        }

        private string m_LicenseNumber;

        public ChargeBatteryPage()
            : base()
        {
            ResetPageValues();
        }

        private void ResetPageValues()
        {
            m_BodyText = string.Format("Charging vehicle (to cancel enter '{0}')", c_CancelActionString);
            m_CurActionIndex = 0;
            ResetActionTexts();
        }

        protected void ResetActionTexts()
        {
            string[] l_ActionTexts = { c_EnterVehicleLicenceNumberActionText,
                                       "Enter amount (minutes): "};
            m_ActionTexts = l_ActionTexts;
        }

        protected override void TakeAction(string i_Input)
        {
            if (i_Input == c_CancelActionString)
            {
                ShouldExitPage = true;
                ResetPageValues();
            }
            else 
            {
                try
                {
                    switch (m_CurActionIndex)
                    {
                        case 0:
                            LicenceNumberAction(i_Input);
                            break;
                        case 1:                            
                            AmountAction(i_Input);
                            break;
                        default:
                            if (m_CurActionIndex == -1)
                            {
                                ShouldExitPage = true;
                                ResetPageValues();
                            }
                            else
                            {
                                m_BodyText = string.Format(c_GeneralErrorTextFormat, "Input corrupted");
                                m_CurActionIndex = -1;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                } 
            }
        }

        private void LicenceNumberAction(string i_Input)
        {
            m_BodyText = "";
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
                    m_LicenseNumber = i_Input;
                    m_CurActionIndex++;
                }
            }
            else
            {
                m_BodyText = l_ErrorMsg;
                m_CurActionIndex = -1;
            }
        }

        private void AmountAction(string i_Input)
        {
            m_BodyText = "";
            try
            {
                float l_amount = float.Parse(i_Input, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                GarageObject.ChargeEngine(m_LicenseNumber, l_amount/60);
                m_CurActionIndex = -1;                
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_InvalidInputGeneralErrorTextFormat, "amount", ex.Message);
                m_CurActionIndex = -1;
            }   
        }
    }
}
