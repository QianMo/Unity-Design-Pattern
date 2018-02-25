# Object Pool Pattern 对象池模式

## Intent 意义

Improve performance and memory use by reusing objects from a fixed pool instead of allocating and freeing them individually.
<br>
使用固定的对象池重用对象，取代单独地分配和释放对象，以此来达到提升性能和优化内存使用的目的。



## The Pattern 模式描述

Define a pool class that maintains a collection of reusable objects. Each object supports an “in use” query to tell if it is currently “alive”. When the pool is initialized, it creates the entire collection of objects up front (usually in a single contiguous allocation) and initializes them all to the “not in use” state.

When you want a new object, ask the pool for one. It finds an available object, initializes it to “in use”, and returns it. When the object is no longer needed, it is set back to the “not in use” state. This way, objects can be freely created and destroyed without needing to allocate memory or other resources.

定义一个保持着可重用对象集合的对象池类。其中的每个对象支持对其“使用（in use）”状态的访问，以确定这一对象目前是否“存活（alive）”。在对象池初始化时，它预先创建整个对象集合（通常为一块连续堆区域），并将它们都置为“未使用（not in use）”状态。

当我们想要创建一个新对象时，就向对象池请求。它将搜索到一个可用的对象，将其初始化为“使用中（in use）”状态并返回给你。当该对象不再被使用时，它将被置回“未使用（not in use）”状态。使用该方法，对象便可以在无需进行内存或其他资源分配的情况下进行任意的创建和销毁。



## When to Use It 使用情形

This pattern is used widely in games for obvious things like game entities and visual effects, but it is also used for less visible data structures such as currently playing sounds. Use Object Pool when:

- You need to frequently create and destroy objects.
- Objects are similar in size.
- Allocating objects on the heap is slow or could lead to memory fragmentation.
- Each object encapsulates a resource such as a database or network connection that is expensive to acquire and could be reused.


此模式被广泛地应用于游戏中的可见物体，如游戏实体对象、各种视觉特效。但是它也可在非可见的数据结构上使用，比如当前播放的声音。

满足以下情况可以使用对象池：

- 需要频繁创建和销毁对象时。
- 对象大小一致时。
- 在堆上分配对象缓慢或者会导致内存碎片时。
- 每个对象都封装了很昂贵且又可以重用的资源，如数据库、网络的连接。
