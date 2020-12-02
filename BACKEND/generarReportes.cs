using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Net;
using BACKEND.DAO;
using BACKEND.DAL;
using System.Threading.Tasks;

namespace BACKEND
{
    public class generarReportes
    {

        public generarReportes() { }

        public void reporteVentasEmpleadoMes(EmpleadoDAO c, int mes, int anio)
        {

            List<VentaDAO> ventas = new VentasDAL().reporteVentasAnio(c.id,mes,anio);


            PdfFont estilocolumnas = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA_BOLD);
            PdfFont estiloContenido = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA
                );


            PdfWriter lector = new PdfWriter("Reporte.pdf");
            PdfDocument pdf = new PdfDocument(lector);
            PageSize tamanio = new PageSize(792, 612);
            Document re = new Document(pdf, tamanio);
            re.SetMargins(60, 20, 55, 20);



            String[] columnas = { "ID", "Nombre", "Total","Fecha"};
            float[] tamanios = { 1, 2, 2, 2 };

            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(estilocolumnas)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#ea2c62")));
            }



            double totalventa = 0;

            for (int i = 0; i < ventas.Count; i++)
            {
                tabla.AddCell(new Paragraph(""+c.id).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#ff9a8c"));
                tabla.AddCell(new Paragraph(c.nombre).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));
                tabla.AddCell(new Paragraph("$"+ventas[i].total).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));
                tabla.AddCell(new Paragraph("" + ventas[i].fecha).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));

                totalventa += ventas[i].total;
            }
            re.Add(tabla);


            String[] columnastotal = { "N. ventas: "+ventas.Count+".\n Total ventas: $" + totalventa };
            float[] tamaniostotal = { 2 };
            tamaniostotal[0] = 2;

            Table total = new Table(UnitValue.CreatePercentArray(tamaniostotal));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnastotal)
            {
                total.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(estilocolumnas))).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#c4fb6d"));
            }

            re.Add(total);
            re.Close();




            var titulo = new Paragraph("Reporte de ventas del mes "+mes+" del año "+anio+" del empleado "+c.nombre+".").SetFont(estilocolumnas);
            titulo.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            titulo.SetFontSize(16);



            PdfDocument pdf2 = new PdfDocument(new PdfReader("Reporte.pdf"), new
                 PdfWriter(@"C:\reportes\reporte_" + c.nombre+".pdf"));
            Document reporte_ = new Document(pdf2);



            int numeropaginas = pdf2.GetNumberOfPages();
            reporte_.Add(titulo);
    
            reporte_.Close();
        }




        public void reporteVentasPeriodo(String inicio, String fin)
        {

            List<VentaDAO> ventas = new VentasDAL().reporteVentasPeriodo(inicio,fin);


            PdfFont estilocolumnas = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA_BOLD);
            PdfFont estiloContenido = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA
                );


            PdfWriter lector = new PdfWriter("Reporte.pdf");
            PdfDocument pdf = new PdfDocument(lector);
            PageSize tamanio = new PageSize(792, 612);
            Document re = new Document(pdf, tamanio);
            re.SetMargins(60, 20, 55, 20);



            String[] columnas = { "ID", "Empleado", "Total", "Fecha" };
            float[] tamanios = { 1, 2, 2, 2 };

            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(estilocolumnas)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#ea2c62")));
            }




            double totalventa = 0;

            for (int i = 0; i < ventas.Count; i++)
            {
                tabla.AddCell(new Paragraph("" + ventas[i].id_venta).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#ff9a8c"));
                tabla.AddCell(new Paragraph(new UsuariosDAL().getOne(ventas[i].idEmpleado).nombre).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));
                tabla.AddCell(new Paragraph("$" + ventas[i].total).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));
                tabla.AddCell(new Paragraph("" + ventas[i].fecha).SetFont(estiloContenido)).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#fad5ad"));

                totalventa += ventas[i].total;
            }
            re.Add(tabla);






            String[] columnastotal = { "N. ventas: " + ventas.Count + ".\n Total ventas: $" + totalventa };
            float[] tamaniostotal = { 2 };
            tamaniostotal[0] = 2;

            Table total = new Table(UnitValue.CreatePercentArray(tamaniostotal));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnastotal)
            {
                total.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(estilocolumnas))).SetBackgroundColor(iText.Kernel.Colors.WebColors.GetRGBColor("#c4fb6d"));
            }

            re.Add(total);


            re.Close();


            var titulo = new Paragraph("Reporte de ventas del periodo " + inicio + " al " + fin+".").SetFont(estilocolumnas);
            titulo.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            titulo.SetFontSize(16);



            PdfDocument pdf2 = new PdfDocument(new PdfReader("Reporte.pdf"), new
                 PdfWriter(@"C:\reportes\reporte_" +"perdiodo"+ ".pdf"));
            Document reporte_ = new Document(pdf2);



            int numeropaginas = pdf2.GetNumberOfPages();
            reporte_.Add(titulo);

            reporte_.Close();
        }











    }
}

