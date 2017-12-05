Imports System.Data.SqlClient

Public Class BackupRestoreDatabaseForm

    Dim con, con1 As SqlConnection
    Dim cmd As SqlCommand
    Dim dread As SqlDataReader
    Dim RestoreDatabase As Byte = 0

    Private Sub BackupRestoreDatabaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalEmployeeIsType < GlobalAdministrator Then
            cmdrestore.Enabled = False
        Else
            cmdrestore.Enabled = True
        End If

        'server(".")
        server(".\sqlexpress")
        If GlobalFirmDetailRow.SQLBackupDefaultDirectory <> "" Then
            SaveFileDialog1.InitialDirectory = GlobalFirmDetailRow.SQLBackupDefaultDirectory
            OpenFileDialog1.InitialDirectory = SaveFileDialog1.InitialDirectory
        End If
    End Sub
    Sub server(ByVal str As String)
        con = New SqlConnection("Data Source=" & str & ";Database=Master;integrated security=SSPI;")
        con.Open()
        cmd = New SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con)
        dread = cmd.ExecuteReader
        While dread.Read
            cmbserver.Items.Add(dread(2))
        End While
        dread.Close()
        cmbserver.SelectedIndex = 0
    End Sub
    Sub connection()
        Dim Selection As Integer = 0
        Dim SelectionLoop As Integer = 0
        con = New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Database=Master;integrated security=SSPI;")
        con.Open()
        cmbdatabase.Items.Clear()
        cmd = New SqlCommand("select * from sysdatabases", con)
        dread = cmd.ExecuteReader
        While dread.Read
            cmbdatabase.Items.Add(dread(0))
            cmbdatabase.SelectedIndex = SelectionLoop
            If cmbdatabase.Text = "CM" Then Selection = cmbdatabase.SelectedIndex
            SelectionLoop += 1
        End While
        dread.Close()
        cmbdatabase.SelectedIndex = Selection
    End Sub

    Private Sub cmbserver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbserver.SelectedIndexChanged
        connection()
    End Sub
    Sub query(ByVal que As String)
        On Error Resume Next
        cmd = New SqlCommand(que, con)
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            'MsgBox("Successfully Done")
            If RestoreDatabase = 0 Then
                OpenFileDialog1.ShowDialog()
            End If
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub
    Sub blank(ByVal str As String)
        If cmbserver.Text = "" Or cmbdatabase.Text = "" Then
            MsgBox("Server Name & Database Blank Field")
            Exit Sub
        Else
            If str = "backup" Then
                SaveFileDialog1.FileName = cmbdatabase.Text
                SaveFileDialog1.ShowDialog()
                Timer1.Enabled = True
                ProgressBar1.Visible = True
                Dim BackupFileName As String
                BackupFileName = SaveFileDialog1.FileName
                query("backup database " & cmbdatabase.Text & " to disk='" & BackupFileName & "'")
            ElseIf str = "restore" Then
                OpenFileDialog1.ShowDialog()
                Timer1.Enabled = True
                ProgressBar1.Visible = True

                'query("RESTORE DATABASE " & cmbdatabase.Text & " FROM disk='" & OpenFileDialog1.FileName & "'")

                Dim DataFolder As String = OpenFileDialog1.FileName
                Dim FirstCharacter As Integer = DataFolder.IndexOf("Backup\")
                DataFolder = Mid(DataFolder, 1, FirstCharacter) & "DATA\" & cmbdatabase.Text

                query("ALTER DATABASE [" & cmbdatabase.Text & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
                query("RESTORE DATABASE [" & cmbdatabase.Text & "] FROM  DISK = '" & OpenFileDialog1.FileName & "' WITH  FILE = 1,  MOVE '" & cmbdatabase.Text & "' TO '" & DataFolder & ".mdf',  MOVE '" & cmbdatabase.Text & "_log' TO '" & DataFolder & "_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5")
                query("ALTER DATABASE [" & cmbdatabase.Text & "] SET MULTI_USER")

                ' This just does not work ?

                'Dim SingleUserMode As String = """ALTER DATABASE [" & cmbdatabase.Text & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"""
                'Dim MultiUserMode As String = """ALTER DATABASE [" & cmbdatabase.Text & "] SET MULTI_USER"""
                'Dim RestoreDatabase As String = """RESTORE DATABASE [" & cmbdatabase.Text & "] FROM  DISK = '" & OpenFileDialog1.FileName & "' WITH  FILE = 1,  MOVE '" & cmbdatabase.Text & "' TO '" & DataFolder & ".mdf',  MOVE '" & cmbdatabase.Text & "_log' TO '" & DataFolder & "_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"""
                'query(SingleUserMode)
                'query(RestoreDatabase)
                'query(MultiUserMode)

            End If
        End If
    End Sub
    Private Sub cmbbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbackup.Click
        RestoreDatabase = 0
        blank("backup")
    End Sub

    Private Sub cmdrestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrestore.Click
        RestoreDatabase = 1
        blank("restore")
        MsgBox("Application will now Close and Exit" & vbCrLf & vbCrLf & "Login again to see changes")
        Application.Exit()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

End Class