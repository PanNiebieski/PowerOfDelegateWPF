using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerOfDelegateWPF
{
    public delegate int DelegateOneOperationRunner(int a, int b);
    public delegate void DelegateOperationsRunner(int a, int b);

    public class OneOperationRunner
    {
        public DelegateOneOperationRunner Run(Operation operation)
        {
            DelegateOneOperationRunner runner = null;

            if (operation == Operation.Add)
                runner += Add;

            if (operation == Operation.Substrack)
                runner += Substract;

            if (operation == Operation.Mutyply)
                runner += Multyply;

            if (operation == Operation.Supply)
                runner += Supply;

            return runner;
        }

        private int Add(int a, int b) { return a + b; }
        private int Substract(int a, int b) { return a - b; }
        private int Multyply(int a, int b) { return a * b; }
        private int Supply(int a, int b) { return a / b; }

    }

    public class OperationsRunner
    {
        private DelegateOperationsRunner runner = null;

        public void AddOperation(Operation operation)
        {
            if (operation == Operation.Add)
                runner += Add;

            if (operation == Operation.Substrack)
                runner += Substract;

            if (operation == Operation.Mutyply)
                runner += Multyply;

            if (operation == Operation.Supply)
                runner += Supply;
        }

        public void Run(int a, int b)
        {
            if (runner == null)
                return;

            runner.Invoke(a, b);
        }

        public int Result
        {
            get;
            set;
        }

        private void Add(int a, int b)
        {
            if (Result == 0) { Result = a + b; } else { Result = Result + b; }
        }
        private void Substract(int a, int b)
        {
            if (Result == 0) { Result = a - b; } else { Result = Result - b; }
        }
        private void Multyply(int a, int b)
        {
            if (Result == 0) { Result = a * b; } else { Result = Result * b; }
        }
        private void Supply(int a, int b)
        {
            if (Result == 0) { Result = a / b; } else { Result = Result / b; }
        }
    }

    public enum Operation
    {
        Add,
        Substrack,
        Mutyply,
        Supply
    }
}
