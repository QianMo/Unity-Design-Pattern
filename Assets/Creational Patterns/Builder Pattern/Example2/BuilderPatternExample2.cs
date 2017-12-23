//-------------------------------------------------------------------------------------
//	BuilderPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace BuilderPatternExample2
{
    public class BuilderPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            IRobotBuilder oldRobot = new OldRobotBuilder();
            RobotEngineer engineer = new RobotEngineer(oldRobot);
            engineer.MakeRobot();

            Robot firstRobot = engineer.GetRobot();
            Debug.Log("First Robot built");
            Debug.Log(firstRobot.ToStringEX());
        }
    }

    public interface IRobotPlan
    {
        void SetRobotHead(string head);

        void SetRobotTorso(string torso);

        void SetRobotArms(string arms);

        void SetRobotLegs(string legs);
    }

    public class Robot : IRobotPlan
    {
        public string head { get; protected set; }
        public string torso { get; protected set; }
        public string arms { get; protected set; }
        public string legs { get; protected set; }

        public void SetRobotHead(string head)
        {
            this.head = head;
        }

        public void SetRobotTorso(string torso)
        {
            this.torso = torso;
        }

        public void SetRobotArms(string arms)
        {
            this.arms = arms;
        }

        public void SetRobotLegs(string legs)
        {
            this.legs = legs;
        }

        public string ToStringEX()
        {
            return "Head: " + this.head + ", torso: " + this.torso + ", Arms: " + arms + ", legs: " + legs;
        }
    }




    // they're kinda like a blueprint these RobotBuilder classes:
    public interface IRobotBuilder
    {
        Robot GetRobot();
        void BuildRobotHead();
        void BuildRobotTorso();
        void BuildRobotArms();
        void BuildRobotLegs();
    }

    // for each new robot that you might want to have just create a new RobotBuilder Object
    public class OldRobotBuilder : IRobotBuilder
    {
        protected Robot robot { get; set; }

        public OldRobotBuilder()
        {
            this.robot = new Robot();
        }

        public Robot GetRobot()
        {
            return robot;
        }

        public void BuildRobotHead()
        {
            this.robot.SetRobotHead("Old Head");
        }

        public void BuildRobotTorso()
        {
            this.robot.SetRobotTorso("Old Torso");
        }

        public void BuildRobotArms()
        {
            this.robot.SetRobotArms("Old Arms");
        }

        public void BuildRobotLegs()
        {
            this.robot.SetRobotLegs("Roller Skates");
        }
    }



    // he just calls the method in the Robot Objects (which are defined by the interface, just think of blueprints)
    public class RobotEngineer
    {
        public IRobotBuilder robotBuilder { get; protected set; }

        public RobotEngineer(IRobotBuilder builder)
        {
            this.robotBuilder = builder;
        }

        public Robot GetRobot()
        {
            return this.robotBuilder.GetRobot();
        }

        public void MakeRobot()
        {
            this.robotBuilder.BuildRobotHead();
            this.robotBuilder.BuildRobotTorso();
            this.robotBuilder.BuildRobotArms();
            this.robotBuilder.BuildRobotLegs();
        }
    }


}
