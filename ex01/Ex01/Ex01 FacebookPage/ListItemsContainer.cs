using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01_FacebookPage
{
    public class ListItemsContainer<T> where T : class
    {
        private T[] m_Items;
        private Action<int, T> r_ListBoxAddItemMethod;
        private Action r_ListBoxItemClearMethod;

        public event EventHandler CurrentItemChanged;

        public T SelectedItem { get; private set; }

        public ListItemsContainer(Action<int, T> i_ListBoxAddItemMethod, Action i_ListBoxItemClearMethod)
        {
            r_ListBoxAddItemMethod = i_ListBoxAddItemMethod;
            r_ListBoxItemClearMethod = i_ListBoxItemClearMethod;
            SelectedItem = null;
            m_Items = null;
        }

        public void ChangeSelectedItem(int i_SelectedIndex)
        {
            SelectedItem = (i_SelectedIndex == -1) ? null : m_Items[i_SelectedIndex];

            if (CurrentItemChanged != null)
            {
                CurrentItemChanged(this, new EventArgs());
            }
        }

        public void UpdateItems(IEnumerable<T> i_Items)
        {
            var itemsAsArray = i_Items as T[] ?? i_Items.ToArray();
            m_Items = i_Items == null ? null : new T[itemsAsArray.Count()];
            r_ListBoxItemClearMethod();
            int i = 0;
            foreach (T item in itemsAsArray)
            {
                m_Items[i] = item;
                r_ListBoxAddItemMethod(i, item); // listBox.Items.Insert(i, getInboxThreadDisplayName(inboxThread));
                i++;
            }
        }
    }
}
