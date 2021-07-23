<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loadingawal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loadingawal))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Progressbar1 = New Bunifu.Framework.UI.BunifuCircleProgressbar()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(270, 812)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(544, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Monotype Corsiva", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(226, 757)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Rumah Sakit Harus Sepi"
        '
        'Progressbar1
        '
        Me.Progressbar1.animated = False
        Me.Progressbar1.animationIterval = 5
        Me.Progressbar1.animationSpeed = 300
        Me.Progressbar1.BackColor = System.Drawing.Color.Transparent
        Me.Progressbar1.BackgroundImage = CType(resources.GetObject("Progressbar1.BackgroundImage"), System.Drawing.Image)
        Me.Progressbar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.Progressbar1.ForeColor = System.Drawing.Color.SeaGreen
        Me.Progressbar1.LabelVisible = True
        Me.Progressbar1.LineProgressThickness = 8
        Me.Progressbar1.LineThickness = 5
        Me.Progressbar1.Location = New System.Drawing.Point(80, 646)
        Me.Progressbar1.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.Progressbar1.MaxValue = 100
        Me.Progressbar1.Name = "Progressbar1"
        Me.Progressbar1.ProgressBackColor = System.Drawing.Color.Gainsboro
        Me.Progressbar1.ProgressColor = System.Drawing.Color.SeaGreen
        Me.Progressbar1.Size = New System.Drawing.Size(133, 133)
        Me.Progressbar1.TabIndex = 5
        Me.Progressbar1.Value = 0
        '
        'loadingawal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.tugas_connect_database.My.Resources.Resources.fotoloading
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1088, 812)
        Me.Controls.Add(Me.Progressbar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "loadingawal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loadfirst"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Progressbar1 As Bunifu.Framework.UI.BunifuCircleProgressbar
End Class
