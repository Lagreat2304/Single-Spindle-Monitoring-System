Imports System.Drawing
Imports System.Globalization
Imports System.Math
Module ModuleCommonFunction
    Public Sub BackgroundGradient(ByRef Control As Object,
                                ByVal Color1 As Drawing.Color,
                                ByVal Color2 As Drawing.Color)

        Dim vLinearGradient As Drawing.Drawing2D.LinearGradientBrush =
            New Drawing.Drawing2D.LinearGradientBrush(New Drawing.Point(Control.Width, Control.Height),
                                                        New Drawing.Point(Control.Width, 0),
                                                        Color1,
                                                        Color2)

        Dim vGraphic As Drawing.Graphics = Control.CreateGraphics
        ' To tile the image background - Using the same image background of the image
        Dim vTexture As New Drawing.TextureBrush(Control.BackgroundImage)

        vGraphic.FillRectangle(vLinearGradient, Control.DisplayRectangle)
        ' vGraphic.FillRectangle(vTexture, Control.DisplayRectangle)

        vGraphic.Dispose() : vGraphic = Nothing : vTexture.Dispose() : vTexture = Nothing
    End Sub
    Public Sub FormAlign(ByVal objForm As Form)
        Try
            objForm.Top = ((Screen.PrimaryScreen.WorkingArea.Height / 2) - (objForm.Height / 2)) + 100
            objForm.Left = ((Screen.PrimaryScreen.WorkingArea.Width / 2) - (objForm.Width / 2)) + 100
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub
    Public Sub Show_Message(ByVal MessageBoxMessage As String, Optional ByVal MessageBoxTitle As String = "S2MS")
        mvarMessageText = ""
        mvarMessageType = ""
        mvarMessageText = MessageBoxMessage
        mvarMessageType = MessageBoxTitle
        MessageBox.Show(MessageBoxMessage, MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Function LongToHexRev01(lLong As Long) As String
        ' by Donald, donald@xbeat.net, 20010910
        Static sTmp As String
        Dim i As Long
        ' to hex, left-padd zeroes
        sTmp = Right$("0000" & Hex$(lLong), 4)
        LongToHexRev01 = sTmp
        ' reverse byte order
        For i = 1 To 3 Step 2
            Mid$(LongToHexRev01, 4 - i) = Mid$(sTmp, i, 2)
        Next
    End Function

    Public Function HexStringToBinary(ByVal hexString As String) As String
        Dim num As Integer = Integer.Parse(hexString, NumberStyles.HexNumber)
        Return Convert.ToString(num, 2)
    End Function

    Public Function ConvertHexToBin(ByVal a As String) As String  'Converts Hex to Binary
        Dim strRet As String = String.Empty
        Dim strB As String
        For j As Integer = 0 To a.Length - 1
            strB = "0000" & Convert.ToString(Convert.ToInt32(a.Substring(j, 1), 16), 2)
            strRet &= strB.Substring(strB.Length - 4, 4) & ""
        Next
        Return strRet
    End Function

    Public Function BinToHex(BinNum As String) As String
        Dim BinLen As Integer, i As Integer
        Dim HexNum As Object
        BinLen = Len(BinNum)
        For i = BinLen To 1 Step -1
            '     Check the string for invalid characters
            If Asc(Mid(BinNum, i, 1)) < 48 Or
               Asc(Mid(BinNum, i, 1)) > 49 Then
                HexNum = ""
                Err.Raise(1002, "BinToHex", "Invalid Input")
            End If
            '     Calculate HEX value of BinNum
            If Mid(BinNum, i, 1) And 1 Then
                HexNum = HexNum + 2 ^ Abs(i - BinLen)
            End If
        Next i
        '  Return HexNum as String
        BinToHex = Hex(HexNum)
    End Function

    Public Function HexReverse(ByVal a As String) As String

        Dim hexCharArray As Char() = a.ToCharArray()
        Array.Reverse(hexCharArray)
        Dim hexStringReversed = New String(hexCharArray)
        Return hexStringReversed
    End Function

    Public Function HexStringReverse(ByVal value As String) As String

        If value.Length Mod 2 <> 0 Then value = "0" & value
        Dim buff As List(Of String) = New List(Of String)()
        For i As Integer = 0 To value.Length / 2
            buff.Add(value.Substring(i, 2))
            i += 1
        Next

        buff.Reverse()
        value = ""
        For Each x As String In buff
            value += x
        Next

        Return value
    End Function

    Public Function LongToHexRev011(lLong As String) As String
        ' by Donald, donald@xbeat.net, 20010910
        Static sTmp As String
        Dim i As Long
        ' to hex, left-padd zeroes
        sTmp = Right$("0000" & (lLong), 4)
        LongToHexRev011 = sTmp
        ' reverse byte order
        For i = 1 To 3 Step 2
            Mid$(LongToHexRev011, 4 - i) = Mid$(sTmp, i, 2)
        Next
    End Function
End Module
