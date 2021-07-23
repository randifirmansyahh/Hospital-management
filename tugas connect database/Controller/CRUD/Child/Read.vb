Public Class Read
    Inherits parentCrud
    Public Function viewdata(a As String) As DataTable
        tabel = New DataTable
        _query = "select * from " + a
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Failed")
        End Try
        Return tabel
    End Function

    Public Function viewwherebebas(a As String, b As String, c As String) As DataTable
        tabel = New DataTable
        Dim _query As String = "select * from " + a + " where " + b + "='" + c + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Gagal", MsgBoxStyle.Critical)
        End Try
        Return tabel
    End Function


    Public Function viewwhere(a As String, b As String) As DataTable
        tabel = New DataTable
        Dim _query As String = "select * from " + b + " where Kode='" + a + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Gagal", MsgBoxStyle.Critical)
        End Try
        Return tabel
    End Function

    Public Function view1where(c As String, b As String, a As String) As Boolean
        tabel = New DataTable
        Dim _query As String = "select " + c + " from " + b + " where Pasien='" + a + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            If tabel.Rows(0).Item(0) = a Then
                bool = True
            Else
                bool = False
            End If
            Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function
End Class