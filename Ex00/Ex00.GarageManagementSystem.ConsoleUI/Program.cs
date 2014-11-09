using System;
using Ex00.GarageLogic;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Garage l_GarageObject = new Garage();
            GarageManagmentMainPage l_GarageManagmentMainPage = new GarageManagmentMainPage();
            l_GarageManagmentMainPage.OpenPage(l_GarageObject);
        }
    }
}