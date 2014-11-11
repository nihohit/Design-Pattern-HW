using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    /// <summary>
    /// Console page that displays a vehicle fuul info
    /// </summary>
    public class DisplayVehicleFullInfoPage : ConsoleAppPage
    {
        #region members
        private string m_BodyText = string.Empty;
        private string m_ActionText = string.Empty;
        
        #endregion members
        #region protected override properties
        protected override string Title
        {
            get
            {
                return "Vehicle Full Info";
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
        
        #endregion protected override properties
        #region private properties
        private bool finished
        {
            get;
            set;
        }
        #endregion private properties
        #region public properties
        public string VehicleLicence
        {
            get; 
            set;
        }

        #endregion public properties
        #region contractor
        public DisplayVehicleFullInfoPage()
        {
            VehicleLicence = string.Empty;
            this.finished = false;
        }

        #endregion contractor
        #region protected override methods
        protected override void TakeAction(string i_Input)
        {
            if (string.IsNullOrEmpty(VehicleLicence))
            {
                VehicleLicence = i_Input;
            }

            if (this.finished)
            {
                exitPage();
            }

            try
            {
                updatePageTexts();
            }
            catch (Exception exception)
            {
                m_BodyText = GetExceptionMessage(exception);
                m_ActionText = k_ReturnToMenuActionText;
            }
        }

        #endregion protected override methods
        #region private methods
        private void updatePageTexts()
        {
            if (!string.IsNullOrEmpty(VehicleLicence))
            {
                string errorMsg;
                bool isVehicleInGarage = IsVehicleInGarage(VehicleLicence, out errorMsg);
                if (string.IsNullOrEmpty(errorMsg))
                {
                    if (isVehicleInGarage)
                    {
                        m_BodyText = GarageObject.GetVehicleInfo(VehicleLicence);
                    }
                    else
                    {
                        throw new Exception(string.Format(k_CannotFindVehicleErrorTextFormat, VehicleLicence));
                    }
                }

                m_ActionText = k_ReturnToMenuActionText;
                this.finished = true;
            }
            else
            {
                m_BodyText = string.Empty;
                m_ActionText = k_VehicleLicenceNumberActionText;
            }
        }

        private void exitPage()
        {
            this.finished = false;
            ShouldExitPage = true;
        }

        #endregion private methods
    }
}