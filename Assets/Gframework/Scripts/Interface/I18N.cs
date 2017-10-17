using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gframework.Core.Interface
{
    /// <summary>
    /// MultiLanguage Interface
    /// </summary>
    public interface I18N
    {
        /// <summary>
        /// Set Language
        /// </summary>
        /// <param name="languageKey"></param>
        void SetLanguage(string languageKey);
    }
}
