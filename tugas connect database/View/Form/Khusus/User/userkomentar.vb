Public Class userkomentar
    Private create As New Create
    Private validasi As New validasi
    Private updatee As New Update
    Private check As New Check
    Private childpengunjung As New childpengunjung
    Private _kode As String = childpengunjung.kode()

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label8.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kirim()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
        usermenu.Show()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        usermenu.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub kirim()
        If validasi.cekkosong(TextBox1.Text) = False Or validasi.cekkosong(RichTextBox1.Text) = False Then
            MsgBox("Harap untuk mengisi semua inputan", MsgBoxStyle.Critical)
        Else
            updatee.updatepengunjung(check.checkmax("pengunjung"), TextBox1.Text, RichTextBox1.Text)
            MsgBox("Terima kasih banyak dan mohon maaf atas ketidaknyamanannya", MsgBoxStyle.Information)
            MsgBox(check.checkmax("pengunjung"))
            Me.Hide()
            usermenu.Show()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub userkomentar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class