/**
* \file      Page.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      December 4. 2018
* \brief     Page class.
*
* \details   This class represent a page. It contains the text and the image displayed in the text in the form.
*/

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Xarxaria
{
    class Page
    {
        #region private attributes
        string title;
        string text;
        string image;
        int id;
        #endregion

        #region public accessor
        public string Title { get { return title; } }
        public string Text { get { return text; } }
        public string Image { get { return image; } }
        public int Id { get { return id; } }
        #endregion

        #region constructor
        /// <summary>
        /// Page constructor. Set id, title, text and an image name.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="image"></param>
        public Page(int id = 0, string title = "", string text = "", string image = "")
        {
            this.id = id;
            this.title = title;
            this.text = text;
            this.image = image;
        }
        #endregion
    }
}
