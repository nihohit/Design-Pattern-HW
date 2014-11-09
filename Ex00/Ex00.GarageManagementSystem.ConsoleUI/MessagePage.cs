using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class MessagePage: ConsoleAppPage
    {
        private string m_Title;
        private string m_BodyText;
        protected override string Title { get { return m_Title; } }        
        protected override string BodyText { get {return m_BodyText;} }
        protected override string ActionText { get { return c_ReturnToMenuActionText; } }

        public MessagePage(string i_Title, string i_BodyText)
            : base()
        {
            m_Title = i_Title;
            m_BodyText = i_BodyText;
        }
        
        protected override void TakeAction(string i_Input)
        {
            ShouldExitPage = true;                        
        }
    }
}
