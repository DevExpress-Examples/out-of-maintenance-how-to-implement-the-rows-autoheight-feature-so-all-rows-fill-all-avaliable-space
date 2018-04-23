using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
                private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) });
            return tbl;
        }


        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(10);
            gridView1.CalcRowHeight += new RowHeightEventHandler(gridView1_CalcRowHeight);
        }


        int minRowHeigth =20;

        void gridView1_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridViewInfo viewInfo = gridView1.GetViewInfo() as GridViewInfo;
            int totalHeight = viewInfo.ViewRects.Rows.Height - minRowHeigth;
            int targetHeight = totalHeight / gridView1.DataRowCount;
            e.RowHeight = Math.Max(minRowHeigth, targetHeight);
        }
    }
}