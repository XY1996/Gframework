using System.Collections;
using System.Collections.Generic;
using Gframework;
using Gframework.Core.Interface;
using UnityEngine;

namespace Gframework
{
    /// <summary>
    /// Manager base Scripts
    /// </summary>
    public class ManagerBaseScripts : BehaviourScript, IManager
    {

        protected bool isInitialize = false;



        /// <summary>
        /// IsInitialize
        /// return true if Init
        /// </summary>
        public bool IsInitialize { get { return isInitialize; } }
        /// <summary>
        /// Initialize Function
        /// return false If Has been Initialized Before or Initialized fail
        /// </summary>
        public virtual bool Initialize()
        {
            if (isInitialize)
            {
                return false;
            }
            isInitialize = true;
            return true;
        }


        /// <summary>UnInitialize</summary>
        public virtual void UnInitialize()
        {
            isInitialize = false;
        }
    }
}

