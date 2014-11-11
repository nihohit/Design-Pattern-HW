using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    internal class DisplayGarageEntriesPage : ConsoleAppPage
    {
        private string m_BodyText = string.Empty;
        private string m_ActionText = string.Empty;
        private bool m_ChooseFilterMode = true;
        private int m_NumberOfFilters;
        private List<string> m_VehicleStates;
        private IEnumerable<IGrouping<string, KeyValuePair<string, string>>> m_VehiclesAndStatesGroupedByState;

        protected override string Title
        {
            get
            {
                return "Garage Vehicles";
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

        public void UpdatePageListAndText()
        {
            m_ActionText = "Choose filter: ";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Filters:");
            m_NumberOfFilters = 0;

            try
            {
                // get filters strings
                m_VehiclesAndStatesGroupedByState = GarageObject.GetGarageVehiclesAndStates().GroupBy(i_Pair => i_Pair.Value);
                m_VehicleStates = new List<string>(m_VehiclesAndStatesGroupedByState.Count());
                foreach (IGrouping<string, KeyValuePair<string, string>> vehicleState in m_VehiclesAndStatesGroupedByState)
                {
                    m_VehicleStates.Add(vehicleState.Key);
                    m_NumberOfFilters++;
                }

                stringBuilder.Append(GetAsChoicesListTexts(m_VehicleStates, 1, out m_NumberOfFilters));

                // add none filter
                m_NumberOfFilters++;
                stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, m_NumberOfFilters, "Without filtering"));
                m_BodyText = stringBuilder.ToString();
            }
            catch (Exception exception)
            {
                m_BodyText = GetExceptionMessage(exception);
            }
        }

        protected override void TakeAction(string i_Input)
        {
            if (m_ActionText == string.Empty)
            {
                UpdatePageListAndText();
                return;
            }

            if (m_ChooseFilterMode)
            {
                try
                {
                    int filterChoice = Convert.ToInt32(i_Input);
                    if ((filterChoice < 1) || (filterChoice > m_NumberOfFilters))
                    {
                        m_BodyText = k_ActionOutOfActionListErrorTextFormat;
                    }
                    else
                    {
                        if (filterChoice == m_NumberOfFilters)
                        {
                            this.updateTextToTable(string.Empty);
                        }
                        else
                        {
                            this.updateTextToTable(m_VehicleStates.ElementAt(filterChoice - 1));
                        }
                    }
                }
                catch (Exception exception)
                {
                    m_BodyText = GetExceptionMessage(exception);
                }

                m_ChooseFilterMode = false;
                m_ActionText = k_ReturnToMenuActionText;
            }
            else
            {
                ShouldExitPage = true;
            }
        }

        private void updateTextToTable(string i_Filter)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("----------------------------------");
            stringBuilder.AppendLine("| Licence Number | Vehicle State |");
            stringBuilder.AppendLine("----------------------------------");

            foreach (IGrouping<string, KeyValuePair<string, string>> group in m_VehiclesAndStatesGroupedByState)
            {
                if (string.IsNullOrEmpty(i_Filter) || 0 == string.Compare(@group.Key.Trim(), i_Filter.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    foreach (KeyValuePair<string, string> pair in group)
                    {
                        stringBuilder.AppendLine(string.Format("| {0,-15}| {1,-14}|", pair.Key, pair.Value));
                    }
                }
            }

            stringBuilder.AppendLine(string.Format("| {0,-15}| {1,-14}|", " ", " "));
            stringBuilder.AppendLine("----------------------------------");

            m_BodyText = stringBuilder.ToString();
        }
    }
}