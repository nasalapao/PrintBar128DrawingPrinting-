Imports System.Drawing.Printing
Imports PrintBar.My.Resources
Imports ZXing
Public Class Form1



    Dim longpaper As Integer
    Sub changelongpaper()
        Dim rowcount As Integer
        longpaper = 0
        ' rowcount = DataGridView1.Rows.Count
        longpaper = rowcount * 15
        longpaper = longpaper + 240
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim barcodewritte As New BarcodeWriter
        barcodewritte.Format = BarcodeFormat.CODE_128

        Dim img = barcodewritte.Write("123456000DDDSS")

        PictureBox1.Image = img

    End Sub

    Private Sub bntPrint_Click(sender As Object, e As EventArgs) Handles bntPrint.Click
        changelongpaper()
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()  'Direct Print
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 314, 196) 'fixed size

        'pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f16b As New Font("TH Niramit AS", 16, FontStyle.Bold)
        Dim f12 As New Font("TH Niramit AS", 12, FontStyle.Regular)
        Dim f10b As New Font("TH Niramit AS", 10, FontStyle.Bold)
        Dim f10 As New Font("TH Niramit AS", 10, FontStyle.Regular)
        Dim f8b As New Font("TH Niramit AS", 8, FontStyle.Bold)
        Dim f8 As New Font("TH Niramit AS", 8, FontStyle.Regular)

        Dim marginL As Integer = PD.DefaultPageSettings.Margins.Left
        Dim marginC As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim marginR As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim Right As New StringFormat
        Dim Center As New StringFormat
        Right.Alignment = StringAlignment.Far
        Center.Alignment = StringAlignment.Center

        Dim Line As String = "--------------------------------------------"

        Dim logoImage As Image = Resource1.ResourceManager.GetObject("logo2")
        e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)
        'e.Graphics.DrawImage(logoImage, 0, 250, 150, 50)

        e.Graphics.DrawString("Label Scale", f16b, Brushes.Black, marginC, 8, Center)
        e.Graphics.DrawString("88888 : 1", f10, Brushes.Black, marginC, 35, Center)
        e.Graphics.DrawString("*******", f10, Brushes.Black, marginC, 50, Center)
        e.Graphics.DrawString("******** Co.,Ltd.", f10b, Brushes.Black, marginC, 70, Center)
        e.Graphics.DrawString(Line, f10, Brushes.Black, marginC, 85, Center)

        Dim adjustMargin As Integer = 18
        e.Graphics.DrawString("ประเภท", f10b, Brushes.Black, 8, 100)
        e.Graphics.DrawString("DMEMO", f10, Brushes.Black, marginR - adjustMargin, 100, Right)

        e.Graphics.DrawString("ชื่อพนักงาน", f10b, Brushes.Black, 8, 115)
        e.Graphics.DrawString("DEMO", f10, Brushes.Black, marginR - adjustMargin, 115, Right)

        e.Graphics.DrawString("เวลาที่ชั่ง", f10b, Brushes.Black, 8, 130)
        e.Graphics.DrawString("13/08/2024 11:11", f10, Brushes.Black, marginR - adjustMargin, 130, Right)

        e.Graphics.DrawString("เวลาที่ปริ้น", f10b, Brushes.Black, 8, 145)
        e.Graphics.DrawString("13/08/2024 13:13", f10, Brushes.Black, marginR - adjustMargin, 145, Right)


        e.Graphics.DrawImage(PictureBox1.Image, CInt((e.PageBounds.Width - 300) / 2), 150, 300, 40)



    End Sub
End Class
