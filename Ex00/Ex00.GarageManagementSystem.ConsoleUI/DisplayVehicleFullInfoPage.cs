using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class DisplayVehicleFullInfoPage : ConsoleAppPage
    {
        private string m_BodyText = string.Empty;
        private string m_ActionText = string.Empty;

        protected override string Title
        {
            get
            {
                return "Vehicle Full Info";
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

        protected bool LegalVehicleLicence { get; set; }

        private string m_VehicleLicence;

        public string VehicleLicence
        {
            get
            {
                return m_VehicleLicence;
            }

            set
            {
                if (m_VehicleLicence != value)
                {
                    m_VehicleLicence = value;
                    UpdatePageTexts();
                }
            }
        }

        public DisplayVehicleFullInfoPage()
        {
            VehicleLicence = string.Empty;
        }

        protected void UpdatePageTexts()
        {
            LegalVehicleLicence = false;
            if (!string.IsNullOrEmpty(VehicleLicence))
            {
                string errorMsg;
                bool isVehicleInGarage = IsVehicleInGarage(VehicleLicence, out errorMsg);
                if (string.IsNullOrEmpty(errorMsg))
                {
                    if (!isVehicleInGarage)
                    {
                        m_BodyText = string.Format(k_CannotFindVehicleErrorTextFormat, VehicleLicence);
                    }
                    else
                    {
                        try
                        {
                            m_BodyText = GarageObject.GetVehicleInfo(VehicleLicence);
                            LegalVehicleLicence = true;
                        }
                        catch (Exception ex)
                        {
                            m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                        }
                    }
                }

                m_ActionText = k_ReturnToMenuActionText;
            }
            else
            {
                m_BodyText = string.Empty;
                m_ActionText = k_EnterVehicleLicenceNumberActionText;
            }
        }

        protected override void TakeAction(string i_Input)
        {
            if (string.IsNullOrEmpty(VehicleLicence))
            {
                VehicleLicence = i_Input;
            }
            else
            {
                ShouldExitPage = true;
            }
        }
    }
}