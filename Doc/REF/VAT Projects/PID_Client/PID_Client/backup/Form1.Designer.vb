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
        Me.components = New System.ComponentModel.Container()
        Me.LbCOM = New System.Windows.Forms.Label()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CbCOM = New System.Windows.Forms.ComboBox()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbUART2 = New System.Windows.Forms.RichTextBox()
        Me.tbUART1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbUART0 = New System.Windows.Forms.RichTextBox()
        Me.Zed1 = New ZedGraph.ZedGraphControl()
        Me.btMode = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbKdfb = New System.Windows.Forms.RichTextBox()
        Me.tbKifb = New System.Windows.Forms.RichTextBox()
        Me.tbKpfb = New System.Windows.Forms.RichTextBox()
        Me.tbSetSpeedfb = New System.Windows.Forms.RichTextBox()
        Me.tbKd = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbKi = New System.Windows.Forms.RichTextBox()
        Me.tbKp = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbSetSpeed = New System.Windows.Forms.RichTextBox()
        Me.btSend = New System.Windows.Forms.Button()
        Me.btMotor = New System.Windows.Forms.Button()
        Me.Zed2 = New ZedGraph.ZedGraphControl()
        Me.btClear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbCOM
        '
        Me.LbCOM.AutoSize = True
        Me.LbCOM.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCOM.Location = New System.Drawing.Point(10, 17)
        Me.LbCOM.Name = "LbCOM"
        Me.LbCOM.Size = New System.Drawing.Size(55, 23)
        Me.LbCOM.TabIndex = 0
        Me.LbCOM.Text = "COM:"
        '
        'btConnect
        '
        Me.btConnect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConnect.Location = New System.Drawing.Point(153, 17)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(85, 23)
        Me.btConnect.TabIndex = 1
        Me.btConnect.Text = "Connect"
        Me.btConnect.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 56000
        Me.SerialPort1.ReadBufferSize = 64
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'CbCOM
        '
        Me.CbCOM.FormattingEnabled = True
        Me.CbCOM.Location = New System.Drawing.Point(63, 18)
        Me.CbCOM.Name = "CbCOM"
        Me.CbCOM.Size = New System.Drawing.Size(84, 21)
        Me.CbCOM.TabIndex = 0
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.Location = New System.Drawing.Point(20, 397)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(78, 15)
        Me.lbStatus.TabIndex = 4
        Me.lbStatus.Text = "Disconnected"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbUART2)
        Me.GroupBox1.Controls.Add(Me.tbUART1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbUART0)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 113)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receive"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 18)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Duty Cycle"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 18)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Feedback Speed"
        '
        'tbUART2
        '
        Me.tbUART2.Location = New System.Drawing.Point(113, 82)
        Me.tbUART2.Name = "tbUART2"
        Me.tbUART2.ReadOnly = True
        Me.tbUART2.Size = New System.Drawing.Size(103, 23)
        Me.tbUART2.TabIndex = 20
        Me.tbUART2.TabStop = False
        Me.tbUART2.Text = ""
        '
        'tbUART1
        '
        Me.tbUART1.Location = New System.Drawing.Point(113, 53)
        Me.tbUART1.Name = "tbUART1"
        Me.tbUART1.ReadOnly = True
        Me.tbUART1.Size = New System.Drawing.Size(103, 23)
        Me.tbUART1.TabIndex = 20
        Me.tbUART1.TabStop = False
        Me.tbUART1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Set Speed"
        '
        'tbUART0
        '
        Me.tbUART0.Location = New System.Drawing.Point(113, 24)
        Me.tbUART0.Name = "tbUART0"
        Me.tbUART0.ReadOnly = True
        Me.tbUART0.Size = New System.Drawing.Size(103, 23)
        Me.tbUART0.TabIndex = 20
        Me.tbUART0.TabStop = False
        Me.tbUART0.Text = ""
        '
        'Zed1
        '
        Me.Zed1.AutoSize = True
        Me.Zed1.IsZoomOnMouseCenter = True
        Me.Zed1.Location = New System.Drawing.Point(244, 12)
        Me.Zed1.Name = "Zed1"
        Me.Zed1.ScrollGrace = 0.0R
        Me.Zed1.ScrollMaxX = 0.0R
        Me.Zed1.ScrollMaxY = 0.0R
        Me.Zed1.ScrollMaxY2 = 0.0R
        Me.Zed1.ScrollMinX = 0.0R
        Me.Zed1.ScrollMinY = 0.0R
        Me.Zed1.ScrollMinY2 = 0.0R
        Me.Zed1.Size = New System.Drawing.Size(1028, 340)
        Me.Zed1.TabIndex = 16
        '
        'btMode
        '
        Me.btMode.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btMode.Location = New System.Drawing.Point(153, 393)
        Me.btMode.Name = "btMode"
        Me.btMode.Size = New System.Drawing.Size(85, 23)
        Me.btMode.TabIndex = 8
        Me.btMode.Text = "Normal"
        Me.btMode.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbKdfb)
        Me.GroupBox2.Controls.Add(Me.tbKifb)
        Me.GroupBox2.Controls.Add(Me.tbKpfb)
        Me.GroupBox2.Controls.Add(Me.tbSetSpeedfb)
        Me.GroupBox2.Controls.Add(Me.tbKd)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbKi)
        Me.GroupBox2.Controls.Add(Me.tbKp)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.tbSetSpeed)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 139)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Send"
        '
        'tbKdfb
        '
        Me.tbKdfb.AutoWordSelection = True
        Me.tbKdfb.Location = New System.Drawing.Point(141, 107)
        Me.tbKdfb.Multiline = False
        Me.tbKdfb.Name = "tbKdfb"
        Me.tbKdfb.ReadOnly = True
        Me.tbKdfb.Size = New System.Drawing.Size(53, 23)
        Me.tbKdfb.TabIndex = 29
        Me.tbKdfb.Text = ""
        '
        'tbKifb
        '
        Me.tbKifb.AutoWordSelection = True
        Me.tbKifb.Location = New System.Drawing.Point(141, 78)
        Me.tbKifb.Multiline = False
        Me.tbKifb.Name = "tbKifb"
        Me.tbKifb.ReadOnly = True
        Me.tbKifb.Size = New System.Drawing.Size(53, 23)
        Me.tbKifb.TabIndex = 28
        Me.tbKifb.Text = ""
        '
        'tbKpfb
        '
        Me.tbKpfb.AutoWordSelection = True
        Me.tbKpfb.Location = New System.Drawing.Point(141, 49)
        Me.tbKpfb.Multiline = False
        Me.tbKpfb.Name = "tbKpfb"
        Me.tbKpfb.ReadOnly = True
        Me.tbKpfb.Size = New System.Drawing.Size(53, 23)
        Me.tbKpfb.TabIndex = 27
        Me.tbKpfb.Text = ""
        '
        'tbSetSpeedfb
        '
        Me.tbSetSpeedfb.AutoWordSelection = True
        Me.tbSetSpeedfb.Location = New System.Drawing.Point(141, 20)
        Me.tbSetSpeedfb.Multiline = False
        Me.tbSetSpeedfb.Name = "tbSetSpeedfb"
        Me.tbSetSpeedfb.ReadOnly = True
        Me.tbSetSpeedfb.Size = New System.Drawing.Size(53, 23)
        Me.tbSetSpeedfb.TabIndex = 26
        Me.tbSetSpeedfb.Text = ""
        '
        'tbKd
        '
        Me.tbKd.AutoWordSelection = True
        Me.tbKd.Location = New System.Drawing.Point(82, 107)
        Me.tbKd.Multiline = False
        Me.tbKd.Name = "tbKd"
        Me.tbKd.Size = New System.Drawing.Size(53, 23)
        Me.tbKd.TabIndex = 5
        Me.tbKd.Text = "0.05"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 18)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Kd"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 18)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Ki"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 18)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Kp"
        '
        'tbKi
        '
        Me.tbKi.AutoWordSelection = True
        Me.tbKi.Location = New System.Drawing.Point(82, 78)
        Me.tbKi.Multiline = False
        Me.tbKi.Name = "tbKi"
        Me.tbKi.Size = New System.Drawing.Size(53, 23)
        Me.tbKi.TabIndex = 4
        Me.tbKi.Text = "1.2"
        '
        'tbKp
        '
        Me.tbKp.AutoWordSelection = True
        Me.tbKp.Location = New System.Drawing.Point(82, 49)
        Me.tbKp.Multiline = False
        Me.tbKp.Name = "tbKp"
        Me.tbKp.Size = New System.Drawing.Size(53, 23)
        Me.tbKp.TabIndex = 3
        Me.tbKp.Text = "2.8"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Set Speed"
        '
        'tbSetSpeed
        '
        Me.tbSetSpeed.AutoWordSelection = True
        Me.tbSetSpeed.Location = New System.Drawing.Point(82, 20)
        Me.tbSetSpeed.Multiline = False
        Me.tbSetSpeed.Name = "tbSetSpeed"
        Me.tbSetSpeed.Size = New System.Drawing.Size(53, 23)
        Me.tbSetSpeed.TabIndex = 2
        Me.tbSetSpeed.Text = "2000"
        '
        'btSend
        '
        Me.btSend.Enabled = False
        Me.btSend.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSend.Location = New System.Drawing.Point(177, 216)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(53, 23)
        Me.btSend.TabIndex = 6
        Me.btSend.Text = "Send"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'btMotor
        '
        Me.btMotor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMotor.Location = New System.Drawing.Point(38, 206)
        Me.btMotor.Name = "btMotor"
        Me.btMotor.Size = New System.Drawing.Size(109, 39)
        Me.btMotor.TabIndex = 7
        Me.btMotor.Text = "STOP"
        Me.btMotor.UseVisualStyleBackColor = True
        '
        'Zed2
        '
        Me.Zed2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Zed2.AutoSize = True
        Me.Zed2.IsZoomOnMouseCenter = True
        Me.Zed2.Location = New System.Drawing.Point(244, 360)
        Me.Zed2.Name = "Zed2"
        Me.Zed2.ScrollGrace = 0.0R
        Me.Zed2.ScrollMaxX = 0.0R
        Me.Zed2.ScrollMaxY = 0.0R
        Me.Zed2.ScrollMaxY2 = 0.0R
        Me.Zed2.ScrollMinX = 0.0R
        Me.Zed2.ScrollMinY = 0.0R
        Me.Zed2.ScrollMinY2 = 0.0R
        Me.Zed2.Size = New System.Drawing.Size(1028, 340)
        Me.Zed2.TabIndex = 27
        '
        'btClear
        '
        Me.btClear.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btClear.Location = New System.Drawing.Point(153, 422)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(85, 23)
        Me.btClear.TabIndex = 9
        Me.btClear.Text = "Clear Graph"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 712)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.Zed2)
        Me.Controls.Add(Me.btMotor)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btMode)
        Me.Controls.Add(Me.Zed1)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.CbCOM)
        Me.Controls.Add(Me.btConnect)
        Me.Controls.Add(Me.LbCOM)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "PID Client"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbCOM As System.Windows.Forms.Label
    Friend WithEvents btConnect As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbUART0 As System.Windows.Forms.RichTextBox
    Friend WithEvents Zed1 As ZedGraph.ZedGraphControl
    Friend WithEvents btMode As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbUART2 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbUART1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbKd As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbKi As System.Windows.Forms.RichTextBox
    Friend WithEvents tbKp As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbSetSpeed As System.Windows.Forms.RichTextBox
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents btMotor As System.Windows.Forms.Button
    Friend WithEvents Zed2 As ZedGraph.ZedGraphControl
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents tbKdfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbKifb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbKpfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbSetSpeedfb As System.Windows.Forms.RichTextBox

End Class
