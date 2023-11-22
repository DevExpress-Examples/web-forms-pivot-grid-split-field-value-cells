<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128577903/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2762)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Pivot Grid for Web Forms - Split Field Value Cells

The following example demonstrates how to split field value cells. In this example, the Grand Total column header is split into two cells: *Price* and *Count*.

![Pivot Grid](images/screenshot.png)
Handle the [CustomFieldValueCells] (https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid.CustomFieldValueCells) and call the event parameter's [Split](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.PivotCustomFieldValueCellsEventArgs.Split.overloads) method is used. Cells that should be split are identified by a predicate that returns `true` for those cells. The quantity, size and captions of newly created cells are specified by an array of cell definitions (the `FieldValueSplitData` objects).

## Files to Review

* [Data.cs](./CS/ASPxPivotGrid_SplittingCells/Data.cs) (VB: [Data.vb](./VB/ASPxPivotGrid_SplittingCells/Data.vb))
* [Default.aspx](./CS/ASPxPivotGrid_SplittingCells/Default.aspx) (VB: [Default.aspx](./VB/ASPxPivotGrid_SplittingCells/Default.aspx))
* [Default.aspx.cs](./CS/ASPxPivotGrid_SplittingCells/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ASPxPivotGrid_SplittingCells/Default.aspx.vb))

## Documentation

* [Field Value](https://docs.devexpress.com/AspNet/3597/components/pivot-grid/ui-elements/field-value)



