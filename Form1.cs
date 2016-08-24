﻿using System;
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
        Site_6pm get6pm = new Site_6pm();
        //Method to add products to list view
        public void AddProduct()
        {
            ListViewItem product = new ListViewItem(TbProdName.Text );
            product.SubItems.Add(tBstockId.Text);
            product.SubItems.Add(tBProductUrl.Text);
            product.SubItems.Add("Not Checked");
            product.SubItems.Add(tBColorId.Text);
            product.SubItems.Add(tBSizeId.Text);
            listView1.Items.Add(product);
        }
       
       private void SetListview1(int item,int subitem,string txtDATA)
        {
            listView1.Items[item].SubItems[subitem].Text = txtDATA;
        }

         private void BtnAddProd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        public void chekStock(HtmlElementCollection htmlcol, NameValueCollection colors, NameValueCollection sizes, WebBrowser wb, int p)
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
                    SetListview1(p,3, strColorSizes);
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
                SetListview1(p, 3, strColorSizes);
            }

        }
        //overide method if you have to check just one product in page
        //checkstock(collection of html objects "select",color id, size id, opened web browser, current number of product in list view
        public void chekStock(HtmlElementCollection htmlcol, string colorid, string sizeid, WebBrowser wb, int i)
        {
            bool color_exist = true;
            bool size_exist = true;
            string colors = string.Join("|", allColors.AllKeys.Select(key => allColors[key]));
            string sizes = string.Join("|", allSizes.AllKeys.Select(key => allSizes[key]));
            colors = "|" + colors + "|";
            sizes = "|" + sizes + "|";
            if (colors.Contains("|" + colorid + "|"))
            {
                htmlcol[0].Focus();
                htmlcol[0].SetAttribute("value", colorid);
                htmlcol[0].RaiseEvent("onChange");
                htmlcol[0].RemoveFocus();
            }
            else
            {
                SetListview1(i, 3, "Color id not found ");
                color_exist = false;
            }

            if (sizes.Contains("|" + sizeid + "|"))
            {
                htmlcol[1].Focus();
                htmlcol[1].SetAttribute("value", sizeid);
                htmlcol[1].RaiseEvent("onChange");
                htmlcol[1].RemoveFocus();
            }
            else
            {
                string txtDATA = color_exist == false ? "Color id and Size id not found " : "Size id not found ";
                SetListview1(i, 3, txtDATA);
                size_exist = false;
            }

            var product = wb.Document.GetElementById(listView1.Items[i].SubItems[1].Text);
            string getstock = "";
            if (product != null)
            {
                getstock = product.InnerText;
                if (color_exist == true && size_exist == true)
                {
                    string txtDATA = !getstock.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                    SetListview1(i, 3, txtDATA);
                }
            }
            else
            {
                SetListview1(i, 3, "Id not found");
            }
        }


        private bool OptionClick1(HtmlElement options, string option, WebBrowser wb, int p)
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
                Console.WriteLine("Get data for product number " + (i + 1));
                tcs = new TaskCompletionSource<Void>();
                wb.DocumentCompleted += documentComplete;
                wb.Navigate(listView1.Items[i].SubItems[2].Text);
                await Task.Delay(500);
                await tcs.Task;
                wb.SetBounds(10, 10, 900, 900);
                // do whatever you want with this instance of WB.Document
                try
                {
                    HtmlElementCollection htmlcol = wb.Document.GetElementsByTagName("select");
                    var product = wb.Document.GetElementById(listView1.Items[i].SubItems[1].Text);
                    string getstock = "";
                    
                    //var helmProduct = wb.Document.GetElementsByTagName("button")["add-to-cart-button"].InnerText;  get element by name

                    if (listView1.Items[i].SubItems[4].Text == "" && listView1.Items[i].SubItems[5].Text == "")
                    {
                        if (htmlcol.Count > 0)
                        {
                            allColors = get6pm.GetColors(htmlcol);
                            allSizes = get6pm.GetSizes(htmlcol);
                            chekStock(htmlcol, allColors, allSizes, wb, i);
                        }
                        else
                        {
                            getstock = product.InnerText;
                            string txtDATA = !getstock.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                            SetListview1(i, 3, txtDATA);
                        }
                    }
                    else
                    {
                        if (htmlcol.Count > 0)
                        {
                            allColors = get6pm.GetColors(htmlcol);
                            allSizes = get6pm.GetSizes(htmlcol);
                            chekStock(htmlcol, listView1.Items[i].SubItems[4].Text, listView1.Items[i].SubItems[5].Text, wb, i);
                        }
                        else
                        {
                            getstock = product.InnerText;
                            string txtDATA = !getstock.Contains("Out of Stock") ? "Stock exists" : "Out of Stock ";
                            SetListview1(i, 3, txtDATA);
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


        private void BtnGetStock_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 10;
            var task =DoNavigationAsync();
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

       
    }
}
