Public Class opbayar
    Private create As New Create
    Private search As New Search
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode, kata, kaki, kaku As String
    Private _aksi As String
    Private updatee As New Update
    Private delete As New Delete
    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Sub New(kode As String)
        InitializeComponent()
        _kode = kode
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("Mohon isi semua data terlebih dahulu")
        Else
            insert()
            opadministrasi.refreshdata()
            opadministrasi.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
    Private Sub tx8(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub combopetugas()
        Try
            For i = 0 To check.checkcount("petugas") - 1
                ComboBox1.Items.Add(read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(0) + " A/n : " + read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(2))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub showdatapasien()
        Dim a As New DataTable
        TextBox4.ReadOnly = True
        a = read.viewwhere(_kode, "pasien")
        TextBox1.Text = a.Rows(0).Item(1)
        TextBox2.Text = a.Rows(0).Item(2)
        TextBox3.Text = a.Rows(0).Item(3)
        TextBox4.Text = a.Rows(0).Item(4)
        TextBox5.Text = a.Rows(0).Item(5)
        TextBox6.Text = a.Rows(0).Item(6)
        TextBox7.Text = a.Rows(0).Item(7)
        a = read.viewwhere(a.Rows(0).Item(1), "dokter")
        TextBox1.Text = a.Rows(0).Item(2)
    End Sub
    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub
    Private Sub insert()
        create.insertinaporpembayaran(TextBox9.Text, _kode, DateTimePicker1.Value, TextBox8.Text)
        If create.bool = True Then
            Me.Hide()
            MsgBox("Terima Kasih Pembayaran telah dilakukan")
        End If
    End Sub
    Private Sub isi()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox9.ReadOnly = True
        combopetugas()
        showdatapasien()
        Label12.Text = "Administrasi"
        Button1.Text = "Selesai"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
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
End Class