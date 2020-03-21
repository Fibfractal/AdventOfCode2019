using System;
using System.Collections.Generic;

namespace Advent_code_4
{
    class PasswordRange
    {
        private string _passwordRange = "245318-765747";
        private int _startNbr;
        private int _endNbr;
        private readonly List<string> _passwords = new List<string>();

        public PasswordRange()
        {
            SetStartAndEnd();
            Passwords();
        }

        private void SetStartAndEnd()
        {
            var array = _passwordRange.Split('-');
            _startNbr = Int32.Parse(array[0]);
            _endNbr = Int32.Parse(array[1]);
        }

        private void Passwords()
        {
            for (int i = _startNbr; i <= _endNbr; i++)
            {
                _passwords.Add(i.ToString());
            }
        }

        public int PasswordAfterRulesPart1()
        {
            var nbrCorrect = 0;
            foreach (var password in _passwords)
            {
                if (AscendingOrSame(password) && NbrPair(password) && SixDigits(password))
                    nbrCorrect++;
            }
            return nbrCorrect;
        }

        public int PasswordAfterRulesPart2()
        {
            var nbrCorrect = 0;
            foreach (var password in _passwords)
            {
                if (AscendingOrSame(password) && NbrPairNotInGroup(password) && SixDigits(password))
                    nbrCorrect++;
            }
            return nbrCorrect;
        }

        private bool AscendingOrSame(string onePassword)
        {
            for (int i = 1; i < onePassword.Length; i++)
            {
                if (!(onePassword[i] >= onePassword[i - 1]))
                    return false;
            }
            return true;
        }

        private bool NbrPair(string onePassword)
        {
            for (int i = 1; i < onePassword.Length; i++)
            {
                if (onePassword[i] == onePassword[i - 1])
                    return true;
            }
            return false;
        }

        private bool NbrPairNotInGroup(string onePassword)
        {
            int nbrDigitsInPairGroup = 1;
            for (int i = 1; i < onePassword.Length; i++)
            {
                if (onePassword[i] == onePassword[i - 1])
                    nbrDigitsInPairGroup++;

                if (onePassword[i] != onePassword[i - 1] && nbrDigitsInPairGroup == 2)
                    return true;

                if (onePassword[i] != onePassword[i - 1] && nbrDigitsInPairGroup > 2)
                    nbrDigitsInPairGroup = 1;
            }

            if (nbrDigitsInPairGroup == 2)
                return true;
            else
                return false;
        }

        private bool SixDigits(string onePassword)
        {
            return onePassword.Length == 6;
        }
    }
}
