using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// Node Command That Can Undo
    /// </summary>
    public interface INodeUndo:INodeCommand
    {
        /// <summary>
        /// Undo
        /// </summary>
        void Undo();
    }
}
