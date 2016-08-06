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
            allColors.Clear();
            allSizes.Clear();
            //get a collection of the parent "select" elements first
            if (htmlcol[0].Name == "colorId")
            { //if the select element is the dropdown we need to select something for
              //create another element collection for the child elements of the "select" element
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allColors.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }else if(htmlcol[0].Name == "dimensionValues")
            {
                HtmlElementCollection htmlcolchild = htmlcol[0].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }
            if (htmlcol.Count==2 && htmlcol[1].Name == "dimensionValues"){
                HtmlElementCollection htmlcolchild = htmlcol[1].Children;
                for (int j = 0; j < htmlcolchild.Count; j++) allSizes.Add(htmlcolchild[j].InnerText, htmlcolchild[j].GetAttribute("value"));
            }
        }

        private void chekStock(HtmlElementCollection htmlcol, NameValueCollection colors, NameValueCollection sizes, WebBrowser wb, int p) {
          string strColorSizes = "";
          string tmp = "";
            if (colors.Count>0)
            {
                for (int i = 0; i < colors.Count; i++)
                {
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
                    listView1.Items[p].SubItems[3].Text = strColorSizes;
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
                listView1.Items[p].SubItems[3].Text = strColorSizes;
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
                    if (htmlcol.Count >0) { 
                    GetColorsAndSizes(htmlcol);
                    Console.WriteLine("--------------------------------------");
                    for (int s = 0; s < allColors.Count; s++)
                        Console.WriteLine(allColors.Get(s) + "=" + allColors.GetKey(s));
                    for (int s = 0; s < allSizes.Count; s++)
                        Console.WriteLine(allSizes.Get(s) + "=" + allSizes.GetKey(s));

                    chekStock(htmlcol, allColors, allSizes, wb, i);
                    }else{
                        var product = wb.Document.GetElementById(listView1.Items[i].SubItems[1].Text);
                        string getstock = "";
                        getstock = product.InnerText;
                        if (!getstock.Contains("Out of Stock"))
                        {
                            listView1.Items[i].SubItems[3].Text = getstock;
                        }else
                        {
                            listView1.Items[i].SubItems[3].Text = "Out of Stock ";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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

        private void openURLInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
           var url = listView1.SelectedItems[0].SubItems[2].Text ;
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

        //end  
    }
}
