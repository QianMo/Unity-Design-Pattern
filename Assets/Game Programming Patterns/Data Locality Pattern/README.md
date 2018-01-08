# Data Locality Pattern 数据局部性模式

## Intent 意义

Accelerate memory access by arranging data to take advantage of CPU caching.
<br>
通过合理组织数据利用CPU的缓存机制来加快内存访问速度。



## The Pattern 模式描述

Modern CPUs have caches to speed up memory access. These can access memory adjacent to recently accessed memory much quicker. Take advantage of that to improve performance by increasing data locality — keeping data in contiguous memory in the order that you process it.

现代的CPU有缓存来加速内存读取，其可以更快地读取最近访问过的内存毗邻的内存。基于这一点，我们通过保证处理的数据排列在连续内存上，以提高内存局部性，从而提高性能。

为了保证数据局部性，就要避免的缓存不命中。也许你需要牺牲一些宝贵的抽象。你越围绕数据局部性设计程序，就越放弃继承、接口和它们带来的好处。没有银弹，只有权衡。




## When to Use It 使用情形

使用数据局部性的第一准则是在遇到性能问题时使用。不要将其应用在代码库不经常使用的角落上。 优化代码后其结果往往更加复杂，更加缺乏灵活性。

就本模式而言，还得确认你的性能问题确实由缓存不命中而引发的。如果代码是因为其他原因而缓慢，这个模式自然就不会有帮助。

简单的性能评估方法是手动添加指令，用计时器检查代码中两点间消耗的时间。而为了找到糟糕的缓存使用情况，知道缓存不命中有多少发生，又是在哪里发生的，则需要使用更加复杂的工具—— profilers。

组件模式是为缓存优化的最常见例子。而任何需要接触很多数据的关键代码，考虑数据局部性都是很重要的。


