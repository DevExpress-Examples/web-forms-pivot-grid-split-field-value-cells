Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Web.UI
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace ASPxPivotGrid_SplittingCells
	Partial Public Class _Default
		Inherits Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsCallback) AndAlso (Not IsPostBack) Then
				PivotHelper.FillPivot(pivotGrid)
			End If
			pivotGrid.DataSource = PivotHelper.GetDataTable()
		End Sub
        Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, _
                                ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGrid.DataSource Is Nothing Then
                Return
            End If
            If radioButtonList.SelectedIndex = 0 Then
                Return
            End If

            ' Creates a predicate that returns true for the Grand Total
            ' headers, and false for any other column/row header.
            ' Only cells that match this predicate are split.
            Dim condition As New Predicate(Of FieldValueCell)(AddressOf AnonymousMethod1)

            ' Creates a list of cell definitions that represent newly created cells.
            ' Two definitions are added to the list. The first one identifies
            ' the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            ' data field headers). The second one identifies the Count cell with 
            ' one nested cell (the Quantity data field header).
            Dim cells As New List(Of FieldValueSplitData)(2)
            cells.Add(New FieldValueSplitData("Price", 2))
            cells.Add(New FieldValueSplitData("Count", 1))

            ' Performs splitting.
            e.Split(True, condition, cells)
        End Sub
        Private Function AnonymousMethod1(ByVal matchCell As FieldValueCell) As Boolean
            Return matchCell.ValueType = PivotGridValueType.GrandTotal AndAlso _
                matchCell.Field Is Nothing
        End Function
        Protected Sub pivotGrid_FieldValueDisplayText(ByVal sender As Object, _
                                    ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Value Is Nothing Then
                Return
            End If
            If Object.Equals(e.Field, pivotGrid.Fields(PivotHelper.Month)) Then
                e.DisplayText = _
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
            End If
        End Sub
    End Class
End Namespace