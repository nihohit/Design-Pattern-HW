using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class VehicleAlreadyExistsPage : ConsoleAppPage
    {
        private string m_BodyText = "";
        protected override string Title { get { return string.Format("Vehicle {0} is already in the garage", VehicleLicence); } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return "Choose an action: ";} }
        protected string VehicleLicence { get; private set; }
        public bool VehicleInGarage { get; protected set; }

        public VehicleAlreadyExistsPage(string i_VehicleLicence)
            : base()
        {
            VehicleLicence = i_VehicleLicence; 
            UpdateBodyTextToActionsList();
        }

        protected void UpdateBodyTextToActionsList()
        {
            StringBuilder l_sb = new StringBuilder();
            l_sb.AppendLine("Vehicle state changed to 'Under Repair.'");
            l_sb.AppendLine("Would you like to see vehicle full info ?");
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 1, "Yes"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 2, "No"));
            m_BodyText = l_sb.ToString();
        }



        protected override void TakeAction(string i_Input)
        {
            int l_choice = 0;
            try
            {
                l_choice = Convert.ToInt32(i_Input);
                switch (l_choice)
                {
                    case 1:
                        DisplayVehicleFullInfoPage l_DisplayGarageEntryPage = new DisplayVehicleFullInfoPage();
                        l_DisplayGarageEntryPage.VehicleLicence = VehicleLicence;
                        l_DisplayGarageEntryPage.OpenPage(GarageObject);
                        break;
                    case 2:
                        //do nothing, just exit
                        break;
                    default:
                         m_BodyText = string.Format(c_InvalidInputGeneralErrorTextFormat, "input", "Action choosen is not a number between 1 and 2");
                         break;
                }                
                ShouldExitPage = true;
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_InvalidInputGeneralErrorTextFormat, "input", ex.Message);
            }            
        }


    }
}
