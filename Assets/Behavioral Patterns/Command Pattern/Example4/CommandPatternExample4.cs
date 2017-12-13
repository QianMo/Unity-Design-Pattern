//-------------------------------------------------------------------------------------
//	CommandPatternExample4.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternExample4
{
    public class CommandPatternExample4 : MonoBehaviour
    {
        void Start()
        {
            Invoker theInvoker = new Invoker();

            Command theCommand = null;
            // 结合命令与执行者
            theCommand = new ConcreteCommand1(new Receiver1(), "hi");
            theInvoker.AddCommand(theCommand);
            theCommand = new ConcreteCommand2(new Receiver2(), 666);
            theInvoker.AddCommand(theCommand);

            // 进行执行
            theInvoker.ExecuteCommand();
        }

    }


    /// <summary>
    /// 命令抽象类
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
    }

    /// <summary>
    /// 实际命令1-绑定命令和receiver
    /// </summary>
    public class ConcreteCommand1 : Command
    {
        Receiver1 m_Receiver = null;
        string m_Command = "";

        public ConcreteCommand1(Receiver1 Receiver, string param)
        {
            m_Receiver = Receiver;
            m_Command = param;
        }

        public override void Execute()
        {
            m_Receiver.Action(m_Command);
        }
    }

    /// <summary>
    /// 实际命令2-绑定命令和receiver
    /// </summary>
    public class ConcreteCommand2 : Command
    {
        Receiver2 m_Receiver = null;
        int m_Param = 0;

        public ConcreteCommand2(Receiver2 Receiver, int Param)
        {
            m_Receiver = Receiver;
            m_Param = Param;
        }

        public override void Execute()
        {
            m_Receiver.Action(m_Param);
        }
    }

    /// <summary>
    /// 功能执行者1
    /// </summary>
    public class Receiver1
    {
        public Receiver1() { }
        public void Action(string param)
        {
            Debug.Log("Receiver1.Action:Command[" + param + "]");
        }
    }

    /// <summary>
    /// 功能执行者2
    /// </summary>
    public class Receiver2
    {
        public Receiver2() { }
        public void Action(int Param)
        {
            Debug.Log("Receiver2.Action:Param[" + Param.ToString() + "]");
        }
    }


    /// <summary>
    /// 命令管理者
    /// </summary>
    public class Invoker
    {
        List<Command> m_Commands = new List<Command>();

        // 加入命令
        public void AddCommand(Command theCommand)
        {
            m_Commands.Add(theCommand);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public void ExecuteCommand()
        {
            // 执行
            foreach (Command theCommand in m_Commands)
                theCommand.Execute();
            // 清空 
            m_Commands.Clear();
        }
    }







}