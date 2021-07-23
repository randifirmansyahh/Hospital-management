Public Class ucmenuuser
    Private _kode As String
    Private childalat As New childalat
    Private check As New Check
    'big 416; 302

    Private normlbig As Integer = 416
    Private hovlbig As Integer = 446
    Private nortingbig As Integer = 302
    Private hovtingbig As Integer = 332

    'cols 416; 148
    Private normlcols As Integer = 416
    Private hovlcols As Integer = 446
    Private normtingcols As Integer = 148
    Private hovtingcols As Integer = 178

    'rows 205; 302
    Private normlrows As Integer = 205
    Private hovlrows As Integer = 235
    Private normtingrows As Integer = 302
    Private hovtingrows As Integer = 332


    Private tingginormal As Integer = 148
    Private tinggihover As Integer = 178
    Private lebarnormal As Integer = 205
    Private lebarhover As Integer = 235
    Private labellebarhover As Integer = 111
    Private labeltinggihover As Integer = 80
    Private labellebarnormal As Integer = 81
    Private labeltingginormal As Integer = 50
    Private search As New Search
    Private Sub menuuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hidepopupkomentar()
        cekberita()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showberita()
    End Sub
    Private Sub Button0_MouseHover(sender As Object, e As EventArgs) Handles Button0.MouseHover
        Button0.Width = hovlbig
        Button0.Height = hovtingbig
        sendback()
    End Sub

    Private Sub Button0_MouseLeave(sender As Object, e As EventArgs) Handles Button0.MouseLeave
        Button0.Width = normlbig
        Button0.Height = nortingbig
    End Sub
    Private Sub button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.Width = hovlrows
        Button1.Height = hovtingrows
        sendback()
    End Sub

    Private Sub button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.Width = normlrows
        Button1.Height = normtingrows
    End Sub
    Private Sub button2_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.Width = lebarhover
        Button3.Height = tinggihover
        sendback()
    End Sub

    Private Sub button2_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.Width = lebarnormal
        Button3.Height = tingginormal
    End Sub
    Private Sub button3_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.Width = hovlrows
        Button5.Height = hovtingrows
        sendback()
    End Sub

    Private Sub button3_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.Width = normlrows
        Button5.Height = normtingrows
    End Sub
    Private Sub button4_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.Width = lebarhover
        Button2.Height = tinggihover
        Label1.Width = labellebarhover
        Label1.Height = labeltinggihover
        sendback()
    End Sub

    Private Sub button4_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Width = lebarnormal
        Button2.Height = tingginormal
        Label1.Width = labellebarnormal
        Label1.Height = labeltingginormal
    End Sub
    Private Sub label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Button2.Width = lebarhover
        Button2.Height = tinggihover
        Label1.Width = labellebarhover
        Label1.Height = labeltinggihover
        sendback()
    End Sub

    Private Sub label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Button2.Width = lebarnormal
        Button2.Height = tingginormal
        Label1.Width = labellebarnormal
        Label1.Height = labeltingginormal
    End Sub
    Private Sub button5_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.Width = hovlcols
        Button4.Height = hovtingcols
        sendback()
        showpopupkomentar()
    End Sub

    Private Sub button5_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.Width = normlcols
        Button4.Height = normtingcols
        hidepopupkomentar()
    End Sub

    Private Sub cekberita()
        If check.checkcount("berita") = "0" Then
            Label1.Hide()
        Else
            Label1.Show()
            Label1.Text = check.checkcount("berita")
        End If
    End Sub

    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        Me.Hide()
        With userMencariPasien
            .TextBox1.Clear()
            .DataGridView1.Hide()
            .Show()
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        With userMencariInap
            .Textbox1.text = ""
            .DataGridView1.Hide()
            .Show()
        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        With userfasilitas
            .ProgressBar1.Value = 0
            .Timer1.Start()
            .Show()
        End With
    End Sub

    Private Sub sendback()
        Button0.SendToBack()
        Button4.SendToBack()
        Button2.SendToBack()
        Button1.SendToBack()
        Button5.SendToBack()
        Button3.SendToBack()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        With userkomentar
            .TextBox1.Clear()
            .RichTextBox1.Clear()
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("Arahkan Penunjuk ke nama nama di bawah keterangan untuk memudahkan anda", MsgBoxStyle.Information)
        Me.Hide()
        userdenahlokasi.Show()
    End Sub


    Private Sub showberita()
        childalat.tabel = New DataTable
        childalat.tabel = search.searchfoto()
        With userberita
            .PictureBox1.Image = Image.FromFile(childalat.tabel.Rows(0).Item(3))
            .PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            .Refresh()
            .ke = 0
            .RichTextBox1.ReadOnly = True
            .Show()
        End With
        Me.Hide()
    End Sub
    Private Sub showpopupkomentar()
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()
    End Sub
    Private Sub hidepopupkomentar()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
    End Sub
End Class
