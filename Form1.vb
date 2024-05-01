Imports Capstone_Project.Form3

Public Class Form1
    Private imageIndex As Integer = 0
    Private WithEvents Timer1 As New Timer
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Defines the rectangle to fill half of the form's area with a color of our choosing
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height * 2 \ 3)

        ' Fill the rectangle with the desired color
        Using brush As New SolidBrush(Color.HotPink) ' Changes the color to HotPink
            e.Graphics.FillRectangle(brush, rect)
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show the apple and android logos on the supposed download buttons right as the form loads
        ShowImage()
    End Sub

    Private Sub ShowImage() ' Shows the apple and android logos on the supposed download buttons

        Button1.Image = ImageList1.Images("apple-logo4.png")
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.TextImageRelation = TextImageRelation.ImageBeforeText

        ' Sets the image and properties for the android button
        Button2.Image = ImageList1.Images("android-logo2.png")
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.TextImageRelation = TextImageRelation.ImageBeforeText
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click ' Clicking the Browse profile button will display form2 and will hide form1
        Dim box = New Form2()
        box.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click ' Clicking the dog profile icon will display form3 and will hide form1
        Dim box = New Form3()
        box.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub
End Class