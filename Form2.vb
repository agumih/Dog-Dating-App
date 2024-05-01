Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Clicking the Home  button will return us to form1 and will hide form2
        Dim box = New Form1()
        box.Show()
        Me.Hide()
    End Sub


    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        ' Changes the cursor to a hand when hovering over the button
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        ' Restores the default cursor when leaving the button
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ' Calculates the height of the blue area 
        Dim blueHeight As Integer = Panel1.Height * 10 \ 10 ' covers the whole panel with our chosen color
        ' Defines the rectangle for the blue area
        Dim blueRect As New Rectangle(0, Panel1.Height - blueHeight, Panel1.Width, blueHeight)


        Using blueBrush As New SolidBrush(Color.Pink) ' Changes to the desired color, pink in this case
            e.Graphics.FillRectangle(blueBrush, blueRect)
        End Using
    End Sub

End Class