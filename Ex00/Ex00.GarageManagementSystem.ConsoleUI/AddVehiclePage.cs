using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex00.GarageLogic;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using System.Globalization;

    /// <summary>
    /// Console page in which the application user adds a vehicle
    /// if vehicle is already in the garage, a new VehicleAlreadyExistsPage will open
    /// </summary>
    public class AddVehiclePage : ConsoleAppPage
    {
        #region members
        #region private
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;
        private int m_NumberOfResetActionTexts;

        #endregion private
        #endregion members
        #region properties
        #region override (protected)
        protected override string Title
        {
            get
            {
                return "Vehicle addition";
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
                if (m_CurActionIndex < 0)
                {
                    return k_ReturnToMenuActionText;
                }

                return m_ActionTexts[m_CurActionIndex];
            }
        }

        #endregion override (protected)
        #region private
        private string licenseNumber { get; set; }

        private string vehicleType { get; set; }

        private string ownerName { get; set; }

        private string ownerPhoneNumber { get; set; }

        private string[] necessaryArgs { get; set; }

        private string[] vehicleTypes { get; set; }

        #endregion private
        #endregion properties
        #region constractor
        public AddVehiclePage()
        {
            this.resetPage();
        }

        #endregion constractor
        #region methods
        #region override (protected)
        protected override void TakeAction(string i_Input)
        {
            ShouldClearPageText = false;
            if (i_Input == k_CancelActionString)
            {
                this.exitPage();
            }
            else
            {
                try
                {
                    switch (m_CurActionIndex)
                    {
                        case 0:
                            this.licenceNumberAction(i_Input);
                            break;

                        case 1:
                            this.vehicleTypeAction(i_Input);
                            break;

                        case 2:
                            this.ownerNameAction(i_Input);
                            break;

                        case 3:
                            this.ownerPhoneNumberAction(i_Input);
                            break;

                        default:
                            if (m_CurActionIndex == -1)
                            {
                                this.exitPage();
                            }
                            else if (m_CurActionIndex < m_ActionTexts.Length)
                            {
                                this.necessaryArgsAction(i_Input);
                            }
                            else
                            {
                                //// should never get here (by code logic)! if got here something gone really wrong :(
                                throw new Exception("Unknown action");
                            }

                            break;
                    }
                }
                catch (Exception exception)
                {
                    resetPage();
                    m_BodyText = GetTryAgainWithExceptionMsgBodyText(exception); ////lines order important! m_BodyText is replaced from the reset text
                }
            }
        }

        #endregion override (protected)
        #region private
        private void resetPage()
        {
            this.vehicleTypes = null;
            m_BodyText = string.Format("Congratulations on adding a new vehcile to the garage!\n(to cancel enter '{0}')", k_CancelActionString);
            m_CurActionIndex = 0;
            resetActionTextsToMinimum();
        }

        private void updateVehicleTypesAndText()
        {
            this.vehicleTypes = GarageObject.GetSupportedVehicleTypes().ToArray();
            if (this.vehicleTypes != null && this.vehicleTypes.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Available vehicle types:");
                for (int i = 0; i < this.vehicleTypes.Length; i++)
                {
                    stringBuilder.AppendLine(string.Format(k_ActionDescriptionFormat, i + 1, this.vehicleTypes[i]));
                }

                m_BodyText = stringBuilder.ToString();
            }
            else
            {
                // should never get here (by code logic)! if got here something gone really wrong :(
                throw new Exception("Missing vehicle types in the system");
            }
        }

        private void resetActionTextsToMinimum()
        {
            string[] actionTexts =
                {
                    k_VehicleLicenceNumberActionText, "Choose type of vehicle: ", "Owner name: ",
                    "Owner phone number: "
                };
            m_ActionTexts = actionTexts;
            m_NumberOfResetActionTexts = actionTexts.Length;
        }
        
        private void licenceNumberAction(string i_Input)
        {
            string errorMsg;
            bool isVehicleInGarage = IsVehicleInGarage(i_Input, out errorMsg);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                m_BodyText = errorMsg;
            }
            else
            {
                if (isVehicleInGarage)
                {
                    VehicleAlreadyExistsPage vehicleAlreadyExistsPage = new VehicleAlreadyExistsPage(i_Input);
                    vehicleAlreadyExistsPage.OpenPage(GarageObject);
                    this.resetPage();
                    ShouldExitPage = true;
                }
                else
                {
                    m_CurActionIndex++;
                    this.licenseNumber = i_Input;
                    this.updateVehicleTypesAndText();
                }
            }
        }

        private void vehicleTypeAction(string i_Input)
        {
            m_BodyText = string.Empty;
            if (this.vehicleTypes == null || this.vehicleTypes.Length < 1)
            {
                this.updateVehicleTypesAndText();
            }
            else
            {
                updateVehicleTypeAndAddNecessaryArgsActionTexts(i_Input);
                m_CurActionIndex++;
            }
        }

        private void updateVehicleTypeAndAddNecessaryArgsActionTexts(string i_Input)
        {
            updateVehicleType(i_Input);
            addNecessaryArgsActionTexts();
        }

        private void updateVehicleType(string i_Input)
        {
            int vehicleTypeChoice;
            if (int.TryParse(i_Input, out vehicleTypeChoice) && (vehicleTypeChoice > 0) && (vehicleTypeChoice - 1 < this.vehicleTypes.Count()))
            {
                this.vehicleType = this.vehicleTypes[vehicleTypeChoice - 1];
            }
            else
            {
                int vehicleTypeIndex = Array.FindIndex(this.vehicleTypes, 0, i_state => 0 == string.Compare(i_state, i_Input.Trim(), StringComparison.OrdinalIgnoreCase));
                if (vehicleTypeIndex != -1)
                {
                    this.vehicleType = this.vehicleTypes[vehicleTypeIndex];
                }
                else
                {
                    throw new FormatException(k_ActionOutOfActionListErrorTextFormat);
                }
            }
        }

        private void addNecessaryArgsActionTexts()
        {
            IEnumerable<string> necessaryArgsForType = GarageObject.GetNecessaryArgsForType(this.vehicleType);
            this.necessaryArgs = new string[necessaryArgsForType.Count()];
            string[] typeActionTexts = new string[necessaryArgsForType.Count()];
            for (int i = 0; i < typeActionTexts.Length; i++)
            {
                string paramName = Extensions.ToFirstLatterUpperRestLower(Extensions.GetDisplayNameOfArgument(necessaryArgsForType.ElementAt(i)));
                typeActionTexts[i] = string.Format("{0}: ", paramName);
            }

            string[] origActionTexts = m_ActionTexts;
            m_ActionTexts = new string[origActionTexts.Length + typeActionTexts.Length];
            origActionTexts.CopyTo(m_ActionTexts, 0);
            typeActionTexts.CopyTo(m_ActionTexts, origActionTexts.Length);
        }

        private void ownerNameAction(string i_Input)
        {
            this.ownerName = i_Input;
            m_BodyText = string.Empty;
            m_CurActionIndex++;
        }

        private void ownerPhoneNumberAction(string i_Input)
        {
            this.ownerPhoneNumber = i_Input;
            m_BodyText = string.Empty;
            m_CurActionIndex++;
        }

        private void necessaryArgsAction(string i_Input)
        {
            this.necessaryArgs[m_CurActionIndex - m_NumberOfResetActionTexts] = i_Input;
            m_BodyText = string.Empty;
            if (m_CurActionIndex < m_ActionTexts.Length - 1)
            {
                m_CurActionIndex++;
                if (m_CurActionIndex < m_ActionTexts.Length - 1
                    && 0 == string.Compare("License number:", ActionText.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    this.necessaryArgs[m_CurActionIndex - m_NumberOfResetActionTexts] = this.licenseNumber;
                    m_CurActionIndex++;
                }
            }
            else
            {
                string msg = GarageObject.AddAVehicleToGarage(this.licenseNumber, this.ownerPhoneNumber, this.ownerName, this.vehicleType, this.necessaryArgs);
                MessagePage messagePage = new MessagePage("New vehicle added to the garage", msg);
                messagePage.OpenPage(GarageObject);
                this.exitPage();
            }
        }
        
        private void exitPage()
        {
            ShouldExitPage = true;
            this.resetPage();
        }

        #endregion private
        #endregion methods
    }
}