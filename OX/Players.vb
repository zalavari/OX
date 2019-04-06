Public Class Player
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _id As Integer
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Private Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Amőba As Amoba
    Sub New(ByRef _amoba As Amoba, _id As Integer)
        Id = _id
        Amőba = _amoba
    End Sub

    Public Overridable Function RakjonIde() As Point

    End Function
End Class


Public Class Human
    Inherits Player

    Public Sub New(ByRef _amoba As Amoba, _id As Integer)
        MyBase.New(_amoba, _id)
    End Sub

    Public Overrides Function RakjonIde() As Point
        Offline.Rakhat = True
        While Offline.Rakhat
            Application.DoEvents()
        End While
        Return New Point(Offline.RakottX, Offline.RakottY)
    End Function
End Class

Public Class Computer
    Inherits Player
    Dim Esély(,) As Integer
    Dim I, J As Integer

    Public Sub New(ByRef _amoba As Amoba, _id As Integer)
        MyBase.New(_amoba, _id)
        ReDim Esély(Amőba.MaxX, Amőba.MaxY)
        For I = 0 To Amőba.MaxX 'oszlopban lévő helyt meghatározó index            sort megadó
            For J = 0 To Amőba.MaxY 'sorban lévő helyt meghatározó index
                Esély(I, J) = 0
            Next
        Next
    End Sub


    Public Overrides Function RakjonIde() As Point

        'A helyek értékelése
        Dim Ellenség As Integer
        For Lépés = 0 To (Amőba.Játékmód - 1) * Amőba.Játékosok
            If Lépés Mod 2 = 0 Then
                Megfelelőhely(Amőba.Játékmód - 1 - (Lépés \ 2), Id, True)
            Else
                Ellenség = Id
                For w = 1 To Amőba.Játékosok - 1
                    Amőba.Léptet(Ellenség)
                    Megfelelőhely(Amőba.Játékmód - 1 - (Lépés \ 2), Ellenség, False)
                Next
            End If
        Next

        'A legértékesebb helyek közül választás
        Dim q As Integer = 0
        Dim EsélyesHelyX(100000) As Integer
        Dim EsélyesHelyY(100000) As Integer
        Dim Max As Integer = -1
        For I = 0 To Amőba.MaxX
            For J = 0 To Amőba.MaxY
                If Amőba.Elem(I, J) = 0 Then
                    Select Case Esély(I, J)
                        Case Is > Max
                            Max = Esély(I, J)
                            q = 0
                            EsélyesHelyX(q) = I
                            EsélyesHelyY(q) = J
                        Case Is = Max
                            q += 1
                            EsélyesHelyX(q) = I
                            EsélyesHelyY(q) = J
                    End Select
                    Esély(I, J) = 0
                End If
            Next
        Next

        Dim Véletlenszám As New Random
        Dim Mem As Integer = Véletlenszám.Next(q + 1)
        Return New Point(EsélyesHelyX(Mem), EsélyesHelyY(Mem))

    End Function

    Private Sub Megfelelőhely(ByVal Mennyi As Integer, ByVal Mi As Integer, ByVal Saját As Boolean) 'Mi=MiVegyeKörül
        Dim o, p, l, m, n As Integer

        I = 0
        Do
            J = 0
            Do
                If Amőba.Elem(I, J) = 0 Then
                    l = 0
                    Do
                        n = 0
                        m = 0 - Mennyi
                        l += 1
                        If Lehet(l, Mi) Then
                            Do
                                Select Case l
                                    Case 1
                                        p = m
                                        o = 0
                                    Case 2
                                        o = m
                                        p = 0
                                    Case 3
                                        p = m
                                        o = m
                                    Case 4
                                        p = m
                                        o = 0 - m
                                End Select
                                If (I + o <= Amőba.MaxX And I + o >= 0 And J + p <= Amőba.MaxY And J + p >= 0) AndAlso Amőba.Elem(I + o, J + p) = Mi Then
                                    n += 1
                                Else
                                    n = 0
                                End If
                                m += 1
                                If m = 0 Then
                                    m += 1
                                End If
                            Loop While m <= Mennyi And n < Mennyi
                            If (n >= Mennyi) Then
                                Esély(I, J) += Pontja(l, Mi, Mennyi, Saját)
                            End If
                        End If
                    Loop While l < 4


                End If
                J += 1
            Loop While J <= Amőba.MaxY
            I += 1
        Loop While I <= Amőba.MaxX

    End Sub

    Private Function Lehet(ByVal l As Integer, ByVal Mi As Integer) As Boolean 'Mi=MiVegyeKörül
        Dim o, p, m, n As Integer
        n = 0
        m = 0 - Amőba.Játékmód
        Do
            Select Case l
                Case 1
                    p = m
                    o = 0
                Case 2
                    o = m
                    p = 0
                Case 3
                    p = m
                    o = m
                Case 4
                    p = m
                    o = 0 - m
            End Select
            If I + o <= Amőba.MaxX AndAlso I + o >= 0 AndAlso J + p <= Amőba.MaxY AndAlso J + p >= 0 AndAlso (Amőba.Elem(I + o, J + p) = Mi Or Amőba.Elem(I + o, J + p) = 0) Then
                n += 1
            Else
                n = 0
            End If
            m += 1
            If m = 0 Then
                m += 1
            End If
        Loop While m <= Amőba.Játékmód And n < Amőba.Játékmód - 1
        Lehet = (n >= Amőba.Játékmód - 1)
    End Function

    Private Function Pontja(ByVal l As Integer, ByVal Mi As Integer, ByVal Mennyi As Integer, ByVal Saját As Boolean) As Integer

        Dim Osztályzat() As Integer = {0, 0}
        Dim Akadálybaütközött() As Boolean = {False, False}
        Dim Falbaütközött() As Boolean = {False, False}
        Dim o, p, m, Szorzó As Integer
        If Saját Then
            Szorzó = 2
        Else
            Szorzó = 1
        End If
        m = 1
        Do
            Select Case l
                Case 1
                    p = m
                    o = 0
                Case 2
                    o = m
                    p = 0
                Case 3
                    p = m
                    o = m
                Case 4
                    p = m
                    o = 0 - m
            End Select
            If Not Akadálybaütközött(0) And Not Falbaütközött(0) Then
                If I + o <= Amőba.MaxX And J + p <= Amőba.MaxY And I + o >= 0 Then
                    If Amőba.Elem(I + o, J + p) = Mi Then
                    ElseIf Amőba.Elem(I + o, J + p) = 0 Then
                        Osztályzat(0) += 1
                    Else
                        Akadálybaütközött(0) = True
                    End If
                Else
                    Falbaütközött(0) = True
                End If
            End If

            If Not Akadálybaütközött(1) And Not Falbaütközött(1) Then
                If I - o >= 0 And J - p >= 0 And I - o <= Amőba.MaxX Then
                    If Amőba.Elem(I - o, J - p) = Mi Then
                    ElseIf Amőba.Elem(I - o, J - p) = 0 Then
                        Osztályzat(1) += 1
                    Else
                        Akadálybaütközött(1) = True
                    End If
                Else
                    Falbaütközött(1) = True
                End If
            End If
            m += 1
        Loop Until (Akadálybaütközött(0) Or Falbaütközött(0)) And (Falbaütközött(1) Or Akadálybaütközött(1))

        'If Osztályzat.Sum >= Játékmód - Mennyi Then
        '    'Lehet
        'End If

        If Osztályzat(0) >= 1 And Osztályzat(1) >= 1 Then
            'legjobb
            Pontja = 10 ^ Mennyi * 4 * Szorzó
        ElseIf Osztályzat(0) < 1 And Falbaütközött(0) Or Osztályzat(1) < 1 And Falbaütközött(1) Then
            'legroszabb
            Pontja = 10 ^ Mennyi * 2 * Szorzó
        Else
            'közepes
            Pontja = 10 ^ Mennyi * 3 * Szorzó
        End If
    End Function

End Class

