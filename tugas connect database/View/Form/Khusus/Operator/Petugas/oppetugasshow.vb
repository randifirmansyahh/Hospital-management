Public Class oppetugasshow
    Private validasi As New validasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private kode, nama As String

    Public Sub refreshdata()
        DataGridView1.DataSource = search.searchpetugas(Textbox1.text)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
        If search.bool = False Then
            Button5.Hide()
        Else
            Button5.Show()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If kode = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                Dim edit As New oppetugasaddoredit("edit", kode)
                edit.ShowDialog()
            Catch ex As Exception
                MsgBox("Tidak ada data yang terpilih")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        admenu.Show()
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
        Button5.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opaddoredit As New oppetugasaddoredit(kode, "tambah")
        opaddoredit.ShowDialog()
    End Sub

    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        If validasi.cekkosong(Textbox1.text) = False Then
            DataGridView1.Hide()
            Button5.Hide()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub
End Class