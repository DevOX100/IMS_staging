using System.Data;
using System.IO;
/// <summary>
/// Summary description for ExportCSV
/// </summary>
public class ExportCSV
{
    public void CSVFile(DataTable dt, string FileName)
    {
        //Build the CSV file data as a Comma separated string.
        string csv = string.Empty;

        foreach (DataColumn column in dt.Columns)
        {
            //Add the Header row for CSV file.
            csv += column.ColumnName + ',';
        }

        //Add new line.
        csv += "\r\n";

        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {
                //Add the Data rows.
                csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
            }

            //Add new line.
            csv += "\r\n";
        }

        //Download the CSV file.
        File.WriteAllText(@"C:\Users\09022\Downloads\" + FileName + ".csv", csv.ToString());
    }

    //public void ExportToPdf(DataTable dt, string strFilePath)
    //{
    //    Document document = new Document();

    //    if (dt.Columns.Count > 15)
    //    {
    //        document = new Document(PageSize.A0, 5f, 5f, 5f, 5f);
    //    }
    //    else
    //    {
    //         document = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
    //    }

    //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\Users\09022\Downloads\" + strFilePath + ".pdf", FileMode.Create));
    //    document.Open();
    //    Font font5 = FontFactory.GetFont(FontFactory.HELVETICA, 4);

    //    PdfPTable table = new PdfPTable(dt.Columns.Count);
    //    PdfPRow row = null;
    //    float[] widths = new float[dt.Columns.Count];
    //    for (int i = 0; i < dt.Columns.Count; i++)
    //        widths[i] = 4f;

    //    table.SetWidths(widths);

    //    table.WidthPercentage = 100;
    //    int iCol = 0;
    //    string colname = "";
    //    PdfPCell cell = new PdfPCell(new Phrase("Products"));

    //    cell.Colspan = dt.Columns.Count;

    //    foreach (DataColumn c in dt.Columns)
    //    {
    //        table.AddCell(new Phrase(c.ColumnName, font5));
    //    }

    //    foreach (DataRow r in dt.Rows)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            for (int h = 0; h < dt.Columns.Count; h++)
    //            {
    //                table.AddCell(new Phrase(r[h].ToString(), font5));
    //            }
    //        }
    //    }
    //    document.Add(table);
    //    document.Close();
    //}

    //public void GenerateWord(DataTable dt, string FileName)
    //{
    //    StringBuilder sbDocBody = new StringBuilder(); ;
    //    try
    //    {
    //        // Declare Styles
    //        sbDocBody.Append("<style>");
    //        sbDocBody.Append(".Header {  background-color:Navy; color:#ffffff; font-weight:bold;font-family:Verdana; font-size:10px;}");
    //        sbDocBody.Append(".SectionHeader { background-color:#8080aa; color:#ffffff; font-family:Verdana; font-size:10px;font-weight:bold;}");


    //        sbDocBody.Append(".Content { background-color:#ccccff; color:#000000; font-family:Verdana; font-size:10px;text-align:left}");
    //        sbDocBody.Append(".Label { background-color:#ccccee; color:#000000; font-family:Verdana; font-size:10px; text-align:right;}");
    //        sbDocBody.Append("</style>");
    //        //
    //        StringBuilder sbContent = new StringBuilder(); ;
    //        sbDocBody.Append("<br><table align=\"center\" cellpadding=1 cellspacing=0 style=\"background-color:#000000;\">");
    //        sbDocBody.Append("<tr><td width=\"500\">");
    //        sbDocBody.Append("<table width=\"100%\" cellpadding=1 cellspacing=2 style=\"background-color:#ffffff;\">");
    //        //
    //        if (dt.Rows.Count > 0)
    //        {
    //            sbDocBody.Append("<tr><td>");
    //            sbDocBody.Append("<table width=\"600\" cellpadding=\"0\" cellspacing=\"2\"><tr><td>");
    //            //
    //            // Add Column Headers
    //            sbDocBody.Append("<tr><td width=\"25\"> </td></tr>");
    //            sbDocBody.Append("<tr>");
    //            sbDocBody.Append("<td> </td>");
    //            for (int i = 0; i < dt.Columns.Count; i++)
    //            {
    //                sbDocBody.Append("<td class=\"Header\" width=\"120\">" + dt.Columns[i].ToString().Replace(".", "<br>") + "</td>");
    //            }
    //            sbDocBody.Append("</tr>");
    //            //
    //            // Add Data Rows
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                sbDocBody.Append("<tr>");
    //                sbDocBody.Append("<td> </td>");
    //                for (int j = 0; j < dt.Columns.Count; j++)
    //                {
    //                    sbDocBody.Append("<td class=\"Content\">" + dt.Rows[i][j].ToString() + "</td>");
    //                }
    //                sbDocBody.Append("</tr>");
    //            }
    //            sbDocBody.Append("</table>");
    //            sbDocBody.Append("</td></tr></table>");
    //            sbDocBody.Append("</td></tr></table>");
    //        }
    //        //
    //        File.WriteAllText(@"C:\Users\09022\Downloads\" + FileName + "..doc", sbDocBody.ToString());
    //    }
    //    catch (Exception ex)
    //    {
    //        // Ignore this error as this is caused due to termination of the Response Stream.
    //    }
    //}

}
