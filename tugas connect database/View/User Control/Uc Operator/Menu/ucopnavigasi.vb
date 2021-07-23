Public Class ucopnavigasi
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim b As New ucuspasien
        a.switch2(b)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Dim b As New ucuscariinap
        a.switch2(b)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim b As New ucopmap
        a.switch2(b)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim b As New ucpasilitas
        a.switch2(b)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim b As New ucopberita
        a.switch2(b)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim b As New ucuskomentar
        a.switch2(b)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b As New ucmenuuser
        a.switch2(b)
    End Sub
End Class
