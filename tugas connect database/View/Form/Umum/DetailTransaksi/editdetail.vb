Public Class editdetail
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private updatee As New Update
    Private kata, kaki, kaku, _kode, _nama As String
    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Public Property nama As String
        Get
            Return _nama
        End Get
        Set(value As String)
            _nama = value
        End Set
    End Property
    Sub New(kode As String, nama As String)
        InitializeComponent()
        _kode = kode
        _nama = nama
    End Sub
    Private Sub editdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combopetugas()
        showdetail()
    End Sub
    Private Sub combopetugas()
        Try
            For i = 0 To check.checkcount("petugas") - 1
                ComboBox1.Items.Add(read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(0) + " A/n : " + read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(2))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            alat.tabel = New DataTable
            kaki = ""
            kata = ComboBox1.Text
            kata.Split()
            For i = 0 To 6
                kaki += kata(i)
            Next
            alat.tabel = read.viewwhere(kaki, "petugas")
            TextBox9.Text = alat.tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        kaku = TextBox8.Text
        kaku.Split()
        Try
            If kaku(0) = "0" Then
                TextBox8.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tx8(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub
    Private Sub showdetail()
        Dim a As New DataTable
        a = read.viewwhere(_kode, "pembayaran")
        TextBox1.Text = _nama
        TextBox1.ReadOnly = True
        DateTimePicker1.Value = a.Rows(0).Item(3)
        TextBox8.Text = a.Rows(0).Item(4)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("Masukan semua inputan terlebih dahulu", MsgBoxStyle.Critical)
        Else
            If MsgBox("Anda yakin Semua data sudah benar ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                updatee.updateinaporpembayaran(_kode, TextBox9.Text, DateTimePicker1.Value, TextBox8.Text)
                If updatee.bool = True Then
                    MsgBox("Detail Pembayaran Berhasil di rubah", MsgBoxStyle.Information)
                    Me.Hide()
                End If
            End If
        End If
    End Sub
End Class