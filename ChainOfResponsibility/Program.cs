using System;

namespace ApproveCostRequest
{

    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void ApproveCosts(int amount);
    }

    public class ProjectManager : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void ApproveCosts(int amount)
        {
            if (amount <= 500)
                Console.WriteLine("Project Manager approves the costs");
            else if (_nextHandler != null)
                _nextHandler.ApproveCosts(amount);
        }
    }

    public class ProgramManager : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void ApproveCosts(int amount)
        {
            if (amount <= 2000)
                Console.WriteLine("Program Manager approves the costs");
            else if (_nextHandler != null)
                _nextHandler.ApproveCosts(amount);
        }
    }

    public class SubdivisionManager : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void ApproveCosts(int amount)
        {
            if (amount <= 5000)
                Console.WriteLine("Subdivision Manager approves the costs");
            else if (_nextHandler != null)
                _nextHandler.ApproveCosts(amount);
        }
    }

    public class DivisionDirector : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void ApproveCosts(int amount)
        {
            if (amount <= 20000)
                Console.WriteLine("Division Director approves the costs");
            else if (_nextHandler != null)
                _nextHandler.ApproveCosts(amount);
        }
    }

    public class CEO : IHandler
    {
        public IHandler SetNext(IHandler handler)
        {
            return this; 
        }

        public void ApproveCosts(int amount)
        {
            if (amount <= 100000)
                Console.WriteLine("CEO approves the costs");
            else
                Console.WriteLine("Cost exceeds the limit");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IHandler projectManager = new ProjectManager(); // handler chain
            IHandler programManager = new ProgramManager();
            IHandler subdivisionManager = new SubdivisionManager();
            IHandler divisionDirector = new DivisionDirector();
            IHandler ceo = new CEO();

            projectManager.SetNext(programManager) // defining sequence of the chain
                          .SetNext(subdivisionManager)
                          .SetNext(divisionDirector)
                          .SetNext(ceo);

            Console.Write("Cost request: ");
            if (int.TryParse(Console.ReadLine(), out int RequestedCost)) // convert string to an integer
            {
                projectManager.ApproveCosts(RequestedCost);
            }
            else
            {
                Console.WriteLine("Please enter a valid cost request!");
            }
        }
    }
}
