//-------------------------------------------------------------------------------------
//	AdapterPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace AdapterPatternExample2
{

    public class AdapterPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            IEnemyAttacker tank = new EnemyTank();

            EnemyRobot fredTheRobot = new EnemyRobot();
            IEnemyAttacker adapter = new EnemyRobotAdaper(fredTheRobot);

            fredTheRobot.ReactToHuman("Hans");
            fredTheRobot.WalkForward();

            tank.AssignDriver("Frank");
            tank.DriveForward();
            tank.FireWeapon();

            adapter.AssignDriver("Mark");
            adapter.DriveForward();
            adapter.FireWeapon();
        }
    }




    public interface IEnemyAttacker
    {
        void FireWeapon();
        void DriveForward();
        void AssignDriver(string driver);
    }


    public class EnemyTank : IEnemyAttacker
    {
        public void FireWeapon()
        {
            int attackDamage = Random.Range(1, 10);
            Debug.Log("Enemy Tank does " + attackDamage + " damage");
        }

        public void DriveForward()
        {
            int movement = Random.Range(1, 5);
            Debug.Log("Enemy Tank moves " + movement + " spaces");
        }

        public void AssignDriver(string driver)
        {
            Debug.Log(driver + " is driving the tank");
        }
    }




    // Adaptee:
    public class EnemyRobot
    {
        public void SmashWithHands()
        {
            int attackDamage = Random.Range(1, 10);
            Debug.Log("Robot causes " + attackDamage + " damage with it hands");
        }

        public void WalkForward()
        {
            int movement = Random.Range(1, 3);
            Debug.Log("Robot walks " + movement + " spaces");
        }

        public void ReactToHuman(string driverName)
        {
            Debug.Log("Robot tramps on " + driverName);
        }
    }


    public class EnemyRobotAdaper : IEnemyAttacker
    {
        EnemyRobot robot;

        public EnemyRobotAdaper(EnemyRobot robot)
        {
            this.robot = robot;
        }

        public void FireWeapon()
        {
            robot.SmashWithHands();
        }

        public void DriveForward()
        {
            robot.WalkForward();
        }

        public void AssignDriver(string driver)
        {
            robot.ReactToHuman(driver);
        }
    }
}
