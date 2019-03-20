using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Helpers
{
	public class HtmlTemplateHelper
	{
		public List<List<string>> SampleData;
		public enum TableRowType { Header, Body, Foot }
		public enum TemplatePart { Table, Row, CellHeader, Cell, THead, TBody, TFoot }
		
				
		public string GenerateHtml(List<List<string>> tableData)
		{			
			var templateHtml     = GetHtmlTemplateContent();
			var templateTBody    = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.TBody)].Trim();
			var tableHtml        = string.Empty;
			var numberOfRows     = tableData.Count;

			if (numberOfRows > 0)
			{
				var tableRowsTHead = string.Empty;
				var tableRowsTBody = new StringBuilder();
				var tableRowsTFoot = string.Empty;
				var templateTable  = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Table)].Trim();
				var templateTHead  = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.THead)].Trim();
				var templateTFoot  = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.TFoot)].Trim();
				var i = 0;

				foreach (var row in tableData)
				{
					if (row.Count > 0)
					{
						var templateTableRow        = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Row)].Trim();
						var templateTableCellHeader = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.CellHeader)].Trim();
						var templateTableCell       = templateHtml.Split('#')[Convert.ToInt16(HtmlTemplateHelper.TemplatePart.Cell)].Trim();
						var tableRowType            = i == 0 ? HtmlTemplateHelper.TableRowType.Header : i == numberOfRows - 1 ? HtmlTemplateHelper.TableRowType.Foot : HtmlTemplateHelper.TableRowType.Body;
						var tableRowCells           = new StringBuilder();

						foreach (var column in row)
						{
							var template = tableRowType == HtmlTemplateHelper.TableRowType.Header ? templateTableCellHeader : templateTableCell;
							tableRowCells.Append(template.Replace("[[CellContent]]", column));
						}

						var tableRow = templateTableRow.Replace("[[RowContent]]", tableRowCells.ToString());

						if (tableRowType == HtmlTemplateHelper.TableRowType.Header)
						{
							tableRowsTHead = tableRow;
						}
						else if (tableRowType == HtmlTemplateHelper.TableRowType.Foot)
						{
							tableRowsTFoot = tableRow;
						}
						else
						{
							tableRowsTBody.Append(tableRow);
						}
					}
					i++;

					var headPart = templateTHead.Replace("[[Content]]", tableRowsTHead);
					var bodyPart = templateTBody.Replace("[[Content]]", tableRowsTBody.ToString());
					var footPart = templateTFoot.Replace("[[Content]]", tableRowsTFoot);
					tableHtml    = templateTable.Replace("[[TableContent]]", $"{headPart}{bodyPart}{footPart}");
				}
			}

			return tableHtml;
		}

		public List<List<string>> GenerateSampleData()
		{
			var sampleData = new List<List<string>>();

			sampleData.Add(new string[] { "Headera", "Headerb", "Headerc", "Headerd", "Headere" }.ToList());
			sampleData.Add(new string[] { "1a", "1b", "1c", "1d", "1e" }.ToList());
			sampleData.Add(new string[] { "2a", "2b", "2c", "2d", "2e" }.ToList());
			sampleData.Add(new string[] { "3a", "3b", "3c", "3d", "3e" }.ToList());
			sampleData.Add(new string[] { "4a", "4b", "4c", "4d", "4e" }.ToList());

			return sampleData;
		}

		public string GetHtmlTemplateContent()
		{
			return GetHtmlTemplate();
		}

		public string GetHtmlTemplate()
		{
			string pathToTemplate = $"{ConfigHelper.GetConfigValue($"HtmlTemplatePath")}TemplateHtmlTable.html";
			
			try
			{
				using (var streamReader = new StreamReader(pathToTemplate))
				{
					return streamReader.ReadToEnd();
				}
			}
			catch(Exception ex)
			{
				return "Problem locating/reading template";
			}			
		}
	}
}
