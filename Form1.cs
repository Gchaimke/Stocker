using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;

namespace Stocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Create a WebBrowser instance. 
        string stock;
        NameValueCollection allColors = new NameValueCollection();
        NameValueCollection allSizes = new NameValueCollection();
        private void AddProduct()
        {
            ListViewItem product = new ListViewItem(TbProdName.Text );
            product.SubItems.Add(tBstockId.Text);
            product.SubItems.Add(tBProductUrl.Text);
            product.SubItems.Add("Not Checked");
            listView1.Items.Add(product);
        }

        private void GetColorsAndSizes(HtmlElementCollection htmlcol)
        {
            //get a collection of the parent "select" elements first
                if (htmlcol[0].Name == "colorId") //if the select element is the dropdown we need to select something for
                {
                    //create another element collection for the child elements of the "select" element
                    HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                    for (int j = 0; j < htmlcolchild.Count; j++)
                    {
                        allColors.Add (htmlcolchild[j].InnerText,htmlcolchild[j].GetAttribute("value"));
                        
                    }
                }

                if (htmlcol[1].Name == "dimensionValues") //if the select element is the dropdown we need to select something for
                {
                    //create another element collection for the child elements of the "select" element
                    HtmlElementCollection htmlcolchild = htmlcol[1].Children;
                    for (int j = 0; j < htmlcolchild.Count; j++)
                    {
                        allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));

                    }
                }
            
        }

        private void chekStock(HtmlElement colorElm, HtmlElement sizeElm, NameValueCollection colors, NameValueCollection sizes, WebBrowser wb, int p) {
          string strColorSizes = "";
            for (int i=0; i<colors.Count; i++)
            {
                
                string tmp = "";
                strColorSizes += colors.GetKey(i)+":";
                for (int s=1; s<sizes.Count; s++)
                {
                    if (OptionClick1(sizeElm, sizes.Get(s), wb, p) == true)
                    {
                        tmp += sizes.GetKey(s) + "/";
                    }

                }
                strColorSizes +=tmp +"   ";
                listView1.Items[p].SubItems[3].Text = strColorSizes;

                OptionClick1(colorElm, colors.Get(i), wb, p);
            }
            
        }
        private bool OptionClick1(HtmlElement options, string option, WebBrowser wb,int p)
        {
            if (options.Id != null)
            {
                options.Focus();
                options.SetAttribute("value", option);
                options.RaiseEvent("onChange");
                options.RemoveFocus();
            }
            option = null;
            var product = wb.Document.GetElementById(listView1.Items[p].SubItems[1].Text);
            string getstock = "";
            getstock = product.InnerText;
            if (!getstock.Contains("Out of Stock"))
            {
                return true;
            }
            return false;
        }

        struct Void { }; // use an empty struct as parameter to generic TaskCompletionSource

        async Task DoNavigationAsync()
        {
            WebBrowser wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            Void v;
            TaskCompletionSource<Void> tcs = null;
            WebBrowserDocumentCompletedEventHandler documentComplete = null;

            documentComplete = new WebBrowserDocumentCompletedEventHandler((s, e) =>
            {
                wb.DocumentCompleted -= documentComplete;
                tcs.SetResult(v); // continue from where awaited
            });

            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {
                tcs = new TaskCompletionSource<Void>();
                wb.DocumentCompleted += documentComplete;
                wb.Navigate(listView1.Items[i].SubItems[2].Text);
                await Task.Delay(500);
                await tcs.Task;
                wb.SetBounds(10,10,900,900);
                // do whatever you want with this instance of WB.Document
                try{
                    HtmlElementCollection htmlcol = wb.Document.GetElementsByTagName("select");
                    GetColorsAndSizes(htmlcol);
                    Console.WriteLine("--------------------------------------");
                    for (int s = 0; s < allColors.Count; s++)
                        Console.WriteLine(allColors.Get(s) + "=" + allColors.GetKey(s));
                    for (int s = 0; s < allSizes.Count; s++)
                        Console.WriteLine(allSizes.Get(s) + "=" + allSizes.GetKey(s));

                    chekStock(htmlcol[0], htmlcol[1], allColors, allSizes, wb, i);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    stock = "not found";
                }
                progressBar1.Value += 5;
            }
            wb.Dispose();
            //return;
        }

        private void BtnAddProd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void BtnGetStock_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 10;
            var task = DoNavigationAsync();
            task.ContinueWith((t) =>
            {
                //MessageBox.Show("Navigation done!");
                progressBar1.Value = 100;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void deleteSelsectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach(ListViewItem lvi in listView1.SelectedItems)
                {
                    lvi.Remove();
                }
            }
        }


        //end  
    }
}
