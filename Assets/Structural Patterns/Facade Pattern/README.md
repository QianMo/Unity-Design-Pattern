# Facade Pattern 外观模式
## Definition

Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use.
<br>要求一个子系统的外部与其内部的通信必须通过一个统一的对象进行。外观模式提供一个高层次的接口，使得子系统更易于使用。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/facade.gif)


## Participants

The classes and objects participating in this pattern are:

### Facade   (MortgageApplication)
* knows which subsystem classes are responsible for a request.
* delegates client requests to appropriate subsystem objects.

### Subsystem classes   (Bank, Credit, Loan)
* implement subsystem functionality.
* handle work assigned by the Facade object.
* have no knowledge of the facade and keep no reference to it.

