using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API._Interface;
using Aspose.Words;
using Aspose.Words.Drawing;
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
        public async Task ChuyenDoiSangPDF()
        {
            var path = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/helloword.doc");
            string folder = Path.Combine(_environment.ContentRootPath, @"wwwroot/output/");
            // tạo 1 file document với 1 file có đường dẫn có sẵn
            Document document = new Document(path);


            // document.Save(folder + "document.pdf", SaveFormat.Pdf);
            document.Save(folder + "document.html", SaveFormat.Html);
            document.Save(folder + "document.md", SaveFormat.Markdown);
            document.Save(folder + "document_image.jpg", SaveFormat.Jpeg);
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
    }
}