# Adapter Pattern
##Definition
	Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
	
![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/adapter.gif)

##Participants

The classes and objects participating in this pattern are:

###Target   (ChemicalCompound)
defines the domain-specific interface that Client uses.
###Adapter   (Compound)
adapts the interface Adaptee to the Target interface.
###Adaptee   (ChemicalDatabank)
defines an existing interface that needs adapting.
###Client   (AdapterApp)
collaborates with objects conforming to the Target interface.


