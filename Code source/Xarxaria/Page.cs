using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xarxaria
{
    class Page
    {
        #region private attributes
        string title;
        string text;
        #endregion

        #region accessor
        public string Title { get { return title; } }
        public string Text { get { return text; } }
        #endregion

        #region constructor

        public Page(string title = "", string text = "")
        {
            this.title = title;
            this.text = text;
        }

        #endregion
    }
}
