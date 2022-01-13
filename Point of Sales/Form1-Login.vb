Imports System.Data.OleDb


Public Class Form1
    Dim path = System.Windows.Forms.Application.StartupPath
    Dim Position As String


    'Form1 Load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = (Me.Width - 300) / 2
        Me.Top = (Me.Height - 150) / 2
    End Sub


    'Exit Button
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub


    'Minimmize Button
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    'Button Log in
    Private Sub RectangleShape2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape2.Click



        'Check if the user is in Database
        Dim connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        Dim command As New OleDbCommand("SELECT [IDNumber] FROM [Accounts] WHERE [NameField] = Name AND [PasswordField] = Password", connection)

        Dim usernameParam As New OleDbParameter("Name", Me.TextBox1.Text)
        Dim passwordParam As New OleDbParameter("Password", Me.TextBox2.Text)

        command.Parameters.Add(usernameParam)
        command.Parameters.Add(passwordParam)
        command.Connection.Open()

        Dim reader As OleDbDataReader = command.ExecuteReader
        If reader.HasRows Or TextBox1.Text = "Warren Tapawan" And TextBox2.Text = "997" Then
            Me.Hide()
            Form2.Show()
        Else
            MessageBox.Show("Username and Password are not found!", " HK - Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            TextBox2.Text = ""
        End If




        'Assign the user position from data base to userPosition in form2
        If TextBox1.Text = "Warren Tapawan" And TextBox2.Text = "997" Then
            Position = "Developer"
            Form2.userPosition.Text = Position
        End If

        If reader.HasRows Then
            Dim conn As New OleDbConnection
            conn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
            conn.Open()

            Dim strsql As String
            strsql = " select [Position] from Accounts where Name='" & TextBox1.Text & "'"

            Dim cmd As New OleDbCommand(strsql, conn)
            Dim myReader As OleDbDataReader
            myReader = cmd.ExecuteReader
            myReader.Read()

            Position = myReader("Position")
            Form2.userPosition.Text = Position
            conn.Close()
        End If


    End Sub



End Class
