using System;
using System.Collections.Generic;

namespace Antlr4Examples.Calculator
{
    public class CalculatorVisitor : CalculatorBaseVisitor<int>
    {
        private Dictionary<string, int> memory = new Dictionary<string, int>();

        public override int VisitAssign(CalculatorParser.AssignContext context)
        {
            string id = context.ID().GetText();
            int value = Visit(context.expr());
            memory.Add(id, value);

            return value;
        }

        public override int VisitPrintExpr(CalculatorParser.PrintExprContext context)
        {
            int value = Visit(context.expr());
            Console.WriteLine(value);
            return 0;
        }

        public override int VisitInt(CalculatorParser.IntContext context)
        {
            return int.Parse(context.INT().GetText());
        }

        public override int VisitId(CalculatorParser.IdContext context)
        {
            string id = context.ID().GetText();
            if (memory.ContainsKey(id))
            {
                return memory[id];
            }

            return 0;
        }

        public override int VisitMulDiv(CalculatorParser.MulDivContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));

            if (context.op.Type == CalculatorParser.MUL)
            {
                return left * right;
            }

            return left / right;
        }

        public override int VisitAddSub(CalculatorParser.AddSubContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));

            if (context.op.Type == CalculatorParser.ADD)
            {
                return left + right;
            }

            return left - right;
        }

        public override int VisitParents(CalculatorParser.ParentsContext context)
        {
            return Visit(context.expr());
        }
    }
}
