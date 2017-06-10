# Mediator Pattern 中介者模式
## Definition

Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
<br>用一个中介对象封装一系列的对象交互，中介者使各对象不需要显示地相互作用，从而使其耦合松散，而且可以独立地改变它们之间的交互。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/mediator.gif)


## Participants

The classes and objects participating in this pattern are:

### Mediator  (IChatroom)
* defines an interface for communicating with Colleague objects

### ConcreteMediator  (Chatroom)
* implements cooperative behavior by coordinating Colleague objects
* knows and maintains its colleagues

### Colleague classes  (Participant)
* each Colleague class knows its Mediator object
* each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague

