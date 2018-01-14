# Dirty Flag Pattern 脏标记模式

## Intent 意义

Avoid unnecessary work by deferring it until the result is needed.
<br>
将工作推迟到必要时进行以避免不必要的工作。



## The Pattern 模式描述

A set of primary data changes over time. A set of derived data is determined from this using some expensive process. A “dirty” flag tracks when the derived data is out of sync with the primary data. It is set when the primary data changes. If the flag is set when the derived data is needed, then it is reprocessed and the flag is cleared. Otherwise, the previous cached derived data is used.

一组原始数据随时间变化。一组颜色数据经过一些代价昂贵的操作由这些数据确定。一个脏标记跟踪这个衍生数据是否和原始数据同步。它在原始数据改变时被设置。如果它被设置了，那么当需要衍生数据时，它们就会被重新计算并且标记被清除。否则就使用缓存的数据。





## When to Use It 使用情形

就像其他优化模式一样，此模式会增加代码复杂度。只在有足够大的性能问题时，再考虑使用这一模式。

脏标记在这两种情况下适用：
- 当前任务有昂贵的计算开销
- 当前任务有昂贵的同步开销。
若满足这两者之一，也就是两者从原始数据转换到目标数据会消耗很多时间，都可以考虑使用脏标记模式来节省开销。

若原始数据的变化速度远高于目标数据的使用速度，此时数据会因为随后的修改而失效，此时就不适合使用脏标记模式。

