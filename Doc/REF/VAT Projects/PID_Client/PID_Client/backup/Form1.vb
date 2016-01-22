Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports ZedGraph

Public Class Form1
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Dim intlen As Integer
    Dim begindata As Byte
    Dim datasize As Integer = 21
    Dim data(datasize) As Byte
    Dim number As Integer
    Dim bytesend(10) As Byte
    Dim intmode = 1
    Dim TickStart As Integer = Environment.TickCount

    Dim data_set_speed As Single
    Dim data_Kp As Single
    Dim data_Ki As Single
    Dim data_Kd As Single

    Dim fb_set_speed As Single
    Dim fb_Kp As Single
    Dim fb_Ki As Single
    Dim fb_Kd As Single

    Dim data_uart0 As Single 'Set Speed
    Dim data_uart1 As Single 'Feedback Speed
    Dim data_uart2 As Single 'Duty Cycle

    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.ReadBufferSize = 64
        SerialPort1.ReceivedBytesThreshold = 2
        Dim myzed1 = Zed1.GraphPane
        Dim myzed2 = Zed2.GraphPane

        myzed1.Title.Text = "Motor Speed"
        myzed1.XAxis.Title.Text = "Times (s)"
        myzed1.YAxis.Title.Text = "Speed (RPM)"

        myzed2.Title.Text = "Control Signal"
        myzed2.XAxis.Title.Text = "Times (s)"
        myzed2.YAxis.Title.Text = "Duty Cycle (%)"

        Dim list0 As New RollingPointPairList(1000)
        Dim list1 As New RollingPointPairList(1000)
        Dim list2 As New RollingPointPairList(1000)

        Dim curve0 As LineItem = myzed1.AddCurve("Set Speed", list0, Color.Red, SymbolType.None)
        Dim curve1 As LineItem = myzed1.AddCurve("Feedback Speed", list1, Color.Blue, SymbolType.None)
        Dim curve2 As LineItem = myzed2.AddCurve("Duty Cycle", list2, Color.Red, SymbolType.None)

        curve0.Line.Width = 2.0F
        curve1.Line.Width = 2.0F
        curve2.Line.Width = 2.0F

        myzed1.XAxis.Scale.Min = 0
        myzed1.XAxis.Scale.Max = 5
        myzed1.XAxis.Scale.MinorStep = 0.1
        myzed1.XAxis.Scale.MajorStep = 0.5

        myzed1.YAxis.Scale.Min = 0
        myzed1.YAxis.Scale.Max = 3500
        myzed1.YAxis.Scale.MinorStep = 100
        myzed1.YAxis.Scale.MajorStep = 500

        myzed2.XAxis.Scale.Min = 0
        myzed2.XAxis.Scale.Max = 5
        myzed2.XAxis.Scale.MinorStep = 0.1
        myzed2.XAxis.Scale.MajorStep = 0.5

        myzed2.YAxis.Scale.Min = 0
        myzed2.YAxis.Scale.Max = 110
        myzed2.YAxis.Scale.MinorStep = 5
        myzed2.YAxis.Scale.MajorStep = 10

        Zed1.AxisChange()
        Zed2.AxisChange()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        myPort = IO.Ports.SerialPort.GetPortNames()
        If (intlen <> myPort.Length) Then
            intlen = myPort.Length
            CbCOM.Items.Clear()
            For i = 0 To UBound(myPort)
                CbCOM.Items.Add(myPort(i))
            Next
            If intlen <> 0 Then
                CbCOM.Text = CbCOM.Items.Item(0)
            Else
                CbCOM.Text = "No COM"
            End If
        End If
    End Sub

    Private Sub btConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConnect.Click
        If lbStatus.Text = "Disconnected" Then
            SerialPort1.PortName = CbCOM.Text
            SerialPort1.Open()
            lbStatus.Text = "Connected"
            btConnect.Text = "Disconnect"
            btClear_Click(sender, e)
        Else
            SerialPort1.Close()
            lbStatus.Text = "Disconnected"
            btConnect.Text = "Connect"

        End If
    End Sub
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Dim timer As Double = (Environment.TickCount - TickStart) / 1000.0
        
        number = SerialPort1.BytesToRead

        If number > datasize Then number = datasize
        SerialPort1.Read(data, 0, number)
        For i = 0 To (datasize - 6) Step 1
            If data(i) = &HFF And data(i + 6) = &HFE Then
                Select Case (data(i + 1))
                    Case &HF0
                        data_uart0 = CSng(BitConverter.ToSingle(data, i + 2))
                    Case &HF1
                        data_uart1 = CSng(BitConverter.ToSingle(data, i + 2))
                    Case &HF2
                        data_uart2 = CSng(BitConverter.ToSingle(data, i + 2))
                    Case &HF3
                        fb_set_speed = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_set_speed - data_set_speed) < 0.00001 And (fb_set_speed - data_set_speed) > -0.00001) Then
                            fb_set_speed = data_set_speed
                        End If
                    Case &HF4
                        fb_Kp = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_Kp - data_Kp) < 0.00001 And (fb_Kp - data_Kp) > -0.00001) Then
                            fb_Kp = data_Kp
                        End If
                    Case &HF5
                        fb_Ki = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_Ki - data_Ki) < 0.00001 And (fb_Ki - data_Ki) > -0.00001) Then
                            fb_Ki = data_Ki
                        End If
                    Case &HF6
                        fb_Kd = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_Kd - data_Kd) < 0.00001 And (fb_Kd - data_Kd) > -0.00001) Then
                            fb_Kd = data_Kd
                        End If
                End Select

            End If
        Next

        draw(data_uart0, data_uart1, data_uart2, timer)
    End Sub

    Private Sub btMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMode.Click
        If btMode.Text = "Normal" Then
            intmode = 0
            btMode.Text = "Scroll"
        Else
            intmode = 1
            btMode.Text = "Normal"
        End If
    End Sub

    Private Sub draw(ByVal data0 As Single, ByVal data1 As Single, ByVal data2 As Single, ByVal t As Double)
        Dim curve0 As LineItem = Zed1.GraphPane.CurveList(0)
        Dim curve1 As LineItem = Zed1.GraphPane.CurveList(1)
        Dim curve2 As LineItem = Zed2.GraphPane.CurveList(0)
        If IsDBNull(curve0) Then
            Return
        End If
        If IsDBNull(curve1) Then
            Return
        End If
        If IsDBNull(curve2) Then
            Return
        End If
        Dim list0 As IPointListEdit = curve0.Points
        Dim list1 As IPointListEdit = curve1.Points
        Dim list2 As IPointListEdit = curve2.Points
        If IsDBNull(list0) Then
            Return
        End If
        If IsDBNull(list1) Then
            Return
        End If
        If IsDBNull(list2) Then
            Return
        End If
        list0.Add(t, data0)
        list1.Add(t, data1)
        list2.Add(t, data2)

        Dim timer As Double = (Environment.TickCount - TickStart) / 1000.0
        Dim xScale1 As Scale = Zed1.GraphPane.XAxis.Scale
        Dim xScale2 As Scale = Zed2.GraphPane.XAxis.Scale
        If timer > (xScale1.Max - xScale1.MajorStep) Then
            If intmode = 1 Then
                xScale1.Max = timer + xScale2.MajorStep
                xScale1.Min = xScale1.Max - 5
            Else
                xScale1.Max = timer + xScale1.MajorStep
                xScale1.Min = 0
            End If
        End If
        If timer > (xScale2.Max - xScale2.MajorStep) Then
            If intmode = 1 Then
                xScale2.Max = timer + xScale2.MajorStep
                xScale2.Min = xScale2.Max - 5
            Else
                xScale2.Max = timer + xScale2.MajorStep
                xScale2.Min = 0
            End If
        End If
        ''''''''''''''''''''''''''''''''''
        Zed1.AxisChange()
        Zed2.AxisChange()
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Zed1.Refresh()
        Zed2.Refresh()
        tbUART0.Text = CStr(data_uart0)
        tbUART1.Text = CStr(data_uart1)
        tbUART2.Text = CStr(data_uart2)
        tbSetSpeedfb.Text = CStr(fb_set_speed)
        tbKpfb.Text = CStr(fb_Kp)
        tbKifb.Text = CStr(fb_Ki)
        tbKdfb.Text = CStr(fb_Kd)

        If tbSetSpeed.Text = String.Empty Or tbKp.Text = String.Empty Or
           tbKi.Text = String.Empty Or tbKd.Text = String.Empty Then
            btSend.Enabled = False
        Else
            btSend.Enabled = True
        End If
    End Sub
    Private Sub btSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSend.Click
        Send()
    End Sub
    Private Sub Send()
        Dim data_byte(3) As Byte
        Dim data_encode(6) As Byte

        data_set_speed = CSng(tbSetSpeed.Text)
        data_Kp = CSng(tbKp.Text)
        data_Ki = CSng(tbKi.Text)
        data_Kd = CSng(tbKd.Text)
        '-----------------------------------
        data_byte = BitConverter.GetBytes(data_set_speed).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HEA
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
        '-----------------------------------
        data_byte = BitConverter.GetBytes(data_Kp).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HEB
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
        '-----------------------------------
        data_byte = BitConverter.GetBytes(data_Ki).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HEC
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
        '-----------------------------------
        data_byte = BitConverter.GetBytes(data_Kd).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HED
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)

        If data_set_speed = 0 Then
            btMotor.Text = "RUN"
        Else
            btMotor.Text = "STOP"
        End If

    End Sub

    Private Sub btMotor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMotor.Click
        Dim data_set_speed As Single
        Dim data_byte(3) As Byte
        Dim data_encode(6) As Byte

        If btMotor.Text = "STOP" Then
            data_set_speed = 0.0
            btMotor.Text = "RUN"
        Else
            data_set_speed = CSng(tbSetSpeed.Text)
            btMotor.Text = "STOP"
        End If

        data_byte = BitConverter.GetBytes(data_set_speed).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HEA
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        Dim curve0 As LineItem = Zed1.GraphPane.CurveList(0)
        Dim curve1 As LineItem = Zed1.GraphPane.CurveList(1)
        Dim curve2 As LineItem = Zed2.GraphPane.CurveList(0)

        Dim list0 As IPointListEdit = curve0.Points
        Dim list1 As IPointListEdit = curve1.Points
        Dim list2 As IPointListEdit = curve2.Points

        Dim xScale1 As Scale = Zed1.GraphPane.XAxis.Scale
        Dim xScale2 As Scale = Zed2.GraphPane.XAxis.Scale

        list0.Clear()
        list1.Clear()
        list2.Clear()

        xScale1.Min = 0
        xScale2.Min = 0
        xScale1.Max = 5
        xScale2.Max = 5

        Zed1.AxisChange()
        Zed2.AxisChange()

        TickStart = Environment.TickCount
    End Sub
End Class
