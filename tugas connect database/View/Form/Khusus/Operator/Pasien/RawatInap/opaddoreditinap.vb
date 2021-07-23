Public Class opaddoreditinap
    Private create As New Create
    Private search As New Search
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode As String
    Private _aksi As String
    Private updatee As New Update
    Private kata, kaki, _nama As String
    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Public Property aksi As String
        Get
            Return _aksi
        End Get
        Set(value As String)
            _aksi = value
        End Set
    End Property
    Sub New(aksi As String, kode As String, nama As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
        _nama = nama
    End Sub
    Public Property nama As String
        Get
            Return _nama
        End Get
        Set(value As String)
            _nama = value
        End Set
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _aksi = "edit" Then
            sunting()
        Else
            insert()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub tx1(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tx2(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tx3(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            kaki = ""
            kata = ComboBox1.Text
            kata.Split()
            For i = 0 To 6
                kaki += kata(i)
            Next
            alat.tabel = read.viewwhere(kaki, "pasien")
            TextBox4.Text = alat.tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub comboinap()
        Try
            kaki = ""
            kata = ""
            Dim cuk As Integer = 0
            alat.tabel = New DataTable
            For i = 0 To check.checkcount("pasien") - 1
                kata = read.viewdata("pasien").Rows(i).Item(0)
                kaki = read.viewdata("pasien").Rows(i).Item(0) + " Atas Nama : " + read.viewdata("pasien").Rows(i).Item(2)
                If check.checkcount("inap") > 0 Then
                    For j = 0 To Val(check.checkcount("inap")) - 1
                        If read.view1where("Pasien", "inap", kata) = True Then
                            cuk += 1
                        Else
                            cuk += 0
                        End If
                    Next
                End If
                If cuk = 0 Then
                    ComboBox1.Items.Add(kaki)
                End If
                cuk = 0
            Next
        Catch ex As Exception
            MsgBox("gagal meload combo")
        End Try
    End Sub
    Private Sub showdatainap()
        Dim a As New DataTable
        TextBox4.ReadOnly = True
        a = read.viewwhere(_kode, "inap")
        ComboBox1.Items.Add(nama)
        TextBox4.Text = a.Rows(0).Item(0)
        ComboBox1.Text = nama
        Textusername.Text = a.Rows(0).Item(2)
        End Sub
    Private Sub optambahdokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
        TextBox4.ReadOnly = True
    End Sub
    Private Sub insert()
        If check.avaliable("inap", "Pasien", TextBox4.Text) = False Then
            MsgBox("Pasien Tersebuh Sudah terdaftar di pasien rawat inap")
        Else
            create.insertinaporpembayaran(TextBox4.Text, Textusername.Text)
            If create.bool = True Then
                Me.Hide()
                oprawatinap.refreshdata()
                MsgBox("Data Pasien Rawat Inap Berhasil Ditambahkan", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Sub sunting()
        updatee.updateinaporpembayaran(_kode, Textusername.Text)
        If updatee.bool = True Then
            Me.Hide()
            oprawatinap.refreshdata()
            MsgBox("Data Pasien Rawat Inap Berhasil Diubah", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub isi()
        If _aksi = "edit" Then
            showdatainap()
            Label12.Text = "Edit Data Pasien"
            Button1.Text = "Selesai"
        Else
            comboinap()
            Label12.Text = "Tambah Pasien Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub
End Class