using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4Examples.Calculator;
using Xunit;

namespace Antlr4Examples.Test.Calculator
{
    public class CalculatorVisitorTest
    {
        [Fact]
        public void ShouldCalcResult()
        {
            StringBuilder input = new StringBuilder();
            input.AppendLine("a=5");
            input.AppendLine("b=6");
            input.AppendLine("a+b*2");

            var intStream = new AntlrInputStream(input.ToString());
            var lexer = new CalculatorLexer(intStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            var tree = parser.prog();

            var visitor = new CalculatorVisitor();
            var result = visitor.Visit(tree);

            Assert.Equal(17, result);
        }
    }
}
