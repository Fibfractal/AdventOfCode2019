using System.Collections.Generic;

namespace Advent_code_1
{
    public class SpaceShip
    {
        private List<Modul> _allModules = new List<Modul>();

        public void GetSpaceShipData()
        {
            var import = new Import();
            InitializeModules(import.DataFromTextFile());
        }

        private void InitializeModules(List<int> fuelDataList)
        {
            for (int i = 0; i < fuelDataList.Count; i++)
            {
                var modul = new Modul(fuelDataList[i], i + 1);
                _allModules.Add(modul);
            }
        }
        public int FuelModulesPart1()
        {
            int fuelConsumption = 0;

            foreach (var modul in _allModules)
            {
                fuelConsumption += modul.CalcFuel(modul.Mass);
            }
            return fuelConsumption;
        }

        public int FuelModulesPart2()
        {
            int fuelConsumption = 0;

            foreach (var modul in _allModules)
            {
                fuelConsumption += modul.CalcTotalFuel(); ;
            }
            return fuelConsumption;
        }
    }
}
