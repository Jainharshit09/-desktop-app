Imports System.Net.Http
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Private stopwatch As Stopwatch = New Stopwatch()
    Private WithEvents timer As Timer = New Timer()

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim textBox As New TextBox()
        textBox.Text = "Slidely Task 2 - Create New Submission"
        textBox.TextAlign = HorizontalAlignment.Center
        textBox.ReadOnly = True
        textBox.Multiline = True
        textBox.Height = 40
        textBox.Width = 578
        textBox.Location = New Point((Me.ClientSize.Width - textBox.Width) / 2, 10)
        Me.Controls.Add(textBox)

        CreateLabelAndTextBox("Name", 60, editable:=True)
        CreateLabelAndTextBox("Email", 110, editable:=True)
        CreateLabelAndTextBox("Phone Number", 160, editable:=True)
        CreateLabelAndTextBox("GitHub Link For Task 2", 210, editable:=True)
        CreateLabelAndTextBox("Stopwatch time", 260, editable:=False)

        Dim btnStopwatch As New Button()
        btnStopwatch.Text = "Start/Stop"
        btnStopwatch.Width = 200
        btnStopwatch.Height = 50
        btnStopwatch.BackColor = Color.CadetBlue
        btnStopwatch.Location = New Point(15, 310)
        AddHandler btnStopwatch.Click, AddressOf Me.BtnStopwatch_Click
        Me.Controls.Add(btnStopwatch)

        Dim btnSubmit As New Button()
        btnSubmit.Text = "Submit (CTRL + S)"
        btnSubmit.Width = 300
        btnSubmit.Height = 50
        btnSubmit.BackColor = Color.Green
        btnSubmit.Location = New Point((Me.ClientSize.Width - btnSubmit.Width) / 2, 370)
        AddHandler btnSubmit.Click, AddressOf Me.BtnSubmit_Click
        Me.Controls.Add(btnSubmit)

        ' Start the stopwatch automatically when the form loads
        StartStopwatch()

        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Me.Timer_Tick
    End Sub

    Private Sub StartStopwatch()
        stopwatch.Start()
        timer.Start()
    End Sub

    Private Sub BtnStopwatch_Click(sender As Object, e As EventArgs)
        ToggleStopwatch()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        Dim timeSpan = stopwatch.Elapsed
        Dim timeFormatted = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds)
        Dim stopwatchTextBox As TextBox = TryCast(Me.Controls("txtStopwatchTime"), TextBox)
        If stopwatchTextBox IsNot Nothing Then
            stopwatchTextBox.Text = timeFormatted
        End If
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        ' Gather data from form fields
        Dim name As String = GetTextBoxText("Name")
        Dim email As String = GetTextBoxText("Email")
        Dim phoneNum As String = GetTextBoxText("Phone Number")
        Dim gitHubLink As String = GetTextBoxText("GitHub Link For Task 2")
        Dim stopwatchTime As String = GetTextBoxText("Stopwatch time")

        ' Create a new Submission object
        Dim submission As New Submission With {
            .name = name,
            .email = email,
            .phone = phoneNum,
            .github_link = gitHubLink,
            .stopwatch_time = stopwatchTime
        }

        ' Implement API call to submit the form data
        SubmitToBackend(submission)
    End Sub

    Private Function GetTextBoxText(textBoxName As String) As String
        Dim textBox As TextBox = TryCast(Me.Controls("txt" & textBoxName.Replace(" ", "")), TextBox)
        If textBox IsNot Nothing Then
            Return textBox.Text
        Else
            Return ""
        End If
    End Function

    Private Sub ToggleStopwatch()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
    End Sub

    Private Async Sub SubmitToBackend(submission As Submission)
        Dim json = JsonConvert.SerializeObject(submission)
        Dim content = New StringContent(json, System.Text.Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Try
                Dim response = Await client.PostAsync("http://localhost:8000/submit", content)
                response.EnsureSuccessStatusCode()
                MessageBox.Show("Submission successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close() ' Close the form after successful submission
            Catch ex As Exception
                MessageBox.Show($"Error submitting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then
            BtnSubmit_Click(Nothing, Nothing)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub CreateLabelAndTextBox(labelText As String, top As Integer, editable As Boolean)
        Dim label As New Label()
        label.Text = labelText
        label.Location = New Point(50, top)
        Me.Controls.Add(label)

        Dim textBox As New TextBox()
        textBox.Name = "txt" & labelText.Replace(" ", "")
        textBox.Width = 400
        textBox.Location = New Point(200, top)
        textBox.ReadOnly = Not editable
        Me.Controls.Add(textBox)
    End Sub
End Class

Public Class Submission
    Public Property name As String
    Public Property email As String
    Public Property phone As String
    Public Property github_link As String
    Public Property stopwatch_time As String
End Class
