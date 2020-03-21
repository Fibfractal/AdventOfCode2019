using System.Collections.Generic;

namespace Advent_code_5
{
    public class InterCodeProgram
    {
        private const int RESTORE_POSITION_1 = 1;
        private const int RESTORE_POSITION_2 = 2;
        private List<int> _restoredInput;

        public InterCodeProgram(List<int> programInput)
        {
            _restoredInput = programInput;
        }

        public List<int> RestoreProgram(int noun, int verb)
        {
            if (_restoredInput.Count >= 4)
            {
                _restoredInput[RESTORE_POSITION_1] = noun;
                _restoredInput[RESTORE_POSITION_2] = verb;

                return _restoredInput;
            }
            else
            {
                System.Console.WriteLine("Intercode program is to short and therefore invalid!");
                return null;
            }
        }
    }
}
