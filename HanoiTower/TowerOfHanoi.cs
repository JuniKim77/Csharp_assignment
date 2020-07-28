using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class TowerOfHanoi
    {

        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs < 0)
            {
                return -1;
            }
            int result = (int)Math.Pow(2.0, (double)numDiscs) - 1;
            return result;
        }

        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            List<List<int>[]> steps = new List<List<int>[]>();
            if (numDiscs < 1)
            {
                return steps;
            }
            const int NUM_POLE = 3;
            List<int>[] step = new List<int>[NUM_POLE];
            for (int i = 0; i < NUM_POLE; ++i)
            {
                step[i] = new List<int>();
            }
            for (int i = numDiscs; i > 0; --i)
            {
                step[0].Add(i);
            }
            steps.Add(step);
            solveSubTower(steps, numDiscs, 2, 0);
            return steps;
        }
        private static void solveSubTower(List<List<int>[]> steps, int numMovingStones, int to, int from)
        {
            if (numMovingStones == 1)
            {
                moveOneStone(steps, to, from);
                return;
            }
            int dummyPole = 3 - to - from;
            if (numMovingStones == 2)
            {
                moveOneStone(steps, dummyPole, from);
                moveOneStone(steps, to, from);
                moveOneStone(steps, to, dummyPole);
                return;
            }
            solveSubTower(steps, numMovingStones - 1, dummyPole, from);
            moveOneStone(steps, to, from);
            solveSubTower(steps, numMovingStones - 1, to, dummyPole);
            return;
        }
        private static void moveOneStone(List<List<int>[]> steps, int to, int from)
        {
            const int NUM_POLE = 3;
            List<int>[] newStep = new List<int>[NUM_POLE];
            int latsStepIndex = steps.Count - 1;
            for (int i = 0; i < NUM_POLE; ++i)
            {
                newStep[i] = new List<int>(steps[latsStepIndex][i]);
            }
            int lastStoneIndex = newStep[from].Count - 1;
            int stone = newStep[from][lastStoneIndex];
            newStep[from].RemoveAt(lastStoneIndex);
            newStep[to].Add(stone);
            steps.Add(newStep);
        }
    }
}
