Public Class opaddoreditpetugas
    Private create As New Create
    Private search As New Search
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode As String
    Private _aksi As String
    Private updatee As New Update
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
    Sub New(aksi As String, kode As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _aksi = "tambah" Then
            insert()
            Me.Hide()
            oppasien.refreshdata()
        Else
            sunting()
            Me.Hide()
            oppasien.refreshdata()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub tx1(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tx2(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tx3(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            alat.tabel = read.viewwhere(ComboBox1.Text, "dokter")
            TextBox4.Text = alat.tabel.Rows(0).Item(2)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub combodokter()
        Try
            For i = 0 To check.checkcount("dokter") - 1
                ComboBox1.Items.Add(read.viewdata("dokter").Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox("Combobox gagal diload")
        End Try
    End Sub
    Private Sub showdatapasien()
        Dim a As New DataTable
        TextBox4.ReadOnly = True
        a = read.viewwhere(_kode, "pasien")
        ComboBox1.Text = a.Rows(0).Item(1)
        Textusername.Text = a.Rows(0).Item(2)
        TextBox1.Text = a.Rows(0).Item(3)
        TextBox2.Text = a.Rows(0).Item(4)
        DateTimePicker1.Value = a.Rows(0).Item(5)
        DateTimePicker2.Value = a.Rows(0).Item(6)
        TextBox3.Text = a.Rows(0).Item(7)
    End Sub
    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
        TextBox4.ReadOnly = True
    End Sub
    Private Sub insert()
        create.insertpasienordokter(ComboBox1.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value), CStr(DateTimePicker2.Value), TextBox3.Text)
        If create.bool = True Then
            Me.Hide()
        End If
    End Sub
    Private Sub sunting()
        updatee.updatepasienordokter(_kode, ComboBox1.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value), CStr(DateTimePicker2.Value), TextBox3.Text)
        If updatee.bool = True Then
            Me.Hide()
        End If
    End Sub
    Private Sub isi()
        combodokter()
        If _aksi = "edit" Then
            showdatapasien()
            Label12.Text = "Edit Data Pasien"
            Button1.Text = "Selesai"
        Else
            Label12.Text = "Tambah Pasien Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub
End Class