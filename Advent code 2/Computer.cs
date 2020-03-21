using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_code_2
{
    public class Computer
    {
        private const int OPT_CODE_1 = 1;
        private const int OPT_CODE_2 = 2;
        private const int OPT_CODE_99 = 99;

        private const int OPT_CODE_STEP = 4;
        private const int INPUT1_STEP = 1;
        private const int INPUT2_STEP = 2;
        private const int OUTPUT_STEP = 3;

        private int _currentOptPos;
        private int _input1Pos;
        private int _input2Pos;
        private int _outputPos;

        private int _optInput1;
        private int _optInput2;
        private int _optOutput;

        private bool _isItOptCode1;

        public int Calculations(List<int> program)
        {
            while (program[_currentOptPos] != OPT_CODE_99)
            {
                if (program[_currentOptPos] == OPT_CODE_1)
                    _isItOptCode1 = true;
                else if (program[_currentOptPos] == OPT_CODE_2)
                    _isItOptCode1 = false;
                else
                {
                    Console.WriteLine("OP CODE is invalid; should have been 1,2 or 99!");
                    return -1;
                }

                OptCodeProcess(program);
            }

            return program[0];
        }

        private void OptCodeProcess(List<int> program)
        {
            _input1Pos = program[_currentOptPos + INPUT1_STEP];
            _input2Pos = program[_currentOptPos + INPUT2_STEP];

            _optInput1 = program[_input1Pos];
            _optInput2 = program[_input2Pos];

            _optOutput = _isItOptCode1 ? _optInput1 + _optInput2 : _optInput1 * _optInput2;

            _outputPos = program[_currentOptPos + OUTPUT_STEP];
            program[_outputPos] = _optOutput;

            _currentOptPos += OPT_CODE_STEP;
        }

        public bool ValidateLogic()
        {
            var list = InitialState();

            Calculations(list);

            if (!list.SequenceEqual(FinalState()))
                Console.WriteLine("The calculation logic is wrong!");

            return list.SequenceEqual(FinalState());
        }

        private List<int> InitialState() => new List<int>() { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
        private List<int> FinalState() => new List<int>() { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
    }
}
