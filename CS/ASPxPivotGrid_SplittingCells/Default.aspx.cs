using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace ASPxPivotGrid_SplittingCells {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsCallback && !IsPostBack) {
                PivotHelper.FillPivot(pivotGrid);
            }
            pivotGrid.DataSource = PivotHelper.GetDataTable();
        }
        protected void pivotGrid_CustomFieldValueCells(object sender,
                             PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGrid.DataSource == null) return;
            if (radioButtonList.SelectedIndex == 0) return;

            // Creates a predicate that returns true for the Grand Total
            // headers, and false for any other column/row header.
            // Only cells that match this predicate are split.
            Predicate<FieldValueCell> condition =
                new Predicate<FieldValueCell>(delegate(FieldValueCell matchCell) {
                return matchCell.ValueType == PivotGridValueType.GrandTotal &&
                    matchCell.Field == null;
            });

            // Creates a list of cell definitions that represent newly created cells.
            // Two definitions are added to the list. The first one identifies
            // the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            // data field headers). The second one identifies the Count cell with 
            // one nested cell (the Quantity data field header).
            List<FieldValueSplitData> cells = new List<FieldValueSplitData>(2);
            cells.Add(new FieldValueSplitData("Price", 2));
            cells.Add(new FieldValueSplitData("Count", 1));

            // Performs splitting.
            e.Split(true, condition, cells);
        }
        protected void pivotGrid_FieldValueDisplayText(object sender, 
                                PivotFieldDisplayTextEventArgs e) {
            if (e.Field == pivotGrid.Fields[PivotHelper.Month] && e.Value is int) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
    }
}