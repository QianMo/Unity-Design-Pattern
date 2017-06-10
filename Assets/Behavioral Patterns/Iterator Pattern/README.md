# Iterator Pattern 迭代器模式
## Definition

Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
<br>提供一种方法访问一个容器对象中各个元素，而又不需暴露该对象的内部细节。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/iterator.gif)


## Participants

The classes and objects participating in this pattern are:

### Iterator  (AbstractIterator)
* defines an interface for accessing and traversing elements.

### ConcreteIterator  (Iterator)
* implements the Iterator interface.
* keeps track of the current position in the traversal of the aggregate.

### Aggregate  (AbstractCollection)
* defines an interface for creating an Iterator object

### ConcreteAggregate  (Collection)
* implements the Iterator creation interface to return an instance of the proper ConcreteIterator

