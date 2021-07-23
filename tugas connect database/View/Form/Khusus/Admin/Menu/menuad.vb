Public Class menuad
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
        Dim c As New opkomentar("admin")
        c.ShowDialog()
    End Sub
    Private Sub hbt9(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Button9.Width = 235
        Button9.Height = 486
        sendback()
        Button9.BringToFront()
    End Sub

    Private Sub lbt9(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.Width = 205
        Button9.Height = 456
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
    Private Sub sendback()
        Button2.SendToBack()
        Button10.SendToBack()
        Button4.SendToBack()
        Button9.SendToBack()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            login.Close()
            pengunjung.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Anda yakin untuk keluar dari Akun?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Hide()
            login.Textusername.Clear()
            login.Textpassword.Clear()
            login.Show()
        End If
    End Sub
    
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
        With berita
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        adop.ShowDialog()
    End Sub

    Private Sub opmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        popupkomentar()
    End Sub
    Private Sub popupkomentar()
        DataGridView1.DataSource = check.email()
        Label1.Text = DataGridView1.RowCount() - 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If check.checkcountfromwhatwhere("petugas", "Divisi", "HRD") = "0" Then
            MsgBox("Anda harus menambahkan petugas divisi HRD untuk memperkerjakan dokter", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            opdokter.Show()
            opdokter.Button5.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If check.checkcount("pasien") = "0" Then
            MsgBox("Anda harus menambahkan Pasien terlebih dahulu untuk mengakses inap", MsgBoxStyle.Critical)
        Else
            Me.Hide()
            oprawatinap.Show()
            oprawatinap.Button5.Hide()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
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
            MsgBox("belum ada pengunjung untuk saat ini", MsgBoxStyle.Information)
        Else
            Me.Hide()
            Dim opshow As New opshowpengunjung("admin")
            opshow.ShowDialog()
        End If
    End Sub
End Class