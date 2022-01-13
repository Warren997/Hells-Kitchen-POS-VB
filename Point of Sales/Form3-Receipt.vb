Imports System.Data.OleDb    ' Saying that we're using Database

Public Class Form3
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Timer1.Start()



        'Location whre Form3 Show
        Me.Left = 500
        Me.Top = 20

        'Sub Total, Tax, Total
        TextBox3.Text = TextBox3.Text & String.Format("{0:n2}", Form2.subTotal)
        TextBox4.Text = TextBox4.Text & String.Format("{0:n2}", Form2.subTotal * 0.025)    '2.5% is the average tax for restaurant dish
        TextBox5.Text = TextBox5.Text & String.Format("{0:n2}", (Form2.subTotal * 0.025) + Form2.subTotal)

        'Date and Host
        Label4.Text = Date.Now
        Label5.Text = "Host: " & Form1.TextBox1.Text

        'Table
        If Form2.ComboBoxTables.SelectedIndex = 0 Then
            Label2.Text = "Table 1"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 1 Then
            Label2.Text = "Table 2"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 2 Then
            Label2.Text = "Table 3"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 3 Then
            Label2.Text = "Table 4"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 4 Then
            Label2.Text = "Table 5"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 5 Then
            Label2.Text = "Table 6"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 6 Then
            Label2.Text = "Table 7"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 7 Then
            Label2.Text = "Table 8"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 8 Then
            Label2.Text = "Table 9"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 9 Then
            Label2.Text = "Table 10"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 10 Then
            Label2.Text = "Table 11"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 11 Then
            Label2.Text = "Table 12"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 12 Then
            Label2.Text = "Table 13"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 13 Then
            Label2.Text = "Table 14"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 14 Then
            Label2.Text = "Table 15"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 15 Then
            Label2.Text = "Table 16"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 16 Then
            Label2.Text = "Table 17"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 17 Then
            Label2.Text = "Table 18"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 18 Then
            Label2.Text = "Table 19"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 19 Then
            Label2.Text = "Table 20"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 20 Then
            Label2.Text = "Table 21"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 21 Then
            Label2.Text = "Table 22"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 22 Then
            Label2.Text = "Table 23"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 23 Then
            Label2.Text = "Table 24"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 24 Then
            Label2.Text = "Table 25"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 25 Then
            Label2.Text = "Table 26"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 26 Then
            Label2.Text = "Table 27"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 27 Then
            Label2.Text = "Table 28"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 28 Then
            Label2.Text = "Table 29"
        ElseIf Form2.ComboBoxTables.SelectedIndex = 29 Then
            Label2.Text = "Table 30"

        End If



        

    End Sub



 
    

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

        If TextBox7.Text < ((Form2.subTotal * 0.025) + Form2.subTotal) Then
            TextBox6.Text = "Payment not enough"
        Else
            TextBox6.Text = TextBox7.Text - ((Form2.subTotal * 0.025) + Form2.subTotal)
        End If








    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If TextBox7.Text < ((Form2.subTotal * 0.025) + Form2.subTotal) Then
            MsgBox("Payment not enough")
        Else



            ' -------- Save To History --------

            myConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HKDatabase.mdb"
            myConnection.Open()

            'Add Values to Database
            Dim cmd As OleDbCommand = New OleDbCommand("Insert into History([Host],[TableNumber],[Date],[SubTotal],[Tax],[Total],[Payment],[Change],[Orders]) Values(?,?,?,?,?,?,?,?,?)", myConnection)
            cmd.Parameters.Add(New OleDbParameter("Host", CType(Form1.TextBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("TableNumber", CType(Label2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Date", CType(Label4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("SubTotal", CType(TextBox3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Tax", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Total", CType(TextBox5.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Payment", CType(TextBox7.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Change", CType(TextBox6.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Orders", CType(TextBox1.Text, String)))


            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



            Me.Close()

        End If




        









    End Sub
End Class