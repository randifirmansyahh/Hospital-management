Public Class loadingawal
    Private childloadingfirst As New childloadingfirst
    Private latar As New login
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        cektime()
    End Sub

    Private Sub Loadfirst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub timestop()
        Timer1.Stop()
        pengunjung.Show()
        Me.Hide()
    End Sub
    Private Sub aksiloading()
        Label4.BackColor = Color.Transparent
        Label4.ForeColor = Color.Black
        BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Private Sub timestart()
        childloadingfirst.loadkata()
        ProgressBar1.Value += childloadingfirst.kecepatanloading()
        aksiloading()
    End Sub

    Private Sub cektime()
        If Progressbar1.Value < 99 Then
            timestart()
            aksiloading()
        ElseIf Progressbar1.Value = 99 Then
            timestop()
        End If
        If ProgressBar1.Value < 25 Then
            Label4.Text = childloadingfirst.kata(0)
        ElseIf ProgressBar1.Value = 25 Then
            Label4.Text = childloadingfirst.kata(1)
            aksiloading()
            Me.BackgroundImage = tugas_connect_database.My.Resources.Resources.Doctor_01
        ElseIf ProgressBar1.Value = 50 Then
            Label4.Text = childloadingfirst.kata(2)
            aksiloading()
            aksiloading()
            Me.BackgroundImage = tugas_connect_database.My.Resources.Resources.Doctor_03_1_
        ElseIf ProgressBar1.Value = 75 Then
            Label4.Text = childloadingfirst.kata(3)
            Me.BackgroundImage = tugas_connect_database.My.Resources.Resources.fotoloading
        End If
    End Sub
End Class