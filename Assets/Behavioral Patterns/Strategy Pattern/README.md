# Strategy Pattern 策略模式
## Definition

Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
<br>定义一组算法，将每个算法都封装起来，并且使它们之间可以互换

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/strategy.gif)


## Participants

The classes and objects participating in this pattern are:

### Strategy  (SortStrategy)
* declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy

### ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
* implements the algorithm using the Strategy interface

### Context  (SortedList)
* is configured with a ConcreteStrategy object
* maintains a reference to a Strategy object
* may define an interface that lets Strategy access its data.

