using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gframework
{
    /// <summary>
    /// Base Data Model
    /// </summary>
    public abstract class BaseData
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        public string Description { get; set; }

    }

}

