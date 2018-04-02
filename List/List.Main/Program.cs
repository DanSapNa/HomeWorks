using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n********************* ADD VALUES *********************");

            TestAddFirstValue();
            TestAddFourValues();
            TestAddFifthValue();

            Console.WriteLine("\n*********************** COUNT ***********************");

            TestCountOneValue();
            TestCountFourValues();
            TestCountFiveValues();

            Console.WriteLine("\n*********************** INSERT ***********************");

            var list = new List.List_();
            int from = 0;
            int to = 4;

            Console.WriteLine("Initial list: ");

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
                Console.WriteLine($"\t\tlist[{i}] = {list[i]}");
            }

            list.Insert(3, 8);
            list.Insert(5, 5);
            list.Insert(6, 7);
            list.Insert(7, 9);

            int count = list.Count;

            Console.WriteLine("Inserted list: ");

            for (int i = from; i < count; i++)
            {
                Console.WriteLine($"\t\tlist[{i}] = {list[i]}");
            }

            Console.WriteLine("\n*********************** REMOVE ***********************");
            TestRemoveFirstValue();
            TestRemoveFourthValue();
            TestRemoveFifthValue();
            TestRemoveMiddleValue();
            TestRemoveAtIndex();

            list.Clear();

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
            int itemIndex = 0;
            var list = new List.List_();

            list.Add(expected);
            list.Remove(expected);

            if (list.CheckArrayItemIsNull(itemIndex))
            {
                Console.WriteLine("TestRemoveFirstValue passed. Value {0} was removed", expected);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFirstValue failed.
                                      Expected: true
                                      Actual: {1}", list.CheckArrayItemIsNull(itemIndex));
            }
        }

        private static void TestRemoveFourthValue()
        {
            var list = new List.List_();
            int itemIndex = 3;
            int from = 0;
            int to = 3;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(3);

            if (list.CheckArrayItemIsNull(itemIndex))
            { 
                Console.WriteLine(@"TestRemoveFourthValue passed. Value {0} was removed", itemIndex);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFourthValue failed.
                                          Expected: true
                                          Actual: {1}", list.CheckArrayItemIsNull(itemIndex));
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

            if (list.CheckArrayItemIsNull(to))
            {
                Console.WriteLine(@"TestRemoveFifthValue passed. Value {0} was removed", to);
            }
            else
            {
                Console.WriteLine(@"TestRemoveFifthValue failed.
                                      Expected: true
                                      Actual: {1}", list.CheckArrayItemIsNull(to));
            }
        }

        private static void TestRemoveMiddleValue()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;
            int valueToRemove = 2;
            bool valueRemoved = false;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(valueToRemove);

            if (list.Count == 4)
            {
                if (!list.CheckArrayItemIsNull(valueToRemove))
                {
                    if (list.CheckArrayItemIsNull(to))
                    {
                        Console.WriteLine(@"TestRemoveMiddleValue passed. Value {0} was removed", valueToRemove);
                        valueRemoved = true;
                    }
                }
            }

            if (!valueRemoved)
            {
                Console.WriteLine(@"TestRemoveMiddleValue failed.
                                      Expected: true
                                      Actual: {1}", valueRemoved);
            }
        }

        private static void TestRemoveAtIndex()
        {
            var list = new List.List_();
            int from = 0;
            int to = 4;
            int valueToRemove = 2;
            bool valueRemoved = false;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(valueToRemove);

            if (list.Count == 4)
            {
                if (!list.CheckArrayItemIsNull(valueToRemove))
                {
                    if (list.CheckArrayItemIsNull(to))
                    {
                        Console.WriteLine(@"TestRemoveAtIndex passed. Value {0} was removed", valueToRemove);
                        valueRemoved = true;
                    }
                }
            }

            if (!valueRemoved)
            {
                Console.WriteLine(@"TestRemoveAtIndex failed.
                                      Expected: true
                                      Actual: {1}", valueRemoved);
            }
        }
    }
}
