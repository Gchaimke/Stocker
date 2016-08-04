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

       private void LoadData()
        {
            ListViewItem product = new ListViewItem(TbProdName.Text );
            product.SubItems.Add("Not Checked");
            product.SubItems.Add(tBstockId.Text);
            product.SubItems.Add(tBProductUrl.Text);
            listView1.Items.Add(product);
        }

        private string GetValues(HtmlElement options)
        {
            if (options != null)
            {
                string _allOptions = "";
                string sizes = options.InnerHtml;
                string[] words = Regex.Split(sizes, @"\D+");
                string[,] multyOptions;
                int x = 0;
                
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word) & word.Length > 3)
                    {
                        x = int.Parse(word);
                       // multyOptions =new String[,]{ { } ,{ } };
                        _allOptions += x + " ";
                    }
                 }
                char[] charsToTrim = { '|' };
                _allOptions= _allOptions.TrimEnd(charsToTrim);
                Console.WriteLine (_allOptions+" ");
                return _allOptions;
            }
            return null;
        }

         private void OptionClick(HtmlElement options,string option)
        {
             if (options.Id != null)
            {
                options.Focus();
                options.SetAttribute("value", option);
                options.RaiseEvent("onChange");
                options.RemoveFocus();
            }
        }

        struct Void { }; // use an empty struct as parameter to generic TaskCompletionSource

        async Task DoNavigationAsync()
        {
            HtmlElement sizeSelect, colorSelect;
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
                wb.Navigate(listView1.Items[i].SubItems[3].Text);
                await Task.Delay(500);
                await tcs.Task;
                wb.SetBounds(10,10,900,900);
                // do whatever you want with this instance of WB.Document
                //MessageBox.Show(wb.Document.Url.ToString());
                 try
                {
                   if(wb.Document.Url.Port   != -1) {
                    colorSelect = wb.Document.GetElementById("color");
                        Console.WriteLine(colorSelect.InnerText);
                    if (colorSelect != null) {
                        GetValues(colorSelect);
                        OptionClick(colorSelect, "616693");//123981 616693 
                    }
                    await Task.Delay(500);

                    sizeSelect = wb.Document.GetElementById("d13");
                    if (sizeSelect != null)
                    {
                        GetValues(sizeSelect);
                        OptionClick(sizeSelect, "138538");
                    }
                   var element = wb.Document.GetElementById(listView1.Items[i].SubItems[2].Text);
                    if (element.Id != null)
                    {
                        stock = element.InnerText;
                        listView1.Items[i].SubItems[1].Text = stock;
                    }
                    }else { listView1.Items[i].SubItems[1].Text = "No internet,or url erorr!"; }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString ());
                    stock = "not found";
                   
                }
                progressBar1.Value += 5;
                sizeSelect = null;

            }
            wb.Dispose();
            //return;
        }

        private void BtnAddProd_Click(object sender, EventArgs e)
        {
            LoadData();
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
