using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected override string Title { get { return "Garage Management"; } }
        protected override string BodyText { get { return m_BodyText; } }
        protected override string ActionText { get {return "Choose an action: ";} }
        #endregion override
        #endregion protected
        #endregion Properties

        #region constractor
        public GarageManagmentMainPage() : base()
        {
            UpdateBodyTextToActionsList();
        }
        #endregion constractor

        #region Methods
        #region protected
        #region override
        protected override void TakeAction(string i_Input)
        {
            int l_choice = 0;
            try
            {
                l_choice = Convert.ToInt32(i_Input);
                switch (l_choice)
                {
                    case 1:
                        AddVehiclePage l_AddVehiclePage = new AddVehiclePage();
                        l_AddVehiclePage.OpenPage(GarageObject);
                        break;
                    case 2:
                        DisplayGarageEntriesPage l_DisplayGarageEntriesPage = new DisplayGarageEntriesPage();
                        l_DisplayGarageEntriesPage.OpenPage(GarageObject);
                        break;
                    case 3:
                        ChangeStatePage l_ChangeStatePage = new ChangeStatePage();
                        l_ChangeStatePage.OpenPage(GarageObject);
                        break;
                    case 4:
                        FillVehicleWheelsPage l_FillVehicleWheelsPage = new FillVehicleWheelsPage();
                        l_FillVehicleWheelsPage.OpenPage(GarageObject);
                        break;
                    case 5:
                        FillFuelPage l_FillFuelPage = new FillFuelPage();
                        l_FillFuelPage.OpenPage(GarageObject);
                        break;
                    case 6:
                        ChargeBatteryPage l_ChargeBatteryPage = new ChargeBatteryPage();
                        l_ChargeBatteryPage.OpenPage(GarageObject);
                        break;
                    case 7:
                        DisplayVehicleFullInfoPage l_DisplayGarageEntryPage = new DisplayVehicleFullInfoPage();
                        l_DisplayGarageEntryPage.OpenPage(GarageObject);
                        break;
                    case 8:
                        ShouldExitPage = true;
                        break;
                    default:
                        throw new FormatException("Action choosen is not a number between 1 and 8");
                }
                UpdateBodyTextToActionsList();
                ShouldClearPageText = true;
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_InvalidInputGeneralErrorTextFormat, "input", ex.Message);
            }
        }
        #endregion override
        #endregion protected
        #region private
        private void UpdateBodyTextToActionsList()
        {
            StringBuilder l_sb = new StringBuilder();            
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 1, "Add new vehicle to the garage"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 2, "Display the licence of all vehicles in the garage according to state"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 3, "Change vehicle state"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 4, "Fill vehicle tires"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 5, "Fill vehicle fuel"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 6, "Charge vehicle battery"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 7, "Display vehicle full info"));
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, 8, "Exit without save"));
            m_BodyText = l_sb.ToString();
        }
        #endregion private
        #endregion Methods
    }
}
