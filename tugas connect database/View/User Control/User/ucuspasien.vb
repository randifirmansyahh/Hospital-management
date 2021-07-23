Public Class ucuspasien
    Private validasi As New validasi
    Private caripasien As New Search
    Private Sub refreshdata()
        DataGridView1.DataSource = caripasien.searchpasien(TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        refreshdata()
    End Sub

    Private Sub userMencariPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
    End Sub
End Class
