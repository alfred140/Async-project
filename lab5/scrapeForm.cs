using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            saveButton.Enabled = false;
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            imgListBox.Items.Clear();
            progressBar.Value = 0;
            saveButton.Enabled = true;
            HttpClient client = new HttpClient();
            Task<string> downloadHtml = null;

            try
            {
                downloadHtml = client.GetStringAsync(searchBox.Text);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("URL not found", "error", MessageBoxButtons.OK);
                return;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("URL not found", "error", MessageBoxButtons.OK);
                return;
            }
            catch (AggregateException)
            {
                MessageBox.Show("URL not found", "error", MessageBoxButtons.OK);
                return;
            }

            try
            {
                downloadHtml.Wait();
            }

            catch (AggregateException)
            {
                MessageBox.Show("URL not found", "error", MessageBoxButtons.OK);
                return;
            }

            string regEx = "(?<=<img[^>]*src=\")([^\">]+)";
            MatchCollection collection = Regex.Matches(downloadHtml.Result, regEx, RegexOptions.IgnoreCase);

            foreach (object match in collection)
            {
                if (match.ToString().Contains(".jpg") || match.ToString().Contains(".jpeg") || match.ToString().Contains(".png"))
                {
                    string imgURL = "";

                    if (Uri.IsWellFormedUriString(match.ToString(), UriKind.Relative))
                    {
                        imgURL = searchBox.Text + match.ToString();
                        imgListBox.Items.Add(imgURL);
                    }
                    else if (Uri.IsWellFormedUriString(match.ToString(), UriKind.Absolute))
                    {
                        imgURL = match.ToString();
                        imgListBox.Items.Add(imgURL);
                    }
                }
            }
            progressBar.Maximum = imgListBox.Items.Count;
            imageCount.Text = "Images found: " + imgListBox.Items.Count.ToString();
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Value = 0;
                    await GetImagesTask(dialog.SelectedPath);
                    MessageBox.Show("Images saved");
                    saveButton.Enabled = false;
                    progressBar.Value = 0;
                    return;
                }
            }
        }

        private async Task GetImagesTask(string savePath)
        {
            int tag = 0;
            Dictionary<Task<byte[]>, string> downloadTasks = new Dictionary<Task<byte[]>, string>();

            for (int i = 0; i < imgListBox.Items.Count; i++)
            {
                HttpClient http = new HttpClient();
                downloadTasks.Add(http.GetByteArrayAsync(imgListBox.Items[i].ToString()), imgListBox.Items[i].ToString());
            }

            while (downloadTasks.Count > 0)
            {
                Task<byte[]> task = null;
                try
                {
                    task = await Task.WhenAny(downloadTasks.Keys);

                    if (task.IsCompleted)
                    {
                        _ = SaveImageTask(task, Path.Combine(
                            savePath,
                            GetFileName(downloadTasks[task]) + 
                            tag + GetFileExtension(downloadTasks[task])));
                    }
                    downloadTasks.Remove(task);
                }
                catch
                {
                    downloadTasks.Remove(task);
                }
                tag++;
                progressBar.PerformStep();

            }
        }

        private string GetFileName(string url)
        {
            url = url.Split('?')[0];
            url = url.Split('/').Last();

            return url.Contains('.') ? url.Substring(0, url.LastIndexOf('.')) : "";
        }
        private string GetFileExtension(string url)
        {
            url = url.Split('?')[0];
            url = url.Split('/').Last();

            return url.Contains('.') ? url.Substring(url.LastIndexOf('.')) : "";
        }

        private async Task SaveImageTask(Task<byte[]> image, string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                await stream.WriteAsync(image.Result, 0, image.Result.Length);
            }
        }
    }
}
