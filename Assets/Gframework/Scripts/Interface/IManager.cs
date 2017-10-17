using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// Manager Interface
    /// </summary>
    public interface IManager
    {

        /// <summary>
        /// IsInitialize
        /// </summary>
        bool IsInitialize { get; }
        /// <summary>
        /// Initialize
        /// </summary>
        bool Initialize();
        /// <summary>
        /// UnInitialize
        /// </summary>
        void UnInitialize();
    }
}
