
using API._Services.Interfaces;
using API.Dtos;
using API.Helpers.Utilities;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;
using Aspose.Words.Replacing;
using Aspose.Words.Saving;

namespace API._Services.Services
{
    public class WordServices : IWordServices
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string inputFolder;
        private readonly string outputFolder;

        private readonly IUploadFileUtility _functionUtility;

        public WordServices(IWebHostEnvironment environment, IUploadFileUtility functionUtility)
        {
            _environment = environment;
            _functionUtility = functionUtility;
            inputFolder = Path.Combine(_environment.ContentRootPath, @"wwwroot/input/");
            outputFolder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");
        }

        /// <summary>
        /// Đọc 1 file có sẵn và chuyển đổi thành file PDF
        /// </summary>
        /// <returns></returns>

        public async Task<List<FileOutput>> ChuyenDoiSangPDF(IFormFile file, string fileType)
        {
            // Tạo biến trả về
            var fileName = new List<FileOutput>();

            string newFileName = await UploadFileToInput(file);

            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);

            // Đọc file bằng Document
            var document = new Document(dataDir);

            // Thêm các tên tệp đã chuyển đổi vào danh sách fileNameList
            string exportFileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}.{fileType.ToLower()}";
            string exportPath = $"{outputFolder}/{Path.GetFileNameWithoutExtension(file.FileName)}.{fileType.ToLower()}";

            // Nếu file đã tồn tại thì xoá
            if (File.Exists(exportPath))
                File.Delete(exportPath);

            // Lưu file theo định dạng
            if (fileType == "PDF")
                document.Save(exportPath, SaveFormat.Pdf);
            if (fileType == "HTML")
                document.Save(exportPath, SaveFormat.Html);
            if (fileType == "MD")
                document.Save(exportPath, SaveFormat.Markdown);
            if (fileType == "JPEG")
                document.Save(exportPath, SaveFormat.Jpeg);


            fileName.Add(new FileOutput()
            {
                FileName = exportFileName,
                Url = exportPath
            });

            return fileName;
        }

        private async Task<string> UploadFileToInput(IFormFile file)
        {
            // Lấy filePath đầu vào
            var filePath = Path.Combine(inputFolder + file.FileName);
            // upload vào Input để lấy mẫu
            return await _functionUtility.UploadAsync(file, "input", Path.GetFileNameWithoutExtension(file.FileName));
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

            document.Save(outputFolder + "BaseConversions.CompressXlsx.xlsx", saveOptions);
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

            newDoc.Save(outputFolder + "ChenVanBan.docx", SaveFormat.Docx);
        }

        public async Task<FileOutput> ThemHinhAnh(UploadFile model)
        {
            string newFileName = await UploadFileToInput(model.File);
            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(dataDir);
            DocumentBuilder builder = new DocumentBuilder(document);
            // Xây dựng Document

            builder.InsertImage(
                outputFolder + "image.jpg" // Tên hình ảnh

                // RelativeHorizontalPosition.Margin, // cách chiều dọc
                // 100,
                // RelativeVerticalPosition.Margin,// cách chiều ngang
                // 100,
                // 200, // Chiều dài hình ảnh : Width
                // 100, // chiều cao hình ảnh : Height
                // WrapType.Square
                );

            string extention = Path.GetExtension(model.File.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(model.File.FileName)}_HasPicture{extention}";
            string exportPath = $"{outputFolder}/{fileName}";
            // Nếu file đã tồn tại thì xoá
            if (File.Exists(exportPath))
                File.Delete(exportPath);

            document.Save(exportPath);

            if (File.Exists(dataDir))
                File.Delete(dataDir);

            return new FileOutput() { FileName = fileName, Url = exportPath };
        }

        public async Task<List<FileOutput>> TrichXuatHinhAnh(UploadFile model)
        {
            var result = new List<FileOutput>();


            string newFileName = await UploadFileToInput(model.File);
            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(dataDir);

            NodeCollection shapes = document.GetChildNodes(NodeType.Shape, true);
            int imageIndex = 0;
            foreach (Shape shape in shapes)
            {
                if (shape.HasImage)
                {
                    string fileName = string.Format("Image.ExportImages.{0}_out{1}", imageIndex, FileFormatUtil.ImageTypeToExtension(shape.ImageData.ImageType));
                    string exportPath = $"{outputFolder}/{fileName}";

                    shape.ImageData.Save(exportPath);
                    imageIndex++;

                    result.Add(new FileOutput()
                    {
                        FileName = fileName,
                        Url = exportPath
                    });
                }
            }

            if (File.Exists(dataDir))
                File.Delete(dataDir);

            return result;
        }

        public async Task<FileOutput> ChenVaThaoTacBieuDo(UploadFile model)
        {
            string newFileName = await UploadFileToInput(model.File);
            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(dataDir);
            DocumentBuilder builder = new DocumentBuilder(document);


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
            // ChartSeries series1 = shapeLine.Chart.Series[1];

            // Change first series name.
            series0.Name = "Trí";

            // Change second series name.
            // series1.Name = "Hải";

            // You can also specify whether the line connecting the points on the chart shall be smoothed using Catmull-Rom splines.
            series0.Smooth = true;
            // series1.Smooth = true;
            #endregion


            string extention = Path.GetExtension(model.File.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(model.File.FileName)}_Add_Sharp{extention}";
            string exportPath = $"{outputFolder}/{fileName}";
            // Nếu file đã tồn tại thì xoá
            if (File.Exists(exportPath))
                File.Delete(exportPath);


            //Chữ kí số

            document.Save(exportPath, SaveFormat.Docx);

            if (File.Exists(dataDir))
                File.Delete(dataDir);

            return new FileOutput() { FileName = fileName, Url = exportPath };
        }

        public async Task<FileOutput> BaoMat(UploadFile model)
        {

            string newFileName = await UploadFileToInput(model.File);
            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(dataDir);
            //    CHỉ đọc

            // Enter a password that's up to 15 characters long.
            document.WriteProtection.SetPassword(model.Password);
            document.WriteProtection.ReadOnlyRecommended = false;
            document.Protect(ProtectionType.NoProtection);

            // Set Mật khẩu
            // Create a document.
            // Document doc = new Document();
            // DocumentBuilder builder = new DocumentBuilder(doc);
            // builder.Write("Hello world!");

            // DocSaveOptions only applies to Doc and Dot save formats.
            DocSaveOptions options = new DocSaveOptions(SaveFormat.Doc);

            // Set a password with which the document will be encrypted, and which will be required to open it.
            options.Password = model.Password;


            //Hạn chế chỉnh sửa
            // doc.Protect(ProtectionType.NoProtection, "password");
            string extention = Path.GetExtension(model.File.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(model.File.FileName)}_HasPassword{extention}";
            string exportPath = $"{outputFolder}/{fileName}";
            // Nếu file đã tồn tại thì xoá
            if (File.Exists(exportPath))
                File.Delete(exportPath);


            //Chữ kí số

            document.Save(exportPath, SaveFormat.Docx);

            if (File.Exists(dataDir))
                File.Delete(dataDir);

            return new FileOutput() { FileName = fileName, Url = exportPath };
        }

        public async Task<FileOutput> BaoMatVoiCHUKISO(UploadFile model)
        {
            string newFileName = await UploadFileToInput(model.File);
            // Lấy path file Mẫu
            var dataDir = Path.Combine(inputFolder, newFileName);
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(dataDir);
            DocumentBuilder builder = new DocumentBuilder(document);

            // Set signature line options.
            SignatureLineOptions signatureLineOptions = new SignatureLineOptions
            {
                Signer = "Lê Minh Trí",
                SignerTitle = "Trí",
                Email = "lmtri1908@gmail.com",

                ShowDate = true,
                DefaultInstructions = false,
                Instructions = "You need more info about signature line",
                AllowComments = true
            };

            // Insert signature line.
            SignatureLine signatureLine = builder.InsertSignatureLine(signatureLineOptions).SignatureLine;
            signatureLine.ProviderId = Guid.Parse("CF5A7BB4-8F3C-4756-9DF6-BEF7F13259A2");

            string extention = Path.GetExtension(model.File.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(model.File.FileName)}_HasWriter{extention}";
            string exportPath = $"{outputFolder}/{fileName}";
            // Nếu file đã tồn tại thì xoá
            if (File.Exists(exportPath))
                File.Delete(exportPath);


            document.Save(exportPath);

            if (File.Exists(dataDir))
                File.Delete(dataDir);
            return new FileOutput() { FileName = fileName, Url = exportPath };
        }
    }
}