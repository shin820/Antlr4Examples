using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4Examples.Calculator;

namespace Antlr4Examples.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShowCalculator();
        }

        private static void ShowCalculator()
        {
            StringBuilder input = new StringBuilder();
            input.AppendLine("193");
            input.AppendLine("a=5");
            input.AppendLine("b=6");
            input.AppendLine("a+b*2");
            input.AppendLine("(1+2)*3");

            var intStream = new AntlrInputStream(input.ToString());
            var lexer = new CalculatorLexer(intStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            var tree = parser.prog();

            var visitor = new CalculatorVisitor();
            visitor.Visit(tree);

            System.Console.ReadKey();
        }
    }
}
