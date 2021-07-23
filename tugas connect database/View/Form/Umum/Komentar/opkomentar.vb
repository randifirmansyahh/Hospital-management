Public Class opkomentar
    Public ke As Integer = 0
    Private check As New Check
    Private search As New Search
    Private childalat As New childalat
    Private delete As New Delete
    Private _aksi, email, _kode As String
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prevkomentar()
    End Sub
    Private Sub back()
        If _aksi = "admin" Then
            Me.Hide()
            With menuad
                .Show()
                .Label1.Hide()
            End With
        Else
            Me.Hide()
            With admenu
                .Show()
                .Label1.Hide()
            End With
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        back()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nextkomentar()
    End Sub
    Private Sub showawal()
        ke = 0
        Dim table As New DataTable
        Dim n As Integer
        DataGridView1.DataSource = check.email()
        n = DataGridView1.RowCount() - 1
        If ke < n Then
            childalat.tabel = New DataTable
            childalat.tabel = check.email()
            _kode = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
            Button1.Show()
            Label5.Show()
        Else
            ke -= 1
            MsgBox("Tidak ada komentar lagi", MsgBoxStyle.Information)
            Button2.Hide()
            Label6.Hide()
        End If
    End Sub
    Private Sub nextkomentar()
        ke += 1
        Dim table As New DataTable
        Dim n As Integer
        DataGridView1.DataSource = check.email()
        n = DataGridView1.RowCount() - 1
        If ke < n Then
            childalat.tabel = New DataTable
            childalat.tabel = check.email()
            _kode = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
            Button1.Show()
            Label5.Show()
        Else
            ke -= 1
            MsgBox("Tidak ada komentar lagi", MsgBoxStyle.Information)
            Button2.Hide()
            Label6.Hide()
        End If
    End Sub
    Private Sub prevkomentar()
        ke -= 1
        If ke >= 0 Then
            childalat.tabel = New DataTable
            childalat.tabel = check.email()
            _kode = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
            Button2.Show()
            Label6.Show()
        Else
            ke += 1
            MsgBox("Ini adalah komentar terbaru", MsgBoxStyle.Information)
            Button1.Hide()
            Label5.Hide()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari Akun?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Hide()
            login.Show()
        End If
    End Sub

    Private Sub opkomentar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showawal()
        If _aksi = "admin" Then
            RichTextBox2.Hide()
            Button4.Show()
            Button5.Show()
            Label9.Hide()
            Button3.Hide()
        Else
            Button4.Hide()
            Button5.Hide()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("Anda yakin untuk menghapus komentar dari " + email + " ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere(_kode, "pengunjung")
            If delete.bool = True Then
                MsgBox("komentar telah dihapus", MsgBoxStyle.Information)
                Try
                    nextkomentar()
                Catch ex As Exception
                    prevkomentar()
                End Try
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Anda yakin untuk menghapus semua komentar ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pengunjung")
            If delete.bool = True Then
                MsgBox("Semua komentar telah terhapus", MsgBoxStyle.Information)
                DataGridView1.DataSource = check.email
                If DataGridView1.RowCount = "0" Then
                    MsgBox("Tidak ada komentar yang dapat di tampilkan", MsgBoxStyle.Information)
                    back()
                Else
                    Try
                        nextkomentar()
                    Catch ex As Exception
                        prevkomentar()
                    End Try
                End If
            End If
        End If
    End Sub
End Class