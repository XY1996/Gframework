using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// Control Command Excute Speed
    /// </summary>
    public interface INodeSpeedControllable:INodeCommand,INodePauseable
    {
        /// <summary>
        /// Change Command Speed
        /// </summary>
        /// <param name="speed"></param>
        void ChangeSpeed(float speed);
    }
}
