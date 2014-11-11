using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console page in which the application user can display the vehicles in the garage (licence number) and their state.
    /// vehicles can be filtered according to their state (show only vehicles of specific state)
    /// </summary>
    public class DisplayGarageEntriesPage : ConsoleAppPage
    {
        #region consts
        private const string k_NoFillterActionText = "None";

        #endregion consts
        #region members 
        private string m_BodyText;
        private string m_ActionText;
        private bool m_ChooseFilterMode;
        private int m_NumberOfFilters;
        private List<string> m_VehicleStates;
        private IEnumerable<IGrouping<string, KeyValuePair<string, string>>> m_VehiclesAndStatesGroupedByState;
        
        #endregion members 
        #region Properties
        #region abstract (protected)
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
        #endregion abstract (protected)
        #endregion Properties
        #region contractor
        public DisplayGarageEntriesPage()
        {
            m_BodyText = string.Empty;
            m_ActionText = string.Empty;
            m_ChooseFilterMode = true;
            m_NumberOfFilters = 0;
        }

        #endregion contractor
        #region ovveride (protected) methods
        protected override void TakeAction(string i_Input)
        {
            if (m_ActionText == string.Empty)
            {
                updatePageListAndText();
                return;
            }

            if (m_ChooseFilterMode)
            {
                try
                {
                    int filterChoice = getFilterChoiceFromInput(i_Input);
                    if (filterChoice == m_NumberOfFilters || 0 == string.Compare(k_NoFillterActionText, i_Input, StringComparison.OrdinalIgnoreCase))
                    {
                        this.updateTextToTable(string.Empty);
                    }
                    else
                    {
                        this.updateTextToTable(m_VehicleStates.ElementAt(filterChoice - 1));
                    }

                    m_ChooseFilterMode = false;
                    m_ActionText = k_ReturnToMenuActionText;
                }
                catch (Exception exception)
                {
                    m_BodyText = GetTryAgainWithExceptionMsgBodyText(exception);
                }
            }
            else
            {
                ShouldExitPage = true;
            }
        }

        #endregion override (protected) methods
        #region private methods
        private int getFilterChoiceFromInput(string i_Input)
        {
            int filterChoice;
            if (!int.TryParse(i_Input, out filterChoice))
            {
                filterChoice = m_VehicleStates.FindIndex(i_state => 0 == string.Compare(i_state, i_Input.Trim(), StringComparison.OrdinalIgnoreCase)) + 1;
            }

            if ((filterChoice < 1) || (filterChoice > m_NumberOfFilters))
            {
                throw new FormatException(k_ActionOutOfActionListErrorTextFormat);
            }

            return filterChoice;
        }

        private void updatePageListAndText()
        {
            m_ActionText = "Choose filter: ";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Filters:");
            stringBuilder.Append(this.updateStateFiltersAndGetChoicesList());
            m_NumberOfFilters++;
            stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, m_NumberOfFilters, k_NoFillterActionText)); ////add none filter
            m_BodyText = stringBuilder.ToString();
        }

        private string updateStateFiltersAndGetChoicesList()
        {
            updateVehiclesByStateLocalMember();
            m_NumberOfFilters = 0;
            m_VehicleStates = new List<string>(m_VehiclesAndStatesGroupedByState.Count());
            foreach (IGrouping<string, KeyValuePair<string, string>> vehicleState in m_VehiclesAndStatesGroupedByState)
            {
                m_VehicleStates.Add(vehicleState.Key);
                m_NumberOfFilters++;
            }

            return GetAsChoicesListTexts(m_VehicleStates, 1, out m_NumberOfFilters);
        }

        private void updateVehiclesByStateLocalMember()
        {
            m_VehiclesAndStatesGroupedByState = GarageObject.GetGarageVehiclesAndStates().GroupBy(i_Pair => i_Pair.Value);
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

        #endregion private methods
    }
}