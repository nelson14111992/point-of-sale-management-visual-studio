Imports System.Linq
Imports System.Data.SqlClient

Imports System.IO
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox11.Text = 1020
        ComboBox1.SelectedItem = "2%"
        Button1.Enabled = False
        Button7.Enabled = False
        Button6.Enabled = False


        'enters current date
        Dim todaysdate As String = String.Format("{0:MM/dd/yyyy}", DateTime.Now)

        RichTextBox1.Text = todaysdate


        'increamenting tid
        'Dim curValue As Integer
        'Dim result As String
        'Using con As SqlConnection = New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
        '    con.Open()
        '    Dim cmd = New SqlCommand("Select MAX(TID) FROM PosTable", con)
        '    result = cmd.ExecuteScalar().ToString()
        '    If String.IsNullOrEmpty(result) Then
        '        result = "P000000"
        '        RichTextBox2.Text = result
        '    End If

        '    result = result.Substring(3)
        '    Int32.TryParse(result, curValue)
        '    curValue = curValue + 1
        '    result = "P" + curValue.ToString("D6")
        '    RichTextBox2.Text = result

        'End Using
        'disabling button till all data entered




    End Sub

    'submit button to enter into db
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(RichTextBox10.Text) > Val(RichTextBox4.Text) Then
            ' RichTextBox1.Text = Convert.ToDateTime(RichTextBox1.Text)

            RichTextBox9.Text = ""
            Dim store As String = RichTextBox10.Text
            RichTextBox10.Text = ""
            RichTextBox13.Text = ""
            Button1.Enabled = False
            Try
                Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                'Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox2.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox1.Text & "' )")
                Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox1.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox2.Text & "','" & RichTextBox12.Text & "','" & RichTextBox11.Text & "','" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox9.Text & "','" & RichTextBox10.Text & "','" & RichTextBox13.Text & "' )")

                sqlStr.Connection = conStr
                conStr.Open()
                sqlStr.ExecuteNonQuery()
                MsgBox("Successfully added")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            'increamenting tid

            'Dim curValue As Integer
            'Dim result As String
            'Using con As SqlConnection = New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
            '    con.Open()
            '    Dim cmd = New SqlCommand("Select MAX(TID) FROM PosTable", con)
            '    result = cmd.ExecuteScalar().ToString()
            '    If String.IsNullOrEmpty(result) Then
            '        result = "P000000"
            '        RichTextBox2.Text = result
            '    End If

            '    result = result.Substring(3)
            '    Int32.TryParse(result, curValue)
            '    curValue = curValue + 1
            '    result = "P" + curValue.ToString("D6")
            '    RichTextBox2.Text = result

            'End Using


            'edit closing stock


            Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
            Dim con As New SqlConnection(str)

            Dim querystr As String = "select Closing_Stock from PosTable Where Closing_Stock != ''"
            con.Open()
            Dim mycmd As New SqlCommand(querystr, con)

            Dim Closing_Stock As String = mycmd.ExecuteScalar()

            con.Close()



            If String.IsNullOrEmpty(Closing_Stock) Then
                Try
                    RichTextBox10.Text = Val(store) - Val(RichTextBox4.Text)
                    'RichTextBox1.Text = ""
                    RichTextBox2.Text = ""
                    RichTextBox3.Text = ""
                    RichTextBox4.Text = ""
                    RichTextBox5.Text = ""
                    RichTextBox6.Text = ""
                    RichTextBox9.Text = ""
                    'RichTextBox10.Text = ""
                    RichTextBox11.Text = ""
                    RichTextBox12.Text = ""
                    RichTextBox13.Text = ""



                    Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                    'Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "'")
                    Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox1.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox2.Text & "','" & RichTextBox12.Text & "','" & RichTextBox11.Text & "','" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox9.Text & "','" & RichTextBox10.Text & "','" & RichTextBox13.Text & "' )")

                    sqlStr.Connection = conStr
                    conStr.Open()
                    sqlStr.ExecuteNonQuery()
                    conStr.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf Closing_Stock = RichTextBox10.Text

                Try
                    RichTextBox2.Text = ""
                    RichTextBox3.Text = ""
                    RichTextBox4.Text = ""
                    RichTextBox5.Text = ""
                    RichTextBox6.Text = ""
                    RichTextBox10.Text = Val(store) - Val(RichTextBox4.Text)
                    RichTextBox9.Text = ""
                    RichTextBox11.Text = ""
                    RichTextBox12.Text = ""

                    Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                    Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "' WHERE Closing_Stock != ''  ")
                    sqlStr.Connection = conStr
                    conStr.Open()
                    sqlStr.ExecuteNonQuery()
                    conStr.Close()


                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                Try
                    RichTextBox10.Text = Val(store) - Val(RichTextBox4.Text)
                    RichTextBox2.Text = ""
                    RichTextBox3.Text = ""
                    RichTextBox4.Text = ""
                    RichTextBox5.Text = ""
                    RichTextBox6.Text = ""

                    RichTextBox9.Text = ""
                    RichTextBox11.Text = ""
                    RichTextBox12.Text = ""

                    Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                    Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "' WHERE Closing_Stock = '" & Closing_Stock & "'  ")
                    sqlStr.Connection = conStr
                    conStr.Open()
                    sqlStr.ExecuteNonQuery()
                    conStr.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
            RichTextBox11.Text = 1020
            ComboBox1.SelectedItem = "2%"
            Dim todaysdate As String = String.Format("{0:MM/dd/yyyy}", DateTime.Now)
            RichTextBox1.Text = todaysdate
        Else
            MsgBox("Not Enough Stocks")
            RichTextBox1.Text = ""
            RichTextBox2.Text = ""
            RichTextBox3.Text = ""
            RichTextBox4.Text = ""
            RichTextBox5.Text = ""
            RichTextBox6.Text = ""
            RichTextBox9.Text = ""
            'RichTextBox10.Text = ""
            RichTextBox11.Text = ""
            RichTextBox12.Text = ""
            RichTextBox13.Text = ""
            Button1.Enabled = False
            'enters current date
            RichTextBox11.Text = 1020
            ComboBox1.SelectedItem = "2%"
            Dim todaysdate As String = String.Format("{0:MM/dd/yyyy}", DateTime.Now)
            RichTextBox1.Text = todaysdate
        End If
    End Sub

    Private Sub RichTextBox6_Click(sender As Object, e As EventArgs) Handles RichTextBox6.Click
        RichTextBox6.Text = Val(RichTextBox4.Text) - Val(RichTextBox5.Text)
        If String.IsNullOrEmpty(RichTextBox1.Text) = False And String.IsNullOrEmpty(RichTextBox2.Text) = False And String.IsNullOrEmpty(RichTextBox3.Text) = False And String.IsNullOrEmpty(RichTextBox4.Text) = False And String.IsNullOrEmpty(RichTextBox5.Text) = False And String.IsNullOrEmpty(RichTextBox6.Text) = False Then
            Button1.Enabled = True
        Else
            MsgBox("Please enter Values")
        End If
    End Sub

    'button for all record
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        Dim com As String = "Select * from PosTable Where Deposit = '' AND Stock_In = '' AND Closing_Stock = '' order by Date desc"

        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Adpt.Fill(ds, "PosTable")

        All_record.DataGridView1.DataSource = ds.Tables(0)
        All_record.Show()
    End Sub

    'todays record button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        'Dim com As String = "SELECT * FROM PosTable WHERE TID IN (SELECT TID FROM PosTable WHERE Date = (SELECT MAX(Date) FROM Postable)) ORDER BY TID DESC"
        Dim com As String = "SELECT * FROM PosTable WHERE Date = (SELECT MAX(Date) FROM Postable) AND Deposit = '' And Stock_In = '' And Closing_Stock = '' ORDER BY Date DESC"

        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Adpt.Fill(ds, "PosTable")

        Todays_record.DataGridView1.DataSource = ds.Tables(0)
        Todays_record.Show()
    End Sub
    'partiular record button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RadioButton1.Checked = True And String.IsNullOrEmpty(RichTextBox7.Text) = False Then
            Dim search As String = RichTextBox7.Text
            Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
            Dim con As New SqlConnection(str)
            Dim com As String = "SELECT * FROM PosTable where Name = '" + search + "'"

            Dim Adpt As New SqlDataAdapter(com, con)

            Dim ds As New DataSet()

            Dim dt As New DataTable

            Adpt.Fill(ds, "PosTable")
            For i As Integer = 0 To ds.Tables("PosTable").Rows.Count - 1
                If RichTextBox7.Text = ds.Tables("PosTable").Rows(i).Item("Name").ToString() Then
                    Particular_Customers_record.DataGridView1.DataSource = ds.Tables(0)
                    Particular_Customers_record.Show()

                End If

            Next

            con.Close()

        End If
        If RadioButton2.Checked = True And String.IsNullOrEmpty(RichTextBox8.Text) = False Then
            Dim s As String = RichTextBox8.Text
            Dim st As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
            Dim co As New SqlConnection(st)
            Dim cm As String = "SELECT * FROM PosTable where ID = '" + s + "'"

            Dim Adp As New SqlDataAdapter(cm, co)

            Dim dss As New DataSet()

            Dim dtt As New DataTable

            Adp.Fill(dss, "PosTable")
            For x As Integer = 0 To dss.Tables("PosTable").Rows.Count - 1
                If RichTextBox8.Text = dss.Tables("PosTable").Rows(x).Item("ID").ToString() Then
                    Particular_Customers_record.DataGridView1.DataSource = dss.Tables(0)
                    Particular_Customers_record.Show()

                End If

            Next

            co.Close()
        End If


    End Sub





    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        RadioButton1.Checked = True
        'RadioButton2.Checked = False
        RichTextBox8.Enabled = False
        MsgBox("Enter Closing Stock")
    End Sub

    Private Sub RadioButton1_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RichTextBox7.Enabled = True
            RichTextBox8.Text = ""
            RichTextBox8.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RichTextBox8.Enabled = True
            RichTextBox7.Text = ""
            RichTextBox7.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "2%" Then
            RichTextBox11.Text = 1020
        End If
        If ComboBox1.SelectedItem = "3%" Then
            RichTextBox11.Text = 1030
        End If

    End Sub

    Private Sub RichTextBox4_Click(sender As Object, e As EventArgs) Handles RichTextBox4.Click
        RichTextBox4.Text = Val(RichTextBox12.Text) * Val(RichTextBox11.Text)
    End Sub

    'Deposit button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox2.Text = ""
        RichTextBox3.Text = ""
        RichTextBox4.Text = ""
        RichTextBox5.Text = ""
        RichTextBox6.Text = ""
        RichTextBox9.Text = ""
        Dim store As String = RichTextBox10.Text
        RichTextBox10.Text = ""
        RichTextBox11.Text = ""
        RichTextBox12.Text = ""


        Try

            Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
            Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox1.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox2.Text & "','" & RichTextBox12.Text & "','" & RichTextBox11.Text & "','" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox9.Text & "','" & RichTextBox10.Text & "','" & RichTextBox13.Text & "' )")
            sqlStr.Connection = conStr
            conStr.Open()
            sqlStr.ExecuteNonQuery()
            MsgBox("Successfully added")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        RichTextBox10.Text = store
        RichTextBox13.Text = ""
        Button7.Enabled = False

        RichTextBox11.Text = 1020
        ComboBox1.SelectedItem = "2%"
    End Sub

    'Add stock in
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox2.Text = ""
        RichTextBox3.Text = ""
        RichTextBox4.Text = ""
        RichTextBox5.Text = ""
        RichTextBox6.Text = ""

        RichTextBox11.Text = ""
        RichTextBox12.Text = ""
        RichTextBox13.Text = ""
        Dim store As String = RichTextBox10.Text
        RichTextBox10.Text = ""
        Try

            Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
            Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox1.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox2.Text & "','" & RichTextBox12.Text & "','" & RichTextBox11.Text & "','" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox9.Text & "','" & RichTextBox10.Text & "','" & RichTextBox13.Text & "' )")
            sqlStr.Connection = conStr
            conStr.Open()
            sqlStr.ExecuteNonQuery()
            MsgBox("Successfully added")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'edit closing stock


        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)

        Dim querystr As String = "select Closing_Stock from PosTable Where Closing_Stock != ''"
        con.Open()
        Dim mycmd As New SqlCommand(querystr, con)

        Dim Closing_Stock As String = mycmd.ExecuteScalar()

        con.Close()



        If String.IsNullOrEmpty(Closing_Stock) Then
            Try
                RichTextBox2.Text = ""
                RichTextBox3.Text = ""
                RichTextBox4.Text = ""
                RichTextBox5.Text = ""
                RichTextBox6.Text = ""
                RichTextBox10.Text = Val(store) + Val(RichTextBox9.Text)
                RichTextBox9.Text = ""
                Button6.Enabled = False

                RichTextBox11.Text = ""
                RichTextBox12.Text = ""
                Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                'Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "'")
                Dim sqlStr As New SqlCommand("insert into PosTable values ('" & RichTextBox1.Text & "' ,'" & RichTextBox3.Text & "', '" & RichTextBox2.Text & "','" & RichTextBox12.Text & "','" & RichTextBox11.Text & "','" & RichTextBox4.Text & "','" & RichTextBox5.Text & "','" & RichTextBox6.Text & "','" & RichTextBox9.Text & "','" & RichTextBox10.Text & "','" & RichTextBox13.Text & "' )")

                sqlStr.Connection = conStr
                conStr.Open()
                sqlStr.ExecuteNonQuery()
                conStr.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf Closing_Stock = RichTextBox10.Text

            Try
                RichTextBox2.Text = ""
                RichTextBox3.Text = ""
                RichTextBox4.Text = ""
                RichTextBox5.Text = ""
                RichTextBox6.Text = ""
                RichTextBox10.Text = Val(store) + Val(RichTextBox9.Text)
                RichTextBox9.Text = ""
                Button6.Enabled = False

                RichTextBox11.Text = ""
                RichTextBox12.Text = ""

                Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "' WHERE Closing_Stock != ''  ")
                sqlStr.Connection = conStr
                conStr.Open()
                sqlStr.ExecuteNonQuery()
                conStr.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                RichTextBox2.Text = ""
                RichTextBox3.Text = ""
                RichTextBox4.Text = ""
                RichTextBox5.Text = ""
                RichTextBox6.Text = ""
                RichTextBox10.Text = Val(store) + Val(RichTextBox9.Text)
                RichTextBox9.Text = ""
                Button6.Enabled = False

                RichTextBox11.Text = ""
                RichTextBox12.Text = ""

                Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
                Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "' WHERE Closing_Stock = '" & Closing_Stock & "'  ")
                sqlStr.Connection = conStr
                conStr.Open()
                sqlStr.ExecuteNonQuery()
                conStr.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        RichTextBox11.Text = 1020
        ComboBox1.SelectedItem = "2%"
    End Sub

    'days deposit view
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        Dim com As String = "SELECT Date,Deposit FROM PosTable WHERE Deposit != '' AND Date = (SELECT MAX(Date) FROM Postable) ORDER BY Date DESC"


        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Dim dt As New DataTable

        Adpt.Fill(ds, "PosTable")

        Days_Deposit.DataGridView1.DataSource = ds.Tables(0)
        Days_Deposit.Show()




        con.Close()

    End Sub

    'all deposit
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        Dim com As String = "SELECT Date,Deposit FROM PosTable where Deposit != '' ORDER BY Date DESC"


        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Dim dt As New DataTable

        Adpt.Fill(ds, "PosTable")

        All_Deposits.DataGridView1.DataSource = ds.Tables(0)
        All_Deposits.Show()



        con.Close()
    End Sub

    Private Sub RichTextBox13_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox13.TextChanged
        If String.IsNullOrEmpty(RichTextBox13.Text) = False Then
            Button7.Enabled = True
        Else

        End If
        If Not IsNumeric(RichTextBox13.Text) Then

            RichTextBox13.Text = ""
        End If
    End Sub

    Private Sub RichTextBox9_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox9.TextChanged
        If String.IsNullOrEmpty(RichTextBox9.Text) = False Then
            Button6.Enabled = True
        Else

        End If
        If Not IsNumeric(RichTextBox9.Text) Then

            RichTextBox9.Text = ""
        End If
    End Sub

    'upload closing stock

    'Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    RichTextBox2.Text = ""
    '    RichTextBox3.Text = ""
    '    RichTextBox4.Text = ""
    '    RichTextBox5.Text = ""
    '    RichTextBox6.Text = ""
    '    RichTextBox9.Text = ""

    '    RichTextBox11.Text = ""
    '    RichTextBox12.Text = ""
    '    'Checking if Closing stock in db empty
    '    Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
    '    Dim con As New SqlConnection(str)

    '    Dim querystr As String = "select Closing_Stock from PosTable Where Closing_Stock != ''"
    '    con.Open()
    '    Dim mycmd As New SqlCommand(querystr, con)

    '    Dim Closing_Stock As String = mycmd.ExecuteScalar()

    '    con.Close()


    '    If String.IsNullOrEmpty(Closing_Stock) Then
    '        Try

    '            Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
    '            Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "'")
    '            sqlStr.Connection = conStr
    '            conStr.Open()
    '            sqlStr.ExecuteNonQuery()
    '            conStr.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try
    '    Else
    '        Try

    '            Dim conStr As New SqlConnection("Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True")
    '            Dim sqlStr As New SqlCommand("UPDATE PosTable set  Date = '" & RichTextBox1.Text & "' ,Name = '" & RichTextBox3.Text & "',ID = '" & RichTextBox2.Text & "',Quantity = '" & RichTextBox12.Text & "',Rate = '" & RichTextBox11.Text & "',Amount = '" & RichTextBox4.Text & "',Paid = '" & RichTextBox5.Text & "',Due = '" & RichTextBox6.Text & "',Stock_In = '" & RichTextBox9.Text & "',Closing_Stock = '" & RichTextBox10.Text & "',Deposit = '" & RichTextBox13.Text & "' WHERE Closing_Stock != ''  ")
    '            sqlStr.Connection = conStr
    '            conStr.Open()
    '            sqlStr.ExecuteNonQuery()
    '            conStr.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)

        Dim querystr As String = "select Closing_Stock from PosTable where Closing_Stock != ''"
        con.Open()
        Dim mycmd As New SqlCommand(querystr, con)

        Dim Closing_Stock As String = mycmd.ExecuteScalar()

        RichTextBox10.Text = Closing_Stock
        con.Close()
    End Sub

    Private Sub RichTextBox10_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox10.TextChanged

    End Sub

    'Todays stock in
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        Dim com As String = "SELECT Date,Stock_In FROM PosTable WHERE Stock_In != '' AND Date = (SELECT MAX(Date) FROM Postable) ORDER BY Date DESC"


        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Dim dt As New DataTable

        Adpt.Fill(ds, "PosTable")

        Todays_Stock_In.DataGridView1.DataSource = ds.Tables(0)
        Todays_Stock_In.Show()



        con.Close()
    End Sub

    'Todays Due
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim str As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
        Dim con As New SqlConnection(str)
        'Dim com As String = "SELECT * FROM PosTable WHERE TID IN (SELECT TID FROM PosTable WHERE Date = (SELECT MAX(Date) FROM Postable)) ORDER BY TID DESC"
        Dim com As String = "SELECT Date,Name,ID,Due FROM PosTable WHERE Date = (SELECT MAX(Date) FROM Postable) AND Deposit = '' And Stock_In = '' And Closing_Stock = '' ORDER BY Date DESC"

        Dim Adpt As New SqlDataAdapter(com, con)

        Dim ds As New DataSet()

        Adpt.Fill(ds, "PosTable")

        Todays_Due.DataGridView1.DataSource = ds.Tables(0)
        Todays_Due.Show()
    End Sub

    'name from id
    Private Sub RichTextBox3_Click(sender As Object, e As EventArgs) Handles RichTextBox3.Click
        Try
            Dim s As String = RichTextBox2.Text
            Dim st As String = "Data Source=FIS;Initial Catalog=pointofsale;Integrated Security=True"
            Dim co As New SqlConnection(st)
            Dim cm As String = "SELECT * FROM PosTable where ID = '" + s + "'"

            Dim Adp As New SqlDataAdapter(cm, co)

            Dim dss As New DataSet()

            Dim dtt As New DataTable

            Adp.Fill(dss, "PosTable")

            If RichTextBox2.Text = dss.Tables("PosTable").Rows(0).Item("ID").ToString() Then
                RichTextBox3.Text = dss.Tables("PosTable").Rows(0).Item("Name").ToString()
            Else

            End If


            co.Close()
        Catch
        End Try


    End Sub

    'ID text to upper case
    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged
        RichTextBox2.Text = UCase$(RichTextBox2.Text)
        RichTextBox2.SelectionStart = Len(RichTextBox2.Text)
    End Sub

    'Name to upper case
    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox3.TextChanged
        RichTextBox3.Text = UCase$(RichTextBox3.Text)
        RichTextBox3.SelectionStart = Len(RichTextBox3.Text)
    End Sub

    Private Sub RichTextBox7_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox7.TextChanged
        RichTextBox7.Text = UCase$(RichTextBox7.Text)
        RichTextBox7.SelectionStart = Len(RichTextBox7.Text)
    End Sub

    Private Sub RichTextBox8_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox8.TextChanged
        RichTextBox8.Text = UCase$(RichTextBox8.Text)
        RichTextBox8.SelectionStart = Len(RichTextBox8.Text)
    End Sub

    'restrict to numeric value
    Private Sub RichTextBox12_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox12.TextChanged
        If Not IsNumeric(RichTextBox12.Text) Then

            RichTextBox12.Text = ""
        End If
    End Sub

    Private Sub RichTextBox11_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox11.TextChanged
        If Not IsNumeric(RichTextBox11.Text) Then

            RichTextBox11.Text = ""
        End If
    End Sub

    Private Sub RichTextBox5_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox5.TextChanged
        If Not IsNumeric(RichTextBox5.Text) Then

            RichTextBox5.Text = ""
        End If
    End Sub


End Class
