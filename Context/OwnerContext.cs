using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ПР50_Осокин.Models;
using Microsoft.Office.Interop.Word;
using System.Windows.Media.Imaging;

namespace ПР50_Осокин.Context
{
    public class OwnerContext
    {
        public OwnerContext(string FirstName, string LastName, string SurName, int NumberRoom) : base(FirstName, LastName, SurName, NumberRoom) { }
        public static List<OwnerContext> AllOwners()
        {
            List<OwnerContext> allOwners = new List<OwnerContext>();
            allOwners.Add(new OwnerContext("Елена", "Иванова", "Петровна", 1));
            allOwners.Add(new OwnerContext("Алексей", "Смирнов", "Владимирович", 2)); ;
            allOwners.Add(new OwnerContext("Анна", "Кузнецова", "Сергеевна", 3));
            allOwners.Add(new OwnerContext("Дмитрий", "Павлов", "Александрович", 3));
            allOwners.Add(new OwnerContext("Ольга", "Михайловна", "Ивановна", 4)); ;
            allOwners.Add(new OwnerContext("Артем", "Козлов", "Олегович", 5));
            allOwners.Add(new OwnerContext("Наталья", "Соколова", "Викторовна", 6));
            allOwners.Add(new OwnerContext("Игорь", "Лебедев", "Андреевич", 6));
            allOwners.Add(new OwnerContext("Екатерина", "Федорова", "Дмитриевна", 7));
            allOwners.Add(new OwnerContext("Андрей", "Александров", "Игоревич", 7));
            allOwners.Add(new OwnerContext("Оксана", "Степановна", "Николаевна", 8));
            allOwners.Add(new OwnerContext("Сергей", "Никитин", "Васильевич", 9));
            allOwners.Add(new OwnerContext("Мария", "Ковалева", "Александровна", 10));
            allOwners.Add(new OwnerContext("Павел", "Фролов", "Михайлович", 11));
            allOwners.Add(new OwnerContext("Елена", "Белова", "Александровна", 12));
            allOwners.Add(new OwnerContext("Илья", "Поляков", "Данилович", 13));
            allOwners.Add(new OwnerContext("Анастасия", "Гаврилова", "Валерьевна", 14));
            allOwners.Add(new OwnerContext("Денис", "Орлов", "Владимирович", 15));
            allOwners.Add(new OwnerContext("Алина", "Киселева", "Сергеевна", 16));
            allOwners.Add(new OwnerContext("Артем", "Ткаченко", "Викторович", 16));
            allOwners.Add(new OwnerContext("Валерия", "Романова", "Павловна", 16));
            allOwners.Add(new OwnerContext("Александр", "Максимов", "Юрьевич", 17));
            allOwners.Add(new OwnerContext("Евгения", "Сидорова", "Игоревна", 17));
            allOwners.Add(new OwnerContext("Никита", "Антонов", "Алексеевич", 18));
            allOwners.Add(new OwnerContext("Юлия", "Дмитриева", "Владимировна", 19));
            return allOwners;
        }
        public static void Report(string fileName)
        {
            Application app = new Application();
            Document doc = app.Documents.Add();
            Paragraph paraHeader = doc.Paragraphs.Add();
            paraHeader.Range.Font.Size = 16;
            paraHeader.Range.Text = "Список жильцов дома";
            paraHeader.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            paraHeader.Range.ParagraphFormat.SpaceAfter = 0;
            paraHeader.Range.Font.Bold = 1;
            paraHeader.Range.InsertParagraphAfter();
            Paragraph paraAddress = doc.Paragraphs.Add();
            paraAddress.Range.Font.Size = 14;
            paraAddress.Range.Text = "по адресу: г. Пермь, ул. Луначарского, д. 24";
            paraHeader.Range.ParagraphFormat.SpaceAfter = 20;
            paraHeader.Range.Font.Bold = 0;
            paraAddress.Range.InsertParagraphAfter();
            Paragraph paraCount = doc.Paragraphs.Add();
            paraCount.Range.Font.Size = 14;
            paraCount.Range.Text = $"Всего жильцов: {AllOwners().Count}";
            paraCount.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            paraHeader.Range.ParagraphFormat.SpaceAfter = 0;
            paraCount.Range.InsertParagraphAfter();
            Paragraph paraTable = doc.Paragraphs.Add();
            Table paymentsTable = doc.Tables.Add(paraTable.Range, AllOwners().Count + 1, 5);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            Cell("№", paymentsTable.Cell(1, 1).Range);
            Cell("Фамилия", paymentsTable.Cell(1, 2).Range);
            Cell("Имя", paymentsTable.Cell(1, 3).Range);
            Cell("Отчество", paymentsTable.Cell(1, 4).Range);
            Cell("Изображение", paymentsTable.Cell(1, 5).Range);
            for (int i = 0; i < AllOwners().Count; i++)
            {
                OwnerContext owner = AllOwners()[i];
                Cell((i + 1).ToString(), paymentsTable.Cell(1 + 1 + i, 1).Range);
                Cell(owner.LastName, paymentsTable.Cell(1 + 1 + i, 2).Range, WdParagraphAlignment.wdAlignParagraphLeft);
                Cell(owner.FirstName, paymentsTable.Cell(1 + 1 + i, 3).Range, WdParagraphAlignment.wdAlignParagraphLeft);
                Cell(owner.SurName, paymentsTable.Cell(1 + 1 + i, 4).Range, WdParagraphAlignment.wdAlignParagraphLeft);
                Cell(owner.Img, paymentsTable.Cell(1 + 1 + i, 5).Range, WdParagraphAlignment.wdAlignParagraphCenter);
            }
            doc.SaveAs2(fileName);
            doc.Close();
            app.Quit();
        }
        public static void Cell(string Text, Range Cell, WdParagraphAlignment alignment = WdParagraphAlignment.wdAlignParagraphCenter)
        {
            Cell.Text = Text;
            Cell.ParagraphFormat.Alignment = alignment;
        }
    }
}
