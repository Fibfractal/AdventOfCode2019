using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_code_5
{
    public class Computer
    {
        // No magic numbers
        private const int OPT_CODE_99 = 99;
        private const int POINTER_STEP_4 = 4;
        private const int POINTER_STEP_3 = 3;
        private const int POINTER_STEP_2 = 2;
        private const int PARAM1_STEP = 1;
        private const int PARAM2_STEP = 2;
        private const int PARAM3_STEP = 3;
        private const int POSITION_MODE = 0;

        private int _input;
        private int _output;
        private int _optCode;
        private int _pointerPos;
        private int _outputPos;
        private int _parameter1Mode;
        private int _parameter2Mode;
        private int _parameter3Mode;

        public int Calculations(List<int> program)
        {
            AnalyzeInstruction(program);

            while (_optCode != OPT_CODE_99)
            {
                switch (_optCode)
                {
                    case 1:
                    case 2:
                        OptCode1Or2Process(program);
                        break;
                    case 3:
                        OptCode3Process(program);
                        break;
                    case 4:
                        OptCode4Process(program);
                        break;
                    case 5:
                        OptCode5Process(program);
                        break;
                    case 6:
                        OptCode6Process(program);
                        break;
                    case 7:
                        OptCode7Process(program);
                        break;
                    case 8:
                        OptCode8Process(program);
                        break;

                    default:
                        Console.WriteLine($"The optCode: {_optCode} doesn't exist yet!");
                        return -1;
                }

                AnalyzeInstruction(program);
            }

            return _output;
        }

        public void EnterInput()
        {
            _input = Input.InputToInteger();
        }

        public void AnalyzeInstruction(List<int> program)
        {
            var instruction = program[_pointerPos];

            _optCode = instruction % 100;
            _parameter1Mode = (instruction % 1000) / 100;
            _parameter2Mode = (instruction % 10000) / 1000;
            _parameter3Mode = (instruction % 100000) / 10000;

            if (_parameter3Mode != 0)
                Console.WriteLine("Parameter 3 can't be immediate! ");
        }

        private void OptCode1Or2Process(List<int> program)
        {
            _output = _optCode == 1 ? Param1Input(program) + Param2Input(program) : Param1Input(program) * Param2Input(program);

            _outputPos = program[_pointerPos + PARAM3_STEP];
            program[_outputPos] = _output;

            _pointerPos += POINTER_STEP_4;
        }

        private int Param1Input(List<int> program)
        {
            if (_parameter1Mode == POSITION_MODE)
            {
                int pos = program[_pointerPos + PARAM1_STEP];
                return program[pos];
            }
            else
                return program[_pointerPos + PARAM1_STEP];
        }

        private int Param2Input(List<int> program)
        {
            if (_parameter2Mode == POSITION_MODE)
            {
                int pos = program[_pointerPos + PARAM2_STEP];
                return program[pos];
            }
            else
                return program[_pointerPos + PARAM2_STEP];
        }

        private void OptCode3Process(List<int> program)
        {
            _outputPos = program[_pointerPos + PARAM1_STEP];
            program[_outputPos] = _input;
            _pointerPos += POINTER_STEP_2;
        }

        private void OptCode4Process(List<int> program)
        {
            _output = Param1Input(program);
            Console.WriteLine(($"Output is: {_output}"));
            _pointerPos += POINTER_STEP_2;
        }

        private void OptCode5Process(List<int> program)
        {
            _pointerPos = Param1Input(program) != 0 ? Param2Input(program) : _pointerPos + POINTER_STEP_3;
        }

        private void OptCode6Process(List<int> program)
        {
            _pointerPos = Param1Input(program) == 0 ? Param2Input(program) : _pointerPos + POINTER_STEP_3;
        }

        private void OptCode7Process(List<int> program)
        {
            int pos3 = program[_pointerPos + PARAM3_STEP];

            program[pos3] = Param1Input(program) < Param2Input(program) ? 1 : 0;
            _pointerPos += POINTER_STEP_4;
        }

        private void OptCode8Process(List<int> program)
        {
            int pos3 = program[_pointerPos + PARAM3_STEP];
            program[pos3] = Param1Input(program) == Param2Input(program) ? 1 : 0;
            _pointerPos += POINTER_STEP_4;
        }


        // --- Test ---

        // Day5_2

        // input = 0 => output = 0 , input != 0 => output = 1
        public List<int> TestOpt5PosMode() => new List<int>() { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };  // OK
        public List<int> TestOpt6ImmMode() => new List<int>() { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };          // OK

        // input < 8 => output = 999, input = 8 => output = 1000, input > 8 => output = 1001                                // OK
        public List<int> TestLarge() => new List<int>() { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };



        // Day2_1
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
