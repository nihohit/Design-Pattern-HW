using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class DisplayVehicleFullInfoPage : ConsoleAppPage
    {
        private string m_BodyText = "";
        private string m_ActionText = "";
        protected override string Title { get { return "Vehicle Full Info"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return m_ActionText;} }
        protected bool LegalVehicleLicence { get; set; }
        private string m_VehicleLicence = null;
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
            : base()
        {
            VehicleLicence = "";
        }
        
        protected void UpdatePageTexts()
        {
            LegalVehicleLicence = false;
            if (!string.IsNullOrEmpty(VehicleLicence))
            {
                string l_ErrorMsg;
                bool l_IsVehicleInGarage = IsVehicleInGarage(VehicleLicence, out l_ErrorMsg);
                if (string.IsNullOrEmpty(l_ErrorMsg))
                {
                    if (!l_IsVehicleInGarage)
                    {
                        m_BodyText = string.Format(c_CannotFindVehicleErrorTextFormat, VehicleLicence);
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
                            m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                        }
                    }
                }
                m_ActionText = c_ReturnToMenuActionText;
            }
            else
            {
                m_BodyText = "";
                m_ActionText = c_EnterVehicleLicenceNumberActionText;
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
