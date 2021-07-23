Imports System.Drawing.Bitmap
Public Class opinputoreditberita
    Private create As New Create
    Private updatee As New Update
    Private alat As New childalat
    Private read As New Read
    Private ke As Integer = 0
    Private _kode As String
    Private _aksi As String

    Sub New(aksi As String, kode As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
    End Sub

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
    Sub isi()
        If _aksi = "edit" Then
            Try
                Label8.Hide()
                alat.tabel = read.viewwhere(_kode, "berita")
                TextBox1.Text = alat.tabel.Rows(0).Item(1)
                RichTextBox1.Text = alat.tabel.Rows(0).Item(2)
                Label1.Text = alat.tabel.Rows(ke).Item(3)
                PictureBox1.Image = Image.FromFile(alat.tabel.Rows(ke).Item(3))
                OpenFileDialog1.FileName = alat.tabel.Rows(ke).Item(3)
            Catch ex As Exception
                PictureBox1.Hide()
                CheckBox1.Hide()
                Label8.Show()
            End Try
        Else
            nopict()
        End If
        kata()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If OpenFileDialog1.ShowDialog Then
                PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
                Label1.Text = "Nama file: " + OpenFileDialog1.FileName
            End If
            If Label1.Text <> "" Then
                PictureBox1.Show()
                CheckBox1.Show()
                Label1.Show()
                Label8.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub kata()
        If _aksi = "edit" Then
            Label5.Text = "Update Berita Terkini"
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isi()
        OpenFileDialog1.Title = "Masukkan foto anda"
        OpenFileDialog1.Filter = "JPEG File|*.jpg;*.jpeg;*.png"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If _aksi = "edit" Then
            If MsgBox("Anda yakin untuk mengirimkan berita ini?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                updatee.updateberitaordetail(kode, TextBox1.Text, RichTextBox1.Text, OpenFileDialog1.FileName)
                MsgBox("Selamat, Berita Anda berhasil Disunting", MsgBoxStyle.Information)
                Dim optampilberita As New optampilberita
                Me.Hide()
                optampilberita.ShowDialog()
            End If
        Else
            If MsgBox("Anda yakin untuk mengirimkan berita ini?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                create.insertberita(TextBox1.Text, RichTextBox1.Text, OpenFileDialog1.FileName)
                MsgBox("Selamat, Sekarang orang orang dapat melihat berita rumah sakit ini", MsgBoxStyle.Information)
                Dim optampilberita As New optampilberita
                Me.Hide()
                optampilberita.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Dim optampil As New optampilberita
        optampil.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub nopict()
        OpenFileDialog1.FileName = ""
        Label1.Text = ""
        PictureBox1.Hide()
        Label8.Show()
        CheckBox1.Hide()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nopict()
    End Sub
End Class