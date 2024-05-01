Public Class Form3


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Clicking the Home  button will return us to form1 and will hide form3
        Dim box = New Form1()
        box.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Creates and configures an OpenFileDialog
        Dim openFileDialog1 As New OpenFileDialog()

        ' Set the title and filters for the OpenFileDialog
        openFileDialog1.Title = "Select Image"
        openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*" 'Shows the allowed files format that can be uploaded

        ' Show the OpenFileDialog
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Gets the selected file name
            Dim selectedFileName As String = openFileDialog1.FileName


            ' Stores the selected file path globally in Module1.uploadedImagePath, This would allow us to navigate through different forms without the saved images resetting everytime we click away.
            Module1.uploadedImagePath = selectedFileName

            ' Saves the uploaded image path to a text file
            System.IO.File.WriteAllText("uploadedImagePath.txt", selectedFileName)


            ' displays the image in a PictureBox of our choosing on this form
            PictureBox1.ImageLocation = selectedFileName
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' This would allow the picture that was saved in the previous session to be automatically re-uploaded right when the form3 loads, so the user doesn't have to re-upload the image again. This also apply for the details such as name and description.
        ' Load the uploaded image path from the text file
        If System.IO.File.Exists("uploadedImagePath.txt") Then
            Module1.uploadedImagePath = System.IO.File.ReadAllText("uploadedImagePath.txt")

            ' Set the image location of PictureBox1 to the uploaded image path
            PictureBox1.ImageLocation = Module1.uploadedImagePath
        End If

        If System.IO.File.Exists("dogInfo.txt") Then
            Dim lines As String() = System.IO.File.ReadAllLines("dogInfo.txt")
            If lines.Length >= 3 Then
                Label2.Text = lines(0)
                Label3.Text = lines(1)
                Label4.Text = lines(2)
            End If
        End If
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim inputName As String = InputBox("Enter name:", "Edit Name")


        ' Checks if the user clicked Cancel
        If String.IsNullOrWhiteSpace(inputName) Then
            Return ' Exit the event handler if input is empty (user clicked Cancel)
        End If

        While Not System.Text.RegularExpressions.Regex.IsMatch(inputName, "^[a-zA-Z\s]+$") ' input validation check for name
            MessageBox.Show("Please enter a valid name.", "Invalid Input", MessageBoxButtons.OK)
            inputName = InputBox("Enter name:", "Edit Name")

        End While

        Dim inputAge As String = InputBox("Enter age:", "Edit Age")

        ' Continue prompting for age until a valid age is entered
        Dim validAge As Boolean = False
        Dim age As Integer


        ' Check if the user clicked Cancel
        If String.IsNullOrWhiteSpace(inputAge) Then
            Return ' Exit the event handler if input is empty (user clicked Cancel)
        End If


        While Not validAge
            If Integer.TryParse(inputAge, age) AndAlso age > 0 Then ' input validation check for age
                validAge = True
            Else
                MessageBox.Show("Please enter a valid number for age.", "Invalid Input", MessageBoxButtons.OK)
                inputAge = InputBox("Enter age:", "Edit Age")

            End If
        End While

        Dim inputDescription As String = InputBox("Enter description:", "Edit Description")


        ' Check if the user clicked Cancel
        If String.IsNullOrWhiteSpace(inputDescription) Then
            MessageBox.Show("Providing a description can make it easier to find your profile.", "Invalid Input", MessageBoxButtons.OK)
            Return ' Exit the event handler if input is empty (user clicked Cancel)
        End If




        ' Validation for description: Check if inputDescription is empty
        If String.IsNullOrWhiteSpace(inputDescription) Then
            MessageBox.Show("Providing a description can make it easier to find your profile.", "Invalid Input", MessageBoxButtons.OK)
            Return
        End If



        ' Update Label2, Label3, and Label4 with the entered information
        Label2.Text = inputName
        Label3.Text = inputDescription
        Label4.Text = inputAge


        ' Save the entered text to a text file, so the user doesn't have to enter their details everytime they access the program
        System.IO.File.WriteAllText("dogInfo.txt", $"{inputName}{Environment.NewLine}{inputDescription}{Environment.NewLine}{inputAge}")


    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub

End Class
