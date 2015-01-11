using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookApplication.Interfaces;
using FacebookApplication;

namespace FacebookAppGUI
{
    public partial class ApplicationTabPage : UserControl
    {
        private IFiltersFeatureManager m_FiltersFeatureManager;

        public IFiltersFeatureManager FiltersFeatureManager
        {
            get { return m_FiltersFeatureManager; }
            set
            {
                if (m_FiltersFeatureManager != value)
                {
                    if (m_FiltersFeatureManager != null)
                    {
                        m_FiltersFeatureManager.AfterFetch -= this.facebookApplicationManager_AfterFetch;
                        OnBeforeFacebookApplicationLogicManagerChanging();
                    }

                    m_FiltersFeatureManager = value;
                    if (m_FiltersFeatureManager != null)
                    {
                        m_FiltersFeatureManager.AfterFetch += this.facebookApplicationManager_AfterFetch;
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
                        () => { FiltersFeatureManager.FetchFromFacebook(eFetchOption.All, -1); });
                }
                else
                {
                    foreach (KeyValuePair<eFetchOption, int> pair in typesToFetchWithTheirCollectionLimit)
                    {
                        KeyValuePair<eFetchOption, int> pair1 = pair;
                        this.TopLevelControl.FetchAndShowWaitWindow(
                        () => this.FiltersFeatureManager.FetchFromFacebook(pair1.Key, pair1.Value), pair.Key.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is NullReferenceException && FiltersFeatureManager == null)
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
            throw new Exception("Unimplemented");
        }
    }
}
