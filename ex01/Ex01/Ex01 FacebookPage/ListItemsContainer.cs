using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    public class ListItemsContainer<T> where T : class
    {
        private T[] m_Items;
        private Action<int, T> r_ListBoxAddItemMethod;
        public event EventHandler CurrentItemChanged;
        public T SelectedItem { get; private set; }

        public ListItemsContainer(Action<int, T> i_ListBoxAddItemMethod)
        {
            r_ListBoxAddItemMethod = i_ListBoxAddItemMethod;
            SelectedItem = null;
            m_Items = null;
        }

        public void CangeSelectedItem(int selectedIndex)
        {
            SelectedItem = (selectedIndex == -1) ? null : m_Items[selectedIndex];

            if (CurrentItemChanged != null)
            {
                CurrentItemChanged(this, new EventArgs());
            }
        }

        public void UpdateItems(IEnumerable<T> i_Items)
        {
            m_Items = i_Items == null ? null : new T[i_Items.Count()];
            int i = 0;
            foreach (T item in i_Items)
            {
                m_Items[i] = item;
                r_ListBoxAddItemMethod(i, item);//listBox.Items.Insert(i, getInboxThreadDisplayName(inboxThread));
                i++;
            }
        }
    }
}
