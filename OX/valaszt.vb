Public Class valaszt
    Public Hányadikjátékos As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
 
        If RadioButton1.Checked Then
            beallitasok.EmberiJátékos(Hányadikjátékos) = 0
        Else
            beallitasok.EmberiJátékos(Hányadikjátékos) = 1
        End If
        beallitasok.JátékosNév(Hányadikjátékos) = TextBox1.Text

        

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

        beallitasok.Frissít()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub valaszt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.EmberiJátékos.Split(" ")(Hányadikjátékos) = 0 Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
        TextBox1.Text = My.Settings.JátékosNév.Split("|")(Hányadikjátékos)
       
    End Sub
End Class