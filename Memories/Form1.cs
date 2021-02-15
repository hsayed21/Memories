﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memories
{
  public partial class Form1 : Form
  {
    DataTable table = new DataTable("Verbs");

    public TextBox Txt_time
    {
      get { return txt_time; }
    }

    public CheckBox CbRandom
    {
      get
      {
        return cbRandom;
      }
    }
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      Mem.readTable(table);
      if (table.Columns.Count < 1) Mem.createTable(table);
      //fillData();
      dataGridView1.DataSource = table;
      DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
      dataGridView1.Columns.Add(chk);
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
      Mem.addWord(txt_word, txt_sentence, txt_translation, table);
      dataGridView1.ClearSelection();
      dataGridView1.Rows[0].Selected = true;
      dataGridView1.FirstDisplayedScrollingRowIndex = 0;
      Mem.writeTable(table);
    }
    private void btnRemove_Click(object sender, EventArgs e)
    {
      Mem.removeWord(dataGridView1);
      Mem.writeTable(table);
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        Mem.removeWord(dataGridView1);
        Mem.writeTable(table);
      }
    }
    private void btnStart_Click(object sender, EventArgs e)
    {
      //Form2 f2 = new Form2(this);
      Hide();
      //f2.ShowDialog();
      Show();


    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Mem.addSentenceCol(txt_word,txt_sentence,txt_translation, table);
    }
  }
}
