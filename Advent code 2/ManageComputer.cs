namespace Advent_code_2
{
    public class ManageComputer
    {
        public int RunComputerPart1()
        {
            const int NOUN = 12;
            const int VERB = 2;

            return RunSequence(NOUN, VERB);
        }

        public int RunComputerPart2()
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

        private int RunSequence(int NOUN, int VERB)
        {
            var intercodeProgram = new InterCodeProgram(new ImportProgram().DataFromTextFile());
            var restoredProgram = intercodeProgram.RestoreProgram(NOUN, VERB);
            var computer = new Computer();

            if (computer.ValidateLogic())
                return computer.Calculations(restoredProgram);

            return -1;
        }
    }
}
