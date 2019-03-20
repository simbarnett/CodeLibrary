using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibraryHelpers.Helpers;

namespace CodeLibrary.ServerSide.Business
{
	public static class UseHtmlTemplateHelper
	{		
		static HtmlTemplateHelper HtmlTemplateHelperInstance { get; set; }
		static List<List<string>> SampleTableData { get; set; }

		static UseHtmlTemplateHelper()
		{
			HtmlTemplateHelperInstance = new HtmlTemplateHelper();
			SampleTableData = HtmlTemplateHelperInstance.GenerateSampleData();
		}

		public static string GetHtml()
		{
			return HtmlTemplateHelperInstance.GenerateHtml(SampleTableData);
		}
		//private enum TableRowType { Header, Body, Foot }
		//private enum TemplatePart { Table, Row, CellHeader, Cell, THead, TBody, TFoot }

		//public static string GenerateHtml()
		//{
		//	var tableData = SampleTableData;
		//	var templateHtml = GetHtmlTemplateContent("TemplateHtmlTable");
		//	var templateTBody = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.TBody)].Trim();
		//	var tableHtml = string.Empty;
		//	var numberOfRows = tableData.Count;

		//	if (numberOfRows > 0)
		//	{
		//		var tableRowsTHead = string.Empty;
		//		var tableRowsTBody = new StringBuilder();
		//		var tableRowsTFoot = string.Empty;
		//		var templateTable = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Table)].Trim();
		//		var templateTHead = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.THead)].Trim();
		//		var templateTFoot = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.TFoot)].Trim();
		//		var i = 0;

		//		foreach (var row in tableData)
		//		{
		//			if (row.Count > 0)
		//			{
		//				var templateTableRow        = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Row)].Trim();
		//				var templateTableCellHeader = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.CellHeader)].Trim();
		//				var templateTableCell       = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Cell)].Trim();
		//				var tableRowType            = i == 0 ? HtmlTemplateHelper.TableRowType.Header : i == numberOfRows-1 ? HtmlTemplateHelper.TableRowType.Foot : HtmlTemplateHelper.TableRowType.Body;						
		//				var tableRowCells           = new StringBuilder();

		//				foreach (var column in row)
		//				{
		//					var template = tableRowType == HtmlTemplateHelper.TableRowType.Header ? templateTableCellHeader : templateTableCell;
		//					tableRowCells.Append(template.Replace("[[CellContent]]", column));
		//				}

		//				var tableRow = templateTableRow.Replace("[[RowContent]]", tableRowCells.ToString());

		//				if (tableRowType == HtmlTemplateHelper.TableRowType.Header)
		//				{
		//					tableRowsTHead = tableRow;
		//				}
		//				else if (tableRowType == HtmlTemplateHelper.TableRowType.Foot)
		//				{
		//					tableRowsTFoot = tableRow;
		//				}
		//				else
		//				{ 
		//					tableRowsTBody.Append(tableRow);
		//				}
		//			}
		//			i++;

		//			var headPart = templateTHead.Replace("[[Content]]", tableRowsTHead);
		//			var bodyPart = templateTBody.Replace("[[Content]]", tableRowsTBody.ToString());
		//			var footPart = templateTFoot.Replace("[[Content]]", tableRowsTFoot);
		//			tableHtml    = templateTable.Replace("[[TableContent]]", $"{headPart}{bodyPart}{footPart}");
		//		}
		//	}

		//	return tableHtml;
		//}

		//public static string GetHtmlTemplateContent(string templateType)
		//{
		//	return HtmlTemplateHelper.GetHtmlTemplate(templateType);
		//}
	}
}
