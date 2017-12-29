# Event Queue Pattern 事件队列模式

## Intent 意义

Decouple when a message or event is sent from when it is processed.
<br>
对消息或事件的发送与受理进行时间上的解耦。



## The Pattern 模式描述

A queue stores a series of notifications or requests in first-in, first-out order. Sending a notification enqueues the request and returns. The request processor then processes items from the queue at a later time. Requests can be handled directly or routed to interested parties. This decouples the sender from the receiver both statically and in time.

事件队列是一个按照先进先出顺序存储一系列通知或者请求的队列。发出通知时系统会将该请求置入队列并返回，请求处理器随后从事件队列中获取并处理这些请求。请求可由处理器直接处理或转交给对其感兴趣的模块。这一模式对消息的发送者与受理者进行了解耦，使消息的处理变得动态且非实时。




## When to Use It 使用情形

If you only want to decouple who receives a message from its sender, patterns like Observer and Command will take care of this with less complexity. You only need a queue when you want to decouple something in time.

I mention this in nearly every chapter, but it’s worth emphasizing. Complexity slows you down, so treat simplicity as a precious resource.

I think of it in terms of pushing and pulling. You have some code A that wants another chunk B to do some work. The natural way for A to initiate that is by pushing the request to B.

Meanwhile, the natural way for B to process that request is by pulling it in at a convenient time in its run cycle. When you have a push model on one end and a pull model on the other, you need a buffer between them. That’s what a queue provides that simpler decoupling patterns don’t.

Queues give control to the code that pulls from it — the receiver can delay processing, aggregate requests, or discard them entirely. But queues do this by taking control away from the sender. All the sender can do is throw a request on the queue and hope for the best. This makes queues a poor fit when the sender needs a response.

如果你只是想解耦接收者和发送者，像观察者模式和命令模式都可以用较小的复杂度来进行处理。在需要解耦某些实时的内容时才建议使用事件队列。

不妨用推和拉来的情形来考虑。有一块代码A需要另一块代码B去做些事情。对A自然的处理方式是将请求推给B。

同时，对B自然的处理方式是在B方便时将请求拉入。当一端有推模型另一端有拉模型时，你就需要在它们间放一个缓冲的区域。 这就是队列比简单的解耦模式多出来的那一部分。

队列给了代码对拉取的控制权——接收者可以延迟处理，合并或者忽视请求。发送者能做的就是向队列发送请求然后就完事了，并不能决定什么时候发送的请求会受到处理。而当发送者需要一些回复反馈时，队列模式就不是一个好的选择。


## Tips

Unity引擎的主要设计正是围绕组件模型来进行的。
