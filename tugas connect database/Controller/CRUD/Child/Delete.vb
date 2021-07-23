Public Class Delete
    Inherits parentCrud
    Public Function deletefromwhatwhere(tabel As String, what As String, kode As String) As Boolean
        'fromwhatwhere
        _query = "delete from " + tabel + " where " + what + "='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function

    Public Overloads Function deleteallorwhere(tabel As String, kode As String) As Boolean
        'where
        _query = "delete from " + tabel + " where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function
    Public Overloads Function deleteallorwhere(tabel As String) As Boolean
        'all
        _query = "delete from " + tabel
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function
End Class