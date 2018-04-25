using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
   public  class Books
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        DateTime publishDate;

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        string iSBN;

        public string ISBN
        {
            get { return iSBN; }
            set { iSBN = value; }
        }
        int wordsCount;

        public int WordsCount
        {
            get { return wordsCount; }
            set { wordsCount = value; }
        }
        decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        string contentDescription;

        public string ContentDescription
        {
            get { return contentDescription; }
            set { contentDescription = value; }
        }
        string aurhorDescription;

        public string AurhorDescription
        {
            get { return aurhorDescription; }
            set { aurhorDescription = value; }
        }
        string editorComment;

        public string EditorComment
        {
            get { return editorComment; }
            set { editorComment = value; }
        }
       string tOC;

       public string TOC
       {
           get { return tOC; }
           set { tOC = value; }
       }
       int clicks;

       public int Clicks
       {
           get { return clicks; }
           set { clicks = value; }
       }
       Publishers publisher;

       public Publishers Publisher
       {
           get { return publisher; }
           set { publisher = value; }
       }
       Catagory catagorys;

       public Catagory Catagorys
       {
           get { return catagorys; }
           set { catagorys = value; }
       }
    }
}
