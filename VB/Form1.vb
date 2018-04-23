Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
				Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) })
			Next i
			Return tbl
				End Function


		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = CreateTable(10)
			AddHandler gridView1.CalcRowHeight, AddressOf gridView1_CalcRowHeight
		End Sub


		Private minRowHeigth As Integer =20

		Private Sub gridView1_CalcRowHeight(ByVal sender As Object, ByVal e As RowHeightEventArgs)
			Dim viewInfo As GridViewInfo = TryCast(gridView1.GetViewInfo(), GridViewInfo)
			Dim totalHeight As Integer = viewInfo.ViewRects.Rows.Height - minRowHeigth
			Dim targetHeight As Integer = totalHeight / gridView1.DataRowCount
			e.RowHeight = Math.Max(minRowHeigth, targetHeight)
		End Sub
	End Class
End Namespace