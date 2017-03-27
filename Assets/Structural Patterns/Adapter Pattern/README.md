# Adapter Pattern 适配器模式
## Definition
Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
<br>将一个类的接口转换成客户希望的另外一个接口。适配器模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。
	
![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/adapter.gif)

## Participants

The classes and objects participating in this pattern are:

### Target   (ChemicalCompound)
* defines the domain-specific interface that Client uses.

### Adapter   (Compound)
* adapts the interface Adaptee to the Target interface.

### Adaptee   (ChemicalDatabank)
* defines an existing interface that needs adapting.

### Client   (AdapterApp)
* collaborates with objects conforming to the Target interface.


