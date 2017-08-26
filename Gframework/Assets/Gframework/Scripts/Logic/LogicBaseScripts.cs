using System.Collections;
using System.Collections.Generic;
using Gframework.Core.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Gframework
{
    /// <summary>
    /// LogicBae
    /// </summary>
    public class LogicBaseScripts : BehaviourScript, INodeCommand
    {
        /// <summary>
        /// Logic Status
        /// </summary>
        public enum LogicStatus
        {
            Start,
            Running,
            Paused,
            Finished,
            Quit
        }



        /// <summary>
        /// Invoke Before Excute
        /// </summary>
        public UnityAction OnEnter;
        /// <summary>
        /// Invoke After Excute
        /// </summary>
        public UnityAction OnExit;

        /// <summary>
        /// Status
        /// </summary>
        private LogicStatus status = LogicStatus.Start;

        /// <summary>
        /// Status
        /// </summary>
        public LogicStatus Status => status;



        /// <summary>Excute Command</summary>
        public void Do()
        {
            status = LogicStatus.Running;
            OnEnter?.Invoke();
            Excute();
            status = LogicStatus.Finished;
            OnExit?.Invoke();
        }

        /// <summary>Exit Command</summary>
        public void Quit()
        {
            Exit();
            status = LogicStatus.Quit;
            OnExit?.Invoke();
        }

        /// <summary>Exit Command</summary>
        protected virtual void Exit()
        {

        }
        /// <summary>
        /// Excute 
        /// </summary>
        protected virtual void Excute()
        {

        }

    }
}

