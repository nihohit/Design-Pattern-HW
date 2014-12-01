using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookApplication.Interfaces;

namespace Ex01_FacebookPage
{
    public partial class ApplicationTabPage : UserControl
    {
        private IFacebookApplicationManager m_FacebookApplicationManager;
        public IFacebookApplicationManager FacebookApplicationLogicManager
        {
            get { return m_FacebookApplicationManager; }
            set
            {
                if (m_FacebookApplicationManager != value)
                {
                    if (m_FacebookApplicationManager != null)
                    {
                        m_FacebookApplicationManager.AfterFetch -= m_FacebookApplicationManager_AfterFetch;
                        OnBeforeFacebookApplicationLogicManagerChanging();
                    }

                    m_FacebookApplicationManager = value;
                    if (m_FacebookApplicationManager != null)
                    {
                        m_FacebookApplicationManager.AfterFetch += m_FacebookApplicationManager_AfterFetch;
                        OnFacebookApplicationLogicManagerChanged();
                    }
                }
                
            }
        }

        protected virtual void OnBeforeFacebookApplicationLogicManagerChanging()
        {
            
        }

        protected virtual void OnFacebookApplicationLogicManagerChanged()
        {

        }

        public ApplicationTabPage()
        {
            InitializeComponent();
        }

        private void linkUpdateFromFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchFromFacebook();
        }

        private void fetchFromFacebook()
        {
            try
            {
                FacebookApplicationLogicManager.FetchFromFacebook();
            }
            catch (Exception exception)
            {
                if (exception is NullReferenceException && FacebookApplicationLogicManager == null)
                {
                    exception = new NullReferenceException("Cannot fetch becouse facebook manager was not set in the page", exception);
                }
                exception.ShowErrorMessageBox();
            } 
        }

        protected virtual void m_FacebookApplicationManager_AfterFetch(object i_Sender, EventArgs e)
        {
            throw new NotImplementedException("Should override method");
        }
    }
}
