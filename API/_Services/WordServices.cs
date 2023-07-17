using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API._Interface;
using Aspose.Words;
using Aspose.Words.DigitalSignatures;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;
using Aspose.Words.Replacing;
using Aspose.Words.Saving;

namespace API._Services
{
    public class WordServices : IWordServices
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string folder;

        public WordServices(IWebHostEnvironment environment)
        {
            _environment = environment;
            folder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");
        }

        /// <summary>
        /// Đọc 1 file có sẵn và chuyển đổi thành file PDF
        /// </summary>
        /// <returns></returns>

        public async Task<byte[]> ChuyenDoiSangPDF(IFormFile file)
        {
            // Lưu tệp từ IFormFile vào thư mục tạm thời với tên tệp ngẫu nhiên
            // var fileName = Path.Combine(_environment.ContentRootPath, file.FileName);
            var filePath = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/" + file.FileName);
            string folder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Tiếp tục xử lý tương tự như bạn đã làm trước đây
            var document = new Document(filePath);
            MemoryStream stream = new MemoryStream();
            // document.Save(stream, SaveFormat.Pdf);
            // document.Save(stream, SaveFormat.Html);
            document.Save(folder + file.Name + ".pdf", SaveFormat.Pdf);
            document.Save(folder + "document.html", SaveFormat.Html);
            document.Save(folder + "document.md", SaveFormat.Markdown);
            document.Save(folder + "document_image.jpg", SaveFormat.Jpeg);

            // Xóa tệp tạm thời sau khi đã sử dụng xong
            File.Delete(filePath);

            return stream.ToArray();
        }

        public async Task TimKiemVaThayThe()
        {
            #region Đọc file từ đường dẫn
            var path = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/document.pdf");
            #endregion


            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(path);

            #region  Tìm và thay thế
            // Chúng ta sẽ dùng "FindReplaceOptions" để tìm và thay thế .
            FindReplaceOptions options = new FindReplaceOptions();

            // Set phân biệt chữ hoa, chữ thường
            options.MatchCase = true;

            // thực hiện tìm kiếm và thay thế, cùng với phân biệt hoa thường
            document.Range.Replace("Ruby", "Jade", options);
            #endregion

            // 
            XlsxSaveOptions saveOptions = new XlsxSaveOptions();
            // 
            saveOptions.CompressionLevel = CompressionLevel.Maximum;

            document.Save(folder + "BaseConversions.CompressXlsx.xlsx", saveOptions);
        }


        public async Task ChenVanBan()
        {
            Document newDoc = new Document();
            List<Paragraph> paragraphList = new List<Paragraph>();
            // paragraphList.Add(new Paragraph("First paragraph"));
            // paragraphList.Add(new Paragraph("Second paragraph"));


            DocumentBuilder builder = new DocumentBuilder(newDoc);
            foreach (Paragraph para in paragraphList)
            {
                Section section = para.ParentSection;

                // Insert section break if the paragraph is not at the beginning of a section already.
                if (para != section.Body.FirstParagraph)
                {
                    builder.MoveTo(para.FirstChild);
                    builder.InsertBreak(BreakType.SectionBreakNewPage);

                    // This is the paragraph that was inserted at the end of the now old section.
                    // We don't really need the extra paragraph, we just needed the section.
                    section.Body.LastParagraph.Remove();
                }
            }

            newDoc.Save(folder + "ChenVanBan.docx", SaveFormat.Docx);
        }

        public async Task ThemHinhAnh()
        {
            // Tạo document 
            Document doc = new Document();
            // Xây dựng Document
            DocumentBuilder builder = new DocumentBuilder(doc);

            builder.InsertImage(
                folder + "image.jpg", // Tên hình ảnh

                RelativeHorizontalPosition.Margin, // cách chiều dọc
                100,
                RelativeVerticalPosition.Margin,// cách chiều ngang
                100,
                200, // Chiều dài hình ảnh : Width
                100, // chiều cao hình ảnh : Height
                WrapType.Square);
            string newSave = folder + "DocumentBuilderInsertFloatingImage_out.doc";
            doc.Save(newSave);
        }

        public async Task TrichXuatHinhAnh()
        {
            // For complete examples and data files, please go to https://github.com/aspose-words/Aspose.Words-for-.NET
            // The path to the documents directory.
            Document doc = new Document(folder + "Image.SampleImages.doc");

            NodeCollection shapes = doc.GetChildNodes(NodeType.Shape, true);
            int imageIndex = 0;
            foreach (Shape shape in shapes)
            {
                if (shape.HasImage)
                {
                    string imageFileName = string.Format(
                        "Image.ExportImages.{0}_out{1}", imageIndex, FileFormatUtil.ImageTypeToExtension(shape.ImageData.ImageType));
                    shape.ImageData.Save(folder + imageFileName);
                    imageIndex++;
                }
            }
            throw new NotImplementedException();
        }

        public async Task ChenVaThaoTacBieuDo()
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            #region Column Chart
            Shape shapeColumn = builder.InsertChart(ChartType.Column, 432, 252);
            builder.InsertBreak(BreakType.SectionBreakContinuous);
            Chart chartColumn = shapeColumn.Chart;

            chartColumn.Title.Text = "Demo ví dụ Column chart";

            ChartSeriesCollection seriesColl = chartColumn.Series;
            // Check series count.
            Console.WriteLine(seriesColl.Count);

            // Delete default generated series.
            seriesColl.Clear();

            // Create category names array, in this example we have two categories.
            string[] categories = new string[] { "AW Category 1", "AW Category 2" };
            // Adding new series. Please note, data arrays must not be empty and arrays must be the same size.
            seriesColl.Add("AW Series 1", categories, new double[] { 1, 2 });
            seriesColl.Add("AW Series 2", categories, new double[] { 3, 4 });
            seriesColl.Add("AW Series 3", categories, new double[] { 5, 6 });
            seriesColl.Add("AW Series 4", categories, new double[] { 7, 8 });
            seriesColl.Add("AW Series 5", categories, new double[] { 9, 10 });

            #endregion

            #region Scatter chart.
            Shape shapeScatter = builder.InsertChart(ChartType.Scatter, 432, 252);
            builder.InsertBreak(BreakType.SectionBreakContinuous);
            Chart chartScatter = shapeScatter.Chart;

            chartColumn.Title.Text = "Demo ví dụ Scatter chart";
            // Use this overload to add series to any type of Scatter charts.
            chartColumn.Series.Add("AW Series 1", new double[] { 0.7, 1.8, 2.6 }, new double[] { 2.7, 3.2, 0.8 });
            #endregion


            #region Bubble Chart
            Shape shapeBubble = builder.InsertChart(ChartType.Bubble, 432, 252);
            builder.InsertBreak(BreakType.SectionBreakContinuous);
            Chart chartBubble = shapeBubble.Chart;

            // Use this overload to add series to any type of Bubble charts.
            chartBubble.Series.Add("AW Series 1", new double[] { 0.7, 1.8, 2.6 }, new double[] { 2.7, 3.2, 0.8 }, new double[] { 10, 4, 8 });
            #endregion


            #region Line Chart
            Shape shapeLine = builder.InsertChart(ChartType.Line, 432, 252);
            Chart chartLine = shapeLine.Chart;
            chartLine.Series.Clear();

            ChartSeries series = chartLine.Series.Add("Series 1",
    new string[] { "Category1", "Category2", "Category3" },
    new double[] { 2.7, 3.2, 0.8 });

            ChartSeriesCollection seriesCollLine = chartLine.Series;
            // Check series count.
            Console.WriteLine(seriesColl.Count);

            chartLine.Title.Show = true;

            // Setting chart Title.
            chartLine.Title.Text = "Demo ví dụ Line chart";

            // Determines whether other chart elements shall be allowed to overlap title.
            chartLine.Title.Overlay = false;

            chartLine.Legend.Position = LegendPosition.Left;
            chartLine.Legend.Overlay = true;



            // ChartSeriesCollection seriesColl = chart.Series;

            ChartSeries series0 = shapeLine.Chart.Series[0];

            // Get second series.
            ChartSeries series1 = shapeLine.Chart.Series[1];

            // Change first series name.
            series0.Name = "Trí";

            // Change second series name.
            series1.Name = "Hải";

            // You can also specify whether the line connecting the points on the chart shall be smoothed using Catmull-Rom splines.
            series0.Smooth = true;
            series1.Smooth = true;
            #endregion






            doc.Save(folder + @"DemoShapeChart.doc");
        }

        public async Task BaoMat()
        {
            var path = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/helloword.doc");
            string folder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(path);
            //    CHỉ đọc

            // Enter a password that's up to 15 characters long.
            document.WriteProtection.SetPassword("MyPassword");
            document.WriteProtection.ReadOnlyRecommended = true;
            document.Protect(ProtectionType.ReadOnly);

            // Set Mật khẩu
            // Create a document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.Write("Hello world!");

            // DocSaveOptions only applies to Doc and Dot save formats.
            DocSaveOptions options = new DocSaveOptions(SaveFormat.Doc);

            // Set a password with which the document will be encrypted, and which will be required to open it.
            options.Password = "MyPassword";


            //Hạn chế chỉnh sửa
            // doc.Protect(ProtectionType.NoProtection, "password");

            //Chữ kí số

            document.Save(folder + "Security.docx", SaveFormat.Docx);
        }

        public async Task BaoMatVoiCHUKISO()
        {
            // Create a Document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Set signature line options.
            SignatureLineOptions signatureLineOptions = new SignatureLineOptions
            {
                Signer = "Entername",
                SignerTitle = "QA",
                Email = "EnterSomeEmail",

                ShowDate = true,
                DefaultInstructions = false,
                Instructions = "You need more info about signature line",
                AllowComments = true
            };

            // Insert signature line.
            SignatureLine signatureLine = builder.InsertSignatureLine(signatureLineOptions).SignatureLine;
            signatureLine.ProviderId = Guid.Parse("CF5A7BB4-8F3C-4756-9DF6-BEF7F13259A2");

            doc.Save(folder + "DocumentBuilder.SignatureLineProviderId.docx");

            // Set signing options. 
            SignOptions signOptions = new SignOptions
            {
                SignatureLineId = signatureLine.Id,
                ProviderId = signatureLine.ProviderId,
                Comments = "Document was signed by vderyushev",
                SignTime = DateTime.Now
            };

            // Create a certificate.
            CertificateHolder certHolder = CertificateHolder.Create(folder + "morzal.pfx", "aw");

            // We can sign the signature line programmatically.
            DigitalSignatureUtil.Sign(folder + "DocumentBuilder.SignatureLineProviderId.docx", folder + "DocumentBuilder.SignatureLineProviderId.Signed.docx", certHolder, signOptions);

            // Create the shape of the signature line.
            doc = new Document(folder + "DocumentBuilder.SignatureLineProviderId.Signed.docx");
            Shape shape = (Shape)doc.GetChild(NodeType.Shape, 0, true);
            signatureLine = shape.SignatureLine;

            // Loading signatures.
            DigitalSignatureCollection signatures = DigitalSignatureUtil.LoadSignatures(folder + "DocumentBuilder.SignatureLineProviderId.Signed.docx");

        }
    }
}