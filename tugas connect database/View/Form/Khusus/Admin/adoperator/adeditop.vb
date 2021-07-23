Public Class adeditop
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
    Sub New(aksi As String, kode As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
    End Sub
    Public Property nama As String
        Get
            Return _nama
        End Get
        Set(value As String)
            _nama = value
        End Set
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If _aksi = "edit" Then
            sunting()
        Else
            insert()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub tx1(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "0" And e.KeyChar <= "9")) Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = "_" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub showdatainap()
        Dim a As New DataTable
        a = read.viewwherebebas("operator", "Username", _kode)
        TextBox1.Text = a.Rows(0).Item(0)
        TextBox4.Text = a.Rows(0).Item(1)
        Textusername.Text = a.Rows(0).Item(2)
    End Sub
    Private Sub optambahdokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub
    Private Sub insert()
        create.insertopereatororpetugas(TextBox1.Text, TextBox4.Text, Textusername.Text)
        If create.bool = True Then
            Me.Hide()
            adop.showall()
            MsgBox("Data Operator Inap Berhasil Ditambahkan", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub sunting()
        updatee.updateopereatororpetugas(TextBox1.Text, _kode, Textusername.Text)
        If updatee.bool = True Then
            Me.Hide()
            adop.showall()
            MsgBox("Data Operator Berhasil Diubah", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub isi()
        If _aksi = "edit" Then
            showdatainap()
            Label12.Text = "Edit Data Operator"
            Button1.Text = "Selesai"
        Else
            Label12.Text = "Tambah Operator Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        adop.Show()
    End Sub
End Class