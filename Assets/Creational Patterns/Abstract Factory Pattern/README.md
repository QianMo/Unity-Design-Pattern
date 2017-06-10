# Abstract Factory Pattern 抽象工厂模式
## Definition

Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
<br>提供一个接口，用于创建相关或者依赖对象的家族，而不需要指定具体的实现类。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/abstract.gif)


## Participants

The classes and objects participating in this pattern are:

### AbstractFactory  (ContinentFactory)
* declares an interface for operations that create abstract products

### ConcreteFactory   (AfricaFactory, AmericaFactory)
* implements the operations to create concrete product objects

### AbstractProduct   (Herbivore, Carnivore)
* declares an interface for a type of product object

### Product  (Wildebeest, Lion, Bison, Wolf)
* defines a product object to be created by the corresponding concrete factory
* implements the AbstractProduct interface

### Client  (AnimalWorld)
* uses interfaces declared by AbstractFactory and AbstractProduct classes


