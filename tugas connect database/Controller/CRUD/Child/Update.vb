Imports MySql.Data.MySqlClient
Public Class Update
    Inherits parentCrud
    Public Property ambilsok() As String
        Get
            Return parentcode()
        End Get
        Set(value As String)
            parentcode = value
        End Set
    End Property
    Public Overloads Function updateinaporpembayaran(kode As String, petugas As String, diterima As String, harga As Integer)
        'pembayaran
        _query = "update pembayaran set Petugas=@petugas,Diterima=@diterima,Pembayaran=@harga where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@petugas", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = petugas
            cmd_b.Parameters.Add("@diterima", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = diterima
            cmd_b.Parameters.Add("@harga", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = harga
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
            bool = False
        End Try
        Return bool
    End Function
    Public Overloads Function updateinaporpembayaran(kode As String, ruang As String)
        'inap
        _query = "update inap set Ruang=@ruang where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@ruang", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = ruang
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Function updatepengunjung(kode As String, email As String, komentar As String)
        'pengunjung
        _query = "update pengunjung set Email=@email,Komentar=@komentar where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = email
            cmd_b.Parameters.Add("@komentar", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = komentar
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function

    Public Overloads Function updatepasienordokter(kode As String, jenis As String, nama As String, alamat As String, agama As String, TTL As String)
        'dokter
        _query = "update dokter set Jenis=@jenis,Nama=@nama,Alamat=@alamat,Agama=@agama,TTL=@TTL where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@jenis", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = jenis
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@alamat", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = alamat
            cmd_b.Parameters.Add("@agama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = agama
            cmd_b.Parameters.Add("@TTL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = TTL
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function updatepasienordokter(kode As String, ditangani As String, nama As String, alamat As String, agama As String, TTL As String, kedatangan As String, keluhan As String)
        'pasien
        _query = "update pasien set Ditangani=@ditangani,Nama=@nama,Alamat=@alamat,Agama=@agama,TTL=@TTL,Kedatangan=@kedatangan,Keluhan=@keluhan where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@ditangani", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = ditangani
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@alamat", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = alamat
            cmd_b.Parameters.Add("@agama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = agama
            cmd_b.Parameters.Add("@TTL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = TTL
            cmd_b.Parameters.Add("@kedatangan", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = kedatangan
            cmd_b.Parameters.Add("@keluhan", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = keluhan
            cmd_b.ExecuteNonQuery()
            bool = True
            MsgBox("Data Pasien Berhasil Diupdate")
        Catch ex As Exception
            MsgBox("Gagal mengupdate Pasien")
        End Try
        Return bool
    End Function
    Public Overloads Function updateopereatororpetugas(kode As String, divisi As String, nama As String, alamat As String, agama As String, TTL As String)
        'petugas
        _query = "update petugas set Divisi=@divisi,Nama=@nama,Alamat=@alamat,Agama=@agama,TTL=@TTL where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@divisi", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = divisi
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@alamat", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = alamat
            cmd_b.Parameters.Add("@agama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = agama
            cmd_b.Parameters.Add("@TTL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = TTL
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Data Petugas Gagal Di Update")
        End Try
        Return bool
    End Function
    Public Overloads Function updateopereatororpetugas(username As String, password As String, email As String)
        'operator
        _query = "update operator set Username=@username,Password=@password,Email=@email where Username='" + username + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@username", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = username
            cmd_b.Parameters.Add("@password", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = password
            cmd_b.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = email
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function updateberitaordetail(kode As String, dokter As String, pasien As String, pembayaran As String, petugas As String, inap As String)
        'detail
        _query = "update detail set Dokter=@dokter,Pasien=@pasien,Pembayaran=@pembayaran,Petugas=@petugas,Inap=@inap where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@dokter", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = dokter
            cmd_b.Parameters.Add("@pasien", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = pasien
            cmd_b.Parameters.Add("@pembayaran", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = pembayaran
            cmd_b.Parameters.Add("@petugas", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = petugas
            cmd_b.Parameters.Add("@inap", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = inap
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function updateberitaordetail(kode As String, judul As String, isi As String, foto As String) As Boolean
        _query = "update berita set Judul=@judul,Isi=@isi,Foto=@foto where Kode='" + kode + "'"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@judul", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = judul
            cmd_b.Parameters.Add("@isi", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = isi
            cmd_b.Parameters.Add("@foto", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = foto
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
End Class