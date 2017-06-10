# Bridge Pattern 桥接模式
## Definition

Decouple an abstraction from its implementation so that the two can vary independently.
<br>将抽象和实现解耦，使得两者可以独立地变化。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/bridge.gif)


## Participants

The classes and objects participating in this pattern are:

### Abstraction   (BusinessObject)
* defines the abstraction's interface.
* maintains a reference to an object of type Implementor.

### RefinedAbstraction   (CustomersBusinessObject)
* extends the interface defined by Abstraction.

### Implementor   (DataObject)
* defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface; in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives.

### ConcreteImplementor   (CustomersDataObject)
* implements the Implementor interface and defines its concrete implementation.

