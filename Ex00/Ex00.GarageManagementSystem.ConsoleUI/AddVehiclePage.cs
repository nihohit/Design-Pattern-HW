using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using System.Globalization;

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

        #region protected

        #region override

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

        #endregion override

        #endregion protected

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

        #region protected

        #region override

        protected override void TakeAction(string i_Input)
        {
            ShouldClearPageText = false;
            if (i_Input == k_CancelActionString)
            {
                ShouldExitPage = true;
                this.resetPage();
                m_CurActionIndex = 0;
                m_BodyText = string.Empty;
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
                                ShouldExitPage = true;
                                this.resetPage();
                                m_CurActionIndex = 0;
                            }
                            else if (m_CurActionIndex < m_ActionTexts.Length)
                            {
                                this.necessaryArgsAction(i_Input);
                            }
                            else
                            {
                                m_BodyText = string.Format(k_GeneralErrorTextFormat, "Input corrupted");
                                m_CurActionIndex = -1;
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
        }

        #endregion override

        #endregion protected

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
            try
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
                    m_BodyText = string.Format(k_GeneralErrorTextFormat, "Missing vehicle types in the system");
                    m_CurActionIndex = -1;
                }
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                m_CurActionIndex = -1;
            }
        }

        private void resetActionTextsToMinimum()
        {
            string[] actionTexts =
                {
                    k_EnterVehicleLicenceNumberActionText, "Choose type of vehicle: ", "Owner name: ",
                    "Owner phone number: "
                };
            m_ActionTexts = actionTexts;
            m_NumberOfResetActionTexts = actionTexts.Length;
        }

        private string getArgDisplayName(string i_Args)
        {
            string args = i_Args;
            if (0 == string.Compare("i_", 0, i_Args, 0, 2, true))
            {
                args = args.Substring(2);
            }

            string displayNameArg = string.Empty;
            foreach (char ch in args)
            {
                if (char.IsLower(ch))
                {
                    displayNameArg += ch.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    displayNameArg += " " + ch.ToString(CultureInfo.InvariantCulture).ToLower();
                }
            }

            return displayNameArg.Trim();
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
                    this.resetPage();
                    ShouldExitPage = true;
                    VehicleAlreadyExistsPage vehicleAlreadyExistsPage = new VehicleAlreadyExistsPage(i_Input);
                    vehicleAlreadyExistsPage.OpenPage(GarageObject);
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
            try
            {
                int vehicleTypeChoice = Convert.ToInt32(i_Input);
                if (this.vehicleTypes == null || this.vehicleTypes.Length < 1)
                {
                    this.updateVehicleTypesAndText();
                }
                else if ((vehicleTypeChoice < 1) || (vehicleTypeChoice > this.vehicleTypes.Length))
                {
                    m_BodyText = string.Format(k_InvalidActionNumErrorTextFormat, "vehicle type", "type", string.Format("Type number out of range 1:{0}", this.vehicleTypes.Length));
                }
                else
                {
                    this.vehicleType = this.vehicleTypes[vehicleTypeChoice - 1];
                    IEnumerable<string> necessaryArgsForType = GarageObject.GetNecessaryArgsForType(this.vehicleType);
                    this.necessaryArgs = new string[necessaryArgsForType.Count()];
                    string[] typeActionTexts = new string[necessaryArgsForType.Count()];
                    for (int i = 0; i < typeActionTexts.Length; i++)
                    {
                        string paramName = this.getArgDisplayName(necessaryArgsForType.ElementAt(i));
                        paramName = paramName.Substring(0, 1).ToUpper() + paramName.Substring(1).ToLower();
                        typeActionTexts[i] = string.Format("{0}: ", paramName);
                    }
                    string[] origActionTexts = m_ActionTexts;
                    m_ActionTexts = new string[origActionTexts.Length + typeActionTexts.Length];
                    origActionTexts.CopyTo(m_ActionTexts, 0);
                    typeActionTexts.CopyTo(m_ActionTexts, origActionTexts.Length);
                    m_CurActionIndex++;
                }
            }
            catch (Exception ex)
            {
                if (ex is OverflowException || ex is FormatException)
                {
                    m_BodyText = string.Format(k_InvalidActionNumErrorTextFormat, "vehicle type", "type", ex.Message);
                }
                else
                {
                    m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
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
                try
                {
                    string msg = GarageObject.AddAVehicleToGarage(this.licenseNumber, this.ownerPhoneNumber, this.ownerName, this.vehicleType, this.necessaryArgs);
                    MessagePage messagePage = new MessagePage("New vehicle added to the garage", msg);
                    messagePage.OpenPage(GarageObject);
                    ShouldExitPage = true;
                    this.resetPage();
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(k_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
        }

        #endregion private

        #endregion methods
    }
}