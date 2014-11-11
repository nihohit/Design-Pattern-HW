using System;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class VehicleAlreadyExistsPage : ConsoleAppPage
    {
        private string m_BodyText = string.Empty;

        protected override string Title
        {
            get
            {
                return string.Format("Vehicle {0} is already in the garage", VehicleLicence);
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
                return "Choose an action: ";
            }
        }

        protected string VehicleLicence { get; private set; }

        public bool VehicleInGarage { get; protected set; }

        public VehicleAlreadyExistsPage(string i_VehicleLicence)
        {
            VehicleLicence = i_VehicleLicence;
            UpdateBodyTextToActionsList();
        }

        protected void UpdateBodyTextToActionsList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicle state changed to 'Under Repair.'");
            sb.AppendLine("Would you like to see vehicle full info ?");
            sb.AppendLine(string.Format(k_ActionDescriptionFormat, 1, "Yes"));
            sb.AppendLine(string.Format(k_ActionDescriptionFormat, 2, "No"));
            m_BodyText = sb.ToString();
        }

        protected override void TakeAction(string i_Input)
        {
            try
            {
                int choice = Convert.ToInt32(i_Input);
                switch (choice)
                {
                    case 1:
                        DisplayVehicleFullInfoPage displayGarageEntryPage = new DisplayVehicleFullInfoPage();
                        displayGarageEntryPage.VehicleLicence = VehicleLicence;
                        displayGarageEntryPage.OpenPage(GarageObject);
                        break;

                    case 2:
                        // do nothing, just exit
                        break;

                    default:
                        m_BodyText = string.Format(k_InvalidInputGeneralErrorTextFormat, "input", "Action choosen is not a number between 1 and 2");
                        break;
                }

                ShouldExitPage = true;
            }
            catch (Exception exception)
            {
                m_BodyText = GetExceptionMessage(exception);
            }
        }
    }
}