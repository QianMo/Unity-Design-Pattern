# Builder Pattern 建造者模式
## Definition

Separate the construction of a complex object from its representation so that the same construction process can create different representations.
<br>将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示，这样的设计模式被称为建造者模式。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/builder.gif)


## Participants

The classes and objects participating in this pattern are:

### Builder  (VehicleBuilder)
* specifies an abstract interface for creating parts of a Product object

### ConcreteBuilder  (MotorCycleBuilder, CarBuilder, ScooterBuilder)
* constructs and assembles parts of the product by implementing the Builder interface
* defines and keeps track of the representation it creates
* provides an interface for retrieving the product

### Director  (Shop)
* constructs an object using the Builder interface

### Product  (Vehicle)
* represents the complex object under construction. ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled
* includes classes that define the constituent parts, including interfaces for assembling the parts into the final result

