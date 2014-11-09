using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class FillVehicleWheelsPage: ConsoleAppPage
    {
        private string m_BodyText;
        private string m_ActionText;
        private bool m_Finished;
        protected override string Title { get { return "Fill Vehicle Tires"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get {return m_ActionText;} }

        public FillVehicleWheelsPage()
            : base()
        {
            ResetPageValues();
        }

        private void ResetPageValues()
        {
            m_Finished = false;
            m_BodyText = string.Format("Lets fill up the tires. (to cancel enter '{0}')", c_CancelActionString);
            m_ActionText = c_EnterVehicleLicenceNumberActionText;
        }

        protected override void TakeAction(string i_Input)
        {
            if (i_Input == c_CancelActionString || m_Finished)
            {
                ShouldExitPage = true;
                ResetPageValues();
            }
            else 
            {
                string l_ErrorMsg;
                bool l_IsVehicleInGarage = IsVehicleInGarage(i_Input, out l_ErrorMsg);
                if (string.IsNullOrEmpty(l_ErrorMsg))
                {
                    if (!l_IsVehicleInGarage)
                    {
                        m_BodyText = string.Format(c_CannotFindVehicleErrorTextFormat, i_Input);
                    }
                    else
                    {
                        try 
                        {
                            m_BodyText = "Tires filled up :)";
                            GarageObject.FillWheelsToMax(i_Input);
                            m_ActionText = c_ReturnToMenuActionText;
                        }
                        catch (Exception ex)
                        {
                            m_BodyText = string.Format(c_GeneralErrorTextFormat, ex.Message);
                            m_ActionText = c_ReturnToMenuActionText;
                        }
                        m_Finished = true;
                    }
                }
                else
                {
                    m_BodyText = l_ErrorMsg;   
                }            
            }
        }
    }
}
