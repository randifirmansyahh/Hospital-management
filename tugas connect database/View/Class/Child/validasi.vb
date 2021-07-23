Public Class validasi
    Inherits classParent
    Public Function cekspasiawal(a As String)
        Try
            a.Split()
            If a(0) = " " Then
                a = ""
            End If
        Catch ex As Exception
        End Try
        Return a
    End Function
    Public Function cekdoublespasi(a As String)
        kaku = a
        kaki = ""
        Try
            kaku.Split()
            For i = 0 To a.Length - 1
                If kaku(i) = " " And kaku(i + 1) = " " Then
                    For j = 0 To i
                        kaki += kaku(j)
                    Next
                    a = kaki
                Else
                    a.Split()
                    If a(0) = " " Then
                        kaki = ""
                        For j = 1 To a.Length - 1
                            kaki += a(j)
                        Next
                        a = kaki
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
        Return a
    End Function

    Public Function cekkosong(a As String) As Boolean
        hasilvalidasi = False
        If a = "" Then
            hasilvalidasi = False
        Else
            hasilvalidasi = True
        End If
        Return hasilvalidasi
    End Function

    Public Function satuhuruf(a As String) As Boolean
        If a.Length = 1 Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function
End Class