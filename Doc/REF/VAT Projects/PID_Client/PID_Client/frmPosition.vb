Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports ZedGraph

Public Class frmPosition
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Dim intlen As Integer
    Dim begindata As Byte
    Dim datasize As Integer = 28
    Dim data(datasize) As Byte
    Dim number As Integer
    Dim intmode = 1
    Dim TickStart As Integer = Environment.TickCount

    Dim data_set_position As Single
    Dim data_start_speed As Single
    Dim data_top_speed As Single
    Dim data_acc As Single
    Dim data_dec As Single

    Dim fb_set_position As Single
    Dim fb_start_speed As Single
    Dim fb_top_speed As Single
    Dim fb_acc As Single
    Dim fb_dec As Single

    Dim data_uart0 As Single 'Set Speed
    Dim data_uart1 As Single 'Feedback Speed
    Dim data_uart2 As Single 'Feedback Position
    Dim data_uart3 As Single 'Elapsed Time

    Dim ctrl_mode As Single = 0

    Dim inter_time As Single = 50 'Interpolation Time in ms
    Dim t_acc As Single 'in min
    Dim t_dec As Single 'in min
    Dim t_top As Single 'in min
    Dim t_sum As Single 'in min
    Dim dis_acc As Single
    Dim dis_dec As Single
    Dim dis_top As Single
    Dim dir_factor As Single = 1

    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Private Sub frmSpeed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.ReadBufferSize = 64
        SerialPort1.ReceivedBytesThreshold = 2
        Dim myzed1 = Zed1.GraphPane
        Dim myzed2 = Zed2.GraphPane

        myzed1.Title.Text = "Motor Speed"
        myzed1.XAxis.Title.Text = "Times (s)"
        myzed1.YAxis.Title.Text = "Speed (RPM)"

        myzed2.Title.Text = "Position"
        myzed2.XAxis.Title.Text = "Times (s)"
        myzed2.YAxis.Title.Text = "Round"

        Dim list0 As New RollingPointPairList(1000)
        Dim list1 As New RollingPointPairList(1000)
        Dim list2 As New RollingPointPairList(1000)

        Dim curve0 As LineItem = myzed1.AddCurve("Set Speed", list0, Color.Red, SymbolType.None)
        Dim curve1 As LineItem = myzed1.AddCurve("Feedback Speed", list1, Color.Blue, SymbolType.None)
        Dim curve2 As LineItem = myzed2.AddCurve("Feedback Position", list2, Color.Red, SymbolType.None)

        curve0.Line.Width = 2.0F
        curve1.Line.Width = 2.0F
        curve2.Line.Width = 2.0F

        myzed1.XAxis.Scale.Min = 0
        myzed1.XAxis.Scale.Max = 5
        myzed1.XAxis.Scale.MinorStep = 0.1
        myzed1.XAxis.Scale.MajorStep = 0.5

        myzed1.YAxis.Scale.Min = -3500
        myzed1.YAxis.Scale.Max = 3500
        myzed1.YAxis.Scale.MinorStep = 100
        myzed1.YAxis.Scale.MajorStep = 500

        myzed2.XAxis.Scale.Min = 0
        myzed2.XAxis.Scale.Max = 5
        myzed2.XAxis.Scale.MinorStep = 0.1
        myzed2.XAxis.Scale.MajorStep = 0.5

        myzed2.YAxis.Scale.Min = -2000
        myzed2.YAxis.Scale.Max = 2000
        myzed2.YAxis.Scale.MinorStep = 100
        myzed2.YAxis.Scale.MajorStep = 500

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
                If SerialPort1.IsOpen = True Then
                    CbCOM.Text = SerialPort1.PortName
                Else
                    CbCOM.Text = CbCOM.Items.Item(0)
                End If
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

            ctrl_mode = 2
            send_data(ctrl_mode, 0)
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
                    Case &HF9
                        data_uart3 = CSng(BitConverter.ToSingle(data, i + 2))
                    Case &HF3
                        fb_set_position = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_set_position - data_set_position) < 0.00001 And (fb_set_position - data_set_position) > -0.00001) Then
                            fb_set_position = data_set_position
                        End If
                    Case &HF4
                        fb_start_speed = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_start_speed - data_start_speed) < 0.00001 And (fb_start_speed - data_start_speed) > -0.00001) Then
                            fb_start_speed = data_start_speed
                        End If
                    Case &HF5
                        fb_top_speed = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_top_speed - data_top_speed) < 0.00001 And (fb_top_speed - data_top_speed) > -0.00001) Then
                            fb_top_speed = data_top_speed
                        End If
                    Case &HF6
                        fb_acc = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_acc - data_acc) < 0.00001 And (fb_acc - data_acc) > -0.00001) Then
                            fb_acc = data_acc
                        End If
                    Case &HF7
                        fb_dec = CSng(BitConverter.ToSingle(data, i + 2))
                        If ((fb_dec - data_dec) < 0.00001 And (fb_dec - data_dec) > -0.00001) Then
                            fb_dec = data_dec
                        End If
                    Case &HF8
                        ctrl_mode = CSng(BitConverter.ToSingle(data, i + 2))
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
        tbUART3.Text = CStr(data_uart3 / 1000)
        tbSetPosfb.Text = CStr(fb_set_position)
        tbStartSpeedfb.Text = CStr(fb_start_speed)
        tbTopSpeedfb.Text = CStr(fb_top_speed)
        tbAccfb.Text = CStr(fb_acc)
        tbDecfb.Text = CStr(fb_dec)

        If tbSetPosition.Text = String.Empty Or tbStartSpeed.Text = String.Empty Or tbTopSpeed.Text = String.Empty Or
           tbAcceleration.Text = String.Empty Or tbDeceleration.Text = String.Empty Or lbStatus.Text = "Disconnected" Then
            btSend.Enabled = False
        Else
            btSend.Enabled = True
        End If

        If lbStatus.Text = "Disconnected" Then
            btMotor.Enabled = False
        Else
            btMotor.Enabled = True
        End If

        If ctrl_mode = 1 Then
            btSpeed_Click(sender, e)
        End If

    End Sub

    Private Sub btEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEstimate.Click
        data_set_position = CSng(tbSetPosition.Text)
        data_start_speed = CSng(tbStartSpeed.Text)
        data_top_speed = CSng(tbTopSpeed.Text)
        data_acc = CSng(tbAcceleration.Text)
        data_dec = CSng(tbDeceleration.Text)

        dir_factor = data_set_position / Math.Abs(data_set_position)

        t_acc = (data_top_speed - data_start_speed) / (data_acc * 60000 / inter_time)
        t_dec = (data_top_speed - data_start_speed) / (data_dec * 60000 / inter_time)
        dis_acc = dir_factor * (data_start_speed * t_acc + 0.5 * (data_acc * 60000 / inter_time) * t_acc * t_acc)
        dis_dec = dir_factor * (data_start_speed * t_dec + 0.5 * (data_dec * 60000 / inter_time) * t_dec * t_dec)
        dis_top = data_set_position - dis_acc - dis_dec
        t_top = dir_factor * dis_top / data_top_speed
        t_sum = t_acc + t_dec + t_top

        tbDisAcc.Text = CStr(dis_acc)
        tbDisDec.Text = CStr(dis_dec)
        tbDisTop.Text = CStr(dis_top)
        tbTotalTime.Text = CStr(t_sum * 60)

    End Sub

    Private Sub btSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSend.Click
        'data_set_position = CSng(tbSetPosition.Text)
        'data_start_speed = CSng(tbStartSpeed.Text)
        'data_top_speed = CSng(tbTopSpeed.Text)
        'data_acc = CSng(tbAcceleration.Text)
        'data_dec = CSng(tbDeceleration.Text)

        btEstimate_Click(sender, e)

        send_data(data_set_position, 1)
        send_data(data_start_speed, 2)
        send_data(data_top_speed, 3)
        send_data(data_acc, 4)
        send_data(data_dec, 5)

        Dim yScale1 As Scale = Zed1.GraphPane.YAxis.Scale
        Dim yScale2 As Scale = Zed2.GraphPane.YAxis.Scale

        yScale1.Max = dir_factor * data_top_speed * 1.2
        yScale1.Min = -dir_factor * data_top_speed * 0.2
        If yScale1.Max < yScale1.Min Then
            yScale1.Max = yScale1.Min
            yScale1.Min = dir_factor * data_top_speed * 1.2
        End If
        If data_top_speed >= 1000 Then
            yScale1.MinorStep = 100
            yScale1.MajorStep = 500
        ElseIf data_top_speed >= 100 Then
            yScale1.MinorStep = 10
            yScale1.MajorStep = 50
        Else
            yScale1.MinorStep = 1
            yScale1.MajorStep = 5
        End If
        Zed1.AxisChange()

        yScale2.Max = data_set_position * 1.2
        yScale2.Min = -data_set_position * 0.2
        If yScale2.Max < yScale2.Min Then
            yScale2.Max = yScale2.Min
            yScale2.Min = data_set_position * 1.2
        End If
        If data_set_position >= 1000 Then
            yScale2.MinorStep = 100
            yScale2.MajorStep = 500
        ElseIf data_set_position >= 100 Then
            yScale2.MinorStep = 10
            yScale2.MajorStep = 50
        Else
            yScale2.MinorStep = 1
            yScale2.MajorStep = 5
        End If
        Zed2.AxisChange()

    End Sub

    Private Sub send_data(ByVal data As Single, ByVal channel As Integer)
        Dim data_byte(3) As Byte
        Dim data_encode(6) As Byte

        data_byte = BitConverter.GetBytes(data).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = &HE0 + channel
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
    End Sub

    Private Sub btMotor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMotor.Click
        send_data(0, 6)
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

    Private Sub btSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSpeed.Click
        frmSpeed.Show()

        If lbStatus.Text = "Connected" Then
            SerialPort1.Close()
            frmSpeed.CbCOM.Text = CbCOM.Text
            frmSpeed.btConnect.PerformClick()
        End If

        Me.Close()
    End Sub

End Class
