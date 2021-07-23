Public Class ucopberita
    Private search As New Search
    Private check As New Check
    Public ke As Integer = 0
    Private a As New childalat
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prevberita()
    End Sub

    Private Sub userberita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadawal()
    End Sub
    Private Sub loadawal()
        RichTextBox1.ReadOnly = True
        Try
            a.tabel = New DataTable
            a.tabel = search.searchfoto()
            Label4.Text = a.tabel.Rows(ke).Item(1)
            RichTextBox1.Text = a.tabel.Rows(ke).Item(2)
            If a.tabel.Rows(ke).Item(3) <> "OpenFileDialog1" Then
                adapicture()
            Else
                nopicture()
            End If
            PictureBox1.Image = Image.FromFile(a.tabel.Rows(ke).Item(3))
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As Exception
            If search.bool = False Then
                Button1.Hide()
                Button2.Hide()
                Label5.Hide()
                Label6.Hide()
                RichTextBox1.Hide()
                Label4.Hide()
                Label7.Hide()
                PictureBox1.Hide()
            End If
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nextberita()
    End Sub
    Private Sub nextberita()
        Try
            ke += 1
            If ke < check.checkcount("berita") Then
                adapicture()
                Dim a As New DataTable
                a = search.searchfoto()
                Label4.Text = a.Rows(ke).Item(1)
                RichTextBox1.Text = a.Rows(ke).Item(2)
                PictureBox1.Image = Image.FromFile(a.Rows(ke).Item(3))
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                Button1.Show()
                Label5.Show()
            Else
                ke -= 1
                MsgBox("Tidak ada berita lagi", MsgBoxStyle.Information)
                Button2.Hide()
                Label6.Hide()
            End If
        Catch ex As Exception
            nopicture()
        End Try

    End Sub
    Private Sub prevberita()
        Try
            ke -= 1
            If ke >= 0 Then
                adapicture()
                Dim a As New DataTable
                a = search.searchfoto()
                Label4.Text = a.Rows(ke).Item(1)
                RichTextBox1.Text = a.Rows(ke).Item(2)
                PictureBox1.Image = Image.FromFile(a.Rows(ke).Item(3))
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                Button2.Show()
                Label6.Show()
            Else
                ke += 1
                MsgBox("Ini adalah berita terbaru", MsgBoxStyle.Information)
                Button1.Hide()
                Label5.Hide()
            End If
        Catch ex As Exception
            nopicture()
        End Try
    End Sub
    Private Sub adapicture()
        '505; 347
        '501; 383
        Label8.Hide()
        Label4.Left = 505
        Label4.Top = 347
        Label4.BringToFront()
        Label7.Left = 501
        Label7.Top = 383
        Label7.BringToFront()
        PictureBox1.Show()
    End Sub

    Private Sub nopicture()
        '266; 321
        '295; 354
        Label8.Show()
        Label4.Left = 266
        Label4.Top = 321
        Label4.BringToFront()
        Label7.Left = 275
        Label7.Top = 354
        Label7.BringToFront()
    End Sub
End Class