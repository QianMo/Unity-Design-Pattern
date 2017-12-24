# Subclass Sandbox Pattern 子类沙盒模式

## Intent 意义

Define behavior in a subclass using a set of operations provided by its base class.
<br>
使用基类提供的操作集合来定义子类中的行为。



## The Pattern 模式描述

A base class defines an abstract sandbox method and several provided operations. Marking them protected makes it clear that they are for use by derived classes. Each derived sandboxed subclass implements the sandbox method using the provided operations.
<br>
一个基类定义了一个抽象的沙盒方法和一些预定义的操作集合。通过将它们设置为受保护的状态以确保它们仅供子类使用。每个派生出的沙盒子类根据父类提供的操作来实现沙盒函数。



## When to Use It 使用情形

The Subclass Sandbox pattern is a very simple, common pattern lurking in lots of codebases, even outside of games. If you have a non-virtual protected method laying around, you’re probably already using something like this. Subclass Sandbox is a good fit when:

- You have a base class with a number of derived classes.

- The base class is able to provide all of the operations that a derived class may need to perform.

- There is behavioral overlap in the subclasses and you want to make it easier to share code between them.

- You want to minimize coupling between those derived classes and the rest of the program.

沙盒模式是运用在多数代码库里、甚至游戏之外的一种非常简单通用的模式。如果你正在部署一个非虚的受保护方法，那么你很可能正在使用与之类似的模式。沙盒模式适用于以下情况：
- 你有一个带大量子类的基类。
- 基类能够提供所有子类可能需要执行的操作集合。
- 在子类之间有重叠的代码，你希望在它们之间更简便地共享代码。
- 你希望使这些继承类与程序其他代码之间的耦合最小化。



