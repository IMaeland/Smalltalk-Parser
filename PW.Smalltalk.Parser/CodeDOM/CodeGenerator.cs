using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace PW.Smalltalk.Parser.CodeDOM
{
    public class CodeGenerator : SmalltalkBaseVisitor<TranslationContext>
    {
        public CodeGenerator()
        {
        }

        protected override TranslationContext DefaultResult => base.DefaultResult;

        // https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/generating-and-compiling-source-code-from-a-codedom-graph

        public static CodeCompileUnit CreateCode()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            
            CodeNamespace samples = new CodeNamespace("Samples");

            samples.Imports.Add(new CodeNamespaceImport("System"));
            compileUnit.Namespaces.Add(samples);
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
            samples.Types.Add(class1);

            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!"));
            start.Statements.Add(cs1);

            class1.Members.Add(start);
            return compileUnit;
        }

        public static string GenerateCSharpCode(CodeCompileUnit compileunit)
        {
            // Generate the code with the C# code provider.
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Build the output file name.
            string sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "HelloWorld" + provider.FileExtension;
            }
            else
            {
                sourceFile = "HelloWorld." + provider.FileExtension;
            }

            // Create a TextWriter to a StreamWriter to the output file.
            using (StreamWriter sw = new StreamWriter(sourceFile, false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

                // Generate source code using the code provider.
                provider.GenerateCodeFromCompileUnit(compileunit, tw,
                    new CodeGeneratorOptions());

                // Close the output file.
                tw.Close();
            }

            return sourceFile;
        }

        public override TranslationContext Visit([NotNull] IParseTree tree)
        {
            return base.Visit(tree);
        }

        public override TranslationContext VisitAnswer([NotNull] SmalltalkParser.AnswerContext context)
        {
            return base.VisitAnswer(context);
        }

        public override TranslationContext VisitAssignment([NotNull] SmalltalkParser.AssignmentContext context)
        {
            return base.VisitAssignment(context);
        }

        public override TranslationContext VisitBareLiteralArray([NotNull] SmalltalkParser.BareLiteralArrayContext context)
        {
            return base.VisitBareLiteralArray(context);
        }

        public override TranslationContext VisitBareSymbol([NotNull] SmalltalkParser.BareSymbolContext context)
        {
            return base.VisitBareSymbol(context);
        }

        public override TranslationContext VisitBinaryMessage([NotNull] SmalltalkParser.BinaryMessageContext context)
        {
            return base.VisitBinaryMessage(context);
        }

        public override TranslationContext VisitBinarySend([NotNull] SmalltalkParser.BinarySendContext context)
        {
            return base.VisitBinarySend(context);
        }

        public override TranslationContext VisitBinaryTail([NotNull] SmalltalkParser.BinaryTailContext context)
        {
            return base.VisitBinaryTail(context);
        }

        public override TranslationContext VisitBlock([NotNull] SmalltalkParser.BlockContext context)
        {
            return base.VisitBlock(context);
        }

        public override TranslationContext VisitBlockParamList([NotNull] SmalltalkParser.BlockParamListContext context)
        {
            return base.VisitBlockParamList(context);
        }

        public override TranslationContext VisitCascade([NotNull] SmalltalkParser.CascadeContext context)
        {
            return base.VisitCascade(context);
        }

        public override TranslationContext VisitCharConstant([NotNull] SmalltalkParser.CharConstantContext context)
        {
            return base.VisitCharConstant(context);
        }

        public override TranslationContext VisitChildren([NotNull] IRuleNode node)
        {
            return base.VisitChildren(node);
        }

        public override TranslationContext VisitClassDefinition([NotNull] SmalltalkParser.ClassDefinitionContext context)
        {
            return base.VisitClassDefinition(context);
        }

        public override TranslationContext VisitClassMethods([NotNull] SmalltalkParser.ClassMethodsContext context)
        {
            return base.VisitClassMethods(context);
        }

        public override TranslationContext VisitClassName([NotNull] SmalltalkParser.ClassNameContext context)
        {
            return base.VisitClassName(context);
        }

        public override TranslationContext VisitClassVariableNames([NotNull] SmalltalkParser.ClassVariableNamesContext context)
        {
            return base.VisitClassVariableNames(context);
        }

        public override TranslationContext VisitEmptyExpressions([NotNull] SmalltalkParser.EmptyExpressionsContext context)
        {
            return base.VisitEmptyExpressions(context);
        }

        public override TranslationContext VisitErrorNode([NotNull] IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        public override TranslationContext VisitExpression([NotNull] SmalltalkParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }

        public override TranslationContext VisitExpressionList([NotNull] SmalltalkParser.ExpressionListContext context)
        {
            return base.VisitExpressionList(context);
        }

        public override TranslationContext VisitExpressions([NotNull] SmalltalkParser.ExpressionsContext context)
        {
            return base.VisitExpressions(context);
        }

        public override TranslationContext VisitInstanceMethods([NotNull] SmalltalkParser.InstanceMethodsContext context)
        {
            return base.VisitInstanceMethods(context);
        }

        public override TranslationContext VisitInstanceVariableNames([NotNull] SmalltalkParser.InstanceVariableNamesContext context)
        {
            return base.VisitInstanceVariableNames(context);
        }

        public override TranslationContext VisitKeywordMessage([NotNull] SmalltalkParser.KeywordMessageContext context)
        {
            return base.VisitKeywordMessage(context);
        }

        public override TranslationContext VisitKeywordPair([NotNull] SmalltalkParser.KeywordPairContext context)
        {
            return base.VisitKeywordPair(context);
        }

        public override TranslationContext VisitKeywords([NotNull] SmalltalkParser.KeywordsContext context)
        {
            return base.VisitKeywords(context);
        }

        public override TranslationContext VisitKeywordSend([NotNull] SmalltalkParser.KeywordSendContext context)
        {
            return base.VisitKeywordSend(context);
        }

        public override TranslationContext VisitLiteral([NotNull] SmalltalkParser.LiteralContext context)
        {
            return base.VisitLiteral(context);
        }

        public override TranslationContext VisitLiteralArray([NotNull] SmalltalkParser.LiteralArrayContext context)
        {
            return base.VisitLiteralArray(context);
        }

        public override TranslationContext VisitLiteralArrayRest([NotNull] SmalltalkParser.LiteralArrayRestContext context)
        {
            return base.VisitLiteralArrayRest(context);
        }

        public override TranslationContext VisitMessage([NotNull] SmalltalkParser.MessageContext context)
        {
            return base.VisitMessage(context);
        }

        public override TranslationContext VisitMetaClassDefinition([NotNull] SmalltalkParser.MetaClassDefinitionContext context)
        {
            return base.VisitMetaClassDefinition(context);
        }

        public override TranslationContext VisitMethod([NotNull] SmalltalkParser.MethodContext context)
        {
            return base.VisitMethod(context);
        }

        public override TranslationContext VisitMethodBody([NotNull] SmalltalkParser.MethodBodyContext context)
        {
            return base.VisitMethodBody(context);
        }

        public override TranslationContext VisitNumber([NotNull] SmalltalkParser.NumberContext context)
        {
            return base.VisitNumber(context);
        }

        public override TranslationContext VisitNumberExp([NotNull] SmalltalkParser.NumberExpContext context)
        {
            return base.VisitNumberExp(context);
        }

        public override TranslationContext VisitOperand([NotNull] SmalltalkParser.OperandContext context)
        {
            return base.VisitOperand(context);
        }

        public override TranslationContext VisitParsetimeLiteral([NotNull] SmalltalkParser.ParsetimeLiteralContext context)
        {
            return base.VisitParsetimeLiteral(context);
        }

        public override TranslationContext VisitPoolDictionaries([NotNull] SmalltalkParser.PoolDictionariesContext context)
        {
            return base.VisitPoolDictionaries(context);
        }

        public override TranslationContext VisitPrimitive([NotNull] SmalltalkParser.PrimitiveContext context)
        {
            return base.VisitPrimitive(context);
        }

        public override TranslationContext VisitPseudoVariable([NotNull] SmalltalkParser.PseudoVariableContext context)
        {
            return base.VisitPseudoVariable(context);
        }

        public override TranslationContext VisitReference([NotNull] SmalltalkParser.ReferenceContext context)
        {
            return base.VisitReference(context);
        }

        public override TranslationContext VisitRuntimeLiteral([NotNull] SmalltalkParser.RuntimeLiteralContext context)
        {
            return base.VisitRuntimeLiteral(context);
        }

        public override TranslationContext VisitSequence([NotNull] SmalltalkParser.SequenceContext context)
        {
            return base.VisitSequence(context);
        }

        public override TranslationContext VisitSourceFile([NotNull] SmalltalkParser.SourceFileContext context)
        {
            return base.VisitSourceFile(context);
        }

        public override TranslationContext VisitStatementAnswer([NotNull] SmalltalkParser.StatementAnswerContext context)
        {
            return base.VisitStatementAnswer(context);
        }

        public override TranslationContext VisitStatementExpressions([NotNull] SmalltalkParser.StatementExpressionsContext context)
        {
            return base.VisitStatementExpressions(context);
        }

        public override TranslationContext VisitStatementExpressionsAnswer([NotNull] SmalltalkParser.StatementExpressionsAnswerContext context)
        {
            return base.VisitStatementExpressionsAnswer(context);
        }

        public override TranslationContext VisitStatements([NotNull] SmalltalkParser.StatementsContext context)
        {
            return base.VisitStatements(context);
        }

        public override TranslationContext VisitStFloat([NotNull] SmalltalkParser.StFloatContext context)
        {
            return base.VisitStFloat(context);
        }

        public override TranslationContext VisitStInteger([NotNull] SmalltalkParser.StIntegerContext context)
        {
            return base.VisitStInteger(context);
        }

        public override TranslationContext VisitStIntegerBaseN([NotNull] SmalltalkParser.StIntegerBaseNContext context)
        {
            return base.VisitStIntegerBaseN(context);
        }

        public override TranslationContext VisitString([NotNull] SmalltalkParser.StringContext context)
        {
            return base.VisitString(context);
        }

        public override TranslationContext VisitSubexpression([NotNull] SmalltalkParser.SubexpressionContext context)
        {
            return base.VisitSubexpression(context);
        }

        public override TranslationContext VisitSuperClassName([NotNull] SmalltalkParser.SuperClassNameContext context)
        {
            return base.VisitSuperClassName(context);
        }

        public override TranslationContext VisitSymbol([NotNull] SmalltalkParser.SymbolContext context)
        {
            return base.VisitSymbol(context);
        }

        public override TranslationContext VisitTemps([NotNull] SmalltalkParser.TempsContext context)
        {
            return base.VisitTemps(context);
        }

        public override TranslationContext VisitTerminal([NotNull] ITerminalNode node)
        {
            return base.VisitTerminal(node);
        }

        public override TranslationContext VisitUnaryMessage([NotNull] SmalltalkParser.UnaryMessageContext context)
        {
            return base.VisitUnaryMessage(context);
        }

        public override TranslationContext VisitUnarySelector([NotNull] SmalltalkParser.UnarySelectorContext context)
        {
            return base.VisitUnarySelector(context);
        }

        public override TranslationContext VisitUnarySend([NotNull] SmalltalkParser.UnarySendContext context)
        {
            return base.VisitUnarySend(context);
        }

        public override TranslationContext VisitUnaryTail([NotNull] SmalltalkParser.UnaryTailContext context)
        {
            return base.VisitUnaryTail(context);
        }

        public override TranslationContext VisitVariable([NotNull] SmalltalkParser.VariableContext context)
        {
            return base.VisitVariable(context);
        }

        public override TranslationContext VisitWs([NotNull] SmalltalkParser.WsContext context)
        {
            return base.VisitWs(context);
        }

        protected override TranslationContext AggregateResult(TranslationContext aggregate, TranslationContext nextResult)
        {
            return base.AggregateResult(aggregate, nextResult);
        }

        protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, TranslationContext currentResult)
        {
            return base.ShouldVisitNextChild(node, currentResult);
        }
    }
}
