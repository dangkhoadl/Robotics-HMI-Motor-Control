Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports ZedGraph

Public Class Form1
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Dim intlen As Integer
    Dim begindata As Byte
    Dim datasize As Integer = 28
    Dim data(datasize) As Byte
    Dim number As Integer
    Dim bytesend(10) As Byte
    Dim intmode = 1
    Dim TickStart As Integer = Environment.TickCount

    Dim uart0 As Double = 4.0
    Dim uart1 As Double = 3.3
    Dim a As Double = 1.0

    'Dim data_update0 As Double
    'Dim data_update1 As Double
    'Dim data_update2 As Double
    'Dim data_update3 As Double
    Dim data_uart0 As Single
    Dim data_uart1 As Single
    Dim data_uart2 As Single
    Dim data_uart3 As Single
    Dim data_sent As Single

    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.ReadBufferSize = 256
        SerialPort1.ReceivedBytesThreshold = 2
        Dim myzed = Zed.GraphPane
        myzed.Title.Text = "Data"
        myzed.XAxis.Title.Text = "Times (s)"
        myzed.YAxis.Title.Text = "Speed (rpm)"
        Dim list0 As New RollingPointPairList(1000)
        Dim list1 As New RollingPointPairList(1000)
        Dim list2 As New RollingPointPairList(1000)
        Dim list3 As New RollingPointPairList(1000)

        Dim curve0 As LineItem = myzed.AddCurve("SPEED", list0, Color.Red, SymbolType.None)
        Dim curve1 As LineItem = myzed.AddCurve("PWM*10", list1, Color.Blue, SymbolType.None)
        Dim curve2 As LineItem = myzed.AddCurve("SETSPEED", list2, Color.Green, SymbolType.None)
        Dim curve3 As LineItem = myzed.AddCurve("UART3", list3, Color.DarkGreen, SymbolType.None)

        curve0.Line.Width = 2.0F
        curve1.Line.Width = 2.0F
        curve2.Line.Width = 2.0F
        curve3.Line.Width = 2.0F

        myzed.XAxis.Scale.Min = 0
        myzed.XAxis.Scale.Max = 5
        myzed.XAxis.Scale.MinorStep = 1
        myzed.XAxis.Scale.MajorStep = 0.5

        myzed.YAxis.Scale.Min = 0
        myzed.YAxis.Scale.Max = 3000
        myzed.YAxis.Scale.MinorStep = 500
        myzed.YAxis.Scale.MajorStep = 250

        Zed.AxisChange()

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

    Private Sub BtConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConnect.Click
        If LbStatus.Text = "Disconnect" Then
            SerialPort1.PortName = CbCOM.Text
            SerialPort1.Open()
            LbStatus.Text = "Connect"
            BtConnect.Text = "Disconnect"
        Else
            SerialPort1.Close()
            LbStatus.Text = "Disconnect"
            BtConnect.Text = "Connect"

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
                        data_uart0 = CDbl(BitConverter.ToSingle(data, i + 2))
                    Case &HF1
                        data_uart1 = CDbl(BitConverter.ToSingle(data, i + 2))
                    Case &HF2
                        data_uart2 = CDbl(BitConverter.ToSingle(data, i + 2))
                    Case &HF3
                        data_uart3 = CDbl(BitConverter.ToSingle(data, i + 2))
                End Select
            End If
        Next
        draw(data_uart0, data_uart1, data_uart2, data_uart3, timer)
    End Sub
    Private Sub btmode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMode.Click
        If btMode.Text = "Normal" Then
            intmode = 0
            btMode.Text = "Scroll"
        Else
            intmode = 1
            btMode.Text = "Normal"
        End If
    End Sub

    Private Sub draw(ByVal data0 As Single, ByVal data1 As Single, ByVal data2 As Single, ByVal data3 As Single, ByVal t As Double)
        If Zed.GraphPane.CurveList.Count <= 0 Then
            Return
        End If
        Dim curve0 As LineItem = Zed.GraphPane.CurveList(0)
        Dim curve1 As LineItem = Zed.GraphPane.CurveList(1)
        Dim curve2 As LineItem = Zed.GraphPane.CurveList(2)
        Dim curve3 As LineItem = Zed.GraphPane.CurveList(3)
        If IsDBNull(curve0) Then
            Return
        End If
        If IsDBNull(curve1) Then
            Return
        End If
        If IsDBNull(curve2) Then
            Return
        End If
        If IsDBNull(curve3) Then
            Return
        End If
        Dim list0 As IPointListEdit = curve0.Points
        Dim list1 As IPointListEdit = curve1.Points
        Dim list2 As IPointListEdit = curve2.Points
        Dim list3 As IPointListEdit = curve3.Points
        If IsDBNull(list0) Then
            Return
        End If
        If IsDBNull(list1) Then
            Return
        End If
        If IsDBNull(list2) Then
            Return
        End If
        If IsDBNull(list3) Then
            Return
        End If

        list0.Add(t, data0)
        list1.Add(t, data1)
        list2.Add(t, data2)
        list3.Add(t, data3)

        Dim timer As Double = (Environment.TickCount - TickStart) / 1000.0
        Dim xScale As Scale = Zed.GraphPane.XAxis.Scale
        If timer > (xScale.Max - xScale.MajorStep) Then
            If intmode = 1 Then
                xScale.Max = timer + xScale.MajorStep
                xScale.Min = xScale.Max - 5
            Else
                xScale.Max = timer + xScale.MajorStep
                xScale.Min = 0
            End If
        End If
        ''''''''''''''''''''''''''''''''''
        Zed.AxisChange()
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Zed.Refresh()
        tbUART0.Text = CStr(data_uart0)
        tbUART1.Text = CStr(data_uart1)
        tbUART2.Text = CStr(data_uart2)
        tbUART3.Text = CStr(data_uart3)

        If Kp.Text = String.Empty Or Ki.Text = String.Empty Or
           Kd.Text = String.Empty Or Speed.Text = String.Empty Then
            btSendPI.Enabled = False
        Else
            btSendPI.Enabled = True
        End If
    End Sub
    Private Sub btSendPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSendPI.Click
        SendPI()
    End Sub
    Private Sub SenddataUART(ByVal data As Single, ByVal des As Byte)
        Dim data_byte(3) As Byte
        Dim data_encode(6) As Byte
        data_byte = BitConverter.GetBytes(data).ToArray()
        data_encode(0) = &HFF
        data_encode(1) = des    'Kp &HEA  Ki &HEB  Kd &HEC   SPEED &HED    STOP &HE0 START &HE1
        For i = 2 To 5 Step 1
            data_encode(i) = data_byte(i - 2)
        Next
        data_encode(6) = &HFE
        SerialPort1.Write(data_encode, 0, 7)
    End Sub
    Private Sub SendPI()
        Dim data_Kp As Single
        Dim data_Ki As Single
        Dim data_Kd As Single
        Dim SpeedREF As Single

        data_Kp = CSng(Kp.Text)
        SenddataUART(data_Kp, &HEA)
        data_Ki = CSng(Ki.Text)
        SenddataUART(data_Ki, &HEB)
        data_Kd = CSng(Kd.Text)
        SenddataUART(data_Kd, &HEC)
        SpeedREF = CSng(Speed.Text)
        SenddataUART(SpeedREF, &HED)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SenddataUART(0, &HE0)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SenddataUART(0, &HE1)
    End Sub
End Class
