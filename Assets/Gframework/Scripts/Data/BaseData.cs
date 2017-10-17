using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Gframework
{
    /// <summary>
    /// Base Data Model
    /// </summary>
    public abstract class BaseData:ICloneable
    {

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
       


    }

}

