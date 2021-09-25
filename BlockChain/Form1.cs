using System;
using System.Windows.Forms;
using BlockChainLib;

namespace BlockChain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Chain _chain = new Chain();
        private void buttonRun_Click(object sender, EventArgs e)
        {
            listBoxBlockChains.Items.Clear();

            _chain.Add(textBoxData.Text, "Admin");
            foreach (var block in _chain.Blocks)
            {
                listBoxBlockChains.Items.Add(block);
            }
            textBoxData.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var block in _chain.Blocks)
            {
                listBoxBlockChains.Items.Add(block);
            }
        }
    }
}
