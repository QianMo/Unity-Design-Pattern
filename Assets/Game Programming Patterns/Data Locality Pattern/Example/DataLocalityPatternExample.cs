//-------------------------------------------------------------------------------------
//	DataLocalityPatternExample.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace DataLocalityPatternExample
{
    public class DataLocalityPatternExample : MonoBehaviour
    {
        GameX gameProject;

        void Start()
        {
            gameProject = new GameX();
            gameProject.Start();
        }

        void Update()
        {
            if (gameProject!=null)
            {
                gameProject.Update();
            }
        }
    }

    /// <summary>
    /// 游戏应用程序类
    /// </summary>
    public class GameX
    {
        const int MAX_ENTITIES = 10000;

        int numEntities;

        /// <summary>
        /// 基于大数组存储保证数据连续性
        /// </summary>
        AIComponent[] aiComponents = new AIComponent[MAX_ENTITIES];
        PhysicsComponent[] physicsComponents = new PhysicsComponent[MAX_ENTITIES];
        RenderComponent[] renderComponents = new RenderComponent[MAX_ENTITIES];

        public void Start()
        {
            numEntities = 10;
            for (int i = 0; i < numEntities; i++)
            {
                aiComponents[i] = new AIComponent();
                physicsComponents[i] = new PhysicsComponent();
                renderComponents[i] = new RenderComponent();
            }

        }


        public void Update()
        {
            // Process AI.
            for (int i = 0; i < numEntities; i++)
            {
                if (aiComponents!=null && aiComponents.Length>i && aiComponents[i]!= null)
                {
                    aiComponents[i].Update();
                }
            }

            // Update physics.
            for (int i = 0; i < numEntities; i++)
            {
                if (physicsComponents != null && physicsComponents.Length > i && physicsComponents[i] != null)
                {
                    physicsComponents[i].Update();
                }

            }

            // Draw to screen.
            for (int i = 0; i < numEntities; i++)
            {
                if (renderComponents != null && renderComponents.Length > i && renderComponents[i] != null)
                {
                    renderComponents[i].Render();
                }
            }
        }



        /// <summary>
        /// 组件接口
        /// </summary>
        public interface IComponent
        {
            void Update();
        }

        /// <summary>
        /// AI组件
        /// </summary>
        public class AIComponent : IComponent
        {
            public void Update()
            {
                Debug.Log("AIComponent Update!");
            }
        }

        /// <summary>
        /// 物理组件
        /// </summary>
        public class PhysicsComponent : IComponent
        {
            public void Update()
            {
                Debug.Log("PhysicsComponent Update!");
            }
        }

        /// <summary>
        /// 渲染组件
        /// </summary>
        public class RenderComponent : IComponent
        {
            public void Update()
            {
                Debug.Log("RenderComponent Update!");
            }


            public void Render()
            {
                Debug.Log("RenderComponent Render!");
            }
        }

    }
    }
