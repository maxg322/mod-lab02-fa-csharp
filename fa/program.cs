using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name { get; set; }
        public bool IsFinal { get; set; }
        public Dictionary<char, State> Transitions { get; set; }

        public State(string name, bool isFinal)
        {
            Name = name;
            IsFinal = isFinal;
            Transitions = new Dictionary<char, State>();
        }
    }

    public class FA1
    {
        public static State StateA = new State("a", false);
        public State StateB = new State("b", false);
        public State StateC = new State("c", false);
        public State StateD = new State("d", false);
        public State StateE = new State("e", true);

        private State _initial = StateA;

        public FA1()
        {
            StateA.Transitions['0'] = StateC;
            StateA.Transitions['1'] = StateB;
            StateB.Transitions['0'] = StateE;
            StateB.Transitions['1'] = StateB;
            StateC.Transitions['0'] = StateD;
            StateC.Transitions['1'] = StateE;
            StateD.Transitions['0'] = StateD;
            StateD.Transitions['1'] = StateD;
            StateE.Transitions['0'] = StateD;
            StateE.Transitions['1'] = StateE;
        }

        public bool? Process(string input)
        {
            State current = _initial;
            foreach (char symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsFinal;
        }
    }

    public class FA2
    {
        public static State StateA = new State("a", false);
        public State StateB = new State("b", false);
        public State StateC = new State("c", false);
        public State StateD = new State("d", false);
        public State StateE = new State("e", true);

        private State _initial = StateA;

        public FA2()
        {
            StateA.Transitions['0'] = StateC;
            StateA.Transitions['1'] = StateB;
            StateB.Transitions['0'] = StateE;
            StateB.Transitions['1'] = StateD;
            StateC.Transitions['0'] = StateD;
            StateC.Transitions['1'] = StateE;
            StateD.Transitions['0'] = StateC;
            StateD.Transitions['1'] = StateB;
            StateE.Transitions['0'] = StateB;
            StateE.Transitions['1'] = StateC;
        }

        public bool? Process(string input)
        {
            State current = _initial;
            foreach (char symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsFinal;
        }
    }

    public class FA3
    {
        public static State StateA = new State("a", false);
        public State StateB = new State("b", false);
        public State StateC = new State("c", true);

        private State _initial = StateA;

        public FA3()
        {
            StateA.Transitions['0'] = StateA;
            StateA.Transitions['1'] = StateB;
            StateB.Transitions['0'] = StateA;
            StateB.Transitions['1'] = StateC;
            StateC.Transitions['0'] = StateC;
            StateC.Transitions['1'] = StateC;
        }

        public bool? Process(string input)
        {
            State current = _initial;
            foreach (char symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsFinal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputSequence = "01111";
            var automaton1 = new FA1();
            bool? result1 = automaton1.Process(inputSequence);
            Console.WriteLine(result1);
            var automaton2 = new FA2();
            bool? result2 = automaton2.Process(inputSequence);
            Console.WriteLine(result2);
            var automaton3 = new FA3();
            bool? result3 = automaton3.Process(inputSequence);
            Console.WriteLine(result3);
        }
    }
}
