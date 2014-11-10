using System;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console main page in a garage mangement application (memmory is per run)
    /// </summary>
    public class GarageManagmentMainPage : ConsoleAppPage
    {
        #region members

        #region private

        private string m_BodyText;

        #endregion private

        #endregion members

        #region Properties

        #region protected

        #region override

        protected override string Title
        {
            get
            {
                return "Garage Management";
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

        #endregion override

        #endregion protected

        #endregion Properties

        #region constractor

        public GarageManagmentMainPage()
        {
            this.updateBodyTextToActionsList();
        }

        #endregion constractor

        #region Methods

        #region protected

        #region override

        protected override void TakeAction(string i_Input)
        {
            try
            {
                int choice = Convert.ToInt32(i_Input);
                switch (choice)
                {
                    case 1:
                        AddVehiclePage addVehiclePage = new AddVehiclePage();
                        addVehiclePage.OpenPage(GarageObject);
                        break;

                    case 2:
                        DisplayGarageEntriesPage displayGarageEntriesPage = new DisplayGarageEntriesPage();
                        displayGarageEntriesPage.OpenPage(GarageObject);
                        break;

                    case 3:
                        ChangeStatePage changeStatePage = new ChangeStatePage();
                        changeStatePage.OpenPage(GarageObject);
                        break;

                    case 4:
                        FillVehicleWheelsPage fillVehicleWheelsPage = new FillVehicleWheelsPage();
                        fillVehicleWheelsPage.OpenPage(GarageObject);
                        break;

                    case 5:
                        FillFuelPage fillFuelPage = new FillFuelPage();
                        fillFuelPage.OpenPage(GarageObject);
                        break;

                    case 6:
                        ChargeBatteryPage chargeBatteryPage = new ChargeBatteryPage();
                        chargeBatteryPage.OpenPage(GarageObject);
                        break;

                    case 7:
                        DisplayVehicleFullInfoPage displayGarageEntryPage = new DisplayVehicleFullInfoPage();
                        displayGarageEntryPage.OpenPage(GarageObject);
                        break;

                    case 8:
                        ShouldExitPage = true;
                        break;

                    default:
                        throw new FormatException("Action choosen is not a number between 1 and 8");
                }

                this.updateBodyTextToActionsList();
                ShouldClearPageText = true;
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(k_InvalidInputGeneralErrorTextFormat, "input", ex.Message);
            }
        }

        #endregion override

        #endregion protected

        #region private

        private void updateBodyTextToActionsList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 1, "Add new vehicle to the garage"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 2, "Display the licence of all vehicles in the garage according to state"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 3, "Change vehicle state"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 4, "Fill vehicle tires"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 5, "Fill vehicle fuel"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 6, "Charge vehicle battery"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 7, "Display vehicle full info"));
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, 8, "Exit without save"));
            m_BodyText = stringBuilder.ToString();
        }

        #endregion private

        #endregion Methods
    }
}