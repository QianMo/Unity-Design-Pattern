# Factory Method Pattern 工厂方法模式
## Definition

Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.
<br>定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法使一个类的实例化延迟到其子类。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/factory.gif)


## Participants

The classes and objects participating in this pattern are:

### Product  (Page)
* defines the interface of objects the factory method creates
* ConcreteProduct  (SkillsPage, EducationPage, ExperiencePage)
* implements the Product interface

### Creator  (Document)
* declares the factory method, which returns an object of type Product. Creator may also define a default implementation of the factory method that returns a default ConcreteProduct object.
* may call the factory method to create a Product object.

### ConcreteCreator  (Report, Resume)
* overrides the factory method to return an instance of a ConcreteProduct.

