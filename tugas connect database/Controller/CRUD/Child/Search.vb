Public Class Search
    Inherits parentCrud
    Public Function searchoperator(cari As String) As DataTable
        tabel = New DataTable
        _query = "select * from operator order by(Kode)desc where Username like '%" + cari + "%' or Password like '%" + cari + "' or Email like '%" + cari + "%'"
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
    Public Function searchkomentar() As DataTable
        tabel = New DataTable
        _query = "select * from komentar order by(Kode)desc"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
    Public Function searchfoto() As DataTable
        tabel = New DataTable
        _query = "select * from berita order by(kode)desc"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
    Public Function searchdokter(cari As String) As DataTable
        tabel = New DataTable
        _query = "select * from dokter where Kode like '%" + cari + "%' or Nama like '%" + cari + "%' or Alamat like '%" + cari + "%' or Agama like '%" + cari + "%' or TTL like '%" + cari + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function searchpasien(cari As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode as Kode, a.Nama as Nama,b.Nama as Ditangani, a.Alamat, a.Agama, a.TTL, a.Kedatangan, a.Keluhan from pasien a inner join dokter b where a.Ditangani=b.Kode and (a.Kode like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function searchpasien(cari As String, b As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode,a.Nama,b.Nama as Ditangani,a.Alamat,a.Agama,a.TTL,a.Kedatangan,a.Keluhan from pasien a inner join dokter b where a.Kode not in(select Pasien from pembayaran) and a.Ditangani=b.Kode and (a.Kode like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchpetugas(cari As String) As DataTable
        tabel = New DataTable
        _query = "select * from petugas where Kode like '%" + cari + "%' or Divisi like '%" + cari + "%' or Nama like '%" + cari + "%' or Alamat like '%" + cari + "%' or Agama like '%" + cari + "%' or TTL like '%" + cari + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchdetail(cari As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode,c.Kode as Entri,d.Kedatangan, c.Diterima,d.Kode as No, d.Nama as Pasien, e.Nama as Dokter,b.Nama as Kasir,c.Pembayaran from detail a inner join petugas b inner join pembayaran c inner join pasien d inner join dokter e where a.Pembayaran = c.Kode And b.Kode = c.Petugas and c.Pasien=d.Kode and d.Ditangani=e.Kode and (a.Kode like '%" + cari + "%' or c.Diterima like '%" + cari + "%' or d.Nama like '%" + cari + "%' or e.Nama like '%" + cari + "%' or b.Nama like '%" + cari + "%' or c.Pembayaran like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function searchinap(cari As String) As DataTable
        tabel = New DataTable
        _query = "select c.Kode as Kode, a.Nama as Nama,b.Nama as Ditangani, a.Alamat, a.Agama, a.TTL, a.Kedatangan, a.Keluhan,c.Ruang from pasien a inner join dokter b inner join inap c where a.Ditangani=b.Kode and a.Kode=c.Pasien and (a.Kode like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%' or c.Ruang like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
    Public Overloads Function searchinap(cari As String, b As String) As DataTable
        tabel = New DataTable
        _query = "select c.Kode,a.Nama,b.Nama as Ditangani,a.Alamat,a.Agama,a.TTL,a.Kedatangan,a.Keluhan,c.ruang from pasien a inner join dokter b inner join inap c where a.Kode not in(select Pasien from pembayaran) and a.Ditangani=b.Kode and a.Kode=c.Pasien and (c.Kode like '%" + cari + "%' or a.Nama like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%' or c.Ruang like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
    Public Function searchpengunjung(cari As String) As DataTable
        tabel = New DataTable
        _query = "select Kode , Nama ,Keperluan,Email from pengunjung where Kode like '%" + cari + "%' or Nama like '%" + cari + "%' or Keperluan like '%" + cari + "' or Email like '%" + cari + "' or Komentar like '%" + cari + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
End Class