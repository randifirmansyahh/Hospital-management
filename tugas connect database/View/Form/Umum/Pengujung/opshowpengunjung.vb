Public Class opshowpengunjung
    Private validasi As New validasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private _aksi, _kode, nama As String
    Public Property aksi As String
        Get
            Return _aksi
        End Get
        Set(value As String)
            _aksi = value
        End Set
    End Property
    Sub New(aksi As String)
        InitializeComponent()
        _aksi = aksi
    End Sub
    
    Public Function refreshdata()
        DataGridView1.DataSource = search.searchpengunjung(TextBox1.Text)
        If DataGridView1.RowCount() < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
        Return True
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        _kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
        nama = DataGridView1.CurrentRow.Cells(1).Value.ToString
        If _aksi = "admin" Then
            Button4.Show()
            Button6.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _aksi = "admin" Then
            Me.Hide()
            menuad.ShowDialog()
        Else
            Me.Hide()
            admenu.Show()
        End If
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showall()
        Button4.Hide()
        Button6.Hide()
        If DataGridView1.RowCount() < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub
    Public Sub showall()
        DataGridView1.Show()
        DataGridView1.DataSource = read.viewdata("pengunjung")
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = validasi.cekdoublespasi(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
        refreshdata()
        If validasi.cekkosong(TextBox1.Text) = False Then
            showall()
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Anda yakin untuk Menghapus " + nama + " dari daftar pengunjung ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pengunjung", _kode)
            If delete.bool = True Then
                MsgBox("Data pengunjung telah dihapus")
            End If
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Anda yakin untuk Menghapus semua data dari daftar pengunjung ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pengunjung")
            If delete.bool = True Then
                MsgBox("Data pengunjung telah dihapus")
            End If
        End If
    End Sub
End Class