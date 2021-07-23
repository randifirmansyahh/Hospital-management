Public Class opdokter
    Private validasi As New validasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private kode As String

    Public Sub refreshdata()
        DataGridView1.DataSource = search.searchdokter(TextBox1.Text)
        childalat.tabel = search.searchdokter(TextBox1.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
        childalat.tabel = search.searchdokter(updatee.ambilsok())
        If search.bool = False Then
            Button5.Hide()
            Button6.Hide()
        Else
            Button5.Show()
            Button6.Show()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If kode = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                Dim edit As New opaddorupdatedokter("edit", kode)
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
        Button6.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validasi.cekkosong(TextBox1.Text) = False Then
            DataGridView1.DataSource = read.viewdata("dokter")
            Button5.Hide()
            Button6.Hide()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tambah As New opaddorupdatedokter("tambah", kode)
            tambah.ShowDialog()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        childalat.tabel = New DataTable
        childalat.tabel = check.querybebastable("select Ditangani,Kode,Nama from pasien a where Kode not in(select Pasien from pembayaran)and ditangani='" + kode + "'")
        Try
            If childalat.tabel.Rows(0).Item(0) = kode Then
                MsgBox("Tidak bisa dihapus karna Dokter masih melayani Pasien")
            End If
        Catch ex As Exception
            If MsgBox("Anda yakin untuk menghapus Dokter ini ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                delete.deleteallorwhere("dokter", kode)
                If delete.bool = True Then
                    MsgBox("Dokter telah di hapus dari daftar", MsgBoxStyle.Information)
                End If
            End If
        End Try
    End Sub
End Class