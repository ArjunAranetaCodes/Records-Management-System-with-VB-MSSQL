﻿Imports System.Data.SqlClient
Public Class Form4

    Public conn As New SqlConnection("Data Source=ALLMANKIND\MSSQLSERVER8; Database=db_vbrecordsys; Integrated Security=True")
    Public adapter As New SqlDataAdapter
    Dim ds As DataSet
    Dim currentid As String

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRecords()
    End Sub

    Public Sub GetRecords()
        ds = New DataSet
        adapter = New SqlDataAdapter("select * from tbl_records", conn)
        adapter.Fill(ds, "tbl_records")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_records"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("insert into tbl_records (firstname, lastname, age, gender) VALUES " &
                                     "('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')", conn)
        adapter.Fill(ds, "tbl_records")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""
        GetRecords()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        ds = New DataSet
        adapter = New SqlDataAdapter("delete from tbl_records where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_records")
        GetRecords()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(3, i).Value.ToString()
        ComboBox1.Text = DataGridView1.Item(4, i).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("update tbl_records set firstname = '" & TextBox1.Text &
                                     "', lastname = '" & TextBox2.Text &
                                     "', age = '" & TextBox3.Text &
                                     "', gender = '" & ComboBox1.Text &
                                     "' where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_records")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""
        GetRecords()
    End Sub
End Class