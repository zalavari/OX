Public Class Amoba
    Public ReadOnly EmberiJátékos(4) As Player

    Public ReadOnly Elem(,) As Integer
    Public ReadOnly MaxX, MaxY As Integer
    Public MemI, MemJ As Integer
    Public UtolsóLépésI, UtolsóLépésJ As Integer
    Public Voltlépés As Boolean
    Public Találat As String
    Public EndGame As Boolean = False

    Public ReadOnly Játékosok As Integer
    Public ReadOnly Játékmód As Integer
    Private _kovetkezo As Integer
    Public Property Következő() As Integer
        Get
            Return _kovetkezo
        End Get
        Private Set(ByVal value As Integer)
            _kovetkezo = value
        End Set
    End Property


    Private I, J As Integer

    Sub New(ByVal TMaxX As Integer, ByVal TMaxY As Integer, ByVal TJátékosok As Integer, ByVal TJátékmód As Integer)
        MaxX = TMaxX
        MaxY = TMaxY
        Játékosok = TJátékosok
        Játékmód = TJátékmód
        MemI = 0 : MemJ = 0
        Voltlépés = False
        EndGame = False
        Találat = ""

        ReDim Elem(MaxX, MaxY)
        ReDim Esély(MaxX, MaxY)
        For I = 0 To MaxX 'oszlopban lévő helyt meghatározó index            sort megadó
            For J = 0 To MaxY 'sorban lévő helyt meghatározó index
                Elem(I, J) = 0
                Esély(I, J) = 0
            Next
        Next

    End Sub

    Sub Initialize(TempEmberiJatekos() As String, JatekosNev() As String)

        For asd = 0 To 4
            If TempEmberiJatekos(asd) = 0 Then
                EmberiJátékos(asd) = New Human(Me, asd)
            Else
                EmberiJátékos(asd) = New Computer(Me, asd)
            End If
            EmberiJátékos(asd).Name = JatekosNev(asd)

        Next
    End Sub

    Sub JátékStart(kezdő As Integer)
        Következő = kezdő
        Offline.ReDraw()
        While (Not EndGame)
            Lép(Következő)

            EndGame = EredményKeresés(Következő)

            If (Not EndGame) Then Léptet(Következő)

            Offline.ReDraw()
        End While

    End Sub

    Private Sub Rakás(ByVal I As Integer, ByVal J As Integer, ByVal Mit As Integer)
        If Elem(I, J) = 0 Then
            Elem(I, J) = Mit
            Voltlépés = True
            UtolsóLépésI = I
            UtolsóLépésJ = J
        End If
    End Sub

    Private Sub Lép(r As Integer)
        Dim p As Point = EmberiJátékos(r).RakjonIde()
        Rakás(p.X, p.Y, r)
        Application.DoEvents()

    End Sub

    Private Function EredményKeresés(ByVal UtoljáraTett As Integer) As Boolean

        Találat = Keres(Játékmód, UtoljáraTett)
        If Találat = "" AndAlso Keres(1, 0) = "" Then
            Találat = "Betelt!"
        End If

        Return Találat <> ""
    End Function

    Private Function Keres(ByVal Mennyit As Integer, ByVal Mit As Integer) As String
        Dim Szám, K As Integer
        Keres = ""
        Szám = 0
        For I = 0 To MaxX
            Szám = 0
            For J = 0 To MaxY
                If Elem(I, J) = Mit Then
                    Szám += 1
                    If Szám >= Mennyit Then 'And (J + 1 <= OX.GetUpperBound(1) AndAlso OX(I, J + 1).Elem = "" Or J - Mennyit >= 0 AndAlso OX(I, J - Mennyit).Elem = "") Then
                        Keres = "Függőleges"
                        MemI = I
                        MemJ = J
                        Exit Function
                    End If
                Else
                    Szám = 0
                End If
            Next
        Next

        Szám = 0
        For J = 0 To MaxY
            Szám = 0
            For I = 0 To MaxX
                If Elem(I, J) = Mit Then
                    Szám += 1
                    If Szám >= Mennyit Then 'And (Not RakásMiatt Or (I + 1 <= OX.GetUpperBound(0) AndAlso OX(I + 1, J).Elem = "" Or I - Mennyit >= 0 AndAlso OX(I - Mennyit, J).Elem = "")) Then
                        Keres = "Vízszintes"
                        MemI = I
                        MemJ = J
                        Exit Function
                    End If
                Else
                    Szám = 0
                End If
            Next
        Next

        Szám = 0
        For I = 0 To MaxX
            For J = 0 To MaxY
                Szám = 0
                K = 0
                Do While I + K <= MaxX And J + K <= MaxY AndAlso Szám < Mennyit
                    If Elem(I + K, J + K) = Mit Then
                        Szám += 1

                        If Szám >= Mennyit Then 'And (Not RakásMiatt Or (I + K + 1 <= OX.GetUpperBound(0) And J + K + 1 <= OX.GetUpperBound(1) AndAlso OX(I + K + 1, J + K + 1).Elem = "") Or (I + K - Mennyit >= 0 And J + K - Mennyit >= 0 AndAlso OX(I + K - Mennyit, J + K - Mennyit).Elem = "")) Then
                            Keres = "BJ átlós"
                            MemI = I + K
                            MemJ = J + K
                            Exit Function
                        End If
                    Else
                        Szám = 0
                    End If
                    K += 1
                Loop
            Next
        Next

        Szám = 0
        For I = 0 To MaxX
            For J = Mennyit - 1 To MaxY
                K = 0
                Szám = 0
                Do While I + K <= MaxX And J - K >= 0 AndAlso Szám < Mennyit
                    If Elem(I + K, J - K) = Mit Then
                        Szám += 1
                        'IndexOutOfRangeException is unhandled!!!
                        If Szám >= Mennyit Then 'AndAlso (Not RakásMiatt Or (I + K + 1 > 0 AndAlso I + K + 1 <= OX.GetUpperBound(0) AndAlso J - K - 1 <= OX.GetUpperBound(1) AndAlso OX(I + K + 1, J - K - 1).Elem = "") Or (I + K - Mennyit >= 0 AndAlso J - K + Mennyit <= OX.GetUpperBound(1) AndAlso OX(I + K - Mennyit, J - K + Mennyit).Elem = "")) Then
                            Keres = "JB átlós"
                            MemI = I + K
                            MemJ = J - K
                            Exit Function
                        End If
                    Else
                        Szám = 0
                    End If
                    K += 1
                Loop
            Next
        Next
    End Function

    Public Sub Léptet(ByRef Index As Integer)
        If Index + 1 > Játékosok Then
            Index = 1
        Else
            Index += 1
        End If
    End Sub
End Class
