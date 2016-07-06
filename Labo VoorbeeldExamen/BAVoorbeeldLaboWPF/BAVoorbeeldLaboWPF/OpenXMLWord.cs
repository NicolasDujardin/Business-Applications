using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXMLDemo
{
    public class OpenXMLWord
    {
        public static void InsertBookMarkText(string sourceFile, string destinationFile, Dictionary<string,string> bookMarksAndText)
        {
            File.Copy(sourceFile, destinationFile, true);

            WordprocessingDocument newdoc = WordprocessingDocument.Open(destinationFile, true);
            IDictionary<String, BookmarkStart> bookmarks = new Dictionary<String, BookmarkStart>();

            foreach (BookmarkStart bms in newdoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
            {
                bookmarks[bms.Name] = bms;
            }
            foreach(string bmkey in bookMarksAndText.Keys)
            {
                string bmtext = bookMarksAndText[bmkey];
                bookmarks[bmkey].Parent.InsertAfter<Run>(new Run(new Text(bmtext)), bookmarks[bmkey]);
            }
            newdoc.Close();
        }
    }
}
