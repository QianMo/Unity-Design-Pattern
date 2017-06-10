# Prototype Pattern 原型模式
## Definition

Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
<br>用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/prototype.gif)


## Participants

The classes and objects participating in this pattern are:

### Prototype  (ColorPrototype)
* declares an interface for cloning itself

### ConcretePrototype  (Color)
* implements an operation for cloning itself

### Client  (ColorManager)
* creates a new object by asking a prototype to clone itself

