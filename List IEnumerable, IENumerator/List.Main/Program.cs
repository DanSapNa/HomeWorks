using System;
using System.Collections;

namespace List.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var enumerable = new List_();
            enumerable.Add(0);
            enumerable.Add(1);
            enumerable.Add(2);
            enumerable.Add(3);
            enumerable.Add(4);

            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            enumerator.Reset();

            Console.ReadKey();
        }

        // Tests
        private static void TestAddFirstValue()
        {
            int expected = 4652;
            var list = new List.List_();
            list.Add(expected);
            if ((int)list[0] == expected)
            {
                Console.WriteLine("TestAddFirstValue passed for value {0}", expected);
            }
            else
            {
                Console.WriteLine(@"TestAddFirstValue failed.
                                      Expected: {0}
                                      Actual: {1}", expected, (int)list[0]);
            }
        }

        private static void TestAddFourValues()
        {
            var list = new List.List_();
            int from = 0;
            int to = 3;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            for (int i = from; i <= to; i++)
            {
                if ((int)list[i] == i)
                {
                    Console.WriteLine(@"TestAddFirstValue passed for value {0}", i);
                }
                else
                {
                    Console.WriteLine(@"TestAddFirstValue failed.
                                          Expected: {0}
                                          Actual: {1}", i, (int)list[0]);
                }
            }
        }

        private static void TestAddFifthValue()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            if ((int)list[to] == to)
            {
                Console.WriteLine(@"TestAddFirstValue passed for value {0}", to);
            }
            else
            {
                Console.WriteLine(@"TestAddFirstValue failed.
                                      Expected: {0}
                                      Actual: {1}", to, (int)list[0]);
            }
        }

        private static void TestCountOneValue()
        {
            int expected = 1;
            int value = 87325;
            var list = new List.List_();
            list.Add(value);
            if (list.Count == expected)
            {
                Console.WriteLine("TestCountOneValue passed for count {0}", expected);
            }
            else
            {
                Console.WriteLine(@"TestCountOneValue failed.
                                      tExpected: {0}
                                      Actual: {1}", expected, list.Count);
            }
        }

        private static void TestCountFourValues()
        {
            int expected = 4;
            var list = new List.List_();
            int from = 0;
            int to = 3;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            if (list.Count == expected)
            {
                Console.WriteLine(@"TestCountFourValues passed for count {0}", expected);
            }
            else
            {
                Console.WriteLine(@"TestCountFourValues failed.
                                      Expected: {0}
                                      Actual: {1}", expected, list.Count);
            }
        }

        private static void TestCountFiveValues()
        {
            int expected = 5;
            var list = new List.List_();
            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            if (list.Count == expected)
            {
                Console.WriteLine(@"TestCountFiveValues passed for count {0}", expected);
            }
            else
            {
                Console.WriteLine(@"TestCountFiveValues failed.
                                      Expected: {0}
                                      Actual: {1}", expected, list.Count);
            }
        }

        private static void TestRemoveFirstValue()
        {
            int expected = 4652;
            var list = new List.List_();
            list.Add(expected);
            list.Remove(expected);
            if (list.Count == 0)
            {
                Console.WriteLine("TestRemoveFirstValue passed. Value {0} was removed", expected);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFirstValue failed.
                                      Expected: null
                                      Actual: {1}", list.Count);
            }
        }

        private static void TestRemoveFourthValue()
        {
            var list = new List.List_();
            int from = 0;
            int to = 3;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(3);

            if (list.Count == 3)
            { 
                Console.WriteLine(@"TestRemoveFourthValue passed. Value {0} was removed", 3);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFourthValue failed.
                                          Expected: null
                                          Actual: {1}", list.Count);
            }
        }

        private static void TestRemoveFifthValue()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(to);

            if (list.Count == 4)
            {
                Console.WriteLine(@"TestRemoveFifthValue passed. Value {0} was removed", to);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFifthValue failed.
                                      Expected: null
                                      Actual: {1}", list.Count);
            }
        }

        private static void TestRemoveMiddleValue()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;
            int valueToRemove = 2;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(valueToRemove);

            if (list.Count == 4)
            {
                Console.WriteLine(@"TestRemoveMiddleValue passed. Value {0} was removed", valueToRemove);
            }
            else
            {
                Console.WriteLine(@"TestRemoveMiddleValue failed.
                                      Expected: null
                                      Actual: {1}", list.Count);
            }
        }

        private static void TestRemoveAtIndex()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;
            int valueToRemove = 2;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(valueToRemove);

            if (list.Count == 4)
            {
                Console.WriteLine(@"TestRemoveAtIndex passed. Value {0} was removed", valueToRemove);
            }
            else
            {
                Console.WriteLine(@"TestRemoveAtIndex failed.
                                      Expected: null
                                      Actual: {1}", list.Count);
            }
        }
    }
}
