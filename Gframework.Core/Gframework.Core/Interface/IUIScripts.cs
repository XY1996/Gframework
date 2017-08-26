using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// UI Scripts Interface
    /// </summary>
    public interface  IUIScripts
    {
        /// <summary>
        /// Show
        /// </summary>
        void Show();

        /// <summary>
        /// Hide
        /// </summary>
        void Hide();
        /// <summary>
        /// Clear
        /// </summary>
        void Clear();
        /// <summary>
        /// Refresh
        /// </summary>
        void Refresh();
    }
}
