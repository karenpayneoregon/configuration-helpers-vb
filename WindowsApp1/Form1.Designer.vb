<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MohammadVersionButton = New System.Windows.Forms.Button()
        Me.KarenVersionButton = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'MohammadVersionButton
        '
        Me.MohammadVersionButton.Image = Global.WindowsApp1.My.Resources.Resources.Stop_16x
        Me.MohammadVersionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MohammadVersionButton.Location = New System.Drawing.Point(159, 12)
        Me.MohammadVersionButton.Name = "MohammadVersionButton"
        Me.MohammadVersionButton.Size = New System.Drawing.Size(128, 23)
        Me.MohammadVersionButton.TabIndex = 1
        Me.MohammadVersionButton.Text = "Mohammad"
        Me.MohammadVersionButton.UseVisualStyleBackColor = true
        '
        'KarenVersionButton
        '
        Me.KarenVersionButton.Image = Global.WindowsApp1.My.Resources.Resources.Checkmark_8x_16x
        Me.KarenVersionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KarenVersionButton.Location = New System.Drawing.Point(12, 12)
        Me.KarenVersionButton.Name = "KarenVersionButton"
        Me.KarenVersionButton.Size = New System.Drawing.Size(128, 23)
        Me.KarenVersionButton.TabIndex = 0
        Me.KarenVersionButton.Text = "Karen"
        Me.KarenVersionButton.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 53)
        Me.Controls.Add(Me.MohammadVersionButton)
        Me.Controls.Add(Me.KarenVersionButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "Compare versions"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents KarenVersionButton As Button
    Friend WithEvents MohammadVersionButton As Button
End Class
