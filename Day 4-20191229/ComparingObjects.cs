using System;
using System.Collections.Generic;
/*
 * IComparable<T> is used to implement the default comparing criteria of an object when compared with the other of the same type. 
 * Comparing objects will help in performing the default sorting of objects done by the Collection classes.
 * If U want to compare the objects on multiple criteria, we have one more interface called IComparer. This interface is implemented by a seperate class whose job is to compare to objects.
 */
namespace Frameworks
{
    enum ComparingCriteria {  Name, Attempts, MaxScore}
    class TestComparer : IComparer<Test>
    {
        private ComparingCriteria condition;
        public TestComparer(ComparingCriteria condition)
        {
            this.condition = condition;
        }
        public int Compare(Test x, Test y)
        {
            switch (condition)
            {
                case ComparingCriteria.Name:
                    return x.TestName.CompareTo(y.TestName);
                case ComparingCriteria.Attempts:
                    return x.CompareTo(y);
                case ComparingCriteria.MaxScore:
                    return x.MaxScore.CompareTo(y.MaxScore);
                default:
                    return 0;
            }
        }
    }
    class Test : IComparable<Test>
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int MaxScore { get; set; }
        public int PassingScore { get; set; }
        public int TotalAttempts { get; set; }//Total students who have taken the exam....

        public int CompareTo(Test other)
        {
            if (TotalAttempts > other.TotalAttempts)
                return 1;
            else if (TotalAttempts < other.TotalAttempts)
                return -1;
            else
                return 0;
        }
    }
    class ComparingObjects
    {
        static void Main(string[] args)
        {
            List<Test> totalTests = new List<Test>();
            Test test = new Test { TestID = 1, TestName = "Math", MaxScore = 100, PassingScore = 40, TotalAttempts = 40 };
            Test test2 = new Test { TestID = 2, TestName = "Science", MaxScore = 100, PassingScore = 40, TotalAttempts = 38 };
            totalTests.Add(test);
            totalTests.Add(test2);
            totalTests.Sort(new TestComparer(ComparingCriteria.Name));//Sort method uses the Type's Comparing clause to sort the elements of the list. This will be the default sorting of the elements. 
            foreach(var t in totalTests)
                Console.WriteLine("{0}-{1}", t.TestName, t.TotalAttempts);
        }
    }
}
