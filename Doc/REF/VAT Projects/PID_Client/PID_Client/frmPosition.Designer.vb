<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosition
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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Zed1 = New ZedGraph.ZedGraphControl()
        Me.Zed2 = New ZedGraph.ZedGraphControl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btEstimate = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbTotalTime = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbDisTop = New System.Windows.Forms.RichTextBox()
        Me.tbDisDec = New System.Windows.Forms.RichTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbDisAcc = New System.Windows.Forms.RichTextBox()
        Me.btSpeed = New System.Windows.Forms.Button()
        Me.LbCOM = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbUART3 = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbUART2 = New System.Windows.Forms.RichTextBox()
        Me.tbUART1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbUART0 = New System.Windows.Forms.RichTextBox()
        Me.btSend = New System.Windows.Forms.Button()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.CbCOM = New System.Windows.Forms.ComboBox()
        Me.btMotor = New System.Windows.Forms.Button()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbDecfb = New System.Windows.Forms.RichTextBox()
        Me.tbDeceleration = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAccfb = New System.Windows.Forms.RichTextBox()
        Me.tbTopSpeedfb = New System.Windows.Forms.RichTextBox()
        Me.tbStartSpeedfb = New System.Windows.Forms.RichTextBox()
        Me.tbSetPosfb = New System.Windows.Forms.RichTextBox()
        Me.tbAcceleration = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbTopSpeed = New System.Windows.Forms.RichTextBox()
        Me.tbStartSpeed = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbSetPosition = New System.Windows.Forms.RichTextBox()
        Me.btMode = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 56000
        Me.SerialPort1.ReadBufferSize = 64
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 10
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Zed1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Zed2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1284, 712)
        Me.TableLayoutPanel2.TabIndex = 29
        '
        'Zed1
        '
        Me.Zed1.AutoSize = True
        Me.Zed1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zed1.IsZoomOnMouseCenter = True
        Me.Zed1.Location = New System.Drawing.Point(253, 3)
        Me.Zed1.Name = "Zed1"
        Me.Zed1.ScrollGrace = 0.0R
        Me.Zed1.ScrollMaxX = 0.0R
        Me.Zed1.ScrollMaxY = 0.0R
        Me.Zed1.ScrollMaxY2 = 0.0R
        Me.Zed1.ScrollMinX = 0.0R
        Me.Zed1.ScrollMinY = 0.0R
        Me.Zed1.ScrollMinY2 = 0.0R
        Me.Zed1.Size = New System.Drawing.Size(1028, 350)
        Me.Zed1.TabIndex = 16
        '
        'Zed2
        '
        Me.Zed2.AutoSize = True
        Me.Zed2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zed2.IsZoomOnMouseCenter = True
        Me.Zed2.Location = New System.Drawing.Point(253, 359)
        Me.Zed2.Name = "Zed2"
        Me.Zed2.ScrollGrace = 0.0R
        Me.Zed2.ScrollMaxX = 0.0R
        Me.Zed2.ScrollMaxY = 0.0R
        Me.Zed2.ScrollMaxY2 = 0.0R
        Me.Zed2.ScrollMinX = 0.0R
        Me.Zed2.ScrollMinY = 0.0R
        Me.Zed2.ScrollMinY2 = 0.0R
        Me.Zed2.Size = New System.Drawing.Size(1028, 350)
        Me.Zed2.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btEstimate)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btSpeed)
        Me.GroupBox3.Controls.Add(Me.LbCOM)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.btSend)
        Me.GroupBox3.Controls.Add(Me.btConnect)
        Me.GroupBox3.Controls.Add(Me.btClear)
        Me.GroupBox3.Controls.Add(Me.CbCOM)
        Me.GroupBox3.Controls.Add(Me.btMotor)
        Me.GroupBox3.Controls.Add(Me.lbStatus)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.btMode)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.TableLayoutPanel2.SetRowSpan(Me.GroupBox3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(244, 670)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        '
        'btEstimate
        '
        Me.btEstimate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEstimate.Location = New System.Drawing.Point(162, 234)
        Me.btEstimate.Name = "btEstimate"
        Me.btEstimate.Size = New System.Drawing.Size(64, 23)
        Me.btEstimate.TabIndex = 29
        Me.btEstimate.Text = "Estimate"
        Me.btEstimate.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.tbTotalTime)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.tbDisTop)
        Me.GroupBox4.Controls.Add(Me.tbDisDec)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.tbDisAcc)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 442)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(224, 143)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Estimation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Total time"
        '
        'tbTotalTime
        '
        Me.tbTotalTime.Location = New System.Drawing.Point(113, 111)
        Me.tbTotalTime.Name = "tbTotalTime"
        Me.tbTotalTime.ReadOnly = True
        Me.tbTotalTime.Size = New System.Drawing.Size(103, 23)
        Me.tbTotalTime.TabIndex = 24
        Me.tbTotalTime.TabStop = False
        Me.tbTotalTime.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 18)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Distance Top"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 18)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Distance Dec."
        '
        'tbDisTop
        '
        Me.tbDisTop.Location = New System.Drawing.Point(113, 82)
        Me.tbDisTop.Name = "tbDisTop"
        Me.tbDisTop.ReadOnly = True
        Me.tbDisTop.Size = New System.Drawing.Size(103, 23)
        Me.tbDisTop.TabIndex = 20
        Me.tbDisTop.TabStop = False
        Me.tbDisTop.Text = ""
        '
        'tbDisDec
        '
        Me.tbDisDec.Location = New System.Drawing.Point(113, 53)
        Me.tbDisDec.Name = "tbDisDec"
        Me.tbDisDec.ReadOnly = True
        Me.tbDisDec.Size = New System.Drawing.Size(103, 23)
        Me.tbDisDec.TabIndex = 20
        Me.tbDisDec.TabStop = False
        Me.tbDisDec.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 18)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Distance Acc."
        '
        'tbDisAcc
        '
        Me.tbDisAcc.Location = New System.Drawing.Point(113, 24)
        Me.tbDisAcc.Name = "tbDisAcc"
        Me.tbDisAcc.ReadOnly = True
        Me.tbDisAcc.Size = New System.Drawing.Size(103, 23)
        Me.tbDisAcc.TabIndex = 20
        Me.tbDisAcc.TabStop = False
        Me.tbDisAcc.Text = ""
        '
        'btSpeed
        '
        Me.btSpeed.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSpeed.Location = New System.Drawing.Point(17, 622)
        Me.btSpeed.Name = "btSpeed"
        Me.btSpeed.Size = New System.Drawing.Size(109, 39)
        Me.btSpeed.TabIndex = 27
        Me.btSpeed.Text = "SPEED"
        Me.btSpeed.UseVisualStyleBackColor = True
        '
        'LbCOM
        '
        Me.LbCOM.AutoSize = True
        Me.LbCOM.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCOM.Location = New System.Drawing.Point(6, 16)
        Me.LbCOM.Name = "LbCOM"
        Me.LbCOM.Size = New System.Drawing.Size(55, 23)
        Me.LbCOM.TabIndex = 0
        Me.LbCOM.Text = "COM:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbUART3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbUART2)
        Me.GroupBox1.Controls.Add(Me.tbUART1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbUART0)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 293)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 143)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receive"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Elapsed Time"
        '
        'tbUART3
        '
        Me.tbUART3.Location = New System.Drawing.Point(113, 111)
        Me.tbUART3.Name = "tbUART3"
        Me.tbUART3.ReadOnly = True
        Me.tbUART3.Size = New System.Drawing.Size(103, 23)
        Me.tbUART3.TabIndex = 24
        Me.tbUART3.TabStop = False
        Me.tbUART3.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 18)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Feedback Pos."
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
        'btSend
        '
        Me.btSend.Enabled = False
        Me.btSend.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSend.Location = New System.Drawing.Point(162, 263)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(64, 23)
        Me.btSend.TabIndex = 6
        Me.btSend.Text = "Send"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'btConnect
        '
        Me.btConnect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConnect.Location = New System.Drawing.Point(149, 16)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(85, 23)
        Me.btConnect.TabIndex = 1
        Me.btConnect.Text = "Connect"
        Me.btConnect.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btClear.Location = New System.Drawing.Point(149, 622)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(85, 23)
        Me.btClear.TabIndex = 9
        Me.btClear.Text = "Clear Graph"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'CbCOM
        '
        Me.CbCOM.FormattingEnabled = True
        Me.CbCOM.Location = New System.Drawing.Point(59, 17)
        Me.CbCOM.Name = "CbCOM"
        Me.CbCOM.Size = New System.Drawing.Size(84, 21)
        Me.CbCOM.TabIndex = 0
        '
        'btMotor
        '
        Me.btMotor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMotor.Location = New System.Drawing.Point(34, 234)
        Me.btMotor.Name = "btMotor"
        Me.btMotor.Size = New System.Drawing.Size(109, 39)
        Me.btMotor.TabIndex = 7
        Me.btMotor.Text = "RUN"
        Me.btMotor.UseVisualStyleBackColor = True
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.Location = New System.Drawing.Point(16, 597)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(78, 15)
        Me.lbStatus.TabIndex = 4
        Me.lbStatus.Text = "Disconnected"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbDecfb)
        Me.GroupBox2.Controls.Add(Me.tbDeceleration)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tbAccfb)
        Me.GroupBox2.Controls.Add(Me.tbTopSpeedfb)
        Me.GroupBox2.Controls.Add(Me.tbStartSpeedfb)
        Me.GroupBox2.Controls.Add(Me.tbSetPosfb)
        Me.GroupBox2.Controls.Add(Me.tbAcceleration)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbTopSpeed)
        Me.GroupBox2.Controls.Add(Me.tbStartSpeed)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.tbSetPosition)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 168)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Send"
        '
        'tbDecfb
        '
        Me.tbDecfb.AutoWordSelection = True
        Me.tbDecfb.Location = New System.Drawing.Point(154, 136)
        Me.tbDecfb.Multiline = False
        Me.tbDecfb.Name = "tbDecfb"
        Me.tbDecfb.ReadOnly = True
        Me.tbDecfb.Size = New System.Drawing.Size(64, 23)
        Me.tbDecfb.TabIndex = 32
        Me.tbDecfb.Text = ""
        '
        'tbDeceleration
        '
        Me.tbDeceleration.AutoWordSelection = True
        Me.tbDeceleration.Location = New System.Drawing.Point(84, 136)
        Me.tbDeceleration.Multiline = False
        Me.tbDeceleration.Name = "tbDeceleration"
        Me.tbDeceleration.Size = New System.Drawing.Size(64, 23)
        Me.tbDeceleration.TabIndex = 30
        Me.tbDeceleration.Text = "300"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 18)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Dec."
        '
        'tbAccfb
        '
        Me.tbAccfb.AutoWordSelection = True
        Me.tbAccfb.Location = New System.Drawing.Point(154, 107)
        Me.tbAccfb.Multiline = False
        Me.tbAccfb.Name = "tbAccfb"
        Me.tbAccfb.ReadOnly = True
        Me.tbAccfb.Size = New System.Drawing.Size(64, 23)
        Me.tbAccfb.TabIndex = 29
        Me.tbAccfb.Text = ""
        '
        'tbTopSpeedfb
        '
        Me.tbTopSpeedfb.AutoWordSelection = True
        Me.tbTopSpeedfb.Location = New System.Drawing.Point(154, 78)
        Me.tbTopSpeedfb.Multiline = False
        Me.tbTopSpeedfb.Name = "tbTopSpeedfb"
        Me.tbTopSpeedfb.ReadOnly = True
        Me.tbTopSpeedfb.Size = New System.Drawing.Size(64, 23)
        Me.tbTopSpeedfb.TabIndex = 28
        Me.tbTopSpeedfb.Text = ""
        '
        'tbStartSpeedfb
        '
        Me.tbStartSpeedfb.AutoWordSelection = True
        Me.tbStartSpeedfb.Location = New System.Drawing.Point(154, 49)
        Me.tbStartSpeedfb.Multiline = False
        Me.tbStartSpeedfb.Name = "tbStartSpeedfb"
        Me.tbStartSpeedfb.ReadOnly = True
        Me.tbStartSpeedfb.Size = New System.Drawing.Size(64, 23)
        Me.tbStartSpeedfb.TabIndex = 27
        Me.tbStartSpeedfb.Text = ""
        '
        'tbSetPosfb
        '
        Me.tbSetPosfb.AutoWordSelection = True
        Me.tbSetPosfb.Location = New System.Drawing.Point(154, 20)
        Me.tbSetPosfb.Multiline = False
        Me.tbSetPosfb.Name = "tbSetPosfb"
        Me.tbSetPosfb.ReadOnly = True
        Me.tbSetPosfb.Size = New System.Drawing.Size(64, 23)
        Me.tbSetPosfb.TabIndex = 26
        Me.tbSetPosfb.Text = ""
        '
        'tbAcceleration
        '
        Me.tbAcceleration.AutoWordSelection = True
        Me.tbAcceleration.Location = New System.Drawing.Point(84, 107)
        Me.tbAcceleration.Multiline = False
        Me.tbAcceleration.Name = "tbAcceleration"
        Me.tbAcceleration.Size = New System.Drawing.Size(64, 23)
        Me.tbAcceleration.TabIndex = 5
        Me.tbAcceleration.Text = "300"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 18)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Acc."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 18)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Top Speed"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 18)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Start Speed"
        '
        'tbTopSpeed
        '
        Me.tbTopSpeed.AutoWordSelection = True
        Me.tbTopSpeed.Location = New System.Drawing.Point(84, 78)
        Me.tbTopSpeed.Multiline = False
        Me.tbTopSpeed.Name = "tbTopSpeed"
        Me.tbTopSpeed.Size = New System.Drawing.Size(64, 23)
        Me.tbTopSpeed.TabIndex = 4
        Me.tbTopSpeed.Text = "1650"
        '
        'tbStartSpeed
        '
        Me.tbStartSpeed.AutoWordSelection = True
        Me.tbStartSpeed.Location = New System.Drawing.Point(84, 49)
        Me.tbStartSpeed.Multiline = False
        Me.tbStartSpeed.Name = "tbStartSpeed"
        Me.tbStartSpeed.Size = New System.Drawing.Size(64, 23)
        Me.tbStartSpeed.TabIndex = 3
        Me.tbStartSpeed.Text = "150"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Set Pos."
        '
        'tbSetPosition
        '
        Me.tbSetPosition.AutoWordSelection = True
        Me.tbSetPosition.Location = New System.Drawing.Point(84, 20)
        Me.tbSetPosition.Multiline = False
        Me.tbSetPosition.Name = "tbSetPosition"
        Me.tbSetPosition.Size = New System.Drawing.Size(64, 23)
        Me.tbSetPosition.TabIndex = 2
        Me.tbSetPosition.Text = "200"
        '
        'btMode
        '
        Me.btMode.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btMode.Location = New System.Drawing.Point(149, 593)
        Me.btMode.Name = "btMode"
        Me.btMode.Size = New System.Drawing.Size(85, 23)
        Me.btMode.TabIndex = 8
        Me.btMode.Text = "Normal"
        Me.btMode.UseVisualStyleBackColor = True
        '
        'frmPosition
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 712)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "frmPosition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Position Control"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Zed1 As ZedGraph.ZedGraphControl
    Friend WithEvents Zed2 As ZedGraph.ZedGraphControl
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LbCOM As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbUART2 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbUART1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbUART0 As System.Windows.Forms.RichTextBox
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents btConnect As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents CbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents btMotor As System.Windows.Forms.Button
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbAccfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbTopSpeedfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbStartSpeedfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbSetPosfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbAcceleration As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbTopSpeed As System.Windows.Forms.RichTextBox
    Friend WithEvents tbStartSpeed As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbSetPosition As System.Windows.Forms.RichTextBox
    Friend WithEvents btMode As System.Windows.Forms.Button
    Friend WithEvents btSpeed As System.Windows.Forms.Button
    Friend WithEvents tbDecfb As System.Windows.Forms.RichTextBox
    Friend WithEvents tbDeceleration As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbTotalTime As System.Windows.Forms.RichTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbDisTop As System.Windows.Forms.RichTextBox
    Friend WithEvents tbDisDec As System.Windows.Forms.RichTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbDisAcc As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbUART3 As System.Windows.Forms.RichTextBox
    Friend WithEvents btEstimate As System.Windows.Forms.Button
End Class
