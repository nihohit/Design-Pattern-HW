﻿using Ex00.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class FillFuelPage: ConsoleAppPage
    {
        private string m_BodyText;
        private string[] m_ActionTexts;
        private int m_CurActionIndex;
        private int m_NumberOfFuelTypes;

        protected override string Title { get { return "Fill Vehicle Fuel"; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText
        {
            get
            {
                if (m_CurActionIndex < 0)
                    return c_ReturnToMenuActionText;

                return m_ActionTexts[m_CurActionIndex];
            }
        }

        private string m_LicenseNumber;
        private eFuelType m_FuelType;

        public FillFuelPage()
            : base()
        {
            ResetPageValues();
        }

        private void ResetPageValues()
        {
            m_BodyText = string.Format("Filling vehicle fuel (to cancel enter '{0}')", c_CancelActionString);
            m_CurActionIndex = 0;
            ResetActionTexts();
        }

        protected void ResetActionTexts()
        {
            string[] l_ActionTexts = { c_EnterVehicleLicenceNumberActionText, 
                                       "Choose type of fuel: ",
                                       "Enter amount (liters): "};
            m_ActionTexts = l_ActionTexts;
        }


        private void UpdateFuelTypesText()
        {
            StringBuilder l_sb = new StringBuilder();
            l_sb.AppendLine("Fuel types:");
            l_sb.Append(GetEnumActionTexts(typeof(eFuelType), 1, out m_NumberOfFuelTypes));
            m_BodyText = l_sb.ToString();
        }

        protected override void TakeAction(string i_Input)
        {
            if (i_Input == c_CancelActionString)
            {
                ShouldExitPage = true;
                ResetPageValues();
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
                            FuelTypeAction(i_Input);
                            break;
                        case 2:
                            AmountAction(i_Input);
                            break;
                        default:
                            if (m_CurActionIndex == -1)
                            {
                                ShouldExitPage = true;
                                ResetPageValues();
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

        private void LicenceNumberAction(string i_Input)
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
                    m_LicenseNumber = i_Input;
                    UpdateFuelTypesText();
                    m_CurActionIndex++;
                }
            }
            else
            {
                m_BodyText = l_ErrorMsg;
                m_CurActionIndex = -1;
            }
        }
        private void FuelTypeAction(string i_Input)
        {
            m_BodyText = "";
            try
            {
                m_FuelType = (eFuelType)Convert.ToInt32(i_Input);
                m_CurActionIndex++;
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_InvalidActionNumErrorTextFormat, "fuel type", "type", ex.Message);
                m_CurActionIndex = -1;
            }
        }

        private void AmountAction(string i_Input)
        {
            m_BodyText = "";
            try
            {
                float l_amount = float.Parse(i_Input, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                GarageObject.FillFuel(m_LicenseNumber, m_FuelType, l_amount);
                m_BodyText = string.Format("Filled {0} liters :)", l_amount);
                m_CurActionIndex = -1;                
            }
            catch (Exception ex)
            {
                m_BodyText = string.Format(c_InvalidInputGeneralErrorTextFormat, "amount", ex.Message);
                m_CurActionIndex = -1;
            }   
        }
    }
}