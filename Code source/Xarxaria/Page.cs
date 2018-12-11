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
        string image;
        #endregion

        #region accessor
        public string Title { get { return title; } }
        public string Text { get { return text; } }
        public string Image { get { return image; } }
        #endregion

        #region constructor

        public Page(string title = "", string text = "", string image = "")
        {
            this.title = title;
            this.text = text;
            this.image = image;
        }

        #endregion
    }
}
