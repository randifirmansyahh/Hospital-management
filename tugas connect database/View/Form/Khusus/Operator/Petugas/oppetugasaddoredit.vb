Public Class oppetugasaddoredit
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
    
    Private Sub Button2_Click(sender As Object, e As EventArgs)
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

    Private Sub showdatapasien()
        Dim a As New DataTable
        a = read.viewwhere(_kode, "petugas")
        TextBox4.Text = a.Rows(0).Item(1)
        Textusername.Text = a.Rows(0).Item(2)
        TextBox1.Text = a.Rows(0).Item(3)
        TextBox2.Text = a.Rows(0).Item(4)
        DateTimePicker1.Value = a.Rows(0).Item(5)
    End Sub
    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub
    Private Sub insert()
        create.insertopereatororpetugas(TextBox4.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value))
        If create.bool = True Then
            Me.Hide()
        End If
    End Sub
    Private Sub sunting()
        updatee.updateopereatororpetugas(_kode, TextBox4.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value))
        If updatee.bool = True Then
            Me.Hide()
        End If
    End Sub
    Private Sub isi()
        If _aksi = "edit" Then
            showdatapasien()
            Label12.Text = "Edit Data Petugas"
            Button1.Text = "Selesai"
        Else
            Label12.Text = "Tambah Petugas Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If _aksi = "edit" Then
            sunting()
            Me.Hide()
            MsgBox("Data Petugas Telah Di Update")
            oppetugasshow.refreshdata()
            oppetugasshow.DataGridView1.Show()
        Else
            insert()
            Me.Hide()
            MsgBox("Petugas Telah Ditambahkan")
            oppetugasshow.refreshdata()
            oppetugasshow.DataGridView1.Show()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class