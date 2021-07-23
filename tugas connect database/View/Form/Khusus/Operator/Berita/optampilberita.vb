Public Class optampilberita
    Private _kode As String
    Private search As New Search
    Private check As New Check
    Private a As New childalat
    Private delete As New Delete
    Public ke As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prevberita()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        admenu.Show()
    End Sub

    Private Sub userberita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadberita()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nextberita()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim input As New opinputoreditberita("edit", _kode)
        input.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim input As New opinputoreditberita("tambah", _kode)
        input.ShowDialog()
    End Sub
    Private Sub nextberita()
        Try
            ke += 1
            If ke < check.checkcount("berita") Then
                adapicture()
                Dim a As New DataTable
                Button1.Show()
                Label5.Show()
                a = search.searchfoto()
                _kode = a.Rows(ke).Item(0)
                Label4.Text = a.Rows(ke).Item(1)
                RichTextBox1.Text = a.Rows(ke).Item(2)
                PictureBox1.Image = Image.FromFile(a.Rows(ke).Item(3))
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
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
    Private Sub cek(a As String)
        If a = "" Then
            nopicture()
        Else
            adapicture()
        End If
    End Sub
    Private Sub prevberita()
        Try
            ke -= 1
            If ke >= 0 Then
                Dim a As New DataTable
                a = search.searchfoto()
                _kode = a.Rows(ke).Item(0)
                Label4.Text = a.Rows(ke).Item(1)
                RichTextBox1.Text = a.Rows(ke).Item(2)
                cek(a.Rows(ke).Item(3))
                PictureBox1.Image = Image.FromFile(a.Rows(ke).Item(3))
                adapicture()
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                Button2.Show()
                Label6.Show()
            Else
                ke += 1
                MsgBox("Tidak ada berita terbaru", MsgBoxStyle.Information)
                Button1.Hide()
                Label5.Hide()
                Button2.Show()
                Label6.Show()
            End If
        Catch ex As Exception
            nopicture()
            Button2.Show()
            Label6.Show()
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
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
    Public Sub loadberita()
        If check.checkcount("berita") = "0" Then
            MsgBox("Tidak ada berita untuk saat ini, silahkan untuk menambahkannya", MsgBoxStyle.Information)
            Button1.Hide()
            Button2.Hide()
            Label5.Hide()
            Label6.Hide()
            RichTextBox1.Hide()
            Label4.Hide()
            Label7.Hide()
            PictureBox1.Hide()
        Else
            Dim ke As Integer = 0
            RichTextBox1.ReadOnly = True
            Try
                Button1.Show()
                Button2.Show()
                Label5.Show()
                Label6.Show()
                RichTextBox1.Show()
                Label4.Show()
                Label7.Show()
                Dim a As New DataTable
                a = New DataTable
                a = search.searchfoto()
                _kode = a.Rows(ke).Item(0)
                Label4.Text = a.Rows(ke).Item(1)
                RichTextBox1.Text = a.Rows(ke).Item(2)
                PictureBox1.Image = Image.FromFile(a.Rows(ke).Item(3))
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                If a.Rows(ke).Item(3) <> "OpenFileDialog1" Then
                    adapicture()
                Else
                    nopicture()
                End If
            Catch ex As Exception
                nopicture()
                If _kode <> "" Then
                Else
                    Button4.Hide()
                    Button5.Hide()
                End If
            End Try
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("Anda yakin untuk Menghapus berita ini?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("berita", _kode)
            MsgBox("Data Berhasil dihapus", MsgBoxStyle.Information)
            loadberita()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class