# Decorator Pattern 装饰模式
## Definition

Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
<br>动态地给一个对象添加一些额外的职责。就增加功能来说，装饰模式相比生成子类更为灵活。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/decorator.gif)


## Participants

The classes and objects participating in this pattern are:

### Component   (LibraryItem)
* defines the interface for objects that can have responsibilities added to them dynamically.

### ConcreteComponent   (Book, Video)
* defines an object to which additional responsibilities can be attached.

### Decorator   (Decorator)
* maintains a reference to a Component object and defines an interface that conforms to Component's interface.

### ConcreteDecorator   (Borrowable)
* adds responsibilities to the component.

