Imports MySql.Data.MySqlClient
Public Class koneksi
    Public connect As String = "server=localhost;user id=root;database=rumahsakit"
    Private con As New MySqlConnection(connect)
    Protected cmd_a As MySqlDataAdapter
    Protected cmd_b As MySqlCommand
    Public Function openconnection() As MySqlConnection
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("lost connection gaes")
        End Try
        Return con
    End Function
End Class