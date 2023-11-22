Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Web.UI
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace ASPxPivotGrid_SplittingCells

    Public Partial Class _Default
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsCallback AndAlso Not IsPostBack Then
                PivotHelper.FillPivot(pivotGrid)
            End If

            pivotGrid.DataSource = GetDataTable()
        End Sub

        Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGrid.DataSource Is Nothing Then Return
            If radioButtonList.SelectedIndex = 0 Then Return
            ' Creates a predicate that returns true for the Grand Total
            ' headers, and false for any other column/row header.
            ' Only cells that match this predicate are split.
            Dim condition As Predicate(Of FieldValueCell) = New Predicate(Of FieldValueCell)(Function(ByVal matchCell) matchCell.ValueType = PivotGridValueType.GrandTotal AndAlso matchCell.Field Is Nothing)
            ' Creates a list of cell definitions that represent newly created cells.
            ' Two definitions are added to the list. The first one identifies
            ' the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            ' data field headers). The second one identifies the Count cell with 
            ' one nested cell (the Quantity data field header).
            Dim cells As List(Of FieldValueSplitData) = New List(Of FieldValueSplitData)(2)
            cells.Add(New FieldValueSplitData("Price", 2))
            cells.Add(New FieldValueSplitData("Count", 1))
            ' Performs splitting.
            e.Split(True, condition, cells)
        End Sub

        Protected Sub pivotGrid_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Field Is pivotGrid.Fields(Month) AndAlso TypeOf e.Value Is Integer Then
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(e.Value))
            End If
        End Sub
    End Class
End Namespace
