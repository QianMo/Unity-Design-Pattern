# Component Pattern 组件模式

## Intent 意义

Allow a single entity to span multiple domains without coupling the domains to each other
<br>
允许一个单一的实体跨越多个不同域而不会导致耦合。



## The Pattern 模式描述

A single entity spans multiple domains. To keep the domains isolated, the code for each is placed in its own component class. The entity is reduced to a simple container of components.
<br>
单一实体横跨了多个域。为了能够保持域之间相互隔离，每个域的代码都独立地放在自己的组件类中。实体本身则可以简化为这些组件的容器。




## When to Use It 使用情形

Components are most commonly found within the core class that defines the entities in a game, but they may be useful in other places as well. This pattern can be put to good use when any of these are true:

- You have a class that touches multiple domains which you want to keep decoupled from each other.
- A class is getting massive and hard to work with.
- You want to be able to define a variety of objects that share different capabilities, but using inheritance doesn’t let you pick the parts you want to reuse precisely enough.

组件最常见于游戏中定义实体的核心类，但是它们也能够用在别的地方。当如下条件成立时，组件模式就能够发挥它的作用：
- 你有一个涉及多个域的类，但是你希望这些域保持相互解耦。
- 一个类越来越庞大，越来越难以开发。
- 你希望定义许多共享不同能力的对象，但采用继承的办法却无法令你精确地重用代码。


## Tips

Unity引擎的主要设计正是围绕组件模型来进行的。
