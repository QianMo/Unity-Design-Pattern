# Observer Pattern 观察者模式
## Definition

Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
<br>定义对象间一种一对多的依赖关系，使得每当一个对象改变状态，则所有依赖于它的对象都会得到通知并被自动更新。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/observer.gif)


## Participants

The classes and objects participating in this pattern are:

### Subject  (Stock)
* knows its observers. Any number of Observer objects may observe a subject
* provides an interface for attaching and detaching Observer objects.

### ConcreteSubject  (IBM)
* stores state of interest to ConcreteObserver
* sends a notification to its observers when its state changes

### Observer  (IInvestor)
* defines an updating interface for objects that should be notified of changes in a subject.

### ConcreteObserver  (Investor)
* maintains a reference to a ConcreteSubject object
* stores state that should stay consistent with the subject's
* implements the Observer updating interface to keep its state consistent with the subject's

