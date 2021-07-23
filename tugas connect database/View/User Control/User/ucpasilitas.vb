Public Class ucpasilitas
    
    Private Sub userfasilitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hidee()
        Timer1.Start()
    End Sub
    Private Sub hidee()
        ProgressBar1.Hide()
        Label1.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        Label6.Hide()
        Label7.Hide()
    End Sub
    Private Sub cek()
        If ProgressBar1.Value < 99 Then
            ProgressBar1.Value += 1
        ElseIf ProgressBar1.Value = 99 Then
            ProgressBar1.Value = 0
            hidee()
        End If
        If ProgressBar1.Value = 5 Then
            Label2.Show()
        ElseIf ProgressBar1.Value = 14 Then
            Label7.Show()
        ElseIf ProgressBar1.Value = 28 Then
            Label1.Show()
        ElseIf ProgressBar1.Value = 42 Then
            Label3.Show()
        ElseIf ProgressBar1.Value = 56 Then
            Label4.Show()
        ElseIf ProgressBar1.Value = 70 Then
            Label5.Show()
        ElseIf ProgressBar1.Value = 84 Then
            Label6.Show()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        cek()
    End Sub
    Private Sub back()
        Timer1.Stop()
        hidee()
        ProgressBar1.Value = 0
        Me.Hide()
        usermenu.Show()
    End Sub
End Class
