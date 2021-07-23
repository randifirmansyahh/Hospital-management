Public Class pengunjung
    Private validasi As New validasi
    Private search As New Search
    Private check As New Check
    Private create As New Create
    Private kaku, kaki, _kode As String
    Private childpengunjung As New childpengunjung
    Private Sub slide()
        ProgressBar1.Value += 1
        If ProgressBar1.Value = 30 Then
            Me.BackColor = Color.DarkSalmon
        ElseIf ProgressBar1.Value = 60 Then
            Me.BackColor = Color.DarkSeaGreen
        ElseIf ProgressBar1.Value = 90 Then
            Me.BackColor = Color.DarkSlateGray
            ProgressBar1.Value = 0
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        slide()
    End Sub

    Private Sub buttonlogadminorop(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Hide()
        login.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cekdulu()
    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label2_MouseHover(sender As Object, e As EventArgs) Handles Label2.MouseHover
        Label2.ForeColor = Color.Lime
    End Sub
    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.White
    End Sub

    Private Sub Label8_MouseHover(sender As Object, e As EventArgs) Handles Label8.MouseHover
        Label8.ForeColor = Color.LimeGreen
    End Sub

    Private Sub tampilanawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Hide()
        Timer1.Start()
        TextBox1.Focus()
        Button4.Hide()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack Or (e.KeyChar = " ")) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            login.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            login.Close()
            Me.Close()
        End If
    End Sub

    Private Sub cekdulu()
        If validasi.cekkosong(TextBox1.Text) = False Or validasi.cekkosong(TextBox2.Text) = False Then
            MsgBox("Isi semua inputan terlebih dahulu", MsgBoxStyle.Critical)
        Else
            If validasi.satuhuruf(TextBox1.Text) Or validasi.satuhuruf(TextBox1.Text) Then
                If MsgBox("Anda Nama atau kebutuhan anda cuman 1 huruf saja ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                    go()
                End If
            Else
                go()
            End If
        End If
    End Sub
    Private Sub go()
        MsgBox("Selamat datang " + TextBox1.Text, MsgBoxStyle.Information)
        _kode = create.pengunjung(TextBox1.Text, TextBox2.Text, "", "")
        popupberita()
        childpengunjung.kode() = _kode
        usermenu.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        MsgBox("Rumah Sakit Ransmart Mengucapkan Selamat Melaksanakan Ibadah puasa bagi yang melaksanakan", MsgBoxStyle.Information)
    End Sub
    Private Sub popupberita()
        usermenu.Label1.Text = check.checkcount("berita")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = validasi.cekdoublespasi(TextBox1.Text)
        TextBox1.Text = validasi.cekspasiawal(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = validasi.cekdoublespasi(TextBox2.Text)
        TextBox2.Text = validasi.cekspasiawal(TextBox2.Text)
        TextBox2.Select(TextBox2.Text.Length, 0)
    End Sub
End Class