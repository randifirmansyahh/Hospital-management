Public Class ucopmenu
    Private childalat As New childalat
    Private berita As New optampilberita
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As New opkomentar("operator")
        c.ShowDialog()
    End Sub
    Private Sub hbt1(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.Width = lebarhover
        Button1.Height = tinggihover
        sendback()
    End Sub

    Private Sub lbt1(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.Width = lebarnormal
        Button1.Height = tingginormal
    End Sub
    Private Sub hbt8(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Button8.Width = lebarhover
        Button8.Height = tinggihover
        sendback()
    End Sub

    Private Sub lbt8(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Button8.Width = lebarnormal
        Button8.Height = tingginormal
    End Sub
    Private Sub hbt9(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Button9.Width = lebarhover
        Button9.Height = tinggihover
        sendback()
        Button9.BringToFront()
    End Sub

    Private Sub lbt9(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.Width = lebarnormal
        Button9.Height = tingginormal
    End Sub
    Private Sub button2_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.Width = lebarhover
        Button5.Height = tinggihover
        sendback()
    End Sub

    Private Sub button2_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.Width = lebarnormal
        Button5.Height = tingginormal
    End Sub
    Private Sub hb0(sender As Object, e As EventArgs) Handles Button0.MouseHover
        Button0.Width = hovlrows
        Button0.Height = hovtingrows
        sendback()
    End Sub

    Private Sub lb0(sender As Object, e As EventArgs) Handles Button0.MouseLeave
        Button0.Width = normlrows
        Button0.Height = normtingrows
    End Sub
    Private Sub hb10(sender As Object, e As EventArgs) Handles Button10.MouseHover
        Button10.Width = hovlrows
        Button10.Height = hovtingrows
        sendback()
        Button10.BringToFront()
    End Sub

    Private Sub lb10(sender As Object, e As EventArgs) Handles Button10.MouseLeave
        Button10.Width = normlrows
        Button10.Height = normtingrows
    End Sub
    Private Sub Button0_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.Width = hovlbig
        Button2.Height = hovtingbig
        sendback()
    End Sub

    Private Sub Button0_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Width = normlbig
        Button2.Height = nortingbig
    End Sub
    Private Sub hb4(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.Width = hovlcols
        Button4.Height = hovtingcols
        sendback()
        Label1.BringToFront()
        Label1.Width = labellebarhover
        Label1.Height = labeltinggihover
    End Sub

    Private Sub lb4(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.Width = normlcols
        Button4.Height = normtingcols
        Label1.Width = labellebarnormal
        Label1.Height = labeltingginormal
    End Sub
    Private Sub hb3(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.Width = hovlcols
        Button3.Height = hovtingcols
        sendback()
    End Sub

    Private Sub lb3(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.Width = normlcols
        Button3.Height = normtingcols
    End Sub
    Private Sub sendback()
        Button2.SendToBack()
        Button3.SendToBack()
        Button5.SendToBack()
        Button0.SendToBack()
        Button9.SendToBack()
        Button4.SendToBack()
        Button1.SendToBack()
        Button8.SendToBack()
        Button10.SendToBack()
    End Sub
    
    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        If check.checkcountfromwhatwhere("petugas", "Divisi", "Kasir") = "0" Then
            MsgBox("Anda harus menambahkan Petugas Divisi Kasir terlebih dahulu untuk mengakses pembayaran", MsgBoxStyle.Critical)
        Else
            Dim adm As New opadministrasi
            adm.ShowDialog()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        With berita
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If check.checkcount("dokter") = "0" Then
            MsgBox("Anda harus menambahkan Dokter terlebih dahulu untuk mengakses Pasien", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            oppasien.Show()
            oppasien.Button5.Hide()
        End If
    End Sub

    Private Sub opmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        popupkomentar()
    End Sub
    Private Sub popupkomentar()
        DataGridView1.DataSource = check.email()
        If DataGridView1.RowCount() - 1 = 0 Then
            Label1.Hide()
        Else
            Label1.Text = DataGridView1.RowCount() - 1
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If check.checkcountfromwhatwhere("petugas", "Divisi", "HRD") = "0" Then
            MsgBox("Anda harus menambahkan petugas divisi HRD untuk memperkerjakan dokter", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            opdokter.Show()
            opdokter.Button5.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If check.checkcount("pasien") = "0" Then
            MsgBox("Anda harus menambahkan Pasien terlebih dahulu untuk mengakses inap", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            oprawatinap.Show()
            oprawatinap.Button5.Hide()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        oppetugasshow.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If check.checkcount("pembayaran") = "0" Then
            MsgBox("Anda harus melakukan Transaksi terlebih dahulu untuk mengakses Detail Transaksi", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            opdetail.ShowDialog()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If check.checkcount("pengunjung") = "0" Then
            MsgBox("Belum ada pengunjung untuk saat ini", MsgBoxStyle.Information)
        Else
            Me.Hide()
            Dim opshow As New opshowpengunjung("op")
            opshow.ShowDialog()
        End If
    End Sub
End Class
