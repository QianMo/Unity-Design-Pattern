# Type Object Pattern 类型对象模式

## Definition

Allow the flexible creation of new “classes” by creating a single class, each instance of which represents a different type of object.
<br>
通过创建一个类来支持新类型的灵活创建，其每个实例都代表一个不同对象类型。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/type-object.png)
两个类，无限的种类

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

