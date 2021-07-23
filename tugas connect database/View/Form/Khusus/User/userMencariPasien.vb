Public Class userMencariPasien
    Private validasi As New validasi
    Private Sub refreshdata()
        Dim caripasien As New Search
        DataGridView1.DataSource = caripasien.searchpasien(TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validasi.cekkosong(TextBox1.Text) = False Then
            DataGridView1.Hide()
        Else
            DataGridView1.Show()
            refreshdata()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        usermenu.Show()
    End Sub

    Private Sub userMencariPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
    End Sub
End Class