﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;

namespace Ex01_FacebookPage
{
    public partial class FriendsFiltersComboBox : UserControl
    {
        private const string c_AllFriendsOptionDisplayName = "All friends";
        private readonly ListItemsContainer<string> r_ListItemsContainer;
        public event EventHandler FriendsFiltersChanged
        {
            add { r_ListItemsContainer.CurrentItemChanged += value; }
            remove { r_ListItemsContainer.CurrentItemChanged -= value; }
        }

        public string SelectedFriendFilterId
        {
            get { return r_ListItemsContainer.SelectedItem == c_AllFriendsOptionDisplayName ? null : r_ListItemsContainer.SelectedItem; }
        }

        public string LabelText
        {
            get
            {
                return friendsListsLabel.Text;
            }
            set
            {
                friendsListsLabel.Text = value;
                int origComboBoxLocationX = comboBox.Location.X;
                comboBox.Location =
                    new System.Drawing.Point(
                        friendsListsLabel.Location.X + friendsListsLabel.Size.Width +
                        Math.Max(friendsListsLabel.Margin.Right, comboBox.Margin.Left), comboBox.Location.Y);
                comboBox.Size = new Size(comboBox.Size.Width + origComboBoxLocationX - comboBox.Location.X, comboBox.Size.Height);
            }
        }

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
                        m_FacebookApplicationManager.FriendFilterAdded -= m_FacebookApplicationManager_FriendFilterAdded;
                        m_FacebookApplicationManager.FriendFilterRemoved -= m_FacebookApplicationManager_FriendFilterRemoved;
                    }

                    m_FacebookApplicationManager = value;
                    if (m_FacebookApplicationManager != null)
                    {
                        m_FacebookApplicationManager.FriendFilterAdded += m_FacebookApplicationManager_FriendFilterAdded;
                        m_FacebookApplicationManager.FriendFilterRemoved += m_FacebookApplicationManager_FriendFilterRemoved;
                    }
                }
            }
        }

        private void m_FacebookApplicationManager_FriendFilterAdded(object sender, EventArgs e)
        {
            UpdateFriendsFilters();
        }

        private void m_FacebookApplicationManager_FriendFilterRemoved(object sender, EventArgs e)
        {
            UpdateFriendsFilters();
        }


        public bool AllFriendsSelected { get { return SelectedFriendFilterId == null; } }

        public FriendsFiltersComboBox()
        {
            InitializeComponent();
            r_ListItemsContainer = new ListItemsContainer<string>(insertFriendFilter, () => comboBox.Items.Clear());
        }

        public void UpdateFriendsFilters()
        {
            comboBox.Items.Clear();
            List<string> filters = new List<string>();
            filters.Add(c_AllFriendsOptionDisplayName);
            filters.AddRange(FacebookApplicationLogicManager.GetFriendFiltersIds());
            r_ListItemsContainer.UpdateItems(filters);
            comboBox.SelectedItem = c_AllFriendsOptionDisplayName;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_ListItemsContainer.ChangeSelectedItem(comboBox.SelectedIndex);
        }

        private void insertFriendFilter(int i, string i_FilterId)
        {
            string filterName = (i_FilterId == c_AllFriendsOptionDisplayName)
                ? i_FilterId
                : FacebookApplicationLogicManager.GetFriendFilterName(i_FilterId);
            comboBox.Items.Insert(i, filterName);
        }
    }
}