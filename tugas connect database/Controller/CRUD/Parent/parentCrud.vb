Public Class parentCrud
    Inherits koneksi
    Private code As String
    Protected _query, str, str2 As String
    Protected tabel As DataTable
    Protected banyak As Integer
    Protected bukti As Boolean
    Public bool As Boolean
    Protected Property parentcode() As String
        Get
            Return code
        End Get
        Set(value As String)
            code = value
        End Set
    End Property
End Class
