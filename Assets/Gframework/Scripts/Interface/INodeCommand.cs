using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// Base Node Command
    /// </summary>
    public interface INodeCommand
    {

        /// <summary>
        /// Excute Command
        /// </summary>
        void Do();
        /// <summary>
        /// Exit Command
        /// </summary>
        void Quit();

    }
}
