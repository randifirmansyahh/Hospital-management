Public Class ucuscariinap
    Private search As New Search
    Private Sub refreshdata()
        DataGridView1.DataSource = search.searchinap(Textbox1.text)
    End Sub
    Private Sub userMencariPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
    End Sub
    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        refreshdata()
    End Sub
End Class
