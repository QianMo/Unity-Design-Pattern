# Type Object Pattern 类型对象模式

## Definition

Allow the flexible creation of new “classes” by creating a single class, each instance of which represents a different type of object.
<br>
通过创建一个类来支持新类型的灵活创建，其每个实例都代表一个不同对象类型。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/type-object.png)
两个类，无限的种类


## The Pattern

Define a type object class and a typed object class. Each type object instance represents a different logical type. Each typed object stores a reference to the type object that describes its type.

Instance-specific data is stored in the typed object instance, and data or behavior that should be shared across all instances of the same conceptual type is stored in the type object. Objects referencing the same type object will function as if they were the same type. This lets us share data and behavior across a set of similar objects, much like subclassing lets us do, but without having a fixed set of hard-coded subclasses.


## When to Use It 

This pattern is useful anytime you need to define a variety of different “kinds” of things, but baking the kinds into your language’s type system is too rigid. In particular, it’s useful when either of these is true:

You don’t know what types you will need up front. (For example, what if our game needed to support downloading content that contained new breeds of monsters?)

You want to be able to modify or add new types without having to recompile or change code.


