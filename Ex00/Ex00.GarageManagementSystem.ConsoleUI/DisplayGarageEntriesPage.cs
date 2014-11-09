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
        private List<string> m_VehicleStates;
        private IEnumerable<IGrouping<string, KeyValuePair<string, string>>>  m_VehiclesAndStatesGroupedByState;
        protected override string Title { get { return "Garage Vehicles"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return m_ActionText;} }
        protected string VehicleLicence { get; private set; }

        public DisplayGarageEntriesPage()
            : base()
        {
        }

        public void UpdatePageListAndText()
        {
            m_ActionText = "Choose filter: ";
            StringBuilder l_sb = new StringBuilder();
            l_sb.AppendLine("Filters:");
            m_NumberOfFilters = 0;

            
            try
            {
                //get filters strings
                m_VehiclesAndStatesGroupedByState = GarageObject.GetGarageVehiclesAndStates().GroupBy(pair => pair.Value);
                m_VehicleStates = new List<string>(m_VehiclesAndStatesGroupedByState.Count());
                foreach (IGrouping<string, KeyValuePair<string, string>> vehicleState in m_VehiclesAndStatesGroupedByState)
                {
                    m_VehicleStates.Add(vehicleState.Key);
                    m_NumberOfFilters++;
                }
                l_sb.Append(GetAsChoicesListTexts(m_VehicleStates, 1, out m_NumberOfFilters));
                //add none filter
                m_NumberOfFilters++;
                l_sb.AppendLine(string.Format(ActionDescriptionFormat, m_NumberOfFilters, "Without filtering"));
                m_BodyText = l_sb.ToString();
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
            }
        }

        protected override void TakeAction(string i_Input)
        {
            if (m_ActionText == "")
            {
                UpdatePageListAndText();
                return;
            }

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
                        if (l_FilterChoice == m_NumberOfFilters)
                            UpdateTextToTable("");
                        else
                            UpdateTextToTable(m_VehicleStates.ElementAt(l_FilterChoice-1));
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
                ShouldExitPage = true;
            }
        }
    
        private void UpdateTextToTable(string filter)
        {
            StringBuilder l_sw = new StringBuilder();

            l_sw.AppendLine();
            l_sw.AppendLine("----------------------------------");
            l_sw.AppendLine("| Licence Number | Vehicle State |"); //16, 15 
            l_sw.AppendLine("----------------------------------");

            foreach (IGrouping<string, KeyValuePair<string, string>> group in m_VehiclesAndStatesGroupedByState)
            {
                if (string.IsNullOrEmpty(filter) || 0 == string.Compare(group.Key.Trim(), filter.Trim(), true))
                {
                    foreach (KeyValuePair<string, string> pair in group)
                    {
                        l_sw.AppendLine(string.Format("| {0,-15}| {1,-14}|", pair.Key, pair.Value));
                    }
                }
            }
            l_sw.AppendLine(string.Format("| {0,-15}| {1,-14}|", " ", " "));
            l_sw.AppendLine("----------------------------------");

            m_BodyText = l_sw.ToString();
        }

    }
}
