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
        
        private bool Finished { get; set; }
        public string VehicleLicence { get; set; }
     
        public DisplayVehicleFullInfoPage()
        {
            VehicleLicence = string.Empty;
        }

        protected void UpdatePageTexts()
        {
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
                        }
                        catch (Exception exception)
                        {
                            m_BodyText = GetExceptionMessage(exception);
                        }
                    }
                }

                m_ActionText = k_ReturnToMenuActionText;
                Finished = true;
            }
            else
            {
                m_BodyText = string.Empty;
                m_ActionText = k_VehicleLicenceNumberActionText;
            }
        }

        protected override void TakeAction(string i_Input)
        { 
            if (string.IsNullOrEmpty(VehicleLicence))
            {
                VehicleLicence = i_Input;
            }

            if (Finished)
            {
                Finished = false;
                ShouldExitPage = true;
            }

            UpdatePageTexts();
        }
    }
}