using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PW.Smalltalk.Parser
{
    public enum SmalltalkTokenType
    {
        EOF = -1,
        STRING = SmalltalkLexer.STRING,
        COMMENT = SmalltalkLexer.COMMENT,
        BLOCK_START = SmalltalkLexer.BLOCK_START,
        BLOCK_END = SmalltalkLexer.BLOCK_END,
        CLOSE_PAREN = SmalltalkLexer.CLOSE_PAREN,
        OPEN_PAREN = SmalltalkLexer.OPEN_PAREN,
        PIPE = SmalltalkLexer.PIPE,
        PERIOD = SmalltalkLexer.PERIOD,
        SEMI_COLON = SmalltalkLexer.SEMI_COLON,
        LESSTHAN = SmalltalkLexer.LESSTHAN,
        GREATERTHAN = SmalltalkLexer.GREATERTHAN,
        MINUS = SmalltalkLexer.MINUS,
        MOD = SmalltalkLexer.MOD,
        DIV = SmalltalkLexer.DIV,
        PLUS = SmalltalkLexer.PLUS,
        MULTIPLY = SmalltalkLexer.MULTIPLY,
        DIVIDE = SmalltalkLexer.DIVIDE,
        EQUALS = SmalltalkLexer.EQUALS,
        NOT_EQUAL = SmalltalkLexer.NOT_EQUAL,
        IDENTICAL = SmalltalkLexer.IDENTICAL,
        NOT_IDENTICAL = SmalltalkLexer.NOT_IDENTICAL,
        GREATERTHAN_OR_EQUAL = SmalltalkLexer.GREATERTHAN_OR_EQUAL,
        LESSTHAN_OR_EQUAL = SmalltalkLexer.LESSTHAN_OR_EQUAL,
        COMMA = SmalltalkLexer.COMMA,
        AT = SmalltalkLexer.AT,
        PERCENT = SmalltalkLexer.PERCENT,
        TILDE = SmalltalkLexer.TILDE,
        AMPERSAND = SmalltalkLexer.AMPERSAND,
        QUESTION = SmalltalkLexer.QUESTION,
        SELF = SmalltalkLexer.SELF,
        SUPER = SmalltalkLexer.SUPER,
        NIL = SmalltalkLexer.NIL,
        TRUE = SmalltalkLexer.TRUE,
        FALSE = SmalltalkLexer.FALSE,
        IDENTIFIER = SmalltalkLexer.IDENTIFIER,
        CARROT = SmalltalkLexer.CARROT,
        COLON = SmalltalkLexer.COLON,
        ASSIGNMENT = SmalltalkLexer.ASSIGNMENT,
        HASH = SmalltalkLexer.HASH,
        DOLLAR = SmalltalkLexer.DOLLAR,
        BASE = SmalltalkLexer.BASE,
        LITARR_START = SmalltalkLexer.LITARR_START,
        DIGITS = SmalltalkLexer.DIGITS,
        DIGITS_BASEN = SmalltalkLexer.DIGITS_BASEN,
        CHARACTER_CONSTANT = SmalltalkLexer.CHARACTER_CONSTANT,
        BANG = SmalltalkLexer.BANG,
        WS = SmalltalkLexer.WS
    }

    public static class TokenExtensions
    {
        public static SmalltalkTokenType TypeEnum(this IToken token)
        {
            return (SmalltalkTokenType)token.Type;
        }
    }
}
