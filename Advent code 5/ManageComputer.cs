namespace Advent_code_5
{
    public class ManageComputer
    {
        public int RunComputerDay2_1()
        {
            const int NOUN = 12;
            const int VERB = 2;

            return RunSequence(NOUN, VERB);
        }
        private int RunSequence(int NOUN, int VERB)
        {
            var intercodeProgram = new InterCodeProgram(new ImportProgram().Day2Code());
            var restoredProgram = intercodeProgram.RestoreProgram(NOUN, VERB);
            var computer = new Computer();

            if (computer.ValidateLogic())
                return computer.Calculations(restoredProgram);

            return -1;
        }

        public int RunComputerDay2_2()
        {
            const int WANTED_OUTPUT = 19690720;

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    if (RunSequence(noun, verb) == WANTED_OUTPUT)
                        return 100 * noun + verb;
                }
            }

            return -1;
        }

        public int RunComputerDay5()
        {
            var computer = new Computer();
            computer.EnterInput();
            return computer.Calculations(new ImportProgram().Day5Code());
        }
    }
}
