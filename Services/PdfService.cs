using iTextSharp.text;
using iTextSharp.text.pdf;
using KevinfalsPhone.Models;

namespace KevinfalsPhone.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateInvoicePdf(Order order, List<CartItem> cartItems, User user)
        {
            using (var stream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, stream);
                
                document.Open();

                // En-tête
                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                var headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var normalFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);

                document.Add(new Paragraph("FACTURE", titleFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph($"Numéro: {order.NumeroFacture}", headerFont));
                document.Add(new Paragraph($"Date: {order.DateCommande:dd/MM/yyyy}", normalFont));
                document.Add(new Paragraph(" "));

                // Informations client
                document.Add(new Paragraph("INFORMATIONS CLIENT", headerFont));
                document.Add(new Paragraph($"Nom: {user.Prenom} {user.Nom}", normalFont));
                document.Add(new Paragraph($"Email: {user.Email}", normalFont));
                document.Add(new Paragraph($"Adresse de livraison: {order.AdresseLivraison}", normalFont));
                document.Add(new Paragraph(" "));

                // Tableau des produits
                document.Add(new Paragraph("DÉTAIL DE LA COMMANDE", headerFont));
                var table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 3, 1, 2, 1, 2 });

                // En-têtes du tableau
                table.AddCell(new PdfPCell(new Phrase("Produit", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Qté", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Prix Unit.", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Catégorie", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Total", headerFont)));

                // Lignes des produits
                foreach (var item in cartItems)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.ProductName, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.Quantite.ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase($"{item.Prix:C}", normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.CategoryName, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase($"{item.Total:C}", normalFont)));
                }

                document.Add(table);
                document.Add(new Paragraph(" "));

                // Total
                document.Add(new Paragraph($"TOTAL: {order.PrixTotal:C}", titleFont) { Alignment = Element.ALIGN_RIGHT });

                document.Close();
                return stream.ToArray();
            }
        }
    }
}