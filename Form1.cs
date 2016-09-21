using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        NameValueCollection allColors = new NameValueCollection();
        NameValueCollection  allSizes = new NameValueCollection();
        Boolean haveColor, haveSize ;
        WebBrowser wb = new WebBrowser();
        //Method to add products to list view

        public void AddProduct()
        {
            ListViewItem product = new ListViewItem(TbProdName.Text);
            product.SubItems.Add(tBProductUrl.Text);
            product.SubItems.Add("Not Checked");
            product.SubItems.Add(tBstockId.Text);
            if (tBColorId.Text.Replace("  ", "") == "")
            {
                product.SubItems.Add("0");
            }
            else
            {
                product.SubItems.Add(tBColorId.Text);
            }
            if (tBSizeId.Text.Replace("  ", "") == "")
            {
                product.SubItems.Add("0");
            }
            else
            {
                product.SubItems.Add( tBSizeId.Text);
            }

            listView1.Items.Add(product);
        }

        private void SetListview1(int item, int subitem, string txtDATA)
        {
            listView1.Items[item].SubItems[subitem].Text = txtDATA;
        }

        //checkstock(collection of html objects "select",color id, size id, opened web browser, current number of product in list view
        public void ClickOnProduct(HtmlElementCollection htmlcol, string colorid, string sizeid)
        {
            //colorId
            htmlcol[0].Focus();
            htmlcol[0].SetAttribute("value", colorid);
            htmlcol[0].RaiseEvent("onChange");
            htmlcol[0].RemoveFocus();
            //dimensionValues
            htmlcol[1].Focus();
            htmlcol[1].SetAttribute("value", sizeid);
            htmlcol[1].RaiseEvent("onChange");
            htmlcol[1].RemoveFocus();
        }

        public void ClickOnProduct(HtmlElementCollection htmlcol, string sizeid)
        {
            htmlcol[0].Focus();
            htmlcol[0].SetAttribute("value", sizeid);
            htmlcol[0].RaiseEvent("onChange");
            htmlcol[0].RemoveFocus();
        }

        DateTime RoundCurrentToNextFiveMinutes()
        {
            DateTime now = DateTime.UtcNow,
                result = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            return result.AddMinutes(((now.Minute / 5) + 1) * 5);
        }
        struct Void { }; // use an empty struct as parameter to generic TaskCompletionSource
        public async Task DoNavigationAsync(CancellationToken token)
        {
            
               wb.ScriptErrorsSuppressed = true;                                           //
                Void v;                                                                     //
                TaskCompletionSource<Void> tcs = null;                                      //>>>> do asynchronic loading of all pages in one browser
                WebBrowserDocumentCompletedEventHandler documentComplete = null;            //
                documentComplete = new WebBrowserDocumentCompletedEventHandler((s, e) =>    //
                {
                    wb.DocumentCompleted -= documentComplete;
                    tcs.SetResult(v); // continue from where awaited
            });
                for (int i = 0; i <= listView1.Items.Count - 1; i++) //start loop throw product lines
                {
                    string site = listView1.Items[i].SubItems[1].Text;
                    string buttonId = listView1.Items[i].SubItems[3].Text;
                    string colorId = listView1.Items[i].SubItems[4].Text;
                    string sizeId = listView1.Items[i].SubItems[5].Text;


                    tcs = new TaskCompletionSource<Void>();
                    wb.DocumentCompleted += documentComplete; //wait browser complate the page loading
                    wb.Navigate(site); //go to the product page
                    await Task.Delay(1000); //delay for loading page
                    await tcs.Task;
                    wb.SetBounds(10, 10, 900, 900); //set browser position and bounds

                    // do whatever you want with this instance of WB.Document
                    //Console.WriteLine("Get data for product number " + (i + 1)); //write to console product number

                    try
                    {
                        SetListview1(i, 2, "Checking...");
                    if (wb.Document.Domain == "www.6pm.com" && colorId != "" && sizeId != "") //if color and size id is set, then
                    {

                        HtmlElementCollection htmlcol = wb.Document.GetElementsByTagName("select"); //get collection of all <select> items on the page
                        //var helmProduct = wb.Document.GetElementsByTagName("button")["add-to-cart-button"].InnerText;  get element by name
                        GetSelect(htmlcol, colorId, sizeId);
                        if (haveColor == true && haveSize == true)
                        {
                            ClickOnProduct(htmlcol, colorId, sizeId);
                            await Task.Delay(3000); //delay for loading page
                            var product = wb.Document.GetElementById(buttonId).InnerText;
                            if (product != null)
                            {
                                //string txtDATA = !product.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                                SetListview1(i, 2, product);
                            }
                        }
                        else if (colorId == "0" && sizeId != "0")
                        {
                            ClickOnProduct(htmlcol, sizeId);
                            var product = wb.Document.GetElementById(buttonId).InnerText;
                            if (product != null)
                            {
                                //string txtDATA = !product.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                                SetListview1(i, 2, product);
                            }
                        }

                        else
                        {
                            SetListview1(i, 2, "NOT FOUND");
                        }
                    }
                    else
                    {
                        SetListview1(i, 2, "set color id and size id first");
                    } //end domain 6pm.com

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    progressBar1.Value += 5;
                }

                progressBar1.Value = 100;
                Console.WriteLine("*******Wait " + 5 + " minutes ********" );
              
        }

        public void  GetSelect(HtmlElementCollection htmlcol,string color,string size)
        {
            String strAllColors= "";
            String strAllSizes = "";

            //get a collection of the parent "select" elements first
            if (color!="0" && htmlcol[0].Name == "colorId")
            { //if the select element is the dropdown we need to select something for
              //create another element collection for the child elements of the "select" element
                allColors.Clear();
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;

                for (int j = 0; j < htmlcolchild.Count; j++)
                {
                    allColors.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
                    strAllColors += htmlcolchild[j].GetAttribute("value") + "/";
                }
            }           

            if (size != "0" && htmlcol[0].Name == "dimensionValues")
            {
                allSizes.Clear();
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                for (int j = 0; j < htmlcolchild.Count; j++)
                {
                    allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
                    strAllSizes  += htmlcolchild[j].GetAttribute("value")+"/";
                }
            } else if (size != "0" &&  htmlcol[1].Name == "dimensionValues")
            {
                allSizes.Clear();
                HtmlElementCollection htmlcolchild = htmlcol[1].Children;
                for (int j = 0; j < htmlcolchild.Count; j++)
                {
                    allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
                    strAllSizes += htmlcolchild[j].GetAttribute("value") + "/";
                }
            }

            haveColor = (strAllColors.Contains(color)) ? true : false;
            haveSize = (strAllSizes.Contains(size)) ? true : false;

            for (int s = 0; s < allSizes.Count; s++) Console.WriteLine(allSizes.Get(s) + "=" + allSizes.GetKey(s));
            for (int s = 0; s < allColors.Count; s++) Console.WriteLine(allColors.Get(s) + "=" + allColors.GetKey(s));
            Console.WriteLine("Color found = " + haveColor + " Size found = " + haveSize);
            Console.WriteLine("******************************end loop******************************");

        }


        private void BtnAddProd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void BtnGetStock_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 10;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var task = DoNavigationAsync(tokenSource.Token);
            task.ContinueWith((t) =>
            {
                Console.WriteLine ("Navigation done!");
                                
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void deleteSelsectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    lvi.Remove();
                }
            }
        }

        private void openURLInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url = listView1.SelectedItems[0].SubItems[1].Text;
            System.Diagnostics.Process.Start(url);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ServerList == null)
            {
                Properties.Settings.Default.ServerList = new StringCollection();
            }

            this.listView1.Items.AddRange((from i in Properties.Settings.Default.ServerList.Cast<string>()
                                           select new ListViewItem(i.Split('|'))).ToArray());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.ServerList = new StringCollection();
            Properties.Settings.Default.ServerList.AddRange((from i in this.listView1.Items.Cast<ListViewItem>()
                                                             select string.Join("|", from si in i.SubItems.Cast<ListViewItem.ListViewSubItem>()
                                                                                     select si.Text)).ToArray());
            Properties.Settings.Default.Save();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           // cancelToken = true;
        }
    }
}

//method to check all color and sizes on page
//public void chekStock(HtmlElementCollection htmlcol, NameValueCollection colors, NameValueCollection sizes, int p)
//{
//    string strColorSizes = "";
//    string tmp = "";
//    if (colors.Count > 0)
//    {
//        for (int i = 0; i < colors.Count; i++)
//        {
//            tmp = "";
//            OptionClick1(htmlcol[0], colors.Get(i), wb, p);
//            strColorSizes += colors.GetKey(i) + ":";
//            for (int s = 1; s < sizes.Count; s++)
//            {
//                if (OptionClick1(htmlcol[1], sizes.Get(s), wb, p) == true)
//                {
//                    tmp += sizes.GetKey(s) + "/";
//                }
//            }
//            strColorSizes += tmp + "   ";
//            SetListview1(p, 2, strColorSizes);
//        }
//    }
//    else
//    {
//        for (int s = 1; s < sizes.Count; s++)
//        {
//            if (OptionClick1(htmlcol[0], sizes.Get(s), wb, p) == true)
//            {
//                tmp += sizes.GetKey(s) + "/";
//            }
//        }
//        strColorSizes += tmp + "   ";
//        SetListview1(p, 2, strColorSizes);
//    }

//}
