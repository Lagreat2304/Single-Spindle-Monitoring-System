Imports System.Threading
Public Class FormSpindleView
    Dim mvarSno As Integer
    Private Sub FormSpindleView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            mvarSno = 1
            c1Tab.SelectedIndex = 0
            C1DockingTabPage2.Enabled = False
            lblAvgSpeed.Text = "0"

            Fill_Grid_Title()
            'Fill_Grid_Data()
            'Fill_Color()

        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Fill_Grid_Title()
        c1fgLHS.Clear()
        c1fgRHS.Clear()

        With c1fgLHS
            .Rows = 41
            .Cols = 25

            For iCol = 1 To .Cols - 1
                .set_TextMatrix(0, iCol, iCol.ToString())
            Next

            Dim i, j As Integer

            i = 1
            j = 24
            For iRow As Integer = 1 To c1fgLHS.Rows - 1
                .set_TextMatrix(iRow, 0, i.ToString + "-" + j.ToString)
                i = i + 24
                j = j + 24
            Next

            For iCol As Integer = 0 To .Cols - 1
                .set_ColWidth(iCol, 90)
            Next

            .KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 0, 0, 0, .Cols - 1) = 3
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 0, 0, 0, .Cols - 1) = True

            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 1, 0, .Rows - 1, 0) = 3
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 1, 0, .Rows - 1, 0) = True
        End With

        With c1fgRHS
            .Rows = 41
            .Cols = 25

            For iCol = 1 To .Cols - 1
                .set_TextMatrix(0, iCol, iCol.ToString())
            Next

            Dim i, j As Integer

            i = 1
            j = 24
            For iRow As Integer = 1 To c1fgLHS.Rows - 1
                .set_TextMatrix(iRow, 0, i.ToString + "-" + j.ToString)
                i = i + 24
                j = j + 24
            Next

            For iCol As Integer = 0 To .Cols - 1
                .set_ColWidth(iCol, 90)
            Next

            .KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 0, 0, 0, .Cols - 1) = 3
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 0, 0, 0, .Cols - 1) = True

            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 1, 0, .Rows - 1, 0) = 3
            .Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 1, 0, .Rows - 1, 0) = True
        End With

        'Thread.Sleep(10000)
    End Sub
    Private Sub Fill_Grid_Data()
        Try
            ds = Nothing
            ds = New DataSet

            If mvarSno > 5 Then
                mvarSno = 1
            End If
            SSQL = ""
            SSQL = "SELECT Top 1 RawData FROM s2ms..machine_binarydata where sno=" & mvarSno & ""

            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")
            If ds.Tables(0).Rows.Count <= 0 Then
                Show_Message("Information : No record found.")
                Exit Sub
            End If

            Dim mRawData As String = Nothing
            Dim mvarRawString1 As String = Nothing
            Dim mvarRawString2 As String = Nothing

            mvarRawString1 = ""
            mvarRawString2 = ""

            mRawData = Trim(ds.Tables(0).Rows(0)(0))

            Dim mstr() As String = Split(mRawData, "AA44120C")

            If mRawData = "" Then Exit Sub

            mvarRawString1 = "AA44120C" + Trim(mstr(1))
            mvarRawString2 = "AA44120C" + Trim(mstr(2))

            Fill_Left_Data(mvarRawString1)
            Fill_Right_Data(mvarRawString2)

            mvarSno = mvarSno + 1
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Fill_Left_Data(ByVal mvarRawString1 As String)
        Try
            Dim mvarFindFetchData1 As String = ""

            mvarFindFetchData1 = mvarRawString1.Substring(0, 32)

            '01 - Machine ID
            Dim mMachineID1 As String = mvarRawString1.Substring(8, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(2, iCol, mMachineID)
            'Next


            ' 4008 1004 - Reverse (0410 - 1040 including header) C0A8 0002 581B 6001 9421 CF8F - 8X2 = 16 byte = 1040 - 16 = 1024
            ' To find and fetch 1024 byte
            Dim mValue1 As String = ""
            mValue1 = mvarFindFetchData1.Substring(4, 4)
            mValue1 = LongToHexRev01("&H" & mValue1)
            mValue1 = CInt("&H" & mValue1) - ((mvarFindFetchData1.Length / 4) * 2)

            '  mvarRawString = mvarRawString.Replace(mvarFindFetchData, "")

            '''MsgBox(mvarRawString)

            'Header Sync AA4412 header length 0C (OC - 12 dynamic header length including AA44)


            '10 - Message ID
            Dim mMessageID1 As String = mvarRawString1.Substring(10, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(3, iCol, mMessageID)
            'Next


            '0000- TimeStamp
            Dim mTimestamp1 As String = mvarRawString1.Substring(12, 4)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(4, iCol, mTimestamp)
            'Next

            '00 - 0 LHS  / 1 - RHS
            Dim mLHSRHS As String = mvarRawString1.Substring(16, 2)
            For iRow As Integer = 1 To c1fgLHS.Rows - 1
                c1fgLHS.set_TextMatrix(iRow, 0, c1fgLHS.get_TextMatrix(iRow, 0) + " - " + IIf(mLHSRHS = "00", "L", "R"))
            Next

            '00 - Sequence number (Packets to be - Future reference purpose)
            Dim mSeqNo1 As String = mvarRawString1.Substring(18, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(6, iCol, mSeqNo)
            'Next

            'DC08 - Message Length 08DC (Reverse - 2268 - Left side data)
            Dim mMessageLength1 As String = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(20, 4)))
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(7, iCol, mMessageLength)
            'Next

            Dim mvarMessageLengthString1 As String = ""
            mvarMessageLengthString1 = mvarRawString1.Substring(24, CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(20, 4))))

            'FB38 - Avg Speed (Reverse 38FB - Formula) - Decimal 14587
            'Speed=1500000/14587=102.8313 * 60 = 6169.877288 rpm

            Dim mvarAvgSpeed1 As String = ""
            '            MsgBox(mvarMessageLengthString.Substring(0, 4))
            If CInt("&H" & LongToHexRev01("&H" & mvarMessageLengthString1.Substring(0, 4))) > 0 Then
                mvarAvgSpeed1 = (1500000 / CInt("&H" & LongToHexRev01("&H" & mvarMessageLengthString1.Substring(0, 4)))) * 60
            Else
                mvarAvgSpeed1 = 0
            End If

            For iCol As Integer = 1 To c1fgLHS.Cols - 1
                'c1fg.set_TextMatrix(8, iCol, Replace(FormatNumber(CDbl(mvarAvgSpeed), 3), ",", ""))

            Next
            lblAvgSpeed.Text = Replace(FormatNumber(CDbl(mvarAvgSpeed1), 3), ",", "")



            Dim mNextNo1 As Integer = 28


            '0100 - Start Spindl no (reverse - 0001)
            Dim mRowNo1 As Integer = 0
            Dim mSection As Integer = 0



1:
            mSection = mSection + 1

            Dim mCountNo1 As Integer = 0
            mCountNo1 = mCountNo1 + 1
            mRowNo1 = mRowNo1 + 1

            Dim mStartSpndlNo1 As Integer = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4)))
            mNextNo1 = mNextNo1 + 4

            '1800 - No of Spindle reverse (0018) - 24 (total Spindl nos)
            Dim mEndSpndlNo1 As Integer = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4)))



            'If mStartSpndlNo1 > 0 And mEndSpndlNo1 > 0 Then
            For iColNo As Integer = 1 To 24
                'Spndl Speed / Status
                mNextNo1 = mNextNo1 + 4

                Dim mHexValue As String = LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4))

                'MsgBox("Section no is  " & mSection.ToString() & " Spindle no is " & iColNo & vbNewLine & mNextNo1.ToString() & "-4  the out come is " & mvarRawString1.Substring(mNextNo1, 4).ToString())

                'Dim mHex2Dec As Double = CDbl("&H" & LongToHexRev01("&H" & mvarRawString.Substring(mNextNo, 4)))

                Dim mHex2Dec As Double = CDbl("&H" & mHexValue.Substring(1, 3))



                Dim mHex2Bin As String = ConvertHexToBin(mHexValue)
                Dim mSign As String = mHex2Bin.Substring(3, 1)
                Dim mStatus As String = mHex2Bin.Substring(0, 3)

                Dim mvarSpndlSpeed As String = ""
                '            MsgBox(mvarMessageLengthString.Substring(0, 4))
                If CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(24, 4))) > 0 Then
                    Dim i As Double = 0
                    i = CDbl("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(24, 4)))
                    If mSign = "0" Then
                        i = i + mHex2Dec
                    Else
                        i = i - mHex2Dec
                    End If
                    mvarSpndlSpeed = (1500000 / i) * 60
                Else
                    mvarSpndlSpeed = 0
                End If


                If mHexValue = "0000" Then
                    mvarSpndlSpeed = 0
                End If


                Dim mText As String = ""

                If mStatus = "000" Then 'Running
                    'c1fg.set_TextMatrix(10, iColNo, "Running")
                    mText = Replace(FormatNumber(CDbl(mvarSpndlSpeed), 3), ",", "").ToString
                    If mvarSpndlSpeed = 0 Then
                        mText = ""
                    End If
                ElseIf mStatus = "001" Then 'Break
                    'c1fg.set_TextMatrix(8, iColNo, "0")
                    'c1fg.set_TextMatrix(9, iColNo, "0")
                    'c1fg.set_TextMatrix(10, iColNo, "Break")
                    mText = "Break"
                ElseIf mStatus = "010" Then 'Idle
                    'c1fg.set_TextMatrix(8, iColNo, "0")
                    'c1fg.set_TextMatrix(9, iColNo, "0")
                    'c1fg.set_TextMatrix(10, iColNo, "Idle")
                    mText = "Idle"
                ElseIf mStatus = "011" Then 'Rogue
                    'c1fg.set_TextMatrix(10, iColNo, "Rogue")
                    mText = "Rogue"
                ElseIf mStatus = "100" Then 'Slip
                    'c1fg.set_TextMatrix(10, iColNo, "Slip")
                    mText = "Slip"
                ElseIf mStatus = "101" Then 'Abnormal slip
                    'c1fg.set_TextMatrix(10, iColNo, "Abnormal slip")
                    mText = "Abnormal slip"
                Else
                    'c1fg.set_TextMatrix(10, iColNo, "")
                    mText = ""

                End If

                c1fgLHS.set_TextMatrix(mRowNo1, iColNo, mText)

                'c1fg.set_TextMatrix(9, iColNo, Replace(FormatNumber(CDbl(mvarSpndlSpeed), 3), ",", ""))
                'mNextNo1 = mNextNo1 + 4
            Next
            mCountNo1 = mCountNo1 + 1
            If mCountNo1 <= 40 Then
                mNextNo1 = mNextNo1 + 4
                GoTo 1
            End If
            'End If
            c1fgLHS.Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 1, 1, c1fgLHS.Rows - 1, c1fgLHS.Cols - 1) = 3
            'c1fg.Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 2, 1, c1fg.Rows - 1, c1fg.Cols - 1) = True
            'c1fgLHS.AutoSizeCols()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_Right_Data(ByVal mvarRawString1 As String)
        Try
            Dim mvarFindFetchData1 As String = ""

            mvarFindFetchData1 = mvarRawString1.Substring(0, 32)

            '01 - Machine ID
            Dim mMachineID1 As String = mvarRawString1.Substring(8, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(2, iCol, mMachineID)
            'Next


            ' 4008 1004 - Reverse (0410 - 1040 including header) C0A8 0002 581B 6001 9421 CF8F - 8X2 = 16 byte = 1040 - 16 = 1024
            ' To find and fetch 1024 byte
            Dim mValue1 As String = ""
            mValue1 = mvarFindFetchData1.Substring(4, 4)
            mValue1 = LongToHexRev01("&H" & mValue1)
            mValue1 = CInt("&H" & mValue1) - ((mvarFindFetchData1.Length / 4) * 2)

            '  mvarRawString = mvarRawString.Replace(mvarFindFetchData, "")

            '''MsgBox(mvarRawString)

            'Header Sync AA4412 header length 0C (OC - 12 dynamic header length including AA44)


            '10 - Message ID
            Dim mMessageID1 As String = mvarRawString1.Substring(10, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(3, iCol, mMessageID)
            'Next


            '0000- TimeStamp
            Dim mTimestamp1 As String = mvarRawString1.Substring(12, 4)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(4, iCol, mTimestamp)
            'Next

            '00 - 0 LHS  / 1 - RHS
            Dim mLHSRHS As String = mvarRawString1.Substring(16, 2)
            For iRow As Integer = 1 To c1fgRHS.Rows - 1
                c1fgRHS.set_TextMatrix(iRow, 0, c1fgRHS.get_TextMatrix(iRow, 0) + " - " + IIf(mLHSRHS = "00", "L", "R"))
            Next

            '00 - Sequence number (Packets to be - Future reference purpose)
            Dim mSeqNo1 As String = mvarRawString1.Substring(18, 2)
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(6, iCol, mSeqNo)
            'Next

            'DC08 - Message Length 08DC (Reverse - 2268 - Left side data)
            Dim mMessageLength1 As String = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(20, 4)))
            'For iCol As Integer = 1 To c1fg.Cols - 1
            '    c1fg.set_TextMatrix(7, iCol, mMessageLength)
            'Next

            Dim mvarMessageLengthString1 As String = ""
            mvarMessageLengthString1 = mvarRawString1.Substring(24, CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(20, 4))))

            'FB38 - Avg Speed (Reverse 38FB - Formula) - Decimal 14587
            'Speed=1500000/14587=102.8313 * 60 = 6169.877288 rpm

            Dim mvarAvgSpeed1 As String = ""
            '            MsgBox(mvarMessageLengthString.Substring(0, 4))
            If CInt("&H" & LongToHexRev01("&H" & mvarMessageLengthString1.Substring(0, 4))) > 0 Then
                mvarAvgSpeed1 = (1500000 / CInt("&H" & LongToHexRev01("&H" & mvarMessageLengthString1.Substring(0, 4)))) * 60
            Else
                mvarAvgSpeed1 = 0
            End If

            For iCol As Integer = 1 To c1fgRHS.Cols - 1
                'c1fg.set_TextMatrix(8, iCol, Replace(FormatNumber(CDbl(mvarAvgSpeed), 3), ",", ""))

            Next
            'lblAvgSpeed.Text = Replace(FormatNumber(CDbl(mvarAvgSpeed1), 3), ",", "")



            Dim mNextNo1 As Integer = 28


            '0100 - Start Spindl no (reverse - 0001)
            Dim mRowNo1 As Integer = 0


1:
            Dim mCountNo1 As Integer = 0
            mCountNo1 = mCountNo1 + 1
            mRowNo1 = mRowNo1 + 1

            Dim mStartSpndlNo1 As Integer = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4)))
            mNextNo1 = mNextNo1 + 4

            '1800 - No of Spindle reverse (0018) - 24 (total Spindl nos)
            Dim mEndSpndlNo1 As Integer = CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4)))



            'If mStartSpndlNo1 > 0 And mEndSpndlNo1 > 0 Then
            For iColNo As Integer = 1 To 24
                'Spndl Speed / Status
                mNextNo1 = mNextNo1 + 4

                Dim mHexValue As String = LongToHexRev01("&H" & mvarRawString1.Substring(mNextNo1, 4))


                'Dim mHex2Dec As Double = CDbl("&H" & LongToHexRev01("&H" & mvarRawString.Substring(mNextNo, 4)))

                Dim mHex2Dec As Double = CDbl("&H" & mHexValue.Substring(1, 3))



                Dim mHex2Bin As String = ConvertHexToBin(mHexValue)
                Dim mSign As String = mHex2Bin.Substring(3, 1)
                Dim mStatus As String = mHex2Bin.Substring(0, 3)

                Dim mvarSpndlSpeed As String = ""
                '            MsgBox(mvarMessageLengthString.Substring(0, 4))
                If CInt("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(24, 4))) > 0 Then
                    Dim i As Double = 0
                    i = CDbl("&H" & LongToHexRev01("&H" & mvarRawString1.Substring(24, 4)))
                    If mSign = "0" Then
                        i = i + mHex2Dec
                    Else
                        i = i - mHex2Dec
                    End If
                    mvarSpndlSpeed = (1500000 / i) * 60
                Else
                    mvarSpndlSpeed = 0
                End If

                If mHexValue = "0000" Then
                    mvarSpndlSpeed = 0
                End If

                Dim mText As String = ""

                If mStatus = "000" Then 'Running
                    'c1fg.set_TextMatrix(10, iColNo, "Running")
                    mText = Replace(FormatNumber(CDbl(mvarSpndlSpeed), 3), ",", "").ToString
                    If mvarSpndlSpeed = 0 Then
                        mText = ""
                    End If
                ElseIf mStatus = "001" Then 'Break
                    'c1fg.set_TextMatrix(8, iColNo, "0")
                    'c1fg.set_TextMatrix(9, iColNo, "0")
                    'c1fg.set_TextMatrix(10, iColNo, "Break")
                    mText = "Break"
                ElseIf mStatus = "010" Then 'Idle
                    'c1fg.set_TextMatrix(8, iColNo, "0")
                    'c1fg.set_TextMatrix(9, iColNo, "0")
                    'c1fg.set_TextMatrix(10, iColNo, "Idle")
                    mText = "Idle"
                ElseIf mStatus = "011" Then 'Rogue
                    'c1fg.set_TextMatrix(10, iColNo, "Rogue")
                    mText = "Rogue"
                ElseIf mStatus = "100" Then 'Slip
                    'c1fg.set_TextMatrix(10, iColNo, "Slip")
                    mText = "Slip"
                ElseIf mStatus = "101" Then 'Abnormal slip
                    'c1fg.set_TextMatrix(10, iColNo, "Abnormal slip")
                    mText = "Abnormal slip"
                Else
                    'c1fg.set_TextMatrix(10, iColNo, "")
                    mText = ""

                End If

                c1fgRHS.set_TextMatrix(mRowNo1, iColNo, mText)

                'c1fg.set_TextMatrix(9, iColNo, Replace(FormatNumber(CDbl(mvarSpndlSpeed), 3), ",", ""))
                'mNextNo1 = mNextNo1 + 4
            Next
            mCountNo1 = mCountNo1 + 1
            If mCountNo1 <= 40 Then
                mNextNo1 = mNextNo1 + 4
                GoTo 1
            End If
            c1fgRHS.Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpAlignment, 1, 1, c1fgRHS.Rows - 1, c1fgRHS.Cols - 1) = 3
            'c1fg.Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpFontBold, 2, 1, c1fg.Rows - 1, c1fg.Cols - 1) = True
            'c1fgRHS.AutoSizeCols()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_Color()

        For iRow As Integer = 1 To c1fgLHS.Rows - 1
            For iCol As Integer = 1 To c1fgLHS.Cols - 1
                If Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Stopped")
                End If
            Next
        Next

        For iRow As Integer = 1 To c1fgRHS.Rows - 1
            For iCol As Integer = 1 To c1fgRHS.Cols - 1
                If Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Stopped")
                End If
            Next
        Next

        For iRow As Integer = 1 To c1fgLHS.Rows - 1
            For iCol As Integer = 1 To c1fgLHS.Cols - 1

                Dim NewStyle1 As C1.Win.C1FlexGrid.CellStyle

                If Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Break" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Break")
                    NewStyle1 = c1fgLHS.Styles.Add("Break" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(255, 146, 170)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Idle" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Idle")
                    NewStyle1 = c1fgLHS.Styles.Add("Idle" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(219, 36, 85)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Rogue" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Rogue")
                    NewStyle1 = c1fgLHS.Styles.Add("Rogue" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(73, 182, 85)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Slip" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Slip")
                    NewStyle1 = c1fgLHS.Styles.Add("Slip" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(146, 255, 170)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Abnormal Slip" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Abnormal Slip")
                    NewStyle1 = c1fgLHS.Styles.Add("AbnormalSlip" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(0, 146, 0)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgLHS.get_TextMatrix(iRow, iCol)) = "Stopped" Then
                    c1fgLHS.set_TextMatrix(iRow, iCol, "Stopped")
                    NewStyle1 = c1fgLHS.Styles.Add("Stopped" & iCol.ToString)
                    NewStyle1.BackColor = Color.Red
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgLHS.SetCellStyle(iRow, iCol, NewStyle1)
                End If
            Next
        Next


        For iRow As Integer = 1 To c1fgRHS.Rows - 1
            For iCol As Integer = 1 To c1fgRHS.Cols - 1

                Dim NewStyle1 As C1.Win.C1FlexGrid.CellStyle

                If Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Break" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Break")
                    NewStyle1 = c1fgRHS.Styles.Add("Break" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(255, 146, 170)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Idle" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Idle")
                    NewStyle1 = c1fgRHS.Styles.Add("Idle" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(219, 36, 85)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Rogue" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Rogue")
                    NewStyle1 = c1fgRHS.Styles.Add("Rogue" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(73, 182, 85)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Slip" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Slip")
                    NewStyle1 = c1fgRHS.Styles.Add("Slip" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(146, 255, 170)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Abnormal Slip" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Abnormal Slip")
                    NewStyle1 = c1fgRHS.Styles.Add("AbnormalSlip" & iCol.ToString)
                    NewStyle1.BackColor = Color.FromArgb(0, 146, 0)
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)

                ElseIf Trim(c1fgRHS.get_TextMatrix(iRow, iCol)) = "Stopped" Then
                    c1fgRHS.set_TextMatrix(iRow, iCol, "Stopped")
                    NewStyle1 = c1fgRHS.Styles.Add("Stopped" & iCol.ToString)
                    NewStyle1.BackColor = Color.Red
                    NewStyle1.ForeColor = Color.White
                    NewStyle1.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    c1fgRHS.SetCellStyle(iRow, iCol, NewStyle1)
                End If
            Next
        Next

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        lblAvgSpeed.Text = "0"
        Fill_Grid_Title()
        Fill_Grid_Data()
        Fill_Color()
    End Sub
End Class