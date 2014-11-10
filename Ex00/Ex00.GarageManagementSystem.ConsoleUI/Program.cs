using Ex00.GarageLogic;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    internal class Program
    {
        public static void Main(string[] i_Args)
        {
            Garage garageObject = new Garage();
            GarageManagmentMainPage garageManagmentMainPage = new GarageManagmentMainPage();
            garageManagmentMainPage.OpenPage(garageObject);
        }
    }
}