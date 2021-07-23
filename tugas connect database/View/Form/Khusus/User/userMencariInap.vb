Public Class userMencariInap
    Private validasi As New validasi
    Private Sub refreshdata()
        Dim search As New Search
        DataGridView1.DataSource = search.searchinap(Textbox1.text)
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
        DataGridView1.Hide()
        refreshdata()
    End Sub

    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        If validasi.cekkosong(Textbox1.text) = False Then
            DataGridView1.Hide()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub
End Class