using System.Collections.Generic;

namespace Advent_code_2
{
    public class InterCodeProgram
    {
        private const int RESTORE_POSITION_1 = 1;
        private const int RESTORE_POSITION_2 = 2;
        private List<int> _programInput;

        public InterCodeProgram(List<int> programInput)
        {
            _programInput = programInput;
        }

        public List<int> RestoreProgram(int noun, int verb)
        {
            if (_programInput.Count >= 4)
            {
                _programInput[RESTORE_POSITION_1] = noun;
                _programInput[RESTORE_POSITION_2] = verb;

                return _programInput;
            }
            else
            {
                System.Console.WriteLine("Intercode program is to short and therefore invalid!");
                return null;
            }
        }
    }
}
