Public Class COperationBuffer

    Public Structure StrOperation

        Public Series As CSeries            ' series

        Public SeriesInternalId As Byte     ' internal row id
        Public CaseId As Integer            ' case number

        Public savedValue As Double?
    End Structure


    Public buffer As New List(Of List(Of StrOperation))(MaxBufferSize)

    Public Const MaxBufferSize As Integer = 24

    ' add operation to the stack
    Public Sub Push(ByVal op As List(Of StrOperation))

        If buffer.Count = MaxBufferSize Then
            buffer.RemoveAt(0)
        End If

        buffer.Add(op)
    End Sub

    ' get from stack
    Public Function Pop() As List(Of StrOperation)

        If buffer.Count = 0 Then Return Nothing

        Dim op As List(Of StrOperation) = buffer(buffer.Count - 1)
        buffer.RemoveAt(buffer.Count - 1)

        Return op
    End Function

    Public ReadOnly Property HasOperations As Boolean
        Get
            Return buffer.Count > 0
        End Get
    End Property
End Class
