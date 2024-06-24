using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Spreadsheet_Side.Data
{

    public class JsonSheetEntry
    {
        public object BandedRanges { get; set; }
        public object BasicFilter { get; set; }
        public object Charts { get; set; }
        public object ColumnGroups { get; set; }
        public Conditionalformat[] ConditionalFormats { get; set; }
        public Data[] Data { get; set; }
        public object DeveloperMetadata { get; set; }
        public object FilterViews { get; set; }
        public object Merges { get; set; }
        public Properties Properties { get; set; }
        public object ProtectedRanges { get; set; }
        public object RowGroups { get; set; }
        public object Slicers { get; set; }
        public object ETag { get; set; }
    }

    public class Properties
    {
        public object DataSourceSheetProperties { get; set; }
        public Gridproperties GridProperties { get; set; }
        public object Hidden { get; set; }
        public int Index { get; set; }
        public object RightToLeft { get; set; }
        public int SheetId { get; set; }
        public string SheetType { get; set; }
        public object TabColor { get; set; }
        public object TabColorStyle { get; set; }
        public string Title { get; set; }
        public object ETag { get; set; }
    }

    public class Gridproperties
    {
        public int ColumnCount { get; set; }
        public bool? ColumnGroupControlAfter { get; set; }
        public object FrozenColumnCount { get; set; }
        public object FrozenRowCount { get; set; }
        public object HideGridlines { get; set; }
        public int RowCount { get; set; }
        public bool? RowGroupControlAfter { get; set; }
        public object ETag { get; set; }
    }

    public class Conditionalformat
    {
        public Booleanrule BooleanRule { get; set; }
        public Gradientrule GradientRule { get; set; }
        public Range[] Ranges { get; set; }
        public object ETag { get; set; }
    }

    public class Booleanrule
    {
        public Condition Condition { get; set; }
        public Format Format { get; set; }
        public object ETag { get; set; }
    }

    public class Condition
    {
        public string Type { get; set; }
        public Value[] Values { get; set; }
        public object ETag { get; set; }
    }

    public class Value
    {
        public object RelativeDate { get; set; }
        public string UserEnteredValue { get; set; }
        public object ETag { get; set; }
    }

    public class Format
    {
        public Backgroundcolor BackgroundColor { get; set; }
        public Backgroundcolorstyle BackgroundColorStyle { get; set; }
        public object Borders { get; set; }
        public object HorizontalAlignment { get; set; }
        public object HyperlinkDisplayType { get; set; }
        public object NumberFormat { get; set; }
        public object Padding { get; set; }
        public object TextDirection { get; set; }
        public object TextFormat { get; set; }
        public object TextRotation { get; set; }
        public object VerticalAlignment { get; set; }
        public object WrapStrategy { get; set; }
        public object ETag { get; set; }
    }

    public class Backgroundcolor
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public int Red { get; set; }
        public object ETag { get; set; }
    }

    public class Backgroundcolorstyle
    {
        public Rgbcolor RgbColor { get; set; }
        public object ThemeColor { get; set; }
        public object ETag { get; set; }
    }

    public class Rgbcolor
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public int Red { get; set; }
        public object ETag { get; set; }
    }

    public class Gradientrule
    {
        public Maxpoint Maxpoint { get; set; }
        public object Midpoint { get; set; }
        public Minpoint Minpoint { get; set; }
        public object ETag { get; set; }
    }

    public class Maxpoint
    {
        public Color Color { get; set; }
        public Colorstyle ColorStyle { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        public object ETag { get; set; }
    }

    public class Color
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public int Red { get; set; }
        public object ETag { get; set; }
    }

    public class Colorstyle
    {
        public Rgbcolor1 RgbColor { get; set; }
        public object ThemeColor { get; set; }
        public object ETag { get; set; }
    }

    public class Rgbcolor1
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public int Red { get; set; }
        public object ETag { get; set; }
    }

    public class Minpoint
    {
        public Color1 Color { get; set; }
        public Colorstyle1 ColorStyle { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        public object ETag { get; set; }
    }

    public class Color1
    {
        public object Alpha { get; set; }
        public float Blue { get; set; }
        public float Green { get; set; }
        public float Red { get; set; }
        public object ETag { get; set; }
    }

    public class Colorstyle1
    {
        public Rgbcolor2 RgbColor { get; set; }
        public object ThemeColor { get; set; }
        public object ETag { get; set; }
    }

    public class Rgbcolor2
    {
        public object Alpha { get; set; }
        public float Blue { get; set; }
        public float Green { get; set; }
        public float Red { get; set; }
        public object ETag { get; set; }
    }

    public class Range
    {
        public int EndColumnIndex { get; set; }
        public int EndRowIndex { get; set; }
        public int SheetId { get; set; }
        public int StartColumnIndex { get; set; }
        public int StartRowIndex { get; set; }
        public object ETag { get; set; }
    }

    public class Data
    {
        public Columnmetadata[] ColumnMetadata { get; set; }
        public Rowdata[] RowData { get; set; }
        public Rowmetadata[] RowMetadata { get; set; }
        public object StartColumn { get; set; }
        public object StartRow { get; set; }
        public object ETag { get; set; }
    }

    public class Columnmetadata
    {
        public object DataSourceColumnReference { get; set; }
        public object DeveloperMetadata { get; set; }
        public object HiddenByFilter { get; set; }
        public object HiddenByUser { get; set; }
        public int PixelSize { get; set; }
        public object ETag { get; set; }
    }

    public class Rowdata
    {
        public Value1[] Values { get; set; }
        public object ETag { get; set; }
    }

    public class Value1
    {
        public object DataSourceFormula { get; set; }
        public object DataSourceTable { get; set; }
        public object DataValidation { get; set; }
        public Effectiveformat EffectiveFormat { get; set; }
        public Effectivevalue EffectiveValue { get; set; }
        public string FormattedValue { get; set; }
        public object Hyperlink { get; set; }
        public object Note { get; set; }
        public object PivotTable { get; set; }
        public object TextFormatRuns { get; set; }
        public Userenteredformat UserEnteredFormat { get; set; }
        public Userenteredvalue UserEnteredValue { get; set; }
        public object ETag { get; set; }
    }

    public class Effectiveformat
    {
        public Backgroundcolor1 BackgroundColor { get; set; }
        public Backgroundcolorstyle1 BackgroundColorStyle { get; set; }
        public object Borders { get; set; }
        public string HorizontalAlignment { get; set; }
        public string HyperlinkDisplayType { get; set; }
        public Numberformat NumberFormat { get; set; }
        public Padding Padding { get; set; }
        public object TextDirection { get; set; }
        public Textformat TextFormat { get; set; }
        public object TextRotation { get; set; }
        public string VerticalAlignment { get; set; }
        public string WrapStrategy { get; set; }
        public object ETag { get; set; }
    }

    public class Backgroundcolor1
    {
        public object Alpha { get; set; }
        public float? Blue { get; set; }
        public float? Green { get; set; }
        public float Red { get; set; }
        public object ETag { get; set; }
    }

    public class Backgroundcolorstyle1
    {
        public Rgbcolor3 RgbColor { get; set; }
        public object ThemeColor { get; set; }
        public object ETag { get; set; }
    }

    public class Rgbcolor3
    {
        public object Alpha { get; set; }
        public float? Blue { get; set; }
        public float? Green { get; set; }
        public float Red { get; set; }
        public object ETag { get; set; }
    }

    public class Numberformat
    {
        public string Pattern { get; set; }
        public string Type { get; set; }
        public object ETag { get; set; }
    }

    public class Padding
    {
        public object Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public object Top { get; set; }
        public object ETag { get; set; }
    }

    public class Textformat
    {
        public bool Bold { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public Foregroundcolor ForegroundColor { get; set; }
        public Foregroundcolorstyle ForegroundColorStyle { get; set; }
        public bool Italic { get; set; }
        public object Link { get; set; }
        public bool Strikethrough { get; set; }
        public bool Underline { get; set; }
        public object ETag { get; set; }
    }

    public class Foregroundcolor
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public object Red { get; set; }
        public object ETag { get; set; }
    }

    public class Foregroundcolorstyle
    {
        public Rgbcolor4 RgbColor { get; set; }
        public object ThemeColor { get; set; }
        public object ETag { get; set; }
    }

    public class Rgbcolor4
    {
        public object Alpha { get; set; }
        public object Blue { get; set; }
        public object Green { get; set; }
        public object Red { get; set; }
        public object ETag { get; set; }
    }

    public class Effectivevalue
    {
        public object BoolValue { get; set; }
        public object ErrorValue { get; set; }
        public object FormulaValue { get; set; }
        public float? NumberValue { get; set; }
        public string StringValue { get; set; }
        public object ETag { get; set; }
    }

    public class Userenteredformat
    {
        public object BackgroundColor { get; set; }
        public object BackgroundColorStyle { get; set; }
        public object Borders { get; set; }
        public object HorizontalAlignment { get; set; }
        public object HyperlinkDisplayType { get; set; }
        public Numberformat1 NumberFormat { get; set; }
        public object Padding { get; set; }
        public object TextDirection { get; set; }
        public Textformat1 TextFormat { get; set; }
        public object TextRotation { get; set; }
        public string VerticalAlignment { get; set; }
        public object WrapStrategy { get; set; }
        public object ETag { get; set; }
    }

    public class Numberformat1
    {
        public string Pattern { get; set; }
        public string Type { get; set; }
        public object ETag { get; set; }
    }

    public class Textformat1
    {
        public object Bold { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public object ForegroundColor { get; set; }
        public object ForegroundColorStyle { get; set; }
        public object Italic { get; set; }
        public object Link { get; set; }
        public object Strikethrough { get; set; }
        public object Underline { get; set; }
        public object ETag { get; set; }
    }

    public class Userenteredvalue
    {
        public object BoolValue { get; set; }
        public object ErrorValue { get; set; }
        public string FormulaValue { get; set; }
        public float? NumberValue { get; set; }
        public string StringValue { get; set; }
        public object ETag { get; set; }
    }

    public class Rowmetadata
    {
        public object DataSourceColumnReference { get; set; }
        public object DeveloperMetadata { get; set; }
        public object HiddenByFilter { get; set; }
        public object HiddenByUser { get; set; }
        public int PixelSize { get; set; }
        public object ETag { get; set; }
    }

}
