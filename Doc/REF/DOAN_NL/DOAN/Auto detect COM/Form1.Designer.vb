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
        Me.BtConnect = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CbCOM = New System.Windows.Forms.ComboBox()
        Me.LbStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbUART3 = New System.Windows.Forms.RichTextBox()
        Me.tbUART2 = New System.Windows.Forms.RichTextBox()
        Me.tbUART1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbUART0 = New System.Windows.Forms.RichTextBox()
        Me.Zed = New ZedGraph.ZedGraphControl()
        Me.btMode = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Speed = New System.Windows.Forms.RichTextBox()
        Me.btSendPI = New System.Windows.Forms.Button()
        Me.Kd = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Ki = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Kp = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbCOM
        '
        Me.LbCOM.AutoSize = True
        Me.LbCOM.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCOM.Location = New System.Drawing.Point(12, 18)
        Me.LbCOM.Name = "LbCOM"
        Me.LbCOM.Size = New System.Drawing.Size(55, 23)
        Me.LbCOM.TabIndex = 0
        Me.LbCOM.Text = "COM:"
        '
        'BtConnect
        '
        Me.BtConnect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtConnect.Location = New System.Drawing.Point(153, 20)
        Me.BtConnect.Name = "BtConnect"
        Me.BtConnect.Size = New System.Drawing.Size(85, 23)
        Me.BtConnect.TabIndex = 1
        Me.BtConnect.Text = "Connect"
        Me.BtConnect.UseVisualStyleBackColor = True
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
        Me.CbCOM.Location = New System.Drawing.Point(63, 20)
        Me.CbCOM.Name = "CbCOM"
        Me.CbCOM.Size = New System.Drawing.Size(84, 21)
        Me.CbCOM.TabIndex = 3
        '
        'LbStatus
        '
        Me.LbStatus.AutoSize = True
        Me.LbStatus.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbStatus.Location = New System.Drawing.Point(22, 56)
        Me.LbStatus.Name = "LbStatus"
        Me.LbStatus.Size = New System.Drawing.Size(65, 15)
        Me.LbStatus.TabIndex = 4
        Me.LbStatus.Text = "Disconnect"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbUART3)
        Me.GroupBox1.Controls.Add(Me.tbUART2)
        Me.GroupBox1.Controls.Add(Me.tbUART1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbUART0)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 154)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Received"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 18)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "UART3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 18)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "UART2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "UART1"
        '
        'tbUART3
        '
        Me.tbUART3.Location = New System.Drawing.Point(61, 106)
        Me.tbUART3.Name = "tbUART3"
        Me.tbUART3.Size = New System.Drawing.Size(139, 23)
        Me.tbUART3.TabIndex = 19
        Me.tbUART3.Text = ""
        '
        'tbUART2
        '
        Me.tbUART2.Location = New System.Drawing.Point(61, 77)
        Me.tbUART2.Name = "tbUART2"
        Me.tbUART2.Size = New System.Drawing.Size(139, 23)
        Me.tbUART2.TabIndex = 21
        Me.tbUART2.Text = ""
        '
        'tbUART1
        '
        Me.tbUART1.Location = New System.Drawing.Point(61, 48)
        Me.tbUART1.Name = "tbUART1"
        Me.tbUART1.Size = New System.Drawing.Size(139, 23)
        Me.tbUART1.TabIndex = 20
        Me.tbUART1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "UART0"
        '
        'tbUART0
        '
        Me.tbUART0.Location = New System.Drawing.Point(61, 19)
        Me.tbUART0.Name = "tbUART0"
        Me.tbUART0.Size = New System.Drawing.Size(139, 23)
        Me.tbUART0.TabIndex = 0
        Me.tbUART0.Text = ""
        '
        'Zed
        '
        Me.Zed.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.Zed.Location = New System.Drawing.Point(246, 20)
        Me.Zed.Name = "Zed"
        Me.Zed.ScrollGrace = 0.0R
        Me.Zed.ScrollMaxX = 0.0R
        Me.Zed.ScrollMaxY = 0.0R
        Me.Zed.ScrollMaxY2 = 0.0R
        Me.Zed.ScrollMinX = 0.0R
        Me.Zed.ScrollMinY = 0.0R
        Me.Zed.ScrollMinY2 = 0.0R
        Me.Zed.Size = New System.Drawing.Size(980, 478)
        Me.Zed.TabIndex = 16
        '
        'btMode
        '
        Me.btMode.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMode.Location = New System.Drawing.Point(129, 49)
        Me.btMode.Name = "btMode"
        Me.btMode.Size = New System.Drawing.Size(109, 39)
        Me.btMode.TabIndex = 17
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
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Speed)
        Me.GroupBox2.Controls.Add(Me.btSendPI)
        Me.GroupBox2.Controls.Add(Me.Kd)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Ki)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Kp)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 121)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Send"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(112, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 18)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Speed"
        '
        'Speed
        '
        Me.Speed.Location = New System.Drawing.Point(163, 48)
        Me.Speed.Name = "Speed"
        Me.Speed.Size = New System.Drawing.Size(53, 23)
        Me.Speed.TabIndex = 29
        Me.Speed.Text = "700"
        '
        'btSendPI
        '
        Me.btSendPI.Enabled = False
        Me.btSendPI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSendPI.Location = New System.Drawing.Point(115, 85)
        Me.btSendPI.Name = "btSendPI"
        Me.btSendPI.Size = New System.Drawing.Size(84, 30)
        Me.btSendPI.TabIndex = 26
        Me.btSendPI.Text = "Send"
        Me.btSendPI.UseVisualStyleBackColor = True
        '
        'Kd
        '
        Me.Kd.Location = New System.Drawing.Point(51, 48)
        Me.Kd.Name = "Kd"
        Me.Kd.Size = New System.Drawing.Size(53, 23)
        Me.Kd.TabIndex = 26
        Me.Kd.Text = "0.2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 18)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Kd"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(124, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 18)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Ki"
        '
        'Ki
        '
        Me.Ki.Location = New System.Drawing.Point(163, 19)
        Me.Ki.Name = "Ki"
        Me.Ki.Size = New System.Drawing.Size(53, 23)
        Me.Ki.TabIndex = 20
        Me.Ki.Text = "0.25"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Kp"
        '
        'Kp
        '
        Me.Kp.Location = New System.Drawing.Point(51, 19)
        Me.Kp.Name = "Kp"
        Me.Kp.Size = New System.Drawing.Size(53, 23)
        Me.Kp.TabIndex = 0
        Me.Kp.Text = "0.75"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(129, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 39)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "STOP"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(9, 217)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 39)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "START"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 510)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btMode)
        Me.Controls.Add(Me.Zed)
        Me.Controls.Add(Me.LbStatus)
        Me.Controls.Add(Me.CbCOM)
        Me.Controls.Add(Me.BtConnect)
        Me.Controls.Add(Me.LbCOM)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Transmit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbCOM As System.Windows.Forms.Label
    Friend WithEvents BtConnect As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents LbStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbUART0 As System.Windows.Forms.RichTextBox
    Friend WithEvents Zed As ZedGraph.ZedGraphControl
    Friend WithEvents btMode As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbUART3 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbUART2 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbUART1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Kd As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Ki As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Kp As System.Windows.Forms.RichTextBox
    Friend WithEvents btSendPI As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Speed As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
