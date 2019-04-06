<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Offline
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Offline))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpciókToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÚjJátékToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PályaméretMegváltoztatásaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JátékKövetéseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NévjegyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeállításokToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JátékmódokToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NegyedelőToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖtödölőToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HatodolóToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VonalToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.SzemélyesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SzemélyesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NégyzetrácsKiterjedéseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.SorokSzámaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpciókToolStripMenuItem, Me.NévjegyToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpciókToolStripMenuItem
        '
        Me.OpciókToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÚjJátékToolStripMenuItem, Me.PályaméretMegváltoztatásaToolStripMenuItem, Me.JátékKövetéseToolStripMenuItem})
        Me.OpciókToolStripMenuItem.Name = "OpciókToolStripMenuItem"
        Me.OpciókToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.OpciókToolStripMenuItem.Text = "Opciók"
        '
        'ÚjJátékToolStripMenuItem
        '
        Me.ÚjJátékToolStripMenuItem.Name = "ÚjJátékToolStripMenuItem"
        Me.ÚjJátékToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ÚjJátékToolStripMenuItem.Text = "Új játék!"
        '
        'PályaméretMegváltoztatásaToolStripMenuItem
        '
        Me.PályaméretMegváltoztatásaToolStripMenuItem.Name = "PályaméretMegváltoztatásaToolStripMenuItem"
        Me.PályaméretMegváltoztatásaToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.PályaméretMegváltoztatásaToolStripMenuItem.Text = "Beállítások"
        '
        'JátékKövetéseToolStripMenuItem
        '
        Me.JátékKövetéseToolStripMenuItem.Checked = True
        Me.JátékKövetéseToolStripMenuItem.CheckOnClick = True
        Me.JátékKövetéseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.JátékKövetéseToolStripMenuItem.Name = "JátékKövetéseToolStripMenuItem"
        Me.JátékKövetéseToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.JátékKövetéseToolStripMenuItem.Text = "Játék követése"
        '
        'NévjegyToolStripMenuItem
        '
        Me.NévjegyToolStripMenuItem.Name = "NévjegyToolStripMenuItem"
        Me.NévjegyToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.NévjegyToolStripMenuItem.Text = "Névjegy"
        '
        'BeállításokToolStripMenuItem
        '
        Me.BeállításokToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JátékmódokToolStripMenuItem, Me.NégyzetrácsKiterjedéseToolStripMenuItem})
        Me.BeállításokToolStripMenuItem.Name = "BeállításokToolStripMenuItem"
        Me.BeállításokToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BeállításokToolStripMenuItem.Text = "Beállítások"
        '
        'JátékmódokToolStripMenuItem
        '
        Me.JátékmódokToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NegyedelőToolStripMenuItem, Me.ÖtödölőToolStripMenuItem, Me.HatodolóToolStripMenuItem, Me.VonalToolStripMenuItem, Me.SzemélyesToolStripMenuItem, Me.SzemélyesToolStripMenuItem1})
        Me.JátékmódokToolStripMenuItem.Name = "JátékmódokToolStripMenuItem"
        Me.JátékmódokToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.JátékmódokToolStripMenuItem.Text = "Játékmódok"
        '
        'NegyedelőToolStripMenuItem
        '
        Me.NegyedelőToolStripMenuItem.CheckOnClick = True
        Me.NegyedelőToolStripMenuItem.Name = "NegyedelőToolStripMenuItem"
        Me.NegyedelőToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.NegyedelőToolStripMenuItem.Text = "Negyedelő"
        '
        'ÖtödölőToolStripMenuItem
        '
        Me.ÖtödölőToolStripMenuItem.Checked = True
        Me.ÖtödölőToolStripMenuItem.CheckOnClick = True
        Me.ÖtödölőToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ÖtödölőToolStripMenuItem.Name = "ÖtödölőToolStripMenuItem"
        Me.ÖtödölőToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ÖtödölőToolStripMenuItem.Text = "Ötödölő"
        '
        'HatodolóToolStripMenuItem
        '
        Me.HatodolóToolStripMenuItem.CheckOnClick = True
        Me.HatodolóToolStripMenuItem.Name = "HatodolóToolStripMenuItem"
        Me.HatodolóToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.HatodolóToolStripMenuItem.Text = "Hatodoló"
        '
        'VonalToolStripMenuItem
        '
        Me.VonalToolStripMenuItem.Name = "VonalToolStripMenuItem"
        Me.VonalToolStripMenuItem.Size = New System.Drawing.Size(133, 6)
        '
        'SzemélyesToolStripMenuItem
        '
        Me.SzemélyesToolStripMenuItem.Name = "SzemélyesToolStripMenuItem"
        Me.SzemélyesToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SzemélyesToolStripMenuItem.Text = "2 személyes"
        '
        'SzemélyesToolStripMenuItem1
        '
        Me.SzemélyesToolStripMenuItem1.Name = "SzemélyesToolStripMenuItem1"
        Me.SzemélyesToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.SzemélyesToolStripMenuItem1.Text = "1 személyes"
        '
        'NégyzetrácsKiterjedéseToolStripMenuItem
        '
        Me.NégyzetrácsKiterjedéseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OToolStripMenuItem, Me.SorokSzámaToolStripMenuItem})
        Me.NégyzetrácsKiterjedéseToolStripMenuItem.Name = "NégyzetrácsKiterjedéseToolStripMenuItem"
        Me.NégyzetrácsKiterjedéseToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.NégyzetrácsKiterjedéseToolStripMenuItem.Text = "Négyzetrács kiterjedése"
        '
        'OToolStripMenuItem
        '
        Me.OToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1})
        Me.OToolStripMenuItem.Name = "OToolStripMenuItem"
        Me.OToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OToolStripMenuItem.Text = "Oszlopok száma"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        '
        'SorokSzámaToolStripMenuItem
        '
        Me.SorokSzámaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox2})
        Me.SorokSzámaToolStripMenuItem.Name = "SorokSzámaToolStripMenuItem"
        Me.SorokSzámaToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SorokSzámaToolStripMenuItem.Text = "Sorok száma"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(100, 23)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 420)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'Offline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Offline"
        Me.Text = "OX"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BeállításokToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JátékmódokToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NegyedelőToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÖtödölőToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HatodolóToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NégyzetrácsKiterjedéseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SorokSzámaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VonalToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SzemélyesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SzemélyesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents OpciókToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÚjJátékToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PályaméretMegváltoztatásaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents JátékKövetéseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NévjegyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
