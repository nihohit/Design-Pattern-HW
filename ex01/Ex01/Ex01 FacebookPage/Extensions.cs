﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookApplication;

namespace Ex01_FacebookPage
{
    using FacebookWrapper.ObjectModel;

    #region Extensions

    public static class Extensions
    {
        public delegate string GetIdReturnDisplayNameDelegate(string i_Id);

        public static DialogResult ShowErrorMessageBox(this Exception i_Exception, string i_Caption = "Error")
        {
            return MessageBox.Show(i_Exception.Message, i_Caption,  MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarningMessageBox(this Exception i_Exception, string i_Caption = "Warning")
        {
            return MessageBox.Show(i_Exception.Message + Environment.NewLine + "Are you sure you want to continue?",
                i_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }

    #endregion Extensions
}