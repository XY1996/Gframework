using System.Collections;
using System.Collections.Generic;
using Gframework;
using Gframework.Core.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Gframework
{
    /// <summary>
    /// UIBaseScripts
    /// </summary>
    public class UIBaseScript : BehaviourScript,IUIScripts,I18N
    {
        /// <summary>
        /// UIStatus
        /// </summary>
        public enum UIStatus
        {
            Show,
            Hide,
        }

        /// <summary>
        /// Invoke After Show
        /// </summary>
        public UnityAction OnShow;
        /// <summary>
        /// Invoke After Hide
        /// </summary>
        public UnityAction OnHide;

        /// <summary>
        /// UIStatus
        /// </summary>
        private UIStatus status;

        /// <summary>
        /// Current Langugae
        /// </summary>
        private string currentLanguage;

        /// <summary>
        /// UIStatus
        /// </summary>
        public UIStatus Status { get { return status; } }
        /// <summary>
        /// Language
        /// </summary>
        public string LanguageKey { get; set; }


        /// <summary>Show</summary>
        public virtual void Show()
        {
            status = UIStatus.Show;
            OnShow?.Invoke();
        }

        /// <summary>Hide</summary>
        public virtual void Hide()
        {
            status = UIStatus.Hide;
            OnHide?.Invoke();
        }

        /// <summary>Clear</summary>
        public virtual void Clear()
        {
            
        }

        /// <summary>Refresh</summary>
        public virtual void Refresh()
        {
            if (currentLanguage != LanguageKey)
            {
                SetLanguage(LanguageKey);              
            }
        }

        /// <summary>Set Language</summary>
        /// <param name="languageKey"></param>
        public virtual void SetLanguage(string languageKey)
        {
            currentLanguage = LanguageKey;
        }
    }
}

