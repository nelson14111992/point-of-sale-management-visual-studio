Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml

Public Class All_record

    ''Change "C:\Users\Jimmy\Documents\Merchandise.accdb" to your database location
    'Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
    ''Change "C:\Users\Jimmy\Desktop\test.xlsx" to your excel file location
    'Dim excelLocation As String = "D:\excel\All _record\All _record.xlsx"
    'Dim MyConn As OleDbConnection
    'Dim da As OleDbDataAdapter
    'Dim ds As DataSet
    'Dim tables As DataTableCollection
    'Dim source1 As New BindingSource
    'Dim APP As New Excel.Application
    'Dim worksheet As Excel.Worksheet
    'Dim workbook As Excel.Workbook

    Private Sub All_record_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try

        '    workbook = APP.Workbooks.Open(excelLocation)
        '    worksheet = workbook.Worksheets("sheet1")
        '    MyConn = New OleDbConnection
        '    MyConn.ConnectionString = connString
        '    ds = New DataSet
        '    tables = ds.Tables
        '    da = New OleDbDataAdapter("Select * from PosTable", MyConn) 'Change items to your database name
        '    da.Fill(ds, "PosTable") 'Change items to your database name
        '    Dim view As New DataView(tables(0))
        '    source1.DataSource = view
        '    DataGridView1.DataSource = view
        '    DataGridView1.AllowUserToAddRows = False

        'Catch

        'End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        '    'Export Header Names Start
        '    Dim columnsCount As Integer = DataGridView1.Columns.Count
        '    For Each column In DataGridView1.Columns
        '        worksheet.Cells(1, column.Index + 1).Value = column.Name
        '    Next
        '    'Export Header Name End


        '    'Export Each Row Start
        '    For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '        Dim columnIndex As Integer = 0
        '        Do Until columnIndex = columnsCount
        '            worksheet.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
        '            columnIndex += 1
        '        Loop
        '    Next
        '    'Export Each Row End
        'Catch

        'End Try
        'MsgBox("excel file generated")


        'different approach
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                For k As Integer = 1 To DataGridView1.Columns.Count
                    xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                Next
            Next
        Next

        xlWorkSheet.SaveAs("D:\All_Record_excel.xlsx")
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox("You can find the file D:\All_Record_excel.xlsx")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub



End Class