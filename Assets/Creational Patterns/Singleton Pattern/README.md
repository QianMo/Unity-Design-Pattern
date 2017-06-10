# Singleton Pattern 单例模式
## Definition

Ensure a class has only one instance and provide a global point of access to it.
<br>确保某一个类只有一个实例，而且自行实例化并向整个系统提供这个实例。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/singleton.gif)


## Participants

The classes and objects participating in this pattern are:

### Singleton   (LoadBalancer)
* defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
* responsible for creating and maintaining its own unique instance.

