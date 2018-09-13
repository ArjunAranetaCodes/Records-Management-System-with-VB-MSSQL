Imports System.Data.SqlClient
Public Class Form1
    Public conn As New SqlConnection("Data Source=ALLMANKIND\MSSQLSERVER8; Database=db_vbrecordsys; Integrated Security=True")
    Public adapter As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox4.Text = TextBox5.Text Then
            ds = New DataSet
            adapter = New SqlDataAdapter("insert into tbl_accounts (username, password, privilege) VALUES " &
                                         "('" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')", conn)
            adapter.Fill(ds, "tbl_accounts")
            MsgBox("User Registered!")
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = ""
        Else
            MsgBox("Passwords do not match!")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("select * from tbl_accounts where username like '" & TextBox1.Text &
                                     "' and password like '" & TextBox2.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")

        If ds.Tables("tbl_accounts").Rows.Count > 0 Then
            MsgBox("Login Successful!")
            TextBox1.Clear()
            TextBox2.Clear()
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("Invalid combination of username and password!")
        End If
    End Sub
End Class
