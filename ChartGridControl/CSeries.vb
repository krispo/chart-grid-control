Public Class CSeries

    Public ParentControl As ChartGridControl        ' The object this series belonged to

    Public S_RowObject As CData                     ' Contains data 
    
    ' relate to the series
    Public Date_first As Date
    Public Date_last As Date
    Public Date_detail As ChartGridControl.EDateInterval

    Public S_Update As Boolean                      ' Series is changed

    ' --- Line block
    Public Structure StrLDescription
        Public L_IsVisible As Boolean
        Public L_Label As String
        Public L_Color As System.Drawing.Color
        Public L_Style As Drawing2D.DashStyle
        Public L_Width As Single
        Public L_Symbol As Object
        Public L_SymbolSize As Single
        Public L_IsVisibleSymbol As Boolean
        Public L_CanMove As Boolean
    End Structure

    ' --- Constructor
    Sub New(ByVal _ParentControl As ChartGridControl, Optional ByVal _Date_detail As Integer = -1)
        ParentControl = _ParentControl
        Date_detail = _Date_detail

        S_Update = False
    End Sub

    ' --- The number of cases in Series
    Public ReadOnly Property NumberOfCases(Optional ByVal date_interval As DateInterval = Nothing) As Integer
        Get
            If date_interval = Nothing Then
                If ParentControl.IsEmptyControl Then
                    date_interval = ParentControl.Date_interval(Date_detail)
                Else
                    date_interval = ParentControl.Date_interval(ParentControl.Date_detail)
                End If
            End If
            Return DateDiff(date_interval, Date_first, Date_last, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) + 1
        End Get
    End Property

    ' --- Shift rfom the first case of Object
    Public ReadOnly Property ShiftFromObjectTopCases As Long
        Get
            Return DateDiff(ParentControl.Date_interval, ParentControl.Date_first, Date_first, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        End Get
    End Property

    ' --- The Series ID
    Public ReadOnly Property SeriesID() As Integer
        Get
            Return ParentControl.SeriesList.IndexOf(Me)
        End Get
    End Property
End Class
