Public Class a
    Public a As New uclogin
    Public b As New navigasiawal
    Public Sub switch1(a As Object)
        Panel1.Controls.Clear()
        Panel1.Controls.Add(a)
    End Sub
    Public Sub switch2(a As Object)
        Panel2.Controls.Clear()
        Panel2.Controls.Add(a)
    End Sub
    Private Sub buatusercontrol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As New ucopmenu
        Dim b As New ucopnavigasi
        Panel1.Controls.Add(b)
        Panel2.Controls.Add(a)
    End Sub
End Class