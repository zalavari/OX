Imports System.Drawing
Public Class Offline

    'SCROLLBARS
    Dim XScrollBar As New HScrollBar
    Dim YScrollBar As New VScrollBar

    'GAME CONTROL
    Public Amőba As Amoba
    Public Rakhat As Boolean = False
    Dim Kezdő As Integer = 0
    Public RakottX, RakottY As Integer

    ' GRAPHICS VARIABLES
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim bmpTile As Bitmap
    Dim sRect, dRect As Rectangle

    ' MAP VARIABLES
    Dim ResWidth, ResHeight As Integer
    Dim TileSize As Integer = 30
    Dim SkinTileSize As Integer = 30
    Dim MapX, MapY As Integer
    Dim FixX, FixY As Integer
    Dim FixPxX, FixPxY As Integer
    Dim Szélén, Alján As Integer

    'Mouse locations
    Dim mouseX, mouseY As Integer
    Dim mMapX, mMapY As Integer

#Region "Kinézet"
    Sub SetLastPos()
        If Not JátékKövetéseToolStripMenuItem.Checked Then Return

        If Amőba.UtolsóLépésI < MapX Then MapX = Amőba.UtolsóLépésI
        If Amőba.UtolsóLépésJ < MapY Then MapY = Amőba.UtolsóLépésJ
        If Amőba.UtolsóLépésI > MapX + FixX Then MapX = Amőba.UtolsóLépésI - FixX
        If Amőba.UtolsóLépésJ > MapY + FixY Then MapY = Amőba.UtolsóLépésJ - FixY
        XScrollBar.Value = MapX
        YScrollBar.Value = MapY
    End Sub

    Sub KontrolBeáll()
        Me.BackColor = Color.Wheat

        bmpTile = New Bitmap(My.Resources.skin)

        ToolStripStatusLabel1.Text = "X: " & "-" & "  Y: " & "-"
        ToolStripStatusLabel2.Text = "Utolsó lépés: X: " & "-" & "  Y: " & "-"
        JátékKövetéseToolStripMenuItem.Checked = My.Settings.JátékKövetése

        XScrollBar.Left = 0
        XScrollBar.SmallChange = 1
        XScrollBar.LargeChange = 5
        XScrollBar.Minimum = 0
        YScrollBar.Top = 24
        YScrollBar.SmallChange = 1
        YScrollBar.LargeChange = 5
        YScrollBar.Minimum = 0
        AddHandler XScrollBar.Scroll, AddressOf XScrollBar_Scroll
        AddHandler YScrollBar.Scroll, AddressOf YScrollBar_Scroll
        Me.Controls.Add(XScrollBar)
        Me.Controls.Add(YScrollBar)

        Szélén = 160
        Alján = 102
        Me.MinimumSize = New Size(Szélén + 2 * TileSize, Alján + 2 * TileSize)

    End Sub
    Sub KontrolHangol()

        MaxX = Amőba.MaxX
        MaxY = Amőba.MaxY

        FixY = (Me.Height - Alján) \ TileSize - 1
        FixX = (Me.Width - Szélén) \ TileSize - 1
        If MaxY < FixY Then FixY = MaxY
        If MaxX < FixX Then FixX = MaxX
        YScrollBar.Visible = FixY < MaxY
        XScrollBar.Visible = FixX < MaxX
        FixPxY = TileSize * (FixY + 1)
        FixPxX = TileSize * (FixX + 1)
        ResHeight = Me.Height - 24
        ResWidth = Me.Width

        BB = New Bitmap(ResWidth, ResHeight)
        If FixY + MapY > MaxY Then MapY = MaxY - FixY
        If FixX + MapX > MaxX Then MapX = MaxX - FixX

        XScrollBar.Width = FixPxX
        XScrollBar.Top = FixPxY + 24
        XScrollBar.Maximum = MaxX - FixX + XScrollBar.LargeChange - 1
        XScrollBar.Value = MapX
        YScrollBar.Height = FixPxY
        YScrollBar.Left = FixPxX
        YScrollBar.Maximum = MaxY - FixY + YScrollBar.LargeChange - 1
        YScrollBar.Value = MapY
    End Sub

    Private Sub DrawGraphics()

        Dim Játékmód As Integer = Amőba.Játékmód

        ' COPY BACKBUFFER TO GRAPHICS OBJECT
        G = Graphics.FromImage(BB)

        ' FIX OVERDRAW
        G.Clear(Color.Wheat)
        Dim Toll As New Pen(Brushes.YellowGreen, 2)

        'DRAW TILES
        For X = 0 To FixX
            For Y = 0 To FixY
                sRect = GetSourceRect(MapX + X, MapY + Y, TileSize, TileSize)

                dRect = New Rectangle((X * TileSize), (Y * TileSize), TileSize, TileSize)

                G.DrawImage(bmpTile, dRect, sRect, GraphicsUnit.Pixel)
            Next
        Next

        If Amőba.Voltlépés Then 'utolsó lépés
            G.DrawRectangle(Toll, (Amőba.UtolsóLépésI - MapX) * TileSize, (Amőba.UtolsóLépésJ - MapY) * TileSize, TileSize, TileSize)
            ToolStripStatusLabel2.Text = "Utolsó lépés: X: " & Amőba.UtolsóLépésI & "  Y: " & Amőba.UtolsóLépésJ
        Else
            ToolStripStatusLabel2.Text = "Utolsó lépés: X: " & "-" & "  Y: " & "-"
        End If

        If Amőba.EndGame Then 'Csík rajzolása
            Dim x1, x2, y1, y2 As Single
            Select Case Amőba.Találat
                Case "Függőleges"
                    x1 = (Amőba.MemI - MapX + 0.5) * TileSize : y1 = (Amőba.MemJ - MapY + 1) * TileSize : x2 = x1 : y2 = y1 - Játékmód * TileSize
                Case "Vízszintes"
                    x1 = (Amőba.MemI - MapX + 1) * TileSize : y1 = (Amőba.MemJ - MapY + 0.5) * TileSize : x2 = x1 - Játékmód * TileSize : y2 = y1
                Case "BJ átlós"
                    x1 = (Amőba.MemI - MapX + 1) * TileSize : y1 = (Amőba.MemJ - MapY + 1) * TileSize : x2 = x1 - Játékmód * TileSize : y2 = y1 - Játékmód * TileSize
                Case "JB átlós"
                    x1 = (Amőba.MemI - MapX + 1) * TileSize : y1 = (Amőba.MemJ - MapY) * TileSize : x2 = x1 - Játékmód * TileSize : y2 = y1 + Játékmód * TileSize
            End Select
            Toll.Brush = Brushes.Black
            Toll.Width = 5
            G.DrawLine(Toll, x1, y1, x2, y2)
        End If

        'Tábla körüli terület lefedése
        Dim Rect As New Rectangle(FixPxX, 0, Szélén + 20, FixPxY)
        G.FillRectangle(Brushes.Wheat, Rect)
        Rect = New Rectangle(0, FixPxY, ResWidth, Alján)
        G.FillRectangle(Brushes.Wheat, Rect)

        'Infók, következő, stb.
        Dim Szoveg As String = ""
        If Amőba.Találat = "Betelt!" Then
            Szoveg = "Döntetlen, betelt a tábla!"
        Else
            Dim p As Player = Amőba.EmberiJátékos(Amőba.Következő)
            If Not Amőba.EndGame And Amőba.Voltlépés Then
                Szoveg = "Következő: " & p.Name
            ElseIf Not Amőba.EndGame Then
                Szoveg = "A játékot kezdi: " & p.Name
            Else
                Szoveg = "Nyertes: " & p.Name
            End If
            sRect = New Rectangle(SkinTileSize * (Amőba.Következő - 1), 0, SkinTileSize, SkinTileSize)
            dRect = New Rectangle(FixPxX + 20, TileSize * 1, TileSize, TileSize)
            G.DrawImage(bmpTile, dRect, sRect, GraphicsUnit.Pixel)
        End If

        G.DrawString(vbCrLf & Szoveg, Me.Font, Brushes.Black, FixPxX + 20, 0)



        ' DRAW BACKBUFFER TO SCREEN
        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 24, ResWidth, ResHeight)


    End Sub
    Private Function GetSourceRect(ByVal X As Integer, ByVal Y As Integer, ByVal w As Integer, ByVal h As Integer) As Rectangle
        Select Case Amőba.Elem(X, Y)
            Case 0 'KERET
                GetSourceRect = New Rectangle(0, 60, SkinTileSize, SkinTileSize)
            Case Is > 0 'EGYÉB
                GetSourceRect = New Rectangle(SkinTileSize * (Amőba.Elem(X, Y) - 1), 0, SkinTileSize, SkinTileSize)
        End Select
    End Function


#End Region

#Region "Játék vezérlés"


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KontrolBeáll()

        Me.Show()
        Me.Focus()

        'ÚjJátékStart()
        Try
            Invoke(New MethodInvoker(AddressOf ÚjJátékStart))
        Catch


        End Try



    End Sub
    Private Sub ÚjJátékToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÚjJátékToolStripMenuItem.Click
        ÚjJátékStart()
    End Sub


    Private Sub ÚjJátékStart()
        Dim Méret() As String = My.MySettings.Default.Méret.Split
        Játékmód = My.Settings.Játékmód
        Dim Játékosok As Integer = My.Settings.Játékosok
        Dim TempEmberiJátékos() As String = My.Settings.EmberiJátékos.Split(" ")
        Dim JátékosNév() As String = My.Settings.JátékosNév.Split("|")

        MaxX = Méret(0) - 1 'Mentett játék beolvasása
        MaxY = Méret(1) - 1
        Amőba = New Amoba(MaxX, MaxY, Játékosok, Játékmód)
        Amőba.Initialize(TempEmberiJátékos, JátékosNév)

        KontrolHangol()

        Amőba.Léptet(Kezdő)
        Amőba.JátékStart(Kezdő)

    End Sub

    Public Sub ReDraw()
        SetLastPos()
        DrawGraphics()
    End Sub

    Private Sub Emberlépés(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Rakhat Then
            If mouseX <= FixX And mouseY <= FixY Then
                If Amőba.Elem(mMapX, mMapY) = 0 Then
                    Rakhat = False
                    RakottX = mMapX
                    RakottY = mMapY
                End If
            End If
        End If
    End Sub
#End Region

#Region "Felhasználói felület"
    Private Sub XScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        MapX = e.NewValue
        DrawGraphics()
    End Sub

    Private Sub Offline_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        DrawGraphics()
    End Sub

    Private Sub YScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        MapY = e.NewValue
        DrawGraphics()
    End Sub

    Private Sub Offline_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Amőba IsNot Nothing Then
            KontrolHangol()
        End If


    End Sub

    Private Sub Offline_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        mouseX = Math.Floor(e.X / TileSize)
        mouseY = Math.Floor((e.Y - 24) / TileSize)

        mMapX = MapX + mouseX
        mMapY = MapY + mouseY

        If mouseX <= FixX And mouseY <= FixY Then
            ToolStripStatusLabel1.Text = "X: " & mMapX & "  Y: " & mMapY
        Else
            ToolStripStatusLabel1.Text = "X: " & "-" & "  Y: " & "-"
        End If

    End Sub
    Private Sub Offline_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        ToolStripStatusLabel1.Text = "X: " & "-" & "  Y: " & "-"
    End Sub

    Private Sub Offline_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Try
            If My.Computer.Keyboard.ShiftKeyDown Then
                If e.Delta > 0 Then
                    XScrollBar.Value -= 1
                    MapX -= 1
                ElseIf XScrollBar.Value <= XScrollBar.Maximum - XScrollBar.LargeChange Then
                    XScrollBar.Value += 1
                    MapX += 1
                End If
            ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                If e.Delta < 0 Then
                    If TileSize > 5 Then TileSize -= 1
                ElseIf XScrollBar.Value <= XScrollBar.Maximum - XScrollBar.LargeChange Then
                    TileSize += 1
                End If
                KontrolHangol()

            Else

                If e.Delta > 0 Then
                    YScrollBar.Value -= 1
                    MapY -= 1
                ElseIf YScrollBar.Value <= YScrollBar.Maximum - YScrollBar.LargeChange Then
                    YScrollBar.Value += 1
                    MapY += 1
                End If
            End If
            DrawGraphics()
            OnMouseMove(e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BeállításokToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PályaméretMegváltoztatásaToolStripMenuItem.Click
        beallitasok.Show()
    End Sub

    Private Sub JátékKövetéseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JátékKövetéseToolStripMenuItem.Click
        If Amőba.Voltlépés And JátékKövetéseToolStripMenuItem.Checked Then SetLastPos() : DrawGraphics()
        My.Settings.JátékKövetése = JátékKövetéseToolStripMenuItem.Checked
    End Sub
#End Region

    Private Sub NévjegyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NévjegyToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

End Class