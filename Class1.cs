using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Stocker
{
    class Site_6pm
    {
        
       
       
        //go throw hmtl collection of "select" and get all colors
        public Site_6pm()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Get data from site 6pm.com");
        }
        public NameValueCollection GetColors(HtmlElementCollection htmlcol)
        {
            NameValueCollection allColors = new NameValueCollection();
            allColors.Clear();
            //get a collection of the parent "select" elements first
            if (htmlcol[0].Name == "colorId")
            { //if the select element is the dropdown we need to select something for
              //create another element collection for the child elements of the "select" element
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allColors.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }
            for (int s = 0; s < allColors.Count; s++)
                Console.WriteLine(allColors.Get(s) + "=" + allColors.GetKey(s));

            return allColors;
        }
        //go throw hmtl collection of "select" and get all  sizes
        public NameValueCollection GetSizes(HtmlElementCollection htmlcol)
        {
            NameValueCollection allSizes = new NameValueCollection();
            allSizes.Clear();
            if (htmlcol[0].Name == "dimensionValues")
            {
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }else if (htmlcol.Count == 2 && htmlcol[1].Name == "dimensionValues")
            {
                HtmlElementCollection htmlcolchild = htmlcol[1].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }
            for (int s = 0; s < allSizes.Count; s++)
                Console.WriteLine(allSizes.Get(s) + "=" + allSizes.GetKey(s));

            return allSizes;
        }

       
       

    }
}
