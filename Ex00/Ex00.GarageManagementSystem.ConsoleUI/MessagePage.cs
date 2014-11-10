namespace Ex00.GarageManagementSystem.ConsoleUI
{
    public class MessagePage : ConsoleAppPage
    {
        private readonly string r_Title;
        private readonly string r_BodyText;

        protected override string Title
        {
            get
            {
                return this.r_Title;
            }
        }

        protected override string BodyText
        {
            get
            {
                return this.r_BodyText;
            }
        }

        protected override string ActionText
        {
            get
            {
                return k_ReturnToMenuActionText;
            }
        }

        public MessagePage(string i_Title, string i_BodyText)
        {
            this.r_Title = i_Title;
            this.r_BodyText = i_BodyText;
        }

        protected override void TakeAction(string i_Input)
        {
            ShouldExitPage = true;
        }
    }
}