# Service Locator Pattern 服务定位器模式

## Intent 意义

Provide a global point of access to a service without coupling users to the concrete class that implements it.
<br>
提供服务的全局接入点，而不必让用户和实现它的具体类耦合。



## The Pattern 模式描述

A service class defines an abstract interface to a set of operations. A concrete service provider implements this interface. A separate service locator provides access to the service by finding an appropriate provider while hiding both the provider’s concrete type and the process used to locate it.
一个服务类为一系列操作定义了一个抽象的接口。一个具体的服务提供者实现这个接口。一个单独的服务定位器通过查找一个合适的提供器来提供这个服务的访问，它同时屏蔽了提供器的具体类型和定位这个服务的过程。



## When to Use It 使用情形


Instead of using a global mechanism to give some code access to an object it needs, first consider passing the object to it instead. That’s dead simple, and it makes the coupling completely obvious. That will cover most of your needs.

But… there are some times when manually passing around an object is gratuitous or actively makes code harder to read. Some systems, like logging or memory management, shouldn’t be part of a module’s public API. The parameters to your rendering code should have to do with rendering, not stuff like logging.

Likewise, other systems represent facilities that are fundamentally singular in nature. Your game probably only has one audio device or display system that it can talk to. It is an ambient property of the environment, so plumbing it through ten layers of methods just so one deeply nested call can get to it is adding needless complexity to your code.

In those kinds of cases, this pattern can help. As we’ll see, it functions as a more flexible, more configurable cousin of the Singleton pattern. When used well, it can make your codebase more flexible with little runtime cost.

The core difficulty with a service locator is that it takes a dependency — a bit of coupling between two pieces of code — and defers wiring it up until runtime. This gives you flexibility, but the price you pay is that it’s harder to understand what your dependencies are by reading the code.

一般通过使用单例或者静态类来实现服务定位模式，提供服务的全局接入点。
服务定位模式可以看做是更加灵活，更加可配置的单例模式。如果用得好，它能以很小的运行时开销，换取很大的灵活性。相反，如果用得不好，它会带来单例模式的所有缺点以及更多的运行时开销。
使用服务定位器的核心难点是它将依赖，也就是两块代码之间的一点耦合，推迟到运行时再连接。这有了更大的灵活度，但是代价是更难在阅读代码时理解其依赖的是什么


## Tips


服务定位器模式在很多方面和单例模式非常相近，所以值得考虑两者来决定哪一个更适合你的需求。

Unity引擎把这个模式和组件模式结合起来，并使用在了GetComponent()方法中。
