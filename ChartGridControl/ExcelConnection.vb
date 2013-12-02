Public Class ExcelConnection
    Private filename As String

    'Excel definition
    Private app As New Excel.Application
    Private workbook As Excel.Workbook
    Private worksheet As Excel.Worksheet

    Private startRowIndex, startColIndex As Integer
    Private RowCount As Integer = 0
    Private ColCount As Integer = 0

    Sub New(ByVal _filename As String,
            ByVal ToRead As Boolean,
            Optional ByVal sheetID As Integer = 1,
            Optional ByVal _startRowIndex As Integer = 1,
            Optional ByVal _startColIndex As Integer = 1)
        filename = _filename
        startRowIndex = _startRowIndex
        startColIndex = _startColIndex

        If ToRead Then 'reading
            workbook = app.Workbooks.Open(filename)
            worksheet = workbook.Sheets.Item(sheetID)

            While Not IsNothing(worksheet.Cells(startRowIndex + RowCount, startColIndex).Value)
                RowCount += 1
            End While

            While Not IsNothing(worksheet.Cells(startRowIndex, startColIndex + ColCount).Value)
                ColCount += 1
            End While
        Else 'writing
            workbook = app.Workbooks.Add()
            worksheet = workbook.Sheets.Item(1)
        End If
    End Sub

    Public Function ReadHeaders() As List(Of String)
        Dim headers As New List(Of String)
        For i = 1 To ColCount
            headers.Add(worksheet.Cells(startRowIndex, i).Value)
        Next
        Return headers
    End Function

    'read excel files
    Public Function ReadData(ByVal selectedDateIndex As Integer, ByVal selectedSeriesIndexes As ListBox.SelectedIndexCollection, Optional ByVal format As String = "") As Object(,)
        Dim val As Object
        Dim data(RowCount - 1, selectedSeriesIndexes.Count) As Object

        ' read first row - column name
        For j = 0 To selectedSeriesIndexes.Count - 1
            data(0, j + 1) = worksheet.Cells(startRowIndex, startColIndex + selectedSeriesIndexes(j)).Value
        Next

        'read the others
        For i = 1 To RowCount - 1
            val = worksheet.Cells(startRowIndex + i, startColIndex + selectedDateIndex).Value
            If Not IsDate(val) Then
                If IsNumeric(val) Then
                    val = Date.FromOADate(val)
                Else
                    Try
                        val = Date.ParseExact(val, format, System.Globalization.CultureInfo.InvariantCulture)
                    Catch ex As Exception
                        MessageBox.Show("Date format is not valid... " + ex.Message, "Attention!", MessageBoxButtons.OK)
                    End Try
                End If
            End If

            data(i, 0) = val

            For j = 0 To selectedSeriesIndexes.Count - 1
                data(i, j + 1) = worksheet.Cells(startRowIndex + i, startColIndex + selectedSeriesIndexes(j)).Value
            Next
        Next
        Return data
    End Function

    Public Sub WriteData(ByVal SeriesList As List(Of CSeries), Optional ByVal formatIndex As Integer = 1)
        Dim series As CSeries
        'write to excel
        worksheet.Cells(1, 1) = "Date"
        For j = 0 To SeriesList.Count - 1
            series = SeriesList(j)
            'column names
            worksheet.Cells(1, j + 2) = series.S_RowObject.L_Description(0).L_Label


            For i = 0 To series.NumberOfCases - 1
                'Date column
                worksheet.Cells(i + 2, 1) = DateAdd(series.ParentControl.Date_interval(series.ParentControl.Date_detail), i, series.ParentControl.Date_first) '.ToOADate()
                'internal series columns
                worksheet.Cells(i + 2, j + 2) = series.S_RowObject.Value(i, 0)
            Next
        Next

        Dim format As Microsoft.Office.Interop.Excel.XlFileFormat
        Select Case formatIndex
            Case 1 ' *.xlsx
                format = Excel.XlFileFormat.xlOpenXMLWorkbook
            Case 2 ' *.xls
                format = Excel.XlFileFormat.xlExcel8
        End Select

        workbook.SaveAs(filename, format)
        workbook.Close()
    End Sub

    Public Sub Close()
        app.Quit()
    End Sub
End Class