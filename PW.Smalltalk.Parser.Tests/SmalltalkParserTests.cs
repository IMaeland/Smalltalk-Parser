using System;
using Antlr4.Runtime;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PW.Smalltalk.Parser.Tests
{
    [TestClass]
    public class SmalltalkParserTests : IAntlrErrorListener<IToken>
    {
        [DeploymentItem("Data")]
        [TestMethod]
        public void TestParseFileCache()
        {
            var srcFile = ParseFile("FileCache.stcls", this);
            Assert.AreEqual(2, srcFile.classMethods().method().Count());
            Assert.AreEqual("\r\n\r\non: anObject from: aFile\r\n\t\"Instance Creation - Answers a cache instance for \r\n\t anObject from aFile.\"\r\n\r\n\t^self new\r\n\t\tinitObject: anObject file: aFile;\r\n\t\tyourself.   ", srcFile.classMethods().method().Last().GetText());
            Assert.AreEqual(10, srcFile.instanceMethods().method().Count());
        }

        [DeploymentItem("Data")]
        [TestMethod]
        public void TestParseT4ExtendedMapiDLL()
        {
            var srcFile = ParseFile("T4ExtendedMapiDLL.stcls", this);
            Assert.AreEqual(3, srcFile.classMethods().method().Count());
            Assert.AreEqual(5, srcFile.instanceMethods().method().Count());
        }

        [DeploymentItem("Data")]
        [TestMethod]
        public void TestParseT4DialogBox()
        {
            var srcFile = ParseFile("T4DialogBox.stcls", this);
            Assert.AreEqual(87, srcFile.classMethods().method().Count());
            Assert.AreEqual(195, srcFile.instanceMethods().method().Count());
        }

        private static SmalltalkParser.SourceFileContext ParseFile(string file, IAntlrErrorListener<IToken> listener)
        {
            var code = File.ReadAllText(file);
            AntlrInputStream inputStream = new AntlrInputStream(code);
            SmalltalkLexer lexer = new SmalltalkLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            SmalltalkParser parser = new SmalltalkParser(commonTokenStream);
            parser.AddErrorListener(listener);
            var srcFile = parser.sourceFile();
            return srcFile;
        }

        private static TokenInfo[] GetTokens(CommonTokenStream commonTokenStream)
        {
            commonTokenStream.Fill();
            return (from t in commonTokenStream.GetTokens()
                    select new TokenInfo
                    {
                        Type = $"{t.TypeEnum()} ({t.Type})",
                        Text = t.Text,
                        Length = t.StopIndex - t.StartIndex,
                        Line = t.Line,
                        Column = t.Column
                    }).ToArray();
        }

        void IAntlrErrorListener<IToken>.SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new InvalidProgramException($"{msg} Line: {line}, Column: {charPositionInLine}");
        }
    }

    public struct TokenInfo
    {
        public string Type;
        public string Text;
        public int Length;
        public int Line;
        public int Column;
    }
}
