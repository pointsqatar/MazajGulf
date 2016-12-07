using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace xmltest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            
            List<ComboBoxItems> values = new List<ComboBoxItems>();

            FileStream stream = new FileStream("result.json", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            var news = JsonConvert.DeserializeObject<FeedItem>(result);
            string title = "";
            string link = "";

            foreach (var item in news.rss.channel.item)
            {
                title = item.title;
                link = item.link;
                values.Add(new ComboBoxItems()
                {
                    key = title,
                    value = link
                });
            }

            comboBox1.DataSource = values;
            comboBox1.DisplayMember = "key";
            comboBox1.ValueMember = "value";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedValue.ToString();
            Process.Start(selectedValue);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            List<ComboBoxItems> values = new List<ComboBoxItems>();
            HttpClient client = new HttpClient();
            var news = await client.GetStringAsync("http://timesofindia.indiatimes.com/rssfeeds/5880659.cms");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(news);
            var nodes = doc.SelectNodes("/rss/channel/item");
            foreach (XmlNode item in nodes)
            {
                string title = "";
                string link = "";
                foreach (XmlNode node in item.ChildNodes)
                {
                    if (node.Name == "title")
                    {
                        title = node.InnerText;
                    }
                    else if (node.Name == "link")
                    {
                        link = node.InnerText;
                    }
                }
                values.Add(new ComboBoxItems()
                {
                    key = title,
                    value = link
                });
            }

            GenerateXML(values);
        }

        private void GenerateXML(List<ComboBoxItems> values)
        {
            var settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };
            FileStream stream = new FileStream("output.xml", FileMode.Create);
            var builder = new StringBuilder();
            var writer = XmlWriter.Create(stream,settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("rssfeed");
            foreach (var item in values)
            {
                writer.WriteStartElement("rssitem");

                writer.WriteStartElement("title");
                writer.WriteString(item.key);
                writer.WriteEndElement();

                writer.WriteStartElement("link");
                writer.WriteString(item.value);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();

            stream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    public class ComboBoxItems
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
