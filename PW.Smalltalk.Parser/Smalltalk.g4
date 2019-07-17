grammar Smalltalk;

/*
* Parser Rules
*/

sourceFile
	:	ws classDefinition? ws metaClassDefinition? ws classMethods? ws instanceMethods? ws EOF
	;

classDefinition
	:	(superClassName ws keyword ws className ws keyword ws instanceVariableNames ws keyword ws classVariableNames ws keyword ws poolDictionaries ws BANG) | (superClassName ws keyword ws variableByteClassName ws keyword ws classVariableNames ws keyword ws poolDictionaries ws BANG)
	;

metaClassDefinition
	:	ws IDENTIFIER ws IDENTIFIER ws keyword ws classInstanceVariableNames ws BANG
	;

superClassName
	:	IDENTIFIER
	;

variableByteClassName
	:	symbol
	;

className
	:	symbol
	;

classInstanceVariableNames
	:	string
	;

instanceVariableNames
	:	string
	;

poolDictionaries
	:	string
	;

classVariableNames
	:	string
	;

classMethods
	:	BANG IDENTIFIER ws IDENTIFIER ws IDENTIFIER ws BANG ws (method ws BANG)* ws BANG
	;

instanceMethods
	:	BANG IDENTIFIER ws IDENTIFIER ws BANG ws (method ws BANG)* ws BANG
	;

method
	:	message ws COMMENT? ws sequence?
	;

methodBody
	:	WS? sequence EOF
	;

sequence
	:	temps? ws statements?
	;

ws
	:	( WS | COMMENT )*
	;

temps
	:	PIPE ( ws IDENTIFIER )+ ws PIPE
	;

statements
	:	answer ws PERIOD? # StatementAnswer | expressions ws PERIOD ws answer ws PERIOD? # StatementExpressionsAnswer | expressions ws PERIOD? ws # StatementExpressions | COMMENT? #EmptyExpressions
	;

answer
	:	CARROT ws expression ws PERIOD?
	;

expression
	:	assignment | cascade | keywordSend | binarySend | primitive
	;

expressions
	:	expression expressionList*
	;

expressionList
	:	PERIOD ws expression
	;

cascade
	:	( keywordSend | binarySend ) ( ws SEMI_COLON ws message )+
	;

message
	:	binaryMessage | unaryMessage | keywordMessage
	;

assignment
	:	variable ws ASSIGNMENT ws expression
	;

variable
	:	IDENTIFIER
	;

binarySend
	:	unarySend binaryTail?
	;

unarySend
	:	operand ws unaryTail?
	;

keywordSend
	:	binarySend keywordMessage
	;

keywordMessage
	:	ws ( keywordPair ws )+
	;

keywordPair
	:	keyword ws binarySend ws
	;

keyword
	:	IDENTIFIER COLON
	;

operand
	:	literal | reference | subexpression
	;

subexpression
	:	OPEN_PAREN ws expression ws CLOSE_PAREN
	;

literal
	:	runtimeLiteral | parsetimeLiteral
	;

runtimeLiteral
	:	block
	;

block
	:	BLOCK_START blockParamList? ws sequence? BLOCK_END
	;

blockParamList
	:	(ws? blockParam )+ ws PIPE
	;

blockParam
	:	COLON IDENTIFIER 
	;

parsetimeLiteral
	:	pseudoVariable | number | charConstant | literalArray | string | symbol
	;

number
	:	numberExp | stIntegerBaseN | stFloat | stInteger
	;

numberExp
	:	( stFloat | stInteger ) EXP stInteger
	;

charConstant
	:	CHARACTER_CONSTANT
	;

stIntegerBaseN
	:	MINUS? DIGITS_BASEN
	;

stInteger
	:	MINUS? DIGITS
	;

stFloat
	:	MINUS? DIGITS+ PERIOD DIGITS+
	;

pseudoVariable
	:	SUPER | SELF | NIL | TRUE | FALSE
	;

string
	:	STRING
	;

symbol
	:	HASH bareSymbol
	;

primitive
	:	LESSTHAN keyword WS? (IDENTIFIER WS?)* GREATERTHAN ws CARROT ws SELF ws IDENTIFIER
	;

bareSymbol
	:	(IDENTIFIER | MOD | DIV | PLUS | MULTIPLY | DIVIDE | EQUALS | IDENTICAL | NOT_EQUAL | NOT_IDENTICAL | GREATERTHAN_OR_EQUAL | LESSTHAN_OR_EQUAL | GREATERTHAN | LESSTHAN | COMMA | AT | PIPE | AMPERSAND | MINUS | QUESTION) | keyword | keywords | string
	;

literalArray
	:	LITARR_START literalArrayRest
	;

literalArrayRest
	:	ws ( ( parsetimeLiteral | bareLiteralArray | bareSymbol ) ws )* CLOSE_PAREN
	;

bareLiteralArray
	:	OPEN_PAREN literalArrayRest
	;

unaryTail
	:	unaryMessage ws unaryTail? ws
	;

unaryMessage
	:	ws unarySelector
	;

unarySelector
	:	IDENTIFIER
	;

keywords
	:	(IDENTIFIER COLON)+
	;

reference
	:	variable
	;

binaryTail
	:	binaryMessage binaryTail?
	;

binaryMessage
	:	ws (MOD | DIV | PLUS | MULTIPLY | DIVIDE | EQUALS | IDENTICAL | NOT_EQUAL | NOT_IDENTICAL | GREATERTHAN_OR_EQUAL | LESSTHAN_OR_EQUAL | GREATERTHAN | LESSTHAN | COMMA | AT | PIPE | AMPERSAND | MINUS) ws ( unarySend | operand )
	;

/*
* Lexer Rules
*/

STRING
	:	'\'' ( . )*? '\''
	;

COMMENT
	:	'"' ( . )*? '"'
	;

BLOCK_START
	:	'['
	;

BLOCK_END
	:	']'
	;

CLOSE_PAREN
	:	')'
	;

OPEN_PAREN
	:	'('
	;

PIPE
	:	'|'
	;

PERIOD
	:	'.'
	;

SEMI_COLON
	:	';'
	;

LESSTHAN_OR_EQUAL
	:	'<='
	;

LESSTHAN
	:	'<'
	;

GREATERTHAN_OR_EQUAL
	:	'>='
	;

GREATERTHAN
	:	'>'
	;

MINUS
	:	'-'
	;

MOD
	:	'\\\\'
	;

DIV
	:	'//'
	;

PLUS
	:	'+'
	;

MULTIPLY
	:	'*'
	;

DIVIDE
	:	'/'
	;

EQUALS
	:	'='
	;

NOT_EQUAL
	:	'~='
	;

IDENTICAL
	:	'=='
	;

NOT_IDENTICAL
	:	'~~'
	;

COMMA
	:	','
	;

AT
	:	'@'
	;

PERCENT
	:	'%'
	;

TILDE
	:	'~'
	;

AMPERSAND 
	:	'&'
	;

QUESTION 
	:	'?'
	;

SUPER
	:	'super'
	;

SELF
	:	'self'
	;

FALSE
	:	'false'
	;

TRUE
	:	'true'
	;

NIL
	:	'nil'
	;

CARROT
	:	'^'
	;

ASSIGNMENT
	:	':='
	;

COLON
	:	':'
	;

HASH
	:	'#'
	;

BANG
	:	'!'
	;

DOLLAR
	:	'$'
	;

BASE
	: [2-9]'r' | [1-2][0-9]'r' | [3][0-6]'r'
	;

LITARR_START
	:	'#('
	;

DIGITS
	:	[0-9]+
	;

DIGITS_BASEN
	:	BASE [0-9A-Z]+
	;

IDENTIFIER
	:	[a-zA-Z]+ [a-zA-Z0-9_]*
	;

CHARACTER_CONSTANT
	:	DOLLAR ( . )
	;

WS
	:[ \r\n\t]+
	;
