Public Class Create
    Inherits parentCrud
    Private search As New Search
    Private check As New Check

    Public Function pengunjung(nama As String, keperluan As String, email As String, komentar As String) As String
        'pengunjung
        _query = "insert into pengunjung values(@kode,@nama,@keperluan,@email,@komentar)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            str = "PNJ" + nomormaxbaru("pengunjung")
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = str
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@keperluan", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = keperluan
            cmd_b.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = email
            cmd_b.Parameters.Add("@komentar", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = komentar
            cmd_b.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return str
    End Function
    Public Function insertberita(Judul As String, Isi As String, Foto As String)
        'berita
        _query = "insert into berita values(@kode,@Judul,@Isi,@Foto)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "BRT" + nomormaxbaru("berita")
            cmd_b.Parameters.Add("@Judul", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Judul
            cmd_b.Parameters.Add("@Isi", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Isi
            cmd_b.Parameters.Add("@Foto", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Foto
            cmd_b.ExecuteNonQuery()
            bukti = True
        Catch ex As Exception
            MsgBox("Failed gaes")
        End Try
        Return bukti
    End Function

    Public Function insertkomentar(email As String, komentar As String)
        'komentar
        _query = "insert into komentar values(@kode,@email,@komentar)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "KMT" + nomormaxbaru("komentar")
            cmd_b.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = email
            cmd_b.Parameters.Add("@komentar", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = komentar
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function

    Public Overloads Function insertinaporpembayaran(petugas As String, pasien As String, diterima As String, harga As Integer)
        'pembayaran
        _query = "insert into pembayaran values(@kode,@petugas,@pasien,@diterima,@harga)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            str = "BYR" + nomormaxbaru("pembayaran")
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = str
            cmd_b.Parameters.Add("@petugas", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = petugas
            cmd_b.Parameters.Add("@pasien", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = pasien
            cmd_b.Parameters.Add("@diterima", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = diterima
            cmd_b.Parameters.Add("@harga", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = harga
            cmd_b.ExecuteNonQuery()
            insertdetail(str)
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function insertinaporpembayaran(pasien As String, ruang As String)
        'inap
        _query = "insert into inap values(@kode,@pasien,@ruang)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "INP" + nomormaxbaru("inap")
            cmd_b.Parameters.Add("@pasien", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = pasien
            cmd_b.Parameters.Add("@ruang", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = ruang
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function insertpasienordokter(jenis As String, nama As String, alamat As String, agama As String, TTL As String)
        'dokter
        _query = "insert into dokter values(@kode,@jenis,@nama,@alamat,@agama,@TTL)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "DTR" + nomormaxbaru("dokter")
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
    Public Overloads Function insertpasienordokter(ditangani As String, nama As String, alamat As String, agama As String, TTL As String, kedatangan As String, keluhan As String)
        'pasien
        _query = "insert into pasien values(@kode,@ditangani,@nama,@alamat,@agama,@TTL,@kedatangan,@keluhan)"
        Try
            bool = False
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "PSN" + nomormaxbaru("pasien")
            cmd_b.Parameters.Add("@ditangani", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = ditangani
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@alamat", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = alamat
            cmd_b.Parameters.Add("@agama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = agama
            cmd_b.Parameters.Add("@TTL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = TTL
            cmd_b.Parameters.Add("@kedatangan", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = kedatangan
            cmd_b.Parameters.Add("@keluhan", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = keluhan
            cmd_b.ExecuteNonQuery()
            bool = True
            MsgBox("Data Pasien telah Ditambahkan")
        Catch ex As Exception
            MsgBox("Gagal Menambahkan Pasien")
        End Try
        Return bool
    End Function
    Public Overloads Function insertopereatororpetugas(divisi As String, nama As String, alamat As String, agama As String, TTL As String)
        'petugas
        _query = "insert into petugas values(@kode,@divisi,@nama,@alamat,@agama,@TTL)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "PTG" + nomormaxbaru("petugas")
            cmd_b.Parameters.Add("@divisi", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = divisi
            cmd_b.Parameters.Add("@nama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = nama
            cmd_b.Parameters.Add("@alamat", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = alamat
            cmd_b.Parameters.Add("@agama", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = agama
            cmd_b.Parameters.Add("@TTL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = TTL
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Petugas Gagal Ditambah")
        End Try
        Return bool
    End Function
    Public Overloads Function insertopereatororpetugas(username As String, password As String, email As String)
        'operator
        _query = "insert into operator values(@username,@password,@email)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@username", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = username
            cmd_b.Parameters.Add("@password", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = password
            cmd_b.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = email
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Failed")
        End Try
        Return bool
    End Function
    Public Overloads Function insertdetail(byr As String)
        'detail
        _query = "insert into detail values(@kode,@byr)"
        Try
            cmd_b = New MySql.Data.MySqlClient.MySqlCommand(_query, openconnection())
            cmd_b.Parameters.Add("@kode", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "DTL" + nomormaxbaru("detail")
            cmd_b.Parameters.Add("@byr", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = byr
            cmd_b.ExecuteNonQuery()
            bool = True
        Catch ex As Exception
            MsgBox("Gagal menambah detail")
        End Try
        Return bool
    End Function
    Public Function autokode(data As String) As String
        Dim a As String = data
        Dim c As String = ""
        If data = "" Then
            c = "1000"
        Else
            a.Split()
            For i As Integer = 3 To a.Length() - 1
                c += a(i)
            Next
        End If
        Return c
    End Function
    Private Function nomormaxbaru(a As String) As String
        str = (Val(autokode(check.checkmax(a))) + 1).ToString
        Return str
    End Function
End Class