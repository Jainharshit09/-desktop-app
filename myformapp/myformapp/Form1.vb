Public Class Form1
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim textBox As New TextBox()
        textBox.Text = "Slidely Task 2 - Slidely Form App"
        textBox.Multiline = True
        textBox.ReadOnly = True
        textBox.Height = 100
        textBox.Width = 578
        textBox.Location = New Point((Me.ClientSize.Width - textBox.Width) / 2, 10)
        textBox.Anchor = AnchorStyles.None
        textBox.Font = New Font("Arial", 17, FontStyle.Bold)

        Me.Controls.Add(textBox)
        textBox.TextAlign = HorizontalAlignment.Center
        textBox.Multiline = True
        textBox.BorderStyle = BorderStyle.None
        Me.Controls.Add(textBox)


        Dim btnViewSubmissions As New Button()
        btnViewSubmissions.Text = "VIEW SUBMISSIONS (CTRL + V)"
        btnViewSubmissions.Width = 300
        btnViewSubmissions.Height = 50
        btnViewSubmissions.BackColor = Color.GreenYellow
        btnViewSubmissions.Location = New Point((Me.ClientSize.Width - btnViewSubmissions.Width) / 2, 200)
        AddHandler btnViewSubmissions.Click, AddressOf Me.BtnViewSubmissions_Click
        Me.Controls.Add(btnViewSubmissions)

        Dim btnCreateSubmission As New Button()
        btnCreateSubmission.Text = "CREATE NEW SUBMISSION (CTRL + N)"
        btnCreateSubmission.Width = 300
        btnCreateSubmission.Height = 50
        btnCreateSubmission.BackColor = Color.LightBlue
        btnCreateSubmission.Location = New Point((Me.ClientSize.Width - btnCreateSubmission.Width) / 2, 300)
        AddHandler btnCreateSubmission.Click, AddressOf Me.BtnCreateSubmission_Click
        Me.Controls.Add(btnCreateSubmission)
    End Sub

    Private Sub BtnViewSubmissions_Click(sender As Object, e As EventArgs)
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.ShowDialog() ' Use ShowDialog to make it a modal dialog
    End Sub

    Private Sub BtnCreateSubmission_Click(sender As Object, e As EventArgs)
        Dim createForm As New CreateSubmissionForm()
        createForm.ShowDialog() ' Use ShowDialog to make it a modal dialog
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.V) Then
            BtnViewSubmissions_Click(Nothing, Nothing)
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            BtnCreateSubmission_Click(Nothing, Nothing)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
