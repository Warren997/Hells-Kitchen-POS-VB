Imports System.Data.OleDb

Public Class Form2
    

    Dim myconnection As OleDbConnection = New OleDbConnection
    Dim myconnection1 As OleDbConnection = New OleDbConnection
    Dim Form3Show As Integer = 0

    'Provider
    Dim constring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb"

    'Contain the price of the Dish from Database, and will send out to Form3
    Public subTotal As Double


    'Form2 Load
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 200
        Me.Top = 125

        'TextBox Container For Id and Price
        TextBoxID.Hide()
        TextBoxPrice.Hide()

        'Table Numbers
        Me.ComboBoxTables.Items.Add("Table 1") : Me.ComboBoxTables.Items.Add("Table 2") : Me.ComboBoxTables.Items.Add("Table 3")
        Me.ComboBoxTables.Items.Add("Table 4") : Me.ComboBoxTables.Items.Add("Table 5") : Me.ComboBoxTables.Items.Add("Table 6")
        Me.ComboBoxTables.Items.Add("Table 7") : Me.ComboBoxTables.Items.Add("Table 8") : Me.ComboBoxTables.Items.Add("Table 9")
        Me.ComboBoxTables.Items.Add("Table 10") : Me.ComboBoxTables.Items.Add("Table 11") : Me.ComboBoxTables.Items.Add("Table 12")
        Me.ComboBoxTables.Items.Add("Table 13") : Me.ComboBoxTables.Items.Add("Table 14") : Me.ComboBoxTables.Items.Add("Table 15")
        Me.ComboBoxTables.Items.Add("Table 16") : Me.ComboBoxTables.Items.Add("Table 17") : Me.ComboBoxTables.Items.Add("Table 18")
        Me.ComboBoxTables.Items.Add("Table 19") : Me.ComboBoxTables.Items.Add("Table 20") : Me.ComboBoxTables.Items.Add("Table 21")
        Me.ComboBoxTables.Items.Add("Table 22") : Me.ComboBoxTables.Items.Add("Table 23") : Me.ComboBoxTables.Items.Add("Table 24")
        Me.ComboBoxTables.Items.Add("Table 25") : Me.ComboBoxTables.Items.Add("Table 26") : Me.ComboBoxTables.Items.Add("Table 27")
        Me.ComboBoxTables.Items.Add("Table 28") : Me.ComboBoxTables.Items.Add("Table 29") : Me.ComboBoxTables.Items.Add("Table 30")


        'Hide Inventory
        InventoryPanel.Hide() : InventoryLogo.Hide() : DataGridView1.Hide() : Button4.Hide() : Button5.Hide() : Label2.Hide()
        Label3.Hide() : Label4.Hide() : Label6.Hide() : TextBox1.Hide() : TextBox2.Hide() : TextBox3.Hide() : TextBox5.Hide()

        'Refresh the DataGridView
        BindGridInventory()

    End Sub


    'Database to DataGridView Inventory
    Private Sub BindGridInventory()
        Using con As New OleDbConnection(constring)
            Using cmd As New OleDbCommand(" select IDNumber,Dish,Stock,Price from Inventory", con)

                cmd.CommandType = CommandType.Text
                con.Open()

                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())
                DataGridView1.DataSource = dt
                con.Close()

            End Using
        End Using

        'Stop the Refreshing of DataGridView
        Timer2.Enabled = False

    End Sub


    'Database to DataGridView History
    Private Sub BindGridHistory()
        Using con1 As New OleDbConnection(constring)
            Using cmd1 As New OleDbCommand(" select Host,TableNumber,Date,SubTotal,Tax,Total,Payment,Change,Orders from History", con1)

                cmd1.CommandType = CommandType.Text
                con1.Open()

                Dim dt1 As New DataTable()
                dt1.Load(cmd1.ExecuteReader())
                HistoryData.DataSource = dt1
                con1.Close()

            End Using
        End Using

    End Sub


    'Database to DataGridView Accounts
    Private Sub BindGridAccounts()
        Using con2 As New OleDbConnection(constring)
            Using cmd2 As New OleDbCommand(" select [IDNumber],[Name],[Password], [Position] from Accounts", con2)

                cmd2.CommandType = CommandType.Text
                con2.Open()

                Dim dt2 As New DataTable()
                dt2.Load(cmd2.ExecuteReader())
                DataGridView3.DataSource = dt2
                con2.Close()

            End Using
        End Using

        'Stop the Refreshing of DataGridView
        Timer3.Enabled = False

    End Sub


    'Timer1 Start
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Timer1.Enabled = True
        userName.Text = Form1.TextBox1.Text
    End Sub


    'Timer1
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        DateForm.Text = Date.Now



        'NumericUpDown Change Color if has value

        '----------------  Hors D'oeuvres  ----------------

        'Bruschetta
        If NumericUpDown1.Value > 0 Then : NumericUpDown1.BackColor = Color.Gold
        ElseIf NumericUpDown1.Value <= 0 Then : NumericUpDown1.BackColor = Color.White
        End If

        'Caviar
        If NumericUpDown2.Value > 0 Then : NumericUpDown2.BackColor = Color.Gold
        ElseIf NumericUpDown2.Value <= 0 Then : NumericUpDown2.BackColor = Color.White
        End If

        'Damplings
        If NumericUpDown3.Value > 0 Then : NumericUpDown3.BackColor = Color.Gold
        ElseIf NumericUpDown3.Value <= 0 Then : NumericUpDown3.BackColor = Color.White
        End If

        'Beef Tartare
        If NumericUpDown4.Value > 0 Then : NumericUpDown4.BackColor = Color.Gold
        ElseIf NumericUpDown4.Value <= 0 Then : NumericUpDown4.BackColor = Color.White
        End If


        '----------------  Appetizers  ----------------

        'Crab Cake
        If NumericUpDown5.Value > 0 Then : NumericUpDown5.BackColor = Color.Gold
        ElseIf NumericUpDown5.Value <= 0 Then : NumericUpDown5.BackColor = Color.White
        End If

        'Buffalo Wings
        If NumericUpDown6.Value > 0 Then : NumericUpDown6.BackColor = Color.Gold
        ElseIf NumericUpDown6.Value <= 0 Then : NumericUpDown6.BackColor = Color.White
        End If

        'Deviled Eggs
        If NumericUpDown7.Value > 0 Then : NumericUpDown7.BackColor = Color.Gold
        ElseIf NumericUpDown7.Value <= 0 Then : NumericUpDown7.BackColor = Color.White
        End If

        'Prawn Cocktail
        If NumericUpDown8.Value > 0 Then : NumericUpDown8.BackColor = Color.Gold
        ElseIf NumericUpDown8.Value <= 0 Then : NumericUpDown8.BackColor = Color.White
        End If


        '----------------  Salad  ----------------

        'Ceasar Salad
        If NumericUpDown9.Value > 0 Then : NumericUpDown9.BackColor = Color.Gold
        ElseIf NumericUpDown9.Value <= 0 Then : NumericUpDown9.BackColor = Color.White
        End If

        'Coleslaw
        If NumericUpDown10.Value > 0 Then : NumericUpDown10.BackColor = Color.Gold
        ElseIf NumericUpDown10.Value <= 0 Then : NumericUpDown10.BackColor = Color.White
        End If

        'Olivier Salad
        If NumericUpDown11.Value > 0 Then : NumericUpDown11.BackColor = Color.Gold
        ElseIf NumericUpDown11.Value <= 0 Then : NumericUpDown11.BackColor = Color.White
        End If

        'Ratatouille
        If NumericUpDown12.Value > 0 Then : NumericUpDown12.BackColor = Color.Gold
        ElseIf NumericUpDown12.Value <= 0 Then : NumericUpDown12.BackColor = Color.White
        End If


        '----------------  Entree  ----------------

        'Beef Wellington
        If NumericUpDown13.Value > 0 Then : NumericUpDown13.BackColor = Color.Gold
        ElseIf NumericUpDown13.Value <= 0 Then : NumericUpDown13.BackColor = Color.White
        End If

        'Rack of Lamb
        If NumericUpDown14.Value > 0 Then : NumericUpDown14.BackColor = Color.Gold
        ElseIf NumericUpDown14.Value <= 0 Then : NumericUpDown14.BackColor = Color.White
        End If

        'Lobster Risotto
        If NumericUpDown15.Value > 0 Then : NumericUpDown15.BackColor = Color.Gold
        ElseIf NumericUpDown15.Value <= 0 Then : NumericUpDown15.BackColor = Color.White
        End If

        'Seared Scallops
        If NumericUpDown16.Value > 0 Then : NumericUpDown16.BackColor = Color.Gold
        ElseIf NumericUpDown16.Value <= 0 Then : NumericUpDown16.BackColor = Color.White
        End If


        '----------------  Dessert  ----------------

        'Carrot Cake
        If NumericUpDown17.Value > 0 Then : NumericUpDown17.BackColor = Color.Gold
        ElseIf NumericUpDown17.Value <= 0 Then : NumericUpDown17.BackColor = Color.White
        End If

        'Creme Brulee
        If NumericUpDown18.Value > 0 Then : NumericUpDown18.BackColor = Color.Gold
        ElseIf NumericUpDown18.Value <= 0 Then : NumericUpDown18.BackColor = Color.White
        End If

        'Tiramisu
        If NumericUpDown19.Value > 0 Then : NumericUpDown19.BackColor = Color.Gold
        ElseIf NumericUpDown19.Value <= 0 Then : NumericUpDown19.BackColor = Color.White
        End If

        'Truffle Cake
        If NumericUpDown20.Value > 0 Then : NumericUpDown20.BackColor = Color.Gold
        ElseIf NumericUpDown20.Value <= 0 Then : NumericUpDown20.BackColor = Color.White
        End If



    End Sub

    'Timer 2
    'Load Access to Datagridview
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        BindGridInventory()
    End Sub

    

    'Orders Button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sidePanel.Height = Button1.Height
        sidePanel.Top = Button1.Top

        'Hide Inventory
        InventoryPanel.Hide() : InventoryLogo.Hide() : DataGridView1.Hide() : Button4.Hide() : Button5.Hide() : Label2.Hide()
        Label3.Hide() : Label4.Hide() : Label6.Hide() : TextBox1.Hide() : TextBox2.Hide() : TextBox3.Hide() : TextBox5.Hide()

    End Sub


    'Inventory Button
    Private Sub Inventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inventory.Click
        sidePanel.Height = Inventory.Height
        sidePanel.Top = Inventory.Top

        'Hide History
        HistoryData.Hide()
        HistoryPanel.Hide()

        'Show Inventory
        InventoryPanel.Show() : InventoryLogo.Show() : DataGridView1.Show() : Button4.Show() : Button5.Show() : Label2.Show()
        Label3.Show() : Label4.Show() : Label6.Show() : TextBox1.Show() : TextBox2.Show() : TextBox3.Show() : TextBox5.Show()

    End Sub


    'History Button
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        sidePanel.Height = Button7.Height
        sidePanel.Top = Button7.Top

        'Show History
        HistoryPanel.Show()
        HistoryData.Show()
        InventoryPanel.Show()
        BindGridHistory()

        'Hide Inventory
        InventoryLogo.Hide() : DataGridView1.Hide() : Button4.Hide() : Button5.Hide() : Label2.Hide() : Label3.Hide()
        Label4.Hide() : Label6.Hide() : TextBox1.Hide() : TextBox2.Hide() : TextBox3.Hide() : TextBox5.Hide()

        'Hide Accounts
        AccountsPanel.Hide() : DataGridView3.Hide() : PictureBox2.Hide() : TextBoxPass.Hide()
        TextBoxName.Hide() : Label12.Hide() : Label13.Hide() : Button10.Hide()

    End Sub


    'Accounts Button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Only Maître d'hôtel and The Owner can Access Accounts
        If userPosition.Text = "Maître d'hôtel" Or userPosition.Text = "Owner" Or userPosition.Text = "Developer" Then
            sidePanel.Height = Button2.Height
            sidePanel.Top = Button2.Top

            'Load the DataGridView
            BindGridAccounts()

            'Show Accounts
            InventoryPanel.Show() : HistoryPanel.Show() : AccountsPanel.Show() : DataGridView3.Show() : PictureBox2.Show()
            TextBoxPass.Show() : TextBoxName.Show() : Label12.Show() : Label13.Show() : Button10.Show()
        Else
            MessageBox.Show("Only Maître d'hôtel and Owner can access Accounts", " HK - Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If

    End Sub


    'Log out Button
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sidePanel.Height = Button3.Height
        sidePanel.Top = Button3.Top

        'Restart the whole Application
        Application.Restart()

    End Sub


    '----------Price of Dish Containers

    'Hors, Appetizers, Salad
    Dim BruschettaP, CaviarP, DumplingsP, BeefTartareP, CrabCakeP, BuffaloWingsP, DeviledEggsP, PrawnCocktailP, CaesarSaladP, ColeslawP, OlivierSaladP, RatatouilleP As Integer

    'Entree, Dessert,Drinks
    Dim BeefWellP, RackLambP, SearedScalP, LobsterRisottoP, CarrotCakeP, CremeBruleeP, TiramisuP, TruffleCakeP, ChardonnayP, PinotGrigioP, ZinfandelP As Integer
    Dim WaterP As String


    '----------Stock of Dish Containers

    'Hors, Appetizers, Salad
    Dim BruschettaS, CaviarS, DumplingsS, BeefTartareS, CrabCakeS, BuffaloWingsS, DeviledEggsS, PrawnCocktailS, CaesarSaladS, ColeslawS, OlivierSaladS, RatatouilleS As String
    Dim BruschettaID, CaviarID, DumplingsID, BeefTartareID, CrabCakeID, BuffaloWingsID, DeviledEggsID, PrawnCocktailID, CaesarSaladID, ColeslawID, OlivierSaladID, RatatouilleID As String

    'Entree, Dessert,Drinks
    Dim BeefWellS, RackLambS, SearedScalS, LobsterRisottoS, CarrotCakeS, CremeBruleeS, TiramisuS, TruffleCakeS, ChardonnayS, PinotGrigioS, ZinfandelS, WaterS As String
    Dim BeefWellID, RackLambID, SearedScalID, LobsterRisottoID, CarrotCakeID, CremeBruleeID, TiramisuID, TruffleCakeID, ChardonnayID, PinotGrigioID, ZinfandelID, WaterID As String


    'Hors
    Dim command, commandx, command2, command3 As String
    'Appetizer
    Dim command4, command5, command6, command7 As String
    'Salad
    Dim command8, command9, command10, command11 As String

    'Entree
    Dim command12, command13, command14, command15 As String
    'Dessert
    Dim command16, command17, command18, command19 As String
    'Drinks
    Dim command20, command21, command22, command23 As String



    'Print Orders
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintIcon.Click



        'Get the Price from Database

        ' ----------- Hors ----------- 

        'Bruschetta
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn.Open()
        Dim strsql As String
        Dim myReader As OleDbDataReader
        TextBoxID.Text = 1
        strsql = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd As New OleDbCommand(strsql, conn)
        myReader = cmd.ExecuteReader
        myReader.Read()
        TextBoxPrice.Text = myReader("Price")
        conn.Close()
        BruschettaP = TextBoxPrice.Text


        ' -------------- Stock -----------------

        'Read Stock from Database and deduct the NumericUpDown Value
        Dim connx As New OleDbConnection
        connx.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        connx.Open()
        Dim strsqlx As String
        Dim myReaderx As OleDbDataReader
        BruschettaID = 1
        strsqlx = " select Stock from Inventory where IDNUMBER=" + BruschettaID + ""
        Dim cmdx As New OleDbCommand(strsqlx, connx)
        myReaderx = cmdx.ExecuteReader
        myReaderx.Read()
        BruschettaS = myReaderx("Stock")
        connx.Close()


        If BruschettaS > Me.NumericUpDown1.Value Then


            BruschettaS = BruschettaS - Me.NumericUpDown1.Value

            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionA As OleDbConnection = New OleDbConnection
            myconnectionA.ConnectionString = constring
            myconnectionA.Open()
            command = "update Inventory set [Stock]='" & BruschettaS & "' where[IDNUMBER]=" & BruschettaID & ""
            Dim cmdA As OleDbCommand = New OleDbCommand(command, myconnectionA)

            Try
                cmdA.ExecuteNonQuery()
                cmdA.Dispose()
                myconnectionA.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MessageBox.Show("We only have " & BruschettaS & " of Bruschetta", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If




        'Caviar
        Dim conn1 As New OleDbConnection
        conn1.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn1.Open()
        Dim strsql1 As String
        Dim myReader1 As OleDbDataReader
        TextBoxID.Text = 2
        strsql1 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd1 As New OleDbCommand(strsql1, conn1)
        myReader1 = cmd1.ExecuteReader
        myReader1.Read()
        TextBoxPrice.Text = myReader1("Price")
        conn1.Close()
        CaviarP = TextBoxPrice.Text


        ' -------------- Stock -----------------


        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn1x As New OleDbConnection
        conn1x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn1x.Open()
        Dim strsql1x As String
        Dim myReader1x As OleDbDataReader
        CaviarID = 2
        strsql1x = " select Stock from Inventory where IDNUMBER=" + CaviarID + ""
        Dim cmd1x As New OleDbCommand(strsql1x, conn1x)
        myReader1x = cmd1x.ExecuteReader
        myReader1x.Read()
        CaviarS = myReader1x("Stock")
        connx.Close()

        If CaviarS > Me.NumericUpDown2.Value Then


            CaviarS = CaviarS - Me.NumericUpDown2.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionB As OleDbConnection = New OleDbConnection
            myconnectionB.ConnectionString = constring
            myconnectionB.Open()
            commandx = "update Inventory set [Stock]='" & CaviarS & "' where[IDNUMBER]=" & CaviarID & ""
            Dim cmdB As OleDbCommand = New OleDbCommand(commandx, myconnectionB)

            Try
                cmdB.ExecuteNonQuery()
                cmdB.Dispose()
                myconnectionB.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & CaviarS & " of Caviar", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If





        'Dumplings
        Dim conn2 As New OleDbConnection
        conn2.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn2.Open()
        Dim strsql2 As String
        Dim myReader2 As OleDbDataReader
        TextBoxID.Text = 3
        strsql2 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd2 As New OleDbCommand(strsql2, conn2)
        myReader2 = cmd2.ExecuteReader
        myReader2.Read()
        TextBoxPrice.Text = myReader2("Price")
        conn2.Close()
        DumplingsP = TextBoxPrice.Text



        ' -------------- Stock -----------------

        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn2x As New OleDbConnection
        conn2x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn2x.Open()
        Dim strsql2x As String
        Dim myReader2x As OleDbDataReader
        DumplingsID = 3
        strsql2x = " select Stock from Inventory where IDNUMBER=" + DumplingsID + ""
        Dim cmd2x As New OleDbCommand(strsql2x, conn2x)
        myReader2x = cmd2x.ExecuteReader
        myReader2x.Read()
        DumplingsS = myReader2x("Stock")
        conn2x.Close()

        If DumplingsS > Me.NumericUpDown3.Value Then
            DumplingsS = DumplingsS - Me.NumericUpDown3.Value 

            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionC As OleDbConnection = New OleDbConnection
            myconnectionC.ConnectionString = constring
            myconnectionC.Open()
            command2 = "update Inventory set [Stock]='" & DumplingsS & "' where[IDNUMBER]=" & DumplingsID & ""
            Dim cmdA2 As OleDbCommand = New OleDbCommand(command2, myconnectionC)

            Try
                cmdA2.ExecuteNonQuery()
                cmdA2.Dispose()
                myconnectionC.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & DumplingsS & " of Dumplings", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If



        'Beef Tartare
        Dim conn3 As New OleDbConnection
        conn3.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn3.Open()
        Dim strsql3 As String
        Dim myReader3 As OleDbDataReader
        TextBoxID.Text = 4
        strsql3 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd3 As New OleDbCommand(strsql3, conn3)
        myReader3 = cmd3.ExecuteReader
        myReader3.Read()
        TextBoxPrice.Text = myReader3("Price")
        conn3.Close()
        BeefTartareP = TextBoxPrice.Text




        ' -------------- Stock -----------------

        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn3x As New OleDbConnection
        conn3x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn3x.Open()
        Dim strsql3x As String
        Dim myReader3x As OleDbDataReader
        BeefTartareID = 4
        strsql3x = " select Stock from Inventory where IDNUMBER=" + BeefTartareID + ""
        Dim cmd3x As New OleDbCommand(strsql3x, conn3x)
        myReader3x = cmd3x.ExecuteReader
        myReader3x.Read()
        BeefTartareS = myReader3x("Stock")
        conn3x.Close()

        If BeefTartareS > Me.NumericUpDown4.Value Then


            BeefTartareS = BeefTartareS - Me.NumericUpDown4.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionD As OleDbConnection = New OleDbConnection
            myconnectionD.ConnectionString = constring
            myconnectionD.Open()
            command3 = "update Inventory set [Stock]='" & BeefTartareS & "' where[IDNUMBER]=" & BeefTartareID & ""
            Dim cmdA3 As OleDbCommand = New OleDbCommand(command3, myconnectionD)

            Try
                cmdA3.ExecuteNonQuery()
                cmdA3.Dispose()
                myconnectionD.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & BeefTartareS & " of Beef Tartare", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If














        ' ----------- Appetizer ----------- 

        'Crab Cake
        Dim conn4 As New OleDbConnection
        conn4.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn4.Open()
        Dim strsql4 As String
        Dim myReader4 As OleDbDataReader
        TextBoxID.Text = 5
        strsql4 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd4 As New OleDbCommand(strsql4, conn4)
        myReader4 = cmd4.ExecuteReader
        myReader4.Read()
        TextBoxPrice.Text = myReader4("Price")
        conn.Close()
        CrabCakeP = TextBoxPrice.Text




        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn4x As New OleDbConnection
        conn4x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn4x.Open()
        Dim strsql4x As String
        Dim myReader4x As OleDbDataReader
        CrabCakeID = 5
        strsql4x = " select Stock from Inventory where IDNUMBER=" + CrabCakeID + ""
        Dim cmd4x As New OleDbCommand(strsql4x, conn4x)
        myReader4x = cmd4x.ExecuteReader
        myReader4x.Read()
        CrabCakeS = myReader4x("Stock")
        conn4x.Close()

        If CrabCakeS > Me.NumericUpDown5.Value Then


            CrabCakeS = CrabCakeS - Me.NumericUpDown5.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionE As OleDbConnection = New OleDbConnection
            myconnectionE.ConnectionString = constring
            myconnectionE.Open()
            command4 = "update Inventory set [Stock]='" & CrabCakeS & "' where[IDNUMBER]=" & CrabCakeID & ""
            Dim cmdA4 As OleDbCommand = New OleDbCommand(command4, myconnectionE)

            Try
                cmdA4.ExecuteNonQuery()
                cmdA4.Dispose()
                myconnectionE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & CrabCakeS & " of Crab Cake", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If











        'Buffalo Wings
        Dim conn5 As New OleDbConnection
        conn5.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn5.Open()
        Dim strsql5 As String
        Dim myReader5 As OleDbDataReader
        TextBoxID.Text = 6
        strsql5 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd5 As New OleDbCommand(strsql5, conn5)
        myReader5 = cmd5.ExecuteReader
        myReader5.Read()
        TextBoxPrice.Text = myReader5("Price")
        conn5.Close()
        BuffaloWingsP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn5x As New OleDbConnection
        conn5x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn5x.Open()
        Dim strsql5x As String
        Dim myReader5x As OleDbDataReader
        BuffaloWingsID = 6
        strsql5x = " select Stock from Inventory where IDNUMBER=" + BuffaloWingsID + ""
        Dim cmd5x As New OleDbCommand(strsql5x, conn5x)
        myReader5x = cmd5x.ExecuteReader
        myReader5x.Read()
        BuffaloWingsS = myReader5x("Stock")
        conn5x.Close()


        If BuffaloWingsS > Me.NumericUpDown6.Value Then


            BuffaloWingsS = BuffaloWingsS - Me.NumericUpDown6.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionF As OleDbConnection = New OleDbConnection
            myconnectionF.ConnectionString = constring
            myconnectionF.Open()
            command5 = "update Inventory set [Stock]='" & BuffaloWingsS & "' where[IDNUMBER]=" & BuffaloWingsID & ""
            Dim cmdA5 As OleDbCommand = New OleDbCommand(command5, myconnectionF)

            Try
                cmdA5.ExecuteNonQuery()
                cmdA5.Dispose()
                myconnectionF.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & BuffaloWingsS & " of Buffalo Wings", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If





        'Deviled Eggs
        Dim conn6 As New OleDbConnection
        conn6.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn6.Open()
        Dim strsql6 As String
        Dim myReader6 As OleDbDataReader
        TextBoxID.Text = 7
        strsql6 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd6 As New OleDbCommand(strsql6, conn6)
        myReader6 = cmd6.ExecuteReader
        myReader6.Read()
        TextBoxPrice.Text = myReader6("Price")
        conn6.Close()
        DeviledEggsP = TextBoxPrice.Text


        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn6x As New OleDbConnection
        conn6x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn6x.Open()
        Dim strsql6x As String
        Dim myReader6x As OleDbDataReader
        DeviledEggsID = 7
        strsql6x = " select Stock from Inventory where IDNUMBER=" + DeviledEggsID + ""
        Dim cmd6x As New OleDbCommand(strsql6x, conn6x)
        myReader6x = cmd6x.ExecuteReader
        myReader6x.Read()
        DeviledEggsS = myReader6x("Stock")
        conn6x.Close()


        If DeviledEggsS > Me.NumericUpDown7.Value Then


            DeviledEggsS = DeviledEggsS - Me.NumericUpDown7.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionG As OleDbConnection = New OleDbConnection
            myconnectionG.ConnectionString = constring
            myconnectionG.Open()
            command6 = "update Inventory set [Stock]='" & DeviledEggsS & "' where[IDNUMBER]=" & DeviledEggsID & ""
            Dim cmdA6 As OleDbCommand = New OleDbCommand(command6, myconnectionG)

            Try
                cmdA6.ExecuteNonQuery()
                cmdA6.Dispose()
                myconnectionG.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & DeviledEggsS & " of Deviled Eggs", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If






        'Prawn Cocktail
        Dim conn7 As New OleDbConnection
        conn7.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn7.Open()
        Dim strsql7 As String
        Dim myReader7 As OleDbDataReader
        TextBoxID.Text = 8
        strsql7 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd7 As New OleDbCommand(strsql7, conn7)
        myReader7 = cmd7.ExecuteReader
        myReader7.Read()
        TextBoxPrice.Text = myReader7("Price")
        conn7.Close()
        PrawnCocktailP = TextBoxPrice.Text




        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn7x As New OleDbConnection
        conn7x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn7x.Open()
        Dim strsql7x As String
        Dim myReader7x As OleDbDataReader
        PrawnCocktailID = 8
        strsql7x = " select Stock from Inventory where IDNUMBER=" + PrawnCocktailID + ""
        Dim cmd7x As New OleDbCommand(strsql7x, conn7x)
        myReader7x = cmd7x.ExecuteReader
        myReader7x.Read()
        PrawnCocktailS = myReader7x("Stock")
        conn7x.Close()

        If PrawnCocktailS > Me.NumericUpDown8.Value Then


            PrawnCocktailS = PrawnCocktailS - Me.NumericUpDown8.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionH As OleDbConnection = New OleDbConnection
            myconnectionH.ConnectionString = constring
            myconnectionH.Open()
            command7 = "update Inventory set [Stock]='" & PrawnCocktailS & "' where[IDNUMBER]=" & PrawnCocktailID & ""
            Dim cmdA7 As OleDbCommand = New OleDbCommand(command7, myconnectionH)

            Try
                cmdA7.ExecuteNonQuery()
                cmdA7.Dispose()
                myconnectionH.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & PrawnCocktailS & " of Prawn Cocktail", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If






        ' ----------- Salad ----------- 

        'Caesar Salad
        Dim conn8 As New OleDbConnection
        conn8.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn8.Open()
        Dim strsql8 As String
        Dim myReader8 As OleDbDataReader
        TextBoxID.Text = 9
        strsql8 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd8 As New OleDbCommand(strsql8, conn8)
        myReader8 = cmd8.ExecuteReader
        myReader8.Read()
        TextBoxPrice.Text = myReader8("Price")
        conn8.Close()
        CaesarSaladP = TextBoxPrice.Text




        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn8x As New OleDbConnection
        conn8x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn8x.Open()
        Dim strsql8x As String
        Dim myReader8x As OleDbDataReader
        CaesarSaladID = 9
        strsql8x = " select Stock from Inventory where IDNUMBER=" + CaesarSaladID + ""
        Dim cmd8x As New OleDbCommand(strsql8x, conn8x)
        myReader8x = cmd8x.ExecuteReader
        myReader8x.Read()
        CaesarSaladS = myReader8x("Stock")
        conn8x.Close()

        If CaesarSaladS > Me.NumericUpDown9.Value Then

            CaesarSaladS = CaesarSaladS - Me.NumericUpDown9.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionI As OleDbConnection = New OleDbConnection
            myconnectionI.ConnectionString = constring
            myconnectionI.Open()
            command8 = "update Inventory set [Stock]='" & CaesarSaladS & "' where[IDNUMBER]=" & CaesarSaladID & ""
            Dim cmdA8 As OleDbCommand = New OleDbCommand(command8, myconnectionI)

            Try
                cmdA8.ExecuteNonQuery()
                cmdA8.Dispose()
                myconnectionI.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & CaesarSaladS & " of Caesar Salad", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If




        'Coleslaw
        Dim conn9 As New OleDbConnection
        conn9.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn9.Open()
        Dim strsql9 As String
        Dim myReader9 As OleDbDataReader
        TextBoxID.Text = 10
        strsql9 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd9 As New OleDbCommand(strsql9, conn9)
        myReader9 = cmd9.ExecuteReader
        myReader9.Read()
        TextBoxPrice.Text = myReader9("Price")
        conn9.Close()
        ColeslawP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn9x As New OleDbConnection
        conn9x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn9x.Open()
        Dim strsql9x As String
        Dim myReader9x As OleDbDataReader
        ColeslawID = 10
        strsql9x = " select Stock from Inventory where IDNUMBER=" + ColeslawID + ""
        Dim cmd9x As New OleDbCommand(strsql9x, conn9x)
        myReader9x = cmd9x.ExecuteReader
        myReader9x.Read()
        ColeslawS = myReader9x("Stock")
        conn9x.Close()

        If ColeslawS > Me.NumericUpDown10.Value Then


            ColeslawS = ColeslawS - Me.NumericUpDown10.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionJ As OleDbConnection = New OleDbConnection
            myconnectionJ.ConnectionString = constring
            myconnectionJ.Open()
            command9 = "update Inventory set [Stock]='" & ColeslawS & "' where[IDNUMBER]=" & ColeslawID & ""
            Dim cmdA9 As OleDbCommand = New OleDbCommand(command9, myconnectionJ)

            Try
                cmdA9.ExecuteNonQuery()
                cmdA9.Dispose()
                myconnectionJ.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & ColeslawS & " of Coleslaw", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If




        'Olivier Salad
        Dim conn10 As New OleDbConnection
        conn10.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn10.Open()
        Dim strsql10 As String
        Dim myReader10 As OleDbDataReader
        TextBoxID.Text = 11
        strsql10 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd10 As New OleDbCommand(strsql10, conn10)
        myReader10 = cmd10.ExecuteReader
        myReader10.Read()
        TextBoxPrice.Text = myReader10("Price")
        conn10.Close()
        OlivierSaladP = TextBoxPrice.Text




        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn10x As New OleDbConnection
        conn10x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn10x.Open()
        Dim strsql10x As String
        Dim myReader10x As OleDbDataReader
        OlivierSaladID = 11
        strsql10x = " select Stock from Inventory where IDNUMBER=" + OlivierSaladID + ""
        Dim cmd10x As New OleDbCommand(strsql10x, conn10x)
        myReader10x = cmd10x.ExecuteReader
        myReader10x.Read()
        OlivierSaladS = myReader10x("Stock")
        conn10x.Close()

        If OlivierSaladS > Me.NumericUpDown11.Value Then


            OlivierSaladS = OlivierSaladS - Me.NumericUpDown11.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionK As OleDbConnection = New OleDbConnection
            myconnectionK.ConnectionString = constring
            myconnectionK.Open()
            command10 = "update Inventory set [Stock]='" & OlivierSaladS & "' where[IDNUMBER]=" & OlivierSaladID & ""
            Dim cmdA10 As OleDbCommand = New OleDbCommand(command10, myconnectionK)

            Try
                cmdA10.ExecuteNonQuery()
                cmdA10.Dispose()
                myconnectionK.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & OlivierSaladS & " of Olivier Salad", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If








        'Ratatouille
        Dim conn11 As New OleDbConnection
        conn11.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn11.Open()
        Dim strsql11 As String
        Dim myReader11 As OleDbDataReader
        TextBoxID.Text = 12
        strsql11 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd11 As New OleDbCommand(strsql11, conn11)
        myReader11 = cmd11.ExecuteReader
        myReader11.Read()
        TextBoxPrice.Text = myReader11("Price")
        conn11.Close()
        RatatouilleP = TextBoxPrice.Text




        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn11x As New OleDbConnection
        conn11x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn11x.Open()
        Dim strsql11x As String
        Dim myReader11x As OleDbDataReader
        RatatouilleID = 12
        strsql11x = " select Stock from Inventory where IDNUMBER=" + RatatouilleID + ""
        Dim cmd11x As New OleDbCommand(strsql11x, conn11x)
        myReader11x = cmd11x.ExecuteReader
        myReader11x.Read()
        RatatouilleS = myReader11x("Stock")
        conn11x.Close()

        If RatatouilleS > Me.NumericUpDown12.Value Then

            RatatouilleS = RatatouilleS - Me.NumericUpDown12.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionL As OleDbConnection = New OleDbConnection
            myconnectionL.ConnectionString = constring
            myconnectionL.Open()
            command11 = "update Inventory set [Stock]='" & RatatouilleS & "' where[IDNUMBER]=" & RatatouilleID & ""
            Dim cmdA11 As OleDbCommand = New OleDbCommand(command11, myconnectionL)

            Try
                cmdA11.ExecuteNonQuery()
                cmdA11.Dispose()
                myconnectionL.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & RatatouilleS & " of Ratatouille", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If






        ' ----------- Entree ----------- 

        'Beef Wellington
        Dim conn12 As New OleDbConnection
        conn12.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn12.Open()
        Dim strsql12 As String
        Dim myReader12 As OleDbDataReader
        TextBoxID.Text = 13
        strsql12 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd12 As New OleDbCommand(strsql12, conn12)
        myReader12 = cmd12.ExecuteReader
        myReader12.Read()
        TextBoxPrice.Text = myReader12("Price")
        conn12.Close()
        BeefWellP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn12x As New OleDbConnection
        conn12x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn12x.Open()
        Dim strsql12x As String
        Dim myReader12x As OleDbDataReader
        BeefWellID = 13
        strsql12x = " select Stock from Inventory where IDNUMBER=" + BeefWellID + ""
        Dim cmd12x As New OleDbCommand(strsql12x, conn12x)
        myReader12x = cmd12x.ExecuteReader
        myReader12x.Read()
        BeefWellS = myReader12x("Stock")
        conn12x.Close()

        If BeefWellS > Me.NumericUpDown13.Value Then


            BeefWellS = BeefWellS - Me.NumericUpDown13.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionM As OleDbConnection = New OleDbConnection
            myconnectionM.ConnectionString = constring
            myconnectionM.Open()
            command12 = "update Inventory set [Stock]='" & BeefWellS & "' where[IDNUMBER]=" & BeefWellID & ""
            Dim cmdA12 As OleDbCommand = New OleDbCommand(command12, myconnectionM)

            Try
                cmdA12.ExecuteNonQuery()
                cmdA12.Dispose()
                myconnectionM.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & BeefWellS & " of Beef Wellington", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If





        'Rack of Lamb
        Dim conn13 As New OleDbConnection
        conn13.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn13.Open()
        Dim strsql13 As String
        Dim myReader13 As OleDbDataReader
        TextBoxID.Text = 14
        strsql13 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd13 As New OleDbCommand(strsql13, conn13)
        myReader13 = cmd13.ExecuteReader
        myReader13.Read()
        TextBoxPrice.Text = myReader13("Price")
        conn13.Close()
        RackLambP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn13x As New OleDbConnection
        conn13x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn13x.Open()
        Dim strsql13x As String
        Dim myReader13x As OleDbDataReader
        RackLambID = 14
        strsql13x = " select Stock from Inventory where IDNUMBER=" + RackLambID + ""
        Dim cmd13x As New OleDbCommand(strsql13x, conn13x)
        myReader13x = cmd13x.ExecuteReader
        myReader13x.Read()
        RackLambS = myReader13x("Stock")
        conn13x.Close()

        If RackLambS > Me.NumericUpDown14.Value Then

            RackLambS = RackLambS - Me.NumericUpDown14.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionN As OleDbConnection = New OleDbConnection
            myconnectionN.ConnectionString = constring
            myconnectionN.Open()
            command13 = "update Inventory set [Stock]='" & RackLambS & "' where[IDNUMBER]=" & RackLambID & ""
            Dim cmdA13 As OleDbCommand = New OleDbCommand(command13, myconnectionN)

            Try
                cmdA13.ExecuteNonQuery()
                cmdA13.Dispose()
                myconnectionN.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & RackLambS & " of Rack of Lamb", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If





        'Lobster Risotto
        Dim conn15 As New OleDbConnection
        conn15.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn15.Open()
        Dim strsql15 As String
        Dim myReader15 As OleDbDataReader
        TextBoxID.Text = 15
        strsql15 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd15 As New OleDbCommand(strsql15, conn15)
        myReader15 = cmd15.ExecuteReader
        myReader15.Read()
        TextBoxPrice.Text = myReader15("Price")
        conn15.Close()
        LobsterRisottoP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn15x As New OleDbConnection
        conn15x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn15x.Open()
        Dim strsql15x As String
        Dim myReader15x As OleDbDataReader
        LobsterRisottoID = 15
        strsql15x = " select Stock from Inventory where IDNUMBER=" + LobsterRisottoID + ""
        Dim cmd15x As New OleDbCommand(strsql15x, conn15x)
        myReader15x = cmd15x.ExecuteReader
        myReader15x.Read()
        LobsterRisottoS = myReader15x("Stock")
        conn15x.Close()

        If LobsterRisottoS > Me.NumericUpDown15.Value Then

            LobsterRisottoS = LobsterRisottoS - Me.NumericUpDown15.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionP As OleDbConnection = New OleDbConnection
            myconnectionP.ConnectionString = constring
            myconnectionP.Open()
            command15 = "update Inventory set [Stock]='" & LobsterRisottoS & "' where[IDNUMBER]=" & LobsterRisottoID & ""
            Dim cmdA15 As OleDbCommand = New OleDbCommand(command15, myconnectionP)

            Try
                cmdA15.ExecuteNonQuery()
                cmdA15.Dispose()
                myconnectionP.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & LobsterRisottoS & " of Lobster Risotto", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If







        'Seared Scallops
        Dim conn14 As New OleDbConnection
        conn14.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn14.Open()
        Dim strsql14 As String
        Dim myReader14 As OleDbDataReader
        TextBoxID.Text = 16
        strsql14 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd14 As New OleDbCommand(strsql14, conn14)
        myReader14 = cmd14.ExecuteReader
        myReader14.Read()
        TextBoxPrice.Text = myReader14("Price")
        conn14.Close()
        SearedScalP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn14x As New OleDbConnection
        conn14x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn14x.Open()
        Dim strsql14x As String
        Dim myReader14x As OleDbDataReader
        SearedScalID = 16
        strsql14x = " select Stock from Inventory where IDNUMBER=" + SearedScalID + ""
        Dim cmd14x As New OleDbCommand(strsql14x, conn14x)
        myReader14x = cmd14x.ExecuteReader
        myReader14x.Read()
        SearedScalS = myReader14x("Stock")
        conn14x.Close()

        If SearedScalS > Me.NumericUpDown16.Value Then

            SearedScalS = SearedScalS - Me.NumericUpDown16.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionO As OleDbConnection = New OleDbConnection
            myconnectionO.ConnectionString = constring
            myconnectionO.Open()
            command14 = "update Inventory set [Stock]='" & SearedScalS & "' where[IDNUMBER]=" & SearedScalID & ""
            Dim cmdA14 As OleDbCommand = New OleDbCommand(command14, myconnectionO)

            Try
                cmdA14.ExecuteNonQuery()
                cmdA14.Dispose()
                myconnectionO.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & SearedScalS & " of Seared Scallops", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If








        







        ' ----------- Dessert ----------- 

        'Carrot Cake
        Dim conn16 As New OleDbConnection
        conn16.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn16.Open()
        Dim strsql16 As String
        Dim myReader16 As OleDbDataReader
        TextBoxID.Text = 17
        strsql16 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd16 As New OleDbCommand(strsql16, conn16)
        myReader16 = cmd16.ExecuteReader
        myReader16.Read()
        TextBoxPrice.Text = myReader16("Price")
        conn16.Close()
        CarrotCakeP = TextBoxPrice.Text


        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn16x As New OleDbConnection
        conn16x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn16x.Open()
        Dim strsql16x As String
        Dim myReader16x As OleDbDataReader
        CarrotCakeID = 17
        strsql16x = " select Stock from Inventory where IDNUMBER=" + CarrotCakeID + ""
        Dim cmd16x As New OleDbCommand(strsql16x, conn16x)
        myReader16x = cmd16x.ExecuteReader
        myReader16x.Read()
        CarrotCakeS = myReader16x("Stock")
        conn16x.Close()


        If CarrotCakeS > Me.NumericUpDown17.Value Then


            CarrotCakeS = CarrotCakeS - Me.NumericUpDown17.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionQ As OleDbConnection = New OleDbConnection
            myconnectionQ.ConnectionString = constring
            myconnectionQ.Open()
            command16 = "update Inventory set [Stock]='" & CarrotCakeS & "' where[IDNUMBER]=" & CarrotCakeID & ""
            Dim cmdA16 As OleDbCommand = New OleDbCommand(command16, myconnectionQ)

            Try
                cmdA16.ExecuteNonQuery()
                cmdA16.Dispose()
                myconnectionQ.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & CarrotCakeS & " of Carrot Cake", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If





        'Creme Brulee
        Dim conn17 As New OleDbConnection
        conn17.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn17.Open()
        Dim strsql17 As String
        Dim myReader17 As OleDbDataReader
        TextBoxID.Text = 18
        strsql17 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd17 As New OleDbCommand(strsql17, conn17)
        myReader17 = cmd17.ExecuteReader
        myReader17.Read()
        TextBoxPrice.Text = myReader17("Price")
        conn17.Close()
        CremeBruleeP = TextBoxPrice.Text


        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn17x As New OleDbConnection
        conn17x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn17x.Open()
        Dim strsql17x As String
        Dim myReader17x As OleDbDataReader
        CremeBruleeID = 18
        strsql17x = " select Stock from Inventory where IDNUMBER=" + CremeBruleeID + ""
        Dim cmd17x As New OleDbCommand(strsql17x, conn17x)
        myReader17x = cmd17x.ExecuteReader
        myReader17x.Read()
        CremeBruleeS = myReader17x("Stock")
        conn17x.Close()

        If CremeBruleeS > Me.NumericUpDown18.Value Then


            CremeBruleeS = CremeBruleeS - Me.NumericUpDown18.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionR As OleDbConnection = New OleDbConnection
            myconnectionR.ConnectionString = constring
            myconnectionR.Open()
            command17 = "update Inventory set [Stock]='" & CremeBruleeS & "' where[IDNUMBER]=" & CremeBruleeID & ""
            Dim cmdA17 As OleDbCommand = New OleDbCommand(command17, myconnectionR)

            Try
                cmdA17.ExecuteNonQuery()
                cmdA17.Dispose()
                myconnectionR.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & CremeBruleeS & " of Creme Brulee", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If








        'Tiramisu
        Dim conn18 As New OleDbConnection
        conn18.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn18.Open()
        Dim strsql18 As String
        Dim myReader18 As OleDbDataReader
        TextBoxID.Text = 19
        strsql18 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd18 As New OleDbCommand(strsql18, conn18)
        myReader18 = cmd18.ExecuteReader
        myReader18.Read()
        TextBoxPrice.Text = myReader18("Price")
        conn18.Close()
        TiramisuP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn18x As New OleDbConnection
        conn18x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn18x.Open()
        Dim strsql18x As String
        Dim myReader18x As OleDbDataReader
        TiramisuID = 19
        strsql18x = " select Stock from Inventory where IDNUMBER=" + TiramisuID + ""
        Dim cmd18x As New OleDbCommand(strsql18x, conn18x)
        myReader18x = cmd18x.ExecuteReader
        myReader18x.Read()
        TiramisuS = myReader18x("Stock")
        conn18x.Close()

        If TiramisuS > Me.NumericUpDown19.Value Then


            TiramisuS = TiramisuS - Me.NumericUpDown19.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionS As OleDbConnection = New OleDbConnection
            myconnectionS.ConnectionString = constring
            myconnectionS.Open()
            command18 = "update Inventory set [Stock]='" & TiramisuS & "' where[IDNUMBER]=" & TiramisuID & ""
            Dim cmdA18 As OleDbCommand = New OleDbCommand(command18, myconnectionS)

            Try
                cmdA18.ExecuteNonQuery()
                cmdA18.Dispose()
                myconnectionS.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & TiramisuS & " of Tiramisu", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If






        'Truffle Cake
        Dim conn19 As New OleDbConnection
        conn19.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn19.Open()
        Dim strsql19 As String
        Dim myReader19 As OleDbDataReader
        TextBoxID.Text = 20
        strsql19 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd19 As New OleDbCommand(strsql19, conn19)
        myReader19 = cmd19.ExecuteReader
        myReader19.Read()
        TextBoxPrice.Text = myReader19("Price")
        conn19.Close()
        TruffleCakeP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn19x As New OleDbConnection
        conn19x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn19x.Open()
        Dim strsql19x As String
        Dim myReader19x As OleDbDataReader
        TruffleCakeID = 20
        strsql19x = " select Stock from Inventory where IDNUMBER=" + TruffleCakeID + ""
        Dim cmd19x As New OleDbCommand(strsql19x, conn19x)
        myReader19x = cmd19x.ExecuteReader
        myReader19x.Read()
        TruffleCakeS = myReader19x("Stock")
        conn19x.Close()

        If TruffleCakeS > Me.NumericUpDown20.Value Then

            TruffleCakeS = TruffleCakeS - Me.NumericUpDown20.Value


            'Refresh DataGridView
            Timer2.Enabled = True

            'Update the Database
            Dim myconnectionT As OleDbConnection = New OleDbConnection
            myconnectionT.ConnectionString = constring
            myconnectionT.Open()
            command19 = "update Inventory set [Stock]='" & TruffleCakeS & "' where[IDNUMBER]=" & TruffleCakeID & ""
            Dim cmdA19 As OleDbCommand = New OleDbCommand(command19, myconnectionT)

            Try
                cmdA19.ExecuteNonQuery()
                cmdA19.Dispose()
                myconnectionT.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("We only have " & TruffleCakeS & " of Truffle Cake", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Form3Show += 1

        End If








        ' ----------- Drinks ----------- 

        'Water
        Dim conn20 As New OleDbConnection
        conn20.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn20.Open()
        Dim strsql20 As String
        Dim myReader20 As OleDbDataReader
        TextBoxID.Text = 24
        strsql20 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd20 As New OleDbCommand(strsql20, conn20)
        myReader20 = cmd20.ExecuteReader
        myReader20.Read()
        TextBoxPrice.Text = myReader20("Price")
        conn20.Close()
        WaterP = TextBoxPrice.Text







        'Chardonnay
        Dim conn21 As New OleDbConnection
        conn21.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn21.Open()
        Dim strsql21 As String
        Dim myReader21 As OleDbDataReader
        TextBoxID.Text = 21
        strsql21 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd21 As New OleDbCommand(strsql21, conn21)
        myReader21 = cmd21.ExecuteReader
        myReader21.Read()
        TextBoxPrice.Text = myReader21("Price")
        conn21.Close()
        ChardonnayP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn20x As New OleDbConnection
        conn20x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn20x.Open()
        Dim strsql20x As String
        Dim myReader20x As OleDbDataReader
        ChardonnayID = 21
        strsql20x = " select Stock from Inventory where IDNUMBER=" + ChardonnayID + ""
        Dim cmd20x As New OleDbCommand(strsql20x, conn20x)
        myReader20x = cmd20x.ExecuteReader
        myReader20x.Read()
        ChardonnayS = myReader20x("Stock")
        conn20x.Close()



        If RadioButton2.Checked = True Then
            If ChardonnayS > 0 Then
                ChardonnayS = ChardonnayS - 1


                'Refresh DataGridView
                Timer2.Enabled = True

                'Update the Database
                Dim myconnectionU As OleDbConnection = New OleDbConnection
                myconnectionU.ConnectionString = constring
                myconnectionU.Open()
                command20 = "update Inventory set [Stock]='" & ChardonnayS & "' where[IDNUMBER]=" & ChardonnayID & ""
                Dim cmdA20 As OleDbCommand = New OleDbCommand(command20, myconnectionU)

                Try
                    cmdA20.ExecuteNonQuery()
                    cmdA20.Dispose()
                    myconnectionU.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("We dont have Chardonay", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Form3Show += 1

            End If


        End If
        







        'Pinot Grigio
        Dim conn22 As New OleDbConnection
        conn22.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn22.Open()
        Dim strsql22 As String
        Dim myReader22 As OleDbDataReader
        TextBoxID.Text = 22
        strsql22 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd22 As New OleDbCommand(strsql22, conn22)
        myReader22 = cmd22.ExecuteReader
        myReader22.Read()
        TextBoxPrice.Text = myReader22("Price")
        conn22.Close()
        PinotGrigioP = TextBoxPrice.Text


        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn21x As New OleDbConnection
        conn21x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn21x.Open()
        Dim strsql21x As String
        Dim myReader21x As OleDbDataReader
        PinotGrigioID = 22
        strsql21x = " select Stock from Inventory where IDNUMBER=" + PinotGrigioID + ""
        Dim cmd21x As New OleDbCommand(strsql21x, conn21x)
        myReader21x = cmd21x.ExecuteReader
        myReader21x.Read()
        PinotGrigioS = myReader21x("Stock")
        conn21x.Close()



        If RadioButton3.Checked = True Then
            If PinotGrigioS > 0 Then
                PinotGrigioS = PinotGrigioS - 1


                'Refresh DataGridView
                Timer2.Enabled = True

                'Update the Database
                Dim myconnectionV As OleDbConnection = New OleDbConnection
                myconnectionV.ConnectionString = constring
                myconnectionV.Open()
                command21 = "update Inventory set [Stock]='" & PinotGrigioS & "' where[IDNUMBER]=" & PinotGrigioID & ""
                Dim cmdA21 As OleDbCommand = New OleDbCommand(command21, myconnectionV)

                Try
                    cmdA21.ExecuteNonQuery()
                    cmdA21.Dispose()
                    myconnectionV.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("We dont have Pinot Grigio", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Form3Show += 1

            End If

        

        End If




        'Zinfandel
        Dim conn23 As New OleDbConnection
        conn23.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn23.Open()
        Dim strsql23 As String
        Dim myReader23 As OleDbDataReader
        TextBoxID.Text = 23
        strsql23 = " select Price from Inventory where IDNUMBER=" + TextBoxID.Text + ""
        Dim cmd23 As New OleDbCommand(strsql23, conn23)
        myReader23 = cmd23.ExecuteReader
        myReader23.Read()
        TextBoxPrice.Text = myReader23("Price")
        conn23.Close()
        ZinfandelP = TextBoxPrice.Text



        'Read Stock from Database and deduct the NumericUpDown Value
        Dim conn22x As New OleDbConnection
        conn22x.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb")
        conn22x.Open()
        Dim strsql22x As String
        Dim myReader22x As OleDbDataReader
        ZinfandelID = 23
        strsql22x = " select Stock from Inventory where IDNUMBER=" + ZinfandelID + ""
        Dim cmd22x As New OleDbCommand(strsql22x, conn22x)
        myReader22x = cmd22x.ExecuteReader
        myReader22x.Read()
        ZinfandelS = myReader22x("Stock")
        conn22x.Close()





        If RadioButton4.Checked = True Then

            If ZinfandelS > 0 Then

                ZinfandelS = ZinfandelS - 1


                'Refresh DataGridView
                Timer2.Enabled = True

                'Update the Database
                Dim myconnectionW As OleDbConnection = New OleDbConnection
                myconnectionW.ConnectionString = constring
                myconnectionW.Open()
                command22 = "update Inventory set [Stock]='" & ZinfandelS & "' where[IDNUMBER]=" & ZinfandelID & ""
                Dim cmdA22 As OleDbCommand = New OleDbCommand(command22, myconnectionW)

                Try
                    cmdA22.ExecuteNonQuery()
                    cmdA22.Dispose()
                    myconnectionW.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("We dont have Zinfandel", " HK - Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Form3Show += 1

            End If
        

        End If







        'Check if the Table is Selected
        If ComboBoxTables.Text = "Select Table" Then
            MsgBox("Please Select Table ")
        Else


            '---------- Print Orders to Receipt in Form3

            'Hors
            If NumericUpDown1.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown1.Value & "  x  Bruschetta" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown1.Value * BruschettaP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown1.Value * BruschettaP)
            End If

            If NumericUpDown2.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown2.Value & "  x  Caviar" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown2.Value * CaviarP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown2.Value * CaviarP)
            End If

            If NumericUpDown3.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown3.Value & "  x  Dumplings" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown3.Value * DumplingsP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown3.Value * DumplingsP)
            End If

            If NumericUpDown4.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown4.Value & "  x  Beef Tartare" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown4.Value * BeefTartareP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown4.Value * BeefTartareP)
            End If


            'Appetizer
            If NumericUpDown5.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown5.Value & "  x  Crab Cake" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown5.Value * CrabCakeP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown5.Value * CrabCakeP)
            End If

            If NumericUpDown6.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown6.Value & "  x  Buffalo Wings" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown6.Value * BuffaloWingsP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown6.Value * BuffaloWingsP)
            End If

            If NumericUpDown7.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown7.Value & "  x  Deviled Eggs" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown7.Value * DeviledEggsP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown7.Value * DeviledEggsP)
            End If

            If NumericUpDown8.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown8.Value & "  x  Prawn Cocktail" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown8.Value * PrawnCocktailP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown8.Value * PrawnCocktailP)
            End If


            'Salad
            If NumericUpDown9.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown9.Value & "  x  Caesar Salad" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & " -  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown9.Value * CaesarSaladP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown9.Value * CaesarSaladP)
            End If

            If NumericUpDown10.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown10.Value & "  x  Coleslaw" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & " -  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown10.Value * ColeslawP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown10.Value * ColeslawP)
            End If

            If NumericUpDown11.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown11.Value & "  x  Olivier Salad" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown11.Value * OlivierSaladP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown11.Value * OlivierSaladP)
            End If

            If NumericUpDown12.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown12.Value & "  x  Ratatouille " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown12.Value * RatatouilleP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown12.Value * RatatouilleP)
            End If

            'Entree
            If NumericUpDown13.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown13.Value & "  x  Beef Wellington" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown13.Value * BeefWellP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown13.Value * BeefWellP)
            End If

            If NumericUpDown14.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown14.Value & "  x  Rack of Lamb" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown14.Value * 30) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown14.Value * RackLambP)
            End If

            If NumericUpDown15.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown15.Value & "  x  Lobster Risotto " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown15.Value * LobsterRisottoP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown15.Value * LobsterRisottoP)
            End If

            If NumericUpDown16.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown16.Value & "  x  Seared Scallops" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown16.Value * SearedScalP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown16.Value * SearedScalP)
            End If


            'Dessert
            If NumericUpDown17.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown17.Value & "  x  Carrot Cake" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown17.Value * CarrotCakeP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown17.Value * CarrotCakeP)
            End If

            If NumericUpDown18.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown18.Value & "  x  Creme Brulee" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown18.Value * CremeBruleeP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown18.Value * CremeBruleeP)
            End If

            If NumericUpDown19.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown19.Value & "  x  Tiramisu" & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown19.Value * TiramisuP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown19.Value * TiramisuP)
            End If

            If NumericUpDown20.Value > 0 Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & Me.NumericUpDown20.Value & "  x  Truffle Cake " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & (Me.NumericUpDown20.Value * TruffleCakeP) & vbNewLine
                subTotal = subTotal + (Me.NumericUpDown20.Value * TruffleCakeP)
            End If


            'Drinks
            If RadioButton1.Checked = True Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & "        Water " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & WaterP & vbNewLine
                subTotal = subTotal + 0
            End If

            If RadioButton2.Checked = True Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & "        Chardonnay " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & ChardonnayP & vbNewLine
                subTotal = subTotal + ChardonnayP
            End If

            If RadioButton3.Checked = True Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & "        Pinot Grigio " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & PinotGrigioP & vbNewLine
                subTotal = subTotal + PinotGrigioP
            End If

            If RadioButton4.Checked = True Then
                Form3.TextBox1.Text = Form3.TextBox1.Text & "        Zinfandel " & vbNewLine
                Form3.TextBox2.Text = Form3.TextBox2.Text & "-  -  -  -  -  -  -  -  -  -  -  -  -         " & ZinfandelP & vbNewLine
                subTotal = subTotal + ZinfandelP
            End If

            'Show Receipt
            If Form3Show = 0 Then
                Form3.Show()
            End If
            Form3Show = 0

        End If



        'Reset all NumericUpDown, RadioButton and Combobox

        NumericUpDown1.Value = 0 : NumericUpDown2.Value = 0 : NumericUpDown3.Value = 0 : NumericUpDown4.Value = 0 : NumericUpDown5.Value = 0
        NumericUpDown6.Value = 0 : NumericUpDown7.Value = 0 : NumericUpDown8.Value = 0 : NumericUpDown9.Value = 0 : NumericUpDown10.Value = 0
        NumericUpDown11.Value = 0 : NumericUpDown12.Value = 0 : NumericUpDown13.Value = 0 : NumericUpDown14.Value = 0 : NumericUpDown15.Value = 0
        NumericUpDown16.Value = 0 : NumericUpDown17.Value = 0 : NumericUpDown18.Value = 0 : NumericUpDown19.Value = 0 : NumericUpDown20.Value = 0
        RadioButton1.Checked = False : RadioButton2.Checked = False : RadioButton3.Checked = False : RadioButton4.Checked = False
        ComboBoxTables.Text = "Select Table"

    End Sub


    'Exit Button
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub


    'Minimize Button
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    'Update Stocks
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'Refresh the DataGridView
        Timer2.Enabled = True

        'Update the Database
        myconnection.ConnectionString = constring
        myconnection.Open()
        command = "update Inventory set [Stock]='" & TextBox2.Text & "' where[IDNUMBER]=" & TextBox1.Text & ""
        Dim cmd1 As OleDbCommand = New OleDbCommand(command, myconnection)

        Try
            cmd1.ExecuteNonQuery()
            cmd1.Dispose()
            myconnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        MessageBox.Show("Update Successful", " HK - Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    'Update Price
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        'Only the Owner change the Price
        If userPosition.Text = "Owner" Or userPosition.Text = "Developer" Then

            'Refresh the DataGridView
            Timer2.Enabled = True

            myconnection.ConnectionString = constring
            myconnection.Open()
            command = "update Inventory set [Price]='" & TextBox5.Text & "' where[IDNUMBER]=" & TextBox3.Text & ""
            Dim cmD As OleDbCommand = New OleDbCommand(command, myconnection)

            Try
                cmD.ExecuteNonQuery()
                cmD.Dispose()
                myconnection.Close()
                TextBox3.Clear()
                TextBox5.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MessageBox.Show("Update Successful", " HK - Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Only Owner can change Price", " HK - Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand)

        End If

    End Sub

   
  
    'Add Account
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        'Database Provider
        myconnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb"
        myconnection1.Open()

        'Add Values to Database
        Dim Cmd As OleDbCommand = New OleDbCommand("Insert into Accounts([Name],[Password],[Position]) Values(?,?,?)", myconnection1)
        Cmd.Parameters.Add(New OleDbParameter("Name", CType(TextBoxName.Text, String)))
        Cmd.Parameters.Add(New OleDbParameter("Password", CType(TextBoxPass.Text, String)))
        Cmd.Parameters.Add(New OleDbParameter("Position", CType(TextBoxPosition.Text, String)))


        Try
            Cmd.ExecuteNonQuery()
            Cmd.Dispose()
            myconnection1.Close()
            TextBoxName.Clear()
            TextBoxPass.Clear()
            TextBoxPosition.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Refresh the DataGridView
        Timer3.Enabled = True


    End Sub


    'Timer 3
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        BindGridAccounts()
    End Sub


    'Delete Accounts
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        'Database Provider
        myconnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HKDatabase.mdb"
        myconnection1.Open()

        'Delete accounts using there ID Number
        Dim str As String
        str = "DELETE from [Accounts] Where [IDNUMBER] = " & TextBoxIDNUMBER.Text & ""
        Dim Cmd As OleDbCommand = New OleDbCommand(str, myconnection1)

        Try
            Cmd.ExecuteNonQuery()
            Cmd.Dispose()
            myconnection1.Close()
            TextBoxIDNUMBER.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Refresh the DataGridView
        Timer3.Enabled = True

    End Sub


   
End Class