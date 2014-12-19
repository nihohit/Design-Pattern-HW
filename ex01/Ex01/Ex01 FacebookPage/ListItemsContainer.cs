using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01_FacebookPage
{
    public class ListItemsContainer<T> where T : class
    {
        private readonly Action<int, T> r_ListBoxAddItemMethod;
        private readonly Action r_ListBoxItemClearMethod;

        private T[] m_Items;

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
            m_Items = i_Items == null ? null : new T[i_Items.Count()];
            r_ListBoxItemClearMethod();
            if (i_Items != null)
            {
                int i = 0;
                foreach (T item in i_Items)
                {
                    m_Items[i] = item;
                    r_ListBoxAddItemMethod(i, item);
                    i++;
                }
            }

            ChangeSelectedItem(-1);
        }
    }
}
