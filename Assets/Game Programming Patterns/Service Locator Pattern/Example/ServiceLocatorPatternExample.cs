//-------------------------------------------------------------------------------------
//	ServiceLocatorPatternExample.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace ServiceLocatorPatternExample
{
    public class ServiceLocatorPatternExample : MonoBehaviour
    {
        void Start()
        {
            //注册到服务定位器
            TheAudioPlayer audio = new TheAudioPlayer();
            ServiceLocator.RegisterService(audio);
        }

        void Update()
        {
            //播放声音
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var audio=ServiceLocator.GetAudioService();
                if (audio!=null)
                {
                    audio.PlaySound(1);
                }
            }

            //结束声音
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var audio = ServiceLocator.GetAudioService();
                if (audio != null)
                {
                    audio.StopSound(1);
                }
            }

            //结束所有声音
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                var audio = ServiceLocator.GetAudioService();
                if (audio != null)
                {
                    audio.StopAllSounds();
                }
            }

            //注册日志音频类
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ServiceLocator.EnableAudioLogging();
            }
        }


    }



    /// <summary>
    /// 服务定位器管理类
    /// </summary>
    public class ServiceLocator
    {
        static IAudio AudioService_;
        static NullAudio NullAudioService_;

        public static IAudio GetAudioService() { return AudioService_; }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="service"></param>
        public static void RegisterService(IAudio service)
        {
            if (service == null)
            {
                // Revert to null service.
                AudioService_ = NullAudioService_;
            }
            else
            {
                AudioService_ = service;
            }
            Debug.Log("[ServiceLocator]Finish Register Service!");
        }

        /// <summary>
        ///  注册带日志的音频类
        /// </summary>
        public static void EnableAudioLogging()
        {
            // Decorate the existing service.
            IAudio service = new LoggedAudio(ServiceLocator.GetAudioService());

            // Swap it in.
            RegisterService(service);
        }

    }



    /// <summary>
    ///音频接口 
    /// </summary>
    public interface IAudio
    {
        void PlaySound(int soundID);
        void StopSound(int soundID);
        void StopAllSounds();
    };

    /// <summary>
    /// 实际的播放音频的实现类
    /// </summary>
    public class TheAudioPlayer : IAudio
    {
        public void PlaySound(int soundID)
        {
            // Play sound using console audio api...
            Debug.Log("Play Sound ! ID = "+soundID.ToString());
        }

        public void StopSound(int soundID)
        {
            // Stop sound using console audio api...
            Debug.Log("Stop Sound ! ID = " + soundID.ToString());
        }

        public void StopAllSounds()
        {
            // Stop all sounds using console audio api...
            Debug.Log("Stop All Sound ! ");
        }
    };

    /// <summary>
    ///  null音频类
    /// </summary>
    public class NullAudio : IAudio
    {
        public void PlaySound(int soundID) { /* Do nothing. */ }
        public void StopSound(int soundID) { /* Do nothing. */ }
        public void StopAllSounds() { /* Do nothing. */ }
    };

    /// <summary>
    /// 带日志的音频类
    /// </summary>
    class LoggedAudio : IAudio
    {

        IAudio wrapped_;
        public LoggedAudio(IAudio wrapped)
        {
            wrapped_ = wrapped;
        }

        public void PlaySound(int soundID)
        {
            Log("[LoggedAudio]Play sound!");
            wrapped_.PlaySound(soundID);
        }

        public void StopSound(int soundID)
        {
            Log("[LoggedAudio]Stop sound!");
            wrapped_.StopSound(soundID);
        }

        public void StopAllSounds()
        {
            Log("[LoggedAudio]Stop all sounds!");
            wrapped_.StopAllSounds();
        }

        private void Log(string message)
        {
            Debug.LogError(message);
            // Code to log message...
        }
    }



}



