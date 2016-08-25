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


        NameValueCollection allColors = new NameValueCollection();
        NameValueCollection allSizes = new NameValueCollection();
        WebBrowser wb = new WebBrowser();
        Site_6pm get6pm = new Site_6pm();
        //Method to add products to list view

        public void AddProduct()
        {
            ListViewItem product = new ListViewItem(TbProdName.Text);
            product.SubItems.Add(tBProductUrl.Text);
            product.SubItems.Add("Not Checked");
            product.SubItems.Add(tBstockId.Text);
            product.SubItems.Add(tBColorId.Text);
            product.SubItems.Add(tBSizeId.Text);
            listView1.Items.Add(product);
        }

        private void SetListview1(int item, int subitem, string txtDATA)
        {
            listView1.Items[item].SubItems[subitem].Text = txtDATA;
        }

        public void chekStock(HtmlElementCollection htmlcol, NameValueCollection colors, NameValueCollection sizes, int p)
        {
            string strColorSizes = "";
            string tmp = "";
            if (colors.Count > 0)
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    tmp = "";
                    OptionClick1(htmlcol[0], colors.Get(i), wb, p);
                    strColorSizes += colors.GetKey(i) + ":";
                    for (int s = 1; s < sizes.Count; s++)
                    {
                        if (OptionClick1(htmlcol[1], sizes.Get(s), wb, p) == true)
                        {
                            tmp += sizes.GetKey(s) + "/";
                        }
                    }
                    strColorSizes += tmp + "   ";
                    SetListview1(p, 2, strColorSizes);
                }
            }
            else
            {
                for (int s = 1; s < sizes.Count; s++)
                {
                    if (OptionClick1(htmlcol[0], sizes.Get(s), wb, p) == true)
                    {
                        tmp += sizes.GetKey(s) + "/";
                    }
                }
                strColorSizes += tmp + "   ";
                SetListview1(p, 2, strColorSizes);
            }

        }
        //overide method if you have to check just one product in page
        //checkstock(collection of html objects "select",color id, size id, opened web browser, current number of product in list view
        public void chekStock(HtmlElementCollection htmlcol, string colorid, string sizeid, int i)
        {
            htmlcol[0].Focus();
            htmlcol[0].SetAttribute("value", colorid);
            htmlcol[0].RaiseEvent("onChange");
            htmlcol[0].RemoveFocus();

            htmlcol[1].Focus();
            htmlcol[1].SetAttribute("value", sizeid);
            htmlcol[1].RaiseEvent("onChange");
            htmlcol[1].RemoveFocus();
        }


        private bool OptionClick1(HtmlElement options, string option, WebBrowser wb, int p) //click on object select by option
        {
            if (options.Id != null)
            {
                options.Focus();
                options.SetAttribute("value", option);
                options.RaiseEvent("onChange");
                options.RemoveFocus();
            }
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

        public async Task DoNavigationAsync()
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
                await Task.Delay(500); //delay for loading page
                await tcs.Task;
                wb.SetBounds(10, 10, 900, 900); //set browser position and bounds

                // do whatever you want with this instance of WB.Document
                //Console.WriteLine("Get data for product number " + (i + 1)); //write to console product number

                try
                {
                    HtmlElementCollection htmlcol = wb.Document.GetElementsByTagName("select"); //get collection of all <select> items on the page

                    var product = wb.Document.GetElementById(listView1.Items[i].SubItems[1].Text);
                    string getstock = "";
                    //var helmProduct = wb.Document.GetElementsByTagName("button")["add-to-cart-button"].InnerText;  get element by name

                    if (colorId != "" && sizeId != "") //if color and size id is set, then
                    {
                        chekStock(htmlcol, colorId, sizeId, i);
                        if (product != null)
                        {
                            getstock = product.InnerText;
                            string txtDATA = !getstock.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                            SetListview1(i, 2, txtDATA);
                        }
                    }
                    else
                    {
                        if (htmlcol.Count > 0) //if objects of "select" > 0, then
                        {
                            allColors = get6pm.GetColors(htmlcol); //get all colors
                            allSizes = get6pm.GetSizes(htmlcol); //get all sizes
                            chekStock(htmlcol, allColors, allSizes, i); //check if pairs of colors and sizes exists
                        }
                        else
                        {
                            getstock = product.InnerText;
                            string txtDATA = !getstock.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                            SetListview1(i, 2, txtDATA);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                progressBar1.Value += 5;
            }
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


    }
}
