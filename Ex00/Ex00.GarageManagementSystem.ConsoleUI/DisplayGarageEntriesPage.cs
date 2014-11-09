using Ex00.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    class DisplayGarageEntriesPage: ConsoleAppPage
    {
        private string m_BodyText = "";
        private string m_ActionText = "";
        private bool m_ChooseFilterMode = true;
        private int m_NumberOfFilters;
        protected override string Title { get { return "Garage Vehicles"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return m_ActionText;} }
        protected string VehicleLicence { get; private set; }

        public DisplayGarageEntriesPage()
            : base()
        {
            ResetPageText();
        }

        private void ResetPageText()
        {
            m_ActionText = "Choose filter: ";
            StringBuilder l_sb = new StringBuilder();
            l_sb.AppendLine("Filters:");
            m_NumberOfFilters = 0;
            l_sb.Append(GetEnumActionTexts(typeof(eVehicleState), 1, out m_NumberOfFilters));
            m_NumberOfFilters++;
            l_sb.AppendLine(string.Format(ActionDescriptionFormat, m_NumberOfFilters, "None"));
            m_BodyText = l_sb.ToString();
        }

        protected override void TakeAction(string i_Input)
        {
            if (m_ChooseFilterMode)
            {
                try
                {
                    int l_FilterChoice = Convert.ToInt32(i_Input);
                    if ((l_FilterChoice < 1) || (l_FilterChoice > m_NumberOfFilters))
                    {
                        m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "filter", "filter", string.Format("Filter number out of range 1:{0}", m_NumberOfFilters));
                    }
                    else
                    {
                        try
                        {
                            IEnumerable<KeyValuePair<string, eVehicleState>> l_VehiclesAndStates = GarageObject.GetGarageVehiclesAndStates();
                            if (l_FilterChoice == m_NumberOfFilters)
                                UpdateTextToTable(l_VehiclesAndStates);
                            else
                            {
                                IEnumerable<IGrouping<eVehicleState, KeyValuePair<string, eVehicleState>>> l_VehiclesAndStatesGroupedByState =
                                    l_VehiclesAndStates.GroupBy(pair => pair.Value);
                                IEnumerable<KeyValuePair<string, eVehicleState>> l_VehiclesAndStatesFiltered = l_VehiclesAndStatesGroupedByState.First(group => group.Key == (eVehicleState)l_FilterChoice);
                                UpdateTextToTable(l_VehiclesAndStatesFiltered);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is InvalidOperationException || ex is ArgumentNullException)
                            {
                                IEnumerable<KeyValuePair<string, eVehicleState>> l_VehiclesAndStatesFiltered = new List<KeyValuePair<string, eVehicleState>>();
                                UpdateTextToTable(l_VehiclesAndStatesFiltered);
                            }
                            else
                                m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    if (ex is OverflowException || ex is FormatException)
                        m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "vehicle type", "type", ex.Message);
                    else
                    {
                        m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                    }
                }
                m_ChooseFilterMode = false;
                m_ActionText = c_ReturnToMenuActionText;
            }
            else
            {
                ResetPageText();
                ShouldExitPage = true;
            }
        }
    
        private void UpdateTextToTable(IEnumerable<KeyValuePair<string, eVehicleState>> i_VehiclesToDisplay)
        {
            StringBuilder l_sw = new StringBuilder();

            l_sw.AppendLine();
            l_sw.AppendLine("----------------------------------");
            l_sw.AppendLine("| Licence Number | Vehicle State |"); //16, 15 
            l_sw.AppendLine("----------------------------------");

            foreach (KeyValuePair<string, eVehicleState> pair in i_VehiclesToDisplay)
            {

                l_sw.AppendLine(string.Format("| {0,-15}| {1,-14}|", pair.Key, pair.Value));

            }
            l_sw.AppendLine(string.Format("| {0,-15}| {1,-14}|", " ", " "));
            l_sw.AppendLine("----------------------------------");

            m_BodyText = l_sw.ToString();
        }

    }
}
