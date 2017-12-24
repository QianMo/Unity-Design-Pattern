# Type Object Pattern 类型对象模式

## Intent 意义

Allow the flexible creation of new “classes” by creating a single class, each instance of which represents a different type of object.
<br>
通过创建一个类来支持新类型的灵活创建，其每个实例都代表一个不同对象类型。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/type-object.png)

两个类，可以实现无限的种类


## The Pattern 模式描述

Define a type object class and a typed object class. Each type object instance represents a different logical type. Each typed object stores a reference to the type object that describes its type.

Instance-specific data is stored in the typed object instance, and data or behavior that should be shared across all instances of the same conceptual type is stored in the type object. Objects referencing the same type object will function as if they were the same type. This lets us share data and behavior across a set of similar objects, much like subclassing lets us do, but without having a fixed set of hard-coded subclasses.

定义一个类型对象类和一个持有类型对象的类。每个类型对象的实例表示一个不同的逻辑类型。每个持有类型对象类的实例引用一个描述其类型的类型对象。

实例数据被存储在持有类型对象的实例中，而所有同概念类型所共享的数据和行为被存储在类型对象中。引用同一个类型对象的对象之间能表示出“同类”的特性。这让我们可以在相似对象集合中共享数据和行为，这与类派生的作用有几分相似，但却无需硬编码出一批派生类。


## When to Use It 使用情形

This pattern is useful anytime you need to define a variety of different “kinds” of things, but baking the kinds into your language’s type system is too rigid. In particular, it’s useful when either of these is true:

- You don’t know what types you will need up front. (For example, what if our game needed to support downloading content that contained new breeds of monsters?)

- You want to be able to modify or add new types without having to recompile or change code.

当你需要定义一系列不同“种类”的东西，但又不想把那些种类硬编码进你的类型系统时，本模式都适用。尤其其是当下面任意一项成立时：
- 你不知道将来会有什么类型（例如，我们的游戏是否需要指出包含怪物新种类的资料包下载？）
- 你需要在不重新编译或修改代码的情况下，修改或添加新的类型。



