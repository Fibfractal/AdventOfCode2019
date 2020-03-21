namespace Advent_code_1
{
    public class Modul
    {
        public Modul(int mass, int modulNumber)
        {
            ModulNumber = modulNumber;
            Mass = mass;
        }

        public int ModulNumber { get; set; }
        public int Mass { get; set; }

        public int CalcFuel(int mass)
        {
            return mass / 3 - 2;
        }

        public int CalcTotalFuel()
        {
            var fuelConsumtion = 0;
            var fuelLeftToCalc = CalcFuel(Mass);

            while (fuelLeftToCalc > 0)
            {
                fuelConsumtion += fuelLeftToCalc;
                fuelLeftToCalc = CalcFuel(fuelLeftToCalc);
            }

            return fuelConsumtion;
        }
    }
}
