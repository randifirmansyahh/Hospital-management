Public Class Check
    Inherits parentCrud
    Public Function cekop(a As String, b As String) As String
        Return cekloginoperator(a, b)
    End Function
    Public Function cekad(a As String, b As String) As String
        Return cekloginadmin(a, b)
    End Function
    Private Function cekloginoperator(a As String, b As String) As String
        tabel = New DataTable
        _query = "select * from operator where username='" + a + "'"
        str = ""
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            If tabel.Rows(0).Item(0) = a And tabel.Rows(0).Item(1) = b Then
                str = "1"
            ElseIf tabel.Rows(0).Item(0) = a And tabel.Rows(0).Item(1) <> b Then
                str = "2"
            Else
                str = "3"
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function
    Private Function cekloginadmin(a As String, b As String) As String
        tabel = New DataTable
        _query = "select * from admin where username='" + a + "'"
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            If tabel.Rows(0).Item(0) = a And tabel.Rows(0).Item(1) = b Then
                str = "1"
            ElseIf tabel.Rows(0).Item(0) = a And tabel.Rows(0).Item(1) <> b Then
                str = "2"
            Else
                str = "3"
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function

    Public Function cekcombo() As datatable
        tabel = New DataTable
        _query = "select * from pasien a inner join inap b where a.Kode = b.Pasien"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return tabel
    End Function
    Public Function banding(from1 As String, where1 As String, from2 As String, where2 As String) As Boolean
        tabel = New DataTable
        _query = "select * from " + from1 + " a inner join " + from2 + " b where a.Kode = b.Pasien"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function

    Public Function avaliable(dari As String, siapa As String, apa As String) As Boolean
        Dim a As Boolean
        tabel = New DataTable
        str = ""
        _query = "select Pasien from " + dari + " where " + siapa + "='" + apa + "'"
        cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
        a = True
        cmd_a.Fill(tabel)
        Try
            str = tabel.Rows(0).Item(0)
        Catch ex As Exception
            Return a = True
        End Try
        If str <> apa Then
            a = False
        Else
            a = True
        End If
        Return a
    End Function
    Public Function checkmax(dari As String) As String
        tabel = New DataTable
        _query = "select max(Kode) from " + dari
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function querybebastable(a As String) As DataTable
        Dim _query As String = a
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return hus
    End Function

    Public Function email() As DataTable
        _query = "select * from pengunjung where komentar !='' or email!='' order by(Kode) desc"
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return hus
    End Function

    Public Function querybebas(a As String) As Integer
        Dim _query As String = a
        Dim gsg As String = ""
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            gsg = hus.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return gsg
    End Function
    Public Function checkcountfromwhatwhere(dari As String, what As String, where As String) As String
        tabel = New DataTable
        _query = "select count(Kode) from " + dari + " where " + what + "='" + where + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function
    Public Function checkcount(dari As String) As String
        tabel = New DataTable
        _query = "select count(Kode) from " + dari
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function hitungrows(a As String) As Integer
        _query = "select count(*)from " + a
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            banyak = tabel.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return banyak
    End Function

    Public Function masukcombobox(a As String, b As String) As DataTable
        _query = "select " + a + " from " + b
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return tabel
    End Function
    Public Function nkomentar() As Integer
        _query = "select count(*)from pengunjung where Komentar=''"
        Try
            MsgBox(banyak)
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            banyak = tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        Return banyak
    End Function
End Class