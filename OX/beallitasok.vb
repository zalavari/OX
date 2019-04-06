Public Class beallitasok
    Dim Címke(4) As LinkLabel
    Public JátékosNév() As String
    Public EmberiJátékos() As String
    Private Sub gamers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AcceptButton = Button1
        CancelButton = Button2
        Dim Temp() As String
        Temp = My.Settings.Méret.Split(" ")
        TextBox7.Text = Temp(0)
        TextBox8.Text = Temp(1)
        Címke(1) = LinkLabel1
        Címke(2) = LinkLabel2
        Címke(3) = LinkLabel3
        Címke(4) = LinkLabel4

        For asd = 1 To 4
            AddHandler Címke(asd).Click, AddressOf Választása
        Next

        LinkLabel3.Enabled = False
        LinkLabel4.Enabled = False
        NumericUpDown1.Value = My.Settings.Játékosok
        NumericUpDown2.Value = My.Settings.Játékmód
        If NumericUpDown1.Value >= 3 Then
            LinkLabel3.Enabled = True
        End If
        If NumericUpDown1.Value >= 4 Then
            LinkLabel4.Enabled = True
        End If

        JátékosNév = My.Settings.JátékosNév.Split("|")
        EmberiJátékos = My.Settings.EmberiJátékos.Split(" ")

        Frissít()
    End Sub

    Sub Frissít()
        
        Dim IsEmber As String
            For asd = 1 To 4
                If EmberiJátékos(asd) = 0 Then
                    IsEmber = " (ember)"
                Else
                    IsEmber = " (számítógép)"
                End If
                Címke(asd).Text = asd & ". játékos: " & JátékosNév(asd) & IsEmber
            Next
    End Sub
    Sub Választása(ByVal sender As System.Object, ByVal e As System.EventArgs)
        valaszt.Hányadikjátékos = sender.name.replace("LinkLabel", "")
        valaszt.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Játékosok = NumericUpDown1.Value
        My.Settings.Játékmód = NumericUpDown2.Value
        If My.Settings.Méret <> TextBox7.Text & " " & TextBox8.Text Then
            My.Settings.Méret = TextBox7.Text & " " & TextBox8.Text
        End If
        Dim Szöveg As String = ""
        For asd = 0 To 3
            Szöveg &= EmberiJátékos(asd) & " "
        Next
        My.Settings.EmberiJátékos = Szöveg & EmberiJátékos(4)


        Szöveg = ""
        For asd = 0 To 3
            Szöveg &= JátékosNév(asd) & "|"
        Next
        My.Settings.JátékosNév = Szöveg & JátékosNév(4)

        Me.Close()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Select Case NumericUpDown1.Value
            Case Is = 2
                LinkLabel3.Enabled = False
                LinkLabel4.Enabled = False
            Case Is = 3
                LinkLabel3.Enabled = True
                LinkLabel4.Enabled = False
            Case Is = 4
                LinkLabel3.Enabled = True
                LinkLabel4.Enabled = True
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox7_LostFocus(sender As Object, e As EventArgs) Handles TextBox7.LostFocus
        If IsNumeric(TextBox7.Text) Then
            If TextBox7.Text > 100 Then
                TextBox7.Text = 100
            ElseIf TextBox7.Text < NumericUpDown2.Value Then
                TextBox7.Text = NumericUpDown2.Value
            End If
        Else
            TextBox7.Text = 20
        End If
    End Sub

    Private Sub TextBox8_LostFocus(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        If IsNumeric(TextBox8.Text) Then
            If TextBox8.Text > 100 Then
                TextBox8.Text = 100
            ElseIf TextBox8.Text < NumericUpDown2.Value Then
                TextBox8.Text = NumericUpDown2.Value
            End If
        Else
            TextBox8.Text = 20
        End If
    End Sub

   
    Private Sub TextBox7_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Click, TextBox8.Click
        TextBox7.SelectionStart = 0
        TextBox7.SelectionLength = TextBox7.Text.Length
        TextBox8.SelectionStart = 0
        TextBox8.SelectionLength = TextBox7.Text.Length
    End Sub


End Class