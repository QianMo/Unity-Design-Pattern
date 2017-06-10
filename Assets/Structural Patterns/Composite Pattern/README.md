# Composite Pattern 组合模式
## Definition

Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
<br>将对象组合成树形结构以表示“部分-整体”的层次结构，使得用户对单个对象和组合对象的使用具有一致性。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/composite.gif)


## Participants

The classes and objects participating in this pattern are:

### Component   (DrawingElement)
* declares the interface for objects in the composition.
* implements default behavior for the interface common to all classes, as appropriate.
* declares an interface for accessing and managing its child components.
* (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate.

### Leaf   (PrimitiveElement)
* represents leaf objects in the composition. A leaf has no children.
* defines behavior for primitive objects in the composition.

### Composite   (CompositeElement)
* defines behavior for components having children.
* stores child components.
* implements child-related operations in the Component interface.

### Client  (CompositeApp)
* manipulates objects in the composition through the Component interface.

