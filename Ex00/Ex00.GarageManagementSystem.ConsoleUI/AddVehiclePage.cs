using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
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
        protected override string Title { get { return "Vehicle addition"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText 
        { 
            get
            {
                if (m_CurActionIndex<0)
                    return c_ReturnToMenuActionText;

                return m_ActionTexts[m_CurActionIndex];
            }
        }
        #endregion override
        #endregion protected
        
        #region private
        
        private string LicenseNumber { get; set; }
        private string VehicleType { get; set; }
        private string OwnerName { get; set; }
        private string OwnerPhoneNumber { get; set; }
        private string[] NecessaryArgs { get; set; }
        private string[] VehicleTypes { get; set; }

        #endregion private
        #endregion properties

        #region constractor
        public AddVehiclePage()
            : base()
        {
            ResetPage();          
        }
        #endregion constractor

        #region methods
        #region protected
        #region override
        protected override void TakeAction(string i_Input)
        {
            ShouldClearPageText = false;
            if (i_Input == c_CancelActionString)
            {
                ShouldExitPage = true;
                ResetPage();
                m_CurActionIndex = 0;
                m_BodyText = "";
            }
            else
            {
                try
                {
                    switch (m_CurActionIndex)
                    {
                        case 0:
                            LicenceNumberAction(i_Input);
                            break;
                        case 1:
                            VehicleTypeAction(i_Input);
                            break;
                        case 2:
                            OwnerNameAction(i_Input);
                            break;
                        case 3:
                            OwnerPhoneNumberAction(i_Input);
                            break;
                        default:
                            if (m_CurActionIndex == -1)
                            {
                                ShouldExitPage = true;
                                ResetPage();
                                m_CurActionIndex = 0;
                            }
                            else if (m_CurActionIndex < m_ActionTexts.Length)
                            {
                                NecessaryArgsAction(i_Input);
                            }
                            else
                            {
                                m_BodyText = string.Format(c_GeneralErrorTextFormat, "Input corrupted");
                                m_CurActionIndex = -1;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
        }

        #endregion override
        #endregion protected

        #region private
        private void ResetPage()
        {
            VehicleTypes = null;
            m_BodyText = string.Format("Congratulations on adding a new vehcile to the garage!\n(to cancel enter '{0}')", c_CancelActionString);
            m_CurActionIndex = 0;
            ResetActionTextsToMinimum();
        }

        private void UpdateVehicleTypesAndText()
        {
            try
            {
                VehicleTypes = GarageObject.GetSupportedVehicleTypes().ToArray();
                if (VehicleTypes != null && VehicleTypes.Length > 0)
                {
                    StringBuilder l_sb = new StringBuilder();
                    l_sb.AppendLine("Available vehicle types:");
                    for (int i = 0; i < VehicleTypes.Length; i++)
                    {
                        l_sb.AppendLine(string.Format(ActionDescriptionFormat, i + 1, VehicleTypes[i]));
                    }
                    m_BodyText = l_sb.ToString();
                }
                else
                {
                    m_BodyText = string.Format(c_GeneralErrorTextFormat, "Misssing vehicle types in the system");
                    m_CurActionIndex = -1;
                }
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                m_CurActionIndex = -1;
            }               

        }

        private void ResetActionTextsToMinimum()
        {
            string[] l_ActionTexts = { c_EnterVehicleLicenceNumberActionText, 
                                       "Choose type of vehicle: ",
                                       "Owner name: ",
                                       "Owner phone number: "};
            m_ActionTexts = l_ActionTexts;
            m_NumberOfResetActionTexts = l_ActionTexts.Length;
        }

        private string GetArgDisplayName(string i_args)
        {
            string l_arg = i_args;
            if (0 == string.Compare("i_", 0, i_args, 0, 2, true))
            {
                l_arg = l_arg.Substring(2);
            }
            string l_DisplayNameArg = "";
            foreach (char ch in l_arg)
            {
                if (char.IsLower(ch))
                {
                    l_DisplayNameArg += ch.ToString();
                }
                else
                {
                    l_DisplayNameArg += " " + ch.ToString().ToLower();
                }
            }
            return l_DisplayNameArg.Trim();
        }

        private void LicenceNumberAction(string i_Input)
        {
            string l_ErrorMsg;
            bool l_IsVehicleInGarage =  IsVehicleInGarage(i_Input, out l_ErrorMsg);
            if (!string.IsNullOrEmpty(l_ErrorMsg))
            {
                m_BodyText = l_ErrorMsg;
            }
            else
            {
                if (l_IsVehicleInGarage)
                {
                    ResetPage();
                    ShouldExitPage = true;
                    VehicleAlreadyExistsPage l_VehicleAlreadyExistsPage = new VehicleAlreadyExistsPage(i_Input);
                    l_VehicleAlreadyExistsPage.OpenPage(GarageObject);
                }
                else
                {
                    m_CurActionIndex++;
                    LicenseNumber = i_Input;
                    UpdateVehicleTypesAndText();
                }
            }        
        }
        private void VehicleTypeAction(string i_Input)
        {
            m_BodyText = "";
            try
            {
                int l_VehicleTypeChoice = Convert.ToInt32(i_Input);
                if (VehicleTypes == null || VehicleTypes.Length < 1)
                {
                    UpdateVehicleTypesAndText();
                }
                else if ((l_VehicleTypeChoice < 1) || (l_VehicleTypeChoice > VehicleTypes.Length))
                {
                    m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "vehicle type", "type", string.Format("Type number out of range 1:{0}", VehicleTypes.Length));
                }
                else
                {
                    VehicleType = VehicleTypes[l_VehicleTypeChoice-1];
                    IEnumerable<string> l_NecessaryArgsForType = GarageObject.GetNecessaryArgsForType(VehicleType);
                    NecessaryArgs = new string[l_NecessaryArgsForType.Count()];
                    string[] l_TypeActionTexts = new string[l_NecessaryArgsForType.Count()];
                    for (int i =0 ; i<l_TypeActionTexts.Length; i++)
                    {
                        string l_ParamName = GetArgDisplayName(l_NecessaryArgsForType.ElementAt(i));
                        l_ParamName = l_ParamName.Substring(0, 1).ToUpper() + l_ParamName.Substring(1).ToLower();
                        l_TypeActionTexts[i] = string.Format("{0}: ", l_ParamName);
                    }
                    string[] l_OrigActionTexts = m_ActionTexts; 
                    m_ActionTexts = new string[l_OrigActionTexts.Length + l_TypeActionTexts.Length ];
                    l_OrigActionTexts.CopyTo(m_ActionTexts, 0);
                    l_TypeActionTexts.CopyTo(m_ActionTexts, l_OrigActionTexts.Length);
                    m_CurActionIndex++;
                }
            }
            catch (Exception ex)
            {
                if (ex is OverflowException || ex is FormatException)
                    m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "vehicle type", "type", ex.Message);
                else
                {
                    m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }                        
        }
        private void OwnerNameAction(string i_Input)
        {
            OwnerName = i_Input;
            m_BodyText = "";
            m_CurActionIndex++;
        }
        private void OwnerPhoneNumberAction(string i_Input)
        {
            OwnerPhoneNumber = i_Input;
            m_BodyText = "";
            m_CurActionIndex++;
        }
        private void NecessaryArgsAction(string i_Input)
        {
            NecessaryArgs[m_CurActionIndex-m_NumberOfResetActionTexts] = i_Input;
            m_BodyText = "";
            if (m_CurActionIndex < m_ActionTexts.Length - 1)
            {
                m_CurActionIndex++;
                if (m_CurActionIndex < m_ActionTexts.Length - 1 
                    && 0 == string.Compare("License number:", ActionText.Trim(), true))
                {
                    NecessaryArgs[m_CurActionIndex - m_NumberOfResetActionTexts] = LicenseNumber;
                    m_CurActionIndex++;
                }
            }
            else
            {
                try
                {
                    string l_msg = GarageObject.AddAVehicleToGarage(LicenseNumber, OwnerPhoneNumber, OwnerName, VehicleType, NecessaryArgs);
                    MessagePage l_MessagePage = new MessagePage("New vehicle added to the garage", l_msg);
                    l_MessagePage.OpenPage(GarageObject);
                    ShouldExitPage = true;
                    ResetPage();
                }
                catch (Exception ex)
                {
                    m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                    m_CurActionIndex = -1;
                }
            }
        }
        #endregion private
        #endregion methods
    }
}
