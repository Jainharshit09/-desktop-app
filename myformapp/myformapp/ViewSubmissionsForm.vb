Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        submissions = Await GetSubmissions()
        Dim textBox As New TextBox()
        textBox.Text = "Harshit Jain, Slidely Task 2 - View Submissions"
        textBox.TextAlign = HorizontalAlignment.Center
        textBox.ReadOnly = True
        textBox.Multiline = True
        textBox.Height = 40
        textBox.Width = 578
        textBox.Location = New Point((Me.ClientSize.Width - textBox.Width) / 2, 10)
        Me.Controls.Add(textBox)
        CreateLabelAndTextBox("Name", 60)
        CreateLabelAndTextBox("Email", 110)
        CreateLabelAndTextBox("Phone Num", 160)
        CreateLabelAndTextBox("GitHub Link For Task 2", 210)
        CreateLabelAndTextBox("Stopwatch time", 260)
        Dim btnPrev As New Button()
        btnPrev.Text = "Prev (CTRL + P)"
        btnPrev.Width = 300
        btnPrev.Height = 50
        btnPrev.BackColor = Color.PaleGoldenrod
        btnPrev.Location = New Point(30, 370)
        AddHandler btnPrev.Click, AddressOf Me.BtnPrevClick
        Me.Controls.Add(btnPrev)

        Dim btnNxt As New Button()
        btnNxt.Text = "Next (CTRL + N)"
        btnNxt.Width = 300
        btnNxt.Height = 50
        btnNxt.BackColor = Color.BlueViolet
        btnNxt.Location = New Point(480, 370)
        AddHandler btnNxt.Click, AddressOf Me.BtnNxt_Click
        Me.Controls.Add(btnNxt)
        If submissions.Count > 0 Then
            LoadSubmission(currentIndex)
        Else
            MessageBox.Show("No submissions found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CreateLabelAndTextBox(labelText As String, top As Integer)
        Dim label As New Label()
        label.Text = labelText
        label.Location = New Point(50, top)
        Me.Controls.Add(label)

        Dim textBox As New TextBox()
        textBox.Name = "txt" & labelText.Replace(" ", "")
        textBox.ReadOnly = True
        textBox.Width = 400
        textBox.Location = New Point(200, top)
        Me.Controls.Add(textBox)
    End Sub

    Private Sub LoadSubmission(index As Integer)
        If index >= 0 AndAlso index < submissions.Count Then
            Dim submission = submissions(index)
            Me.Controls("txtName").Text = submission.Name
            Me.Controls("txtEmail").Text = submission.Email
            Me.Controls("txtPhoneNum").Text = submission.phone
            Me.Controls("txtGitHubLinkForTask2").Text = submission.github_link
            Me.Controls("txtStopwatchTime").Text = submission.stopwatch_time
        End If
    End Sub
    Private Sub BtnPrevClick(sender As Object, e As EventArgs)
        ' Handle previous button click
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission(currentIndex)
        End If
    End Sub
    Private Sub BtnNxt_Click(sender As Object, e As EventArgs)
        ' Handle next button click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            LoadSubmission(currentIndex)
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            ' Ctrl + P for previous
            If currentIndex > 0 Then
                currentIndex -= 1
                LoadSubmission(currentIndex)
            End If
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            ' Ctrl + N for next
            If currentIndex < submissions.Count - 1 Then
                currentIndex += 1
                LoadSubmission(currentIndex)
            End If
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Async Function GetSubmissions() As Task(Of List(Of Submission))
        Dim submissions As List(Of Submission) = Nothing
        Using client As New HttpClient()
            Try
                Dim response = Await client.GetAsync("http://localhost:8000/readAll")

                If response.IsSuccessStatusCode Then
                    Dim submissionsJson = Await response.Content.ReadAsStringAsync()
                    submissions = JsonConvert.DeserializeObject(Of List(Of Submission))(submissionsJson)
                Else
                    MessageBox.Show($"Error fetching submissions: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error fetching submissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return submissions
    End Function
End Class
