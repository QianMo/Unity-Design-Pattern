# Interpreter Pattern 解释器模式
## Definition

Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.
<br>给定一门语言，定义它的文法的一种表示，并定义一个解释器，该解释器使用该表示来解释语言中的句子。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/interpreter.gif)


## Participants

The classes and objects participating in this pattern are:

### AbstractExpression  (Expression)
* declares an interface for executing an operation

### TerminalExpression  ( ThousandExpression, HundredExpression, TenExpression, OneExpression )
* implements an Interpret operation associated with terminal symbols in the grammar.
* an instance is required for every terminal symbol in the sentence.

### NonterminalExpression  ( not used )
* one such class is required for every rule R ::= R1R2...Rn in the grammar
* maintains instance variables of type AbstractExpression for each of the symbols R1 through Rn.
* implements an Interpret operation for nonterminal symbols in the grammar. Interpret typically calls itself recursively on the variables representing R1 through Rn.

### Context  (Context)
* contains information that is global to the interpreter

### Client  (InterpreterApp)
* builds (or is given) an abstract syntax tree representing a particular sentence in the language that the grammar defines. The abstract syntax tree is assembled from instances of the NonterminalExpression and TerminalExpression classes
* invokes the Interpret operation

