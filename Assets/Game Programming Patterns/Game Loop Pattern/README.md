# Game Loop Pattern 游戏循环模式 

## Intent 意义

Decouple the progression of game time from user input and processor speed.
<br>
游戏循环模式，实现游戏运行过程中对用户输入处理和时间处理的解耦。



## The Pattern 模式描述

A game loop runs continuously during gameplay. Each turn of the loop, it processes user input without blocking, updates the game state, and renders the game. It tracks the passage of time to control the rate of gameplay.

游戏循环模式：游戏循环在游戏过程中持续运转。每循环一次，它非阻塞地处理用户的输入，更新游戏状态，并渲染游戏。它跟踪流逝的时间并控制游戏的速率。

游戏循环将游戏的处理过程和玩家输入解耦，和处理器速度解耦，实现用户输入和处理器速度在游戏行进时间上的分离。

游戏循环也许需要与平台的事件循环相协调。如果在操作系统的高层或有图形UI和内建事件循环的平台上构建游戏，那就有了两个应用循环在同时运作，需要对他们进行相应的协调。



## When to Use It 使用情形

任何游戏或游戏引擎都拥有自己的游戏循环，因为游戏循环是游戏运行的主心骨。

Unity已经内建了游戏循环模式，即Update( )方法。
