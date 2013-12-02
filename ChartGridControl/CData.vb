Public Class CData

    Public ParentSeries As CSeries

    'Data array
    Public Value(,) As Nullable(Of Double)
    Public Name As String
    Public NumberOfRows As Byte ' Use internal series, for example, we can include the corresponding confidence limits in the main series

    ' --- curve description
    Public L_Description() As CSeries.StrLDescription

    Sub New(ByVal _ParentSeries As CSeries, Optional ByVal _NumberOfRows As Byte = 1)
        ParentSeries = _ParentSeries
        NumberOfRows = _NumberOfRows
    End Sub

    ' Load data from file
    ' data is an array [N,2]: first column - Date, second column - series
    Public Function LoadData(ByVal data As Object(,), ByVal seriesIndex As Integer) As Boolean
        ParentSeries.Date_first = data(1, 0)
        ParentSeries.Date_last = data(data.GetLength(0) - 1, 0)

        If ParentSeries.Date_detail = -1 Then
            Dim Date_second As Date = data(2, 0)
            For i = 0 To 4 'EDateInterval in CartGridControl
                If DateDiff(ParentSeries.ParentControl.Date_interval(i), _
                            ParentSeries.ParentControl.ClearDate(ParentSeries.Date_first, i), _
                            ParentSeries.ParentControl.ClearDate(Date_second, i), _
                            FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) = 1 Then
                    ParentSeries.Date_detail = i
                End If
            Next
        End If

        'select Date_interval
        Dim interval As DateInterval
        If ParentSeries.ParentControl.IsEmptyControl Then
            interval = ParentSeries.ParentControl.Date_interval(ParentSeries.Date_detail)
        Else
            interval = ParentSeries.ParentControl.Date_interval(ParentSeries.ParentControl.Date_detail)
        End If

        'clear date
        ParentSeries.Date_first = ParentSeries.ParentControl.ClearDate(ParentSeries.Date_first, ParentSeries.Date_detail)
        ParentSeries.Date_last = ParentSeries.ParentControl.ClearDate(ParentSeries.Date_last, ParentSeries.Date_detail)

        Name = data(0, seriesIndex)

        ReDim Value(ParentSeries.NumberOfCases - 1, 0)
        Dim j As Integer = 1

        For i = 0 To ParentSeries.NumberOfCases - 1
            If DateAdd(interval, i, ParentSeries.Date_first) < data(j, 0) Then
                Value(i, 0) = Nothing
            Else
                Value(i, 0) = data(j, seriesIndex)
                j += 1
            End If
        Next

        Return True
    End Function

    ' --- Default curve settings
    Public Sub LoadDefL_Description()
        ReDim L_Description(NumberOfRows - 1)
        Dim r = New Random()

        L_Description(0).L_IsVisible = True
        L_Description(0).L_Label = Name
        L_Description(0).L_Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)) 'Color.Blue
        L_Description(0).L_Width = 2
        L_Description(0).L_Style = Drawing2D.DashStyle.Solid
        L_Description(0).L_Symbol = r.Next(9) 'ZedGraph.SymbolType.Circle
        L_Description(0).L_SymbolSize = 4
        L_Description(0).L_IsVisibleSymbol = True
        L_Description(0).L_CanMove = True

        'if main series has additional (internal) series
        If NumberOfRows > 1 Then
            For i = 0 To NumberOfRows - 1
                L_Description(i).L_IsVisible = True
                L_Description(i).L_Label = Name + "_" + (i + 1).ToString
                L_Description(i).L_Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))
                L_Description(i).L_Width = 2
                L_Description(i).L_Style = Drawing2D.DashStyle.Solid
                L_Description(i).L_Symbol = r.Next(9) 'ZedGraph.SymbolType.Circle
                L_Description(i).L_SymbolSize = 4
                L_Description(i).L_IsVisibleSymbol = True
                L_Description(i).L_CanMove = False
            Next
        End If
    End Sub

    ' Transform End Date, according to detail
    Private Function ConvertDateByDetail(ByVal date_ As Date) As Date
        If ParentSeries.ParentControl.Date_detail = ChartGridControl.EDateInterval.Hour Then
            Return date_
        End If

        ' ----------------------------   day -> 23:00
        If date_.Hour < 23 Then
            date_ = DateAdd(DateInterval.Hour, -1 * (date_.Hour + 1), date_)
        End If
        If ParentSeries.ParentControl.Date_detail = ChartGridControl.EDateInterval.Day Then
            Return date_
        End If

        ' ----------------------------   week -> sunday 23:00
        Dim Date_week As Date
        If date_.DayOfWeek <> DayOfWeek.Sunday Then
            Date_week = DateAdd(DateInterval.Day, -1 * date_.DayOfWeek, date_)
        End If
        If ParentSeries.ParentControl.Date_detail = ChartGridControl.EDateInterval.WeekOfYear Then
            Return Date_week
        End If

        ' --------------------------- month -> last day 23:00
        If date_.AddDays(1).Day <> 1 Then
            date_ = DateAdd(DateInterval.Day, -1 * (date_.Day), date_)
        End If
        Return date_
    End Function
End Class
