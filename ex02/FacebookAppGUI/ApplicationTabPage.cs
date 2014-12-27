using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookApplication.Interfaces;
using FacebookApplication;

namespace FacebookAppGUI
{
    public partial class ApplicationTabPage : UserControl
    {
        private IFiltersFicherManager m_FacebookApplicationManager;

        public IFiltersFicherManager FacebookApplicationLogicManager
        {
            get { return m_FacebookApplicationManager; }
            set
            {
                if (m_FacebookApplicationManager != value)
                {
                    if (m_FacebookApplicationManager != null)
                    {
                        m_FacebookApplicationManager.AfterFetch -= this.facebookApplicationManager_AfterFetch;
                        OnBeforeFacebookApplicationLogicManagerChanging();
                    }

                    m_FacebookApplicationManager = value;
                    if (m_FacebookApplicationManager != null)
                    {
                        m_FacebookApplicationManager.AfterFetch += this.facebookApplicationManager_AfterFetch;
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
                Dictionary<eFetchOption, int> typesToFetchWithTheirCollectionLimit =
                    GetFetchTypesToFetchWithTheirCollectionLimit();
                if (typesToFetchWithTheirCollectionLimit == null || typesToFetchWithTheirCollectionLimit.Count < 1)
                {
                    this.TopLevelControl.FetchAndShowWaitWindow(
                        () => { FacebookApplicationLogicManager.FetchFromFacebook(eFetchOption.All, -1); });
                }
                else
                {
                    foreach (KeyValuePair<eFetchOption, int> pair in typesToFetchWithTheirCollectionLimit)
                    {
                        KeyValuePair<eFetchOption, int> pair1 = pair;
                        this.TopLevelControl.FetchAndShowWaitWindow(
                        () => this.FacebookApplicationLogicManager.FetchFromFacebook(pair1.Key, pair1.Value), pair.Key.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is NullReferenceException && FacebookApplicationLogicManager == null)
                {
                    exception = new NullReferenceException("Cannot fetch because facebook manager was not set in the page", exception);
                }

                exception.ShowErrorMessageBox();
            }
        }

        protected virtual Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            return null;
        }

        protected virtual void facebookApplicationManager_AfterFetch(object sender, FetchEventArgs e)
        {
            throw new NotImplementedException("Should override method");
        }
    }
}
