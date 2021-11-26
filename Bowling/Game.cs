using System;
using System.Collections.Generic;

namespace Bowling
{
    class Game
    {
        List<int> rolls = new List<int>();

        int index = 1;
        bool isFirst = true;
        int lastRoll = 0;
        bool anatherRoll = false;

        public bool Roll(int pins)
        {
            switch (index)
            {
                case 11:
                    bonusRoll(pins);
                    return false;
                case 10:
                    lastRound(pins);
                    if (isFirst && !anatherRoll) return false;
                    return true;

                default:
                    regularRound(pins);
                    return true;
            }
        }
        public int Score()
        {
            int score = 0;
            isFirst = true;
            index = 1;

            for (int i = 0; i < rolls.Count; i++)
            {
                if (anatherRoll && i == rolls.Count - 1) continue;
                if (anatherRoll && i == rolls.Count - 2 && rolls[i] == 10) continue;

                score += rolls[i];
                if (isFirst)
                {
                    if (rolls[i] == 10)
                    {
                        score += bonus(i, 2);
                        index++;
                        continue;
                    }
                    isFirst = false;
                    continue;
                }
                index++;
                var sum = rolls[i] + rolls[i - 1];
                if (sum == 10) score += bonus(i, 1);
                isFirst = true;
            }
            return score;
        }

        private void regularRound(int pins)
        {
            rolls.Add(pins);
            if (isFirst)
            {
                if (pins == 10) index++;
                else isFirst = false;
            }
            else
            {
                index++;
                isFirst = true;
            }
        }
        private void lastRound(int pins)
        {
            rolls.Add(pins);
            if (isFirst)
            {
                lastRoll = pins;
                isFirst = false;
            }
            else
            {
                var sum = lastRoll + pins;
                if (sum == 10 || sum == 20) anatherRoll = true;
                index++;
            }
        }
        private void bonusRoll(int pins)
        {
            rolls.Add(pins);
        }

        private int bonus(int i, int steps)
        {
            var res = 0;
            for (int j = 1; j <= steps; j++)
            {
                if (i + j >= rolls.Count) return res;
                res += rolls[i + j];
            }
            return res;
        }
        //recursive i tried...(not working :C)
        //private int bonus(int i, int steps, int result = 0)
        //{
        //    if (steps == 0) return result;
        //    if (i >= rolls.Count) return bonus(i + 1, steps - 1, result);
        //    return bonus(i + 1, steps - 1, result) + rolls[i];
        //}
    }
}
