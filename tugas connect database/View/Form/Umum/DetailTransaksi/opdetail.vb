Public Class opdetail
    Private validasi As New validasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private kode As String

    Public Sub refreshdata()
        Dim caripasien As New Search
        DataGridView1.DataSource = search.searchdetail(TextBox1.Text)
        childalat.tabel = search.searchpasien(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        admenu.Show()
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validasi.cekkosong(TextBox1.Text) = False Then
            DataGridView1.Hide()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class