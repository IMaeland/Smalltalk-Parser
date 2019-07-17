using System;
using Antlr4.Runtime;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PW.Smalltalk.Parser.Tests
{
    [TestClass]
    public class SmalltalkLexerTests
    {

        [TestMethod]
        public void TestExpression()
        {
            var tokens = GetTokens("recipients := aCollection1 collect: [:each | ExternalAddress copyToNonSmalltalkMemory: each asAsciiZ].");
            Assert.AreEqual(26, tokens.Count);
            int i = 0;
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.ASSIGNMENT, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PIPE, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[i++].TypeEnum());
        }

        [TestMethod]
        public void TestExpression2()
        {
            var tokens = GetTokens("^((self itemIds associations select: [:e | e key asString beginsWith: 'IDI_']) asSortedCollection: [:a :b | a value <= b value]) asOrderedCollection collect: [:each | each key].!");
            Assert.AreEqual(73, tokens.Count);
            int i = 0;
            Assert.AreEqual(SmalltalkTokenType.CARROT, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.OPEN_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.OPEN_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.SELF, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PIPE, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CLOSE_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());            
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PIPE, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.LESSTHAN_OR_EQUAL, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CLOSE_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PIPE, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[i++].TypeEnum());
        }

        [TestMethod]
        public void TestExpression3()
        {
            var tokens = GetTokens("(self itemIds associations select: [:e | e])");
            Assert.AreEqual(20, tokens.Count);
            int i = 0;

            Assert.AreEqual(SmalltalkTokenType.OPEN_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.SELF, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.PIPE, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CLOSE_PAREN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[i++].TypeEnum());
        }

        [TestMethod]
        public void TestPrimitive()
        {
            var tokens = GetTokens("<api: T4SendMessage long structIn boolean>\r\n    ^self invaliArgument");
            Assert.AreEqual(18, tokens.Count);
            int i = 0;
            Assert.AreEqual(SmalltalkTokenType.LESSTHAN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.GREATERTHAN, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CARROT, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.SELF, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[i++].TypeEnum());
        }


        [TestMethod]
        public void TestInteger()
        {
            var tokens = GetTokens("012345");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[0].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());

            tokens = GetTokens("-12345");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.MINUS, tokens[0].TypeEnum());
            Assert.AreEqual("-", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[1].TypeEnum());
            Assert.AreEqual("12345", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestHexInteger()
        {
            var tokens = GetTokens("16r12345");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[0].TypeEnum());
            Assert.AreEqual("16r12345", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());

            tokens = GetTokens("-16r2345");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.MINUS, tokens[0].TypeEnum());
            Assert.AreEqual("-", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[1].TypeEnum());
            Assert.AreEqual("16r2345", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestBinaryDigit()
        {
            var tokens = GetTokens("2r101");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[0].TypeEnum());
            Assert.AreEqual("2r101", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());

            tokens = GetTokens("-2r101");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.MINUS, tokens[0].TypeEnum());
            Assert.AreEqual("-", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[1].TypeEnum());
            Assert.AreEqual("2r101", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestBase36Digit()
        {
            var tokens = GetTokens("36rZ01");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[0].TypeEnum());
            Assert.AreEqual("36rZ01", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());

            tokens = GetTokens("-36rZ01");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.MINUS, tokens[0].TypeEnum());
            Assert.AreEqual("-", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS_BASEN, tokens[1].TypeEnum());
            Assert.AreEqual("36rZ01", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestFloat()
        {
            var tokens = GetTokens("1.2345");
            Assert.AreEqual(4, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[0].TypeEnum());
            Assert.AreEqual("1", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[1].TypeEnum());
            Assert.AreEqual(".", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[2].TypeEnum());
            Assert.AreEqual("2345", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[3].TypeEnum());

            tokens = GetTokens("-2.345");
            Assert.AreEqual(5, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.MINUS, tokens[0].TypeEnum());
            Assert.AreEqual("-", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[1].TypeEnum());
            Assert.AreEqual("2", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[2].TypeEnum());
            Assert.AreEqual(".", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[3].TypeEnum());
            Assert.AreEqual("345", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[4].TypeEnum());
        }

        [TestMethod]
        public void TestComment()
        {
            var tokens = GetTokens("\"This is a Smalltalk comment\"");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.COMMENT, tokens[0].TypeEnum());
            Assert.AreEqual("\"This is a Smalltalk comment\"", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());
        }

        [TestMethod]
        public void TestLessThan()
        {
            var tokens = GetTokens("1 < 2");
            Assert.AreEqual(6, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[0].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.LESSTHAN, tokens[2].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[3].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[4].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[5].TypeEnum());
        }

        [TestMethod]
        public void TestGreaterThan()
        {
            var tokens = GetTokens("1 > 2");
            Assert.AreEqual(6, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[0].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.GREATERTHAN, tokens[2].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[3].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[4].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[5].TypeEnum());
        }

        [TestMethod]
        public void TestEmbeddedBang()
        {
            var tokens = GetTokens("'!'\"!\"");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[0].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COMMENT, tokens[1].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestCharacterConstant()
        {
            var tokens = GetTokens("$a $1$0 $-");
            Assert.AreEqual(7, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.CHARACTER_CONSTANT, tokens[0].TypeEnum());
            Assert.AreEqual("$a", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CHARACTER_CONSTANT, tokens[2].TypeEnum());
            Assert.AreEqual("$1", tokens[2].Text);

            Assert.AreEqual(SmalltalkTokenType.CHARACTER_CONSTANT, tokens[3].TypeEnum());
            Assert.AreEqual("$0", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[4].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.CHARACTER_CONSTANT, tokens[5].TypeEnum());
            Assert.AreEqual("$-", tokens[5].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[6].TypeEnum());
        }

        [TestMethod]
        public void TestClassDefinition()
        {
            var tokens = GetTokens("Object subclass: #ClassName \r\n  instanceVariableNames: \r\n 'ab cd' \r\n  classVariableNames: ''\r\n  poolDictionaries: ''  !");
            Assert.AreEqual(25, tokens.Count);
            int i = 0;
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.HASH, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[i++].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[i++].TypeEnum());
        }

        [TestMethod]
        public void TestString()
        {
            var tokens = GetTokens("'This is a Smalltalk string'");
            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[0].TypeEnum());
            Assert.AreEqual("'This is a Smalltalk string'", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[1].TypeEnum());
        }

        [TestMethod]
        public void TestSymbol()
        {
            var tokens = GetTokens("#symbol");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.HASH, tokens[0].TypeEnum());
            Assert.AreEqual("#", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[1].TypeEnum());
            Assert.AreEqual("symbol", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());

            tokens = GetTokens("#controlEvent:id:");
            Assert.AreEqual(6, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.HASH, tokens[0].TypeEnum());
            Assert.AreEqual("#", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[1].TypeEnum());
            Assert.AreEqual("controlEvent", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[2].TypeEnum());
            Assert.AreEqual(":", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[3].TypeEnum());
            Assert.AreEqual("id", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[4].TypeEnum());
            Assert.AreEqual(":", tokens[4].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[5].TypeEnum());

        }

        [TestMethod]
        public void TestSymbolWithSpace()
        {
            var tokens = GetTokens("#'symbol with space'");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.HASH, tokens[0].TypeEnum());
            Assert.AreEqual("#", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.STRING, tokens[1].TypeEnum());
            Assert.AreEqual("'symbol with space'", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[2].TypeEnum());
        }

        [TestMethod]
        public void TestAssignment()
        {
            var tokens = GetTokens("abc := 123");
            Assert.AreEqual(6, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[0].TypeEnum());
            Assert.AreEqual("abc", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(" ", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.ASSIGNMENT, tokens[2].TypeEnum());
            Assert.AreEqual(":=", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[3].TypeEnum());
            Assert.AreEqual(" ", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[4].TypeEnum());
            Assert.AreEqual("123", tokens[4].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[5].TypeEnum());

            tokens = GetTokens("abc:=123");
            Assert.AreEqual(4, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[0].TypeEnum());
            Assert.AreEqual("abc", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.ASSIGNMENT, tokens[1].TypeEnum());
            Assert.AreEqual(":=", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[2].TypeEnum());
            Assert.AreEqual("123", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[3].TypeEnum());
        }

        [TestMethod]
        public void TestKeyWord()
        {
            var tokens = GetTokens("abc ifTrue: [] ifFalse: [].");
            Assert.AreEqual(15, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[0].TypeEnum());
            Assert.AreEqual("abc", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(" ", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[2].TypeEnum());
            Assert.AreEqual("ifTrue", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[3].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[4].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[5].TypeEnum());
            Assert.AreEqual("[", tokens[5].Text);
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[6].TypeEnum());
            Assert.AreEqual("]", tokens[6].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[7].TypeEnum());
            Assert.AreEqual(" ", tokens[7].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[8].TypeEnum());
            Assert.AreEqual("ifFalse", tokens[8].Text);
            Assert.AreEqual(SmalltalkTokenType.COLON, tokens[9].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[10].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.BLOCK_START, tokens[11].TypeEnum());
            Assert.AreEqual("[", tokens[11].Text);
            Assert.AreEqual(SmalltalkTokenType.BLOCK_END, tokens[12].TypeEnum());
            Assert.AreEqual("]", tokens[12].Text);
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[13].TypeEnum());
            Assert.AreEqual(".", tokens[13].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[14].TypeEnum());
        }

        [TestMethod]
        public void TestUnarySelector()
        {
            var tokens = GetTokens("abc not.");
            Assert.AreEqual(5, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[0].TypeEnum());
            Assert.AreEqual("abc", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[1].TypeEnum());
            Assert.AreEqual(" ", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[2].TypeEnum());
            Assert.AreEqual("not", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.PERIOD, tokens[3].TypeEnum());
            Assert.AreEqual(".", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[4].TypeEnum());
        }

        [TestMethod]
        public void TestDynamicArray()
        {
            var tokens = GetTokens("#(1 2)");
            Assert.AreEqual(6, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.LITARR_START, tokens[0].TypeEnum());
            Assert.AreEqual("#(", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[1].TypeEnum());
            Assert.AreEqual("1", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[2].TypeEnum());
            Assert.AreEqual(" ", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.DIGITS, tokens[3].TypeEnum());
            Assert.AreEqual("2", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.CLOSE_PAREN, tokens[4].TypeEnum());
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[5].TypeEnum());
        }

        [TestMethod]
        public void TestMethodGroup()
        {
            var tokens = GetTokens("!FileCache methods !");
            Assert.AreEqual(7, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[0].TypeEnum());
            Assert.AreEqual("!", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[1].TypeEnum());
            Assert.AreEqual("FileCache", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[2].TypeEnum());
            Assert.AreEqual(" ", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[3].TypeEnum());
            Assert.AreEqual("methods", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[4].TypeEnum());
            Assert.AreEqual(" ", tokens[4].Text);
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[5].TypeEnum());
            Assert.AreEqual("!", tokens[5].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[6].TypeEnum());
        }

        [TestMethod]
        public void TestClassMethodGroup()
        {
            var tokens = GetTokens("!FileCache class methods !");
            Assert.AreEqual(9, tokens.Count);
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[0].TypeEnum());
            Assert.AreEqual("!", tokens[0].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[1].TypeEnum());
            Assert.AreEqual("FileCache", tokens[1].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[2].TypeEnum());
            Assert.AreEqual(" ", tokens[2].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[3].TypeEnum());
            Assert.AreEqual("class", tokens[3].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[4].TypeEnum());
            Assert.AreEqual(" ", tokens[4].Text);
            Assert.AreEqual(SmalltalkTokenType.IDENTIFIER, tokens[5].TypeEnum());
            Assert.AreEqual("methods", tokens[5].Text);
            Assert.AreEqual(SmalltalkTokenType.WS, tokens[6].TypeEnum());
            Assert.AreEqual(" ", tokens[6].Text);
            Assert.AreEqual(SmalltalkTokenType.BANG, tokens[7].TypeEnum());
            Assert.AreEqual("!", tokens[7].Text);
            Assert.AreEqual(SmalltalkTokenType.EOF, tokens[8].TypeEnum());
        }

        private IList<IToken> GetTokens(string code)
        {
            var lexer = new SmalltalkLexer(new AntlrInputStream(code));
            var tokensStream = new CommonTokenStream(lexer);
            tokensStream.Fill();
            return tokensStream.GetTokens();
        }
    }
}
