# Visitor Pattern 访问者模式
## Definition

Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.
<br>封装一些作用于某种数据结构中的各元素的操作，它可以在不改变数据结构的前提下定义作用于这些元素的新的操作。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/visitor.gif)


## Participants

The classes and objects participating in this pattern are:

### Visitor  (Visitor)
* declares a Visit operation for each class of ConcreteElement in the object structure. The operation's name and signature identifies the class that sends the Visit request to the visitor. That lets the visitor determine the concrete class of the element being visited. Then the visitor can access the elements directly through its particular interface

### ConcreteVisitor  (IncomeVisitor, VacationVisitor)
* implements each operation declared by Visitor. Each operation implements a fragment of the algorithm defined for the corresponding class or object in the structure. ConcreteVisitor provides the context for the algorithm and stores its local state. This state often accumulates results during the traversal of the structure.

### Element  (Element)
* defines an Accept operation that takes a visitor as an argument.

### ConcreteElement  (Employee)
* implements an Accept operation that takes a visitor as an argument

### ObjectStructure  (Employees)
* can enumerate its elements
* may provide a high-level interface to allow the visitor to visit its elements
* may either be a Composite (pattern) or a collection such as a list or a set

