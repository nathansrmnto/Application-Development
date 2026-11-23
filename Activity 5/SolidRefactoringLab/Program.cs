using System;

namespace SolidRefactoringLab{

    //[NEW]: Interface - IReportFormatter with a method
    public interface IReportFormatter{
        void FormatReport();
    }

    /* [REMOVE]
    public void GeneratorReport(string reportType){
            if (reportType == "PDF"){
                Console.WriteLine("Formatting report as a PDF...");
            }
            else if (reportType == "Word"){
                Console.WriteLine("Formatting report as a Word Document...");
            }
            else{
                Console.WriteLine("Formatting report as plain text...");
            }
        }
    */
    

    //[REPLACE]: new classes that implement this interface for PDF
    public class PdfFormatter : IReportFormatter{
        public void FormatReport(){
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    //[REPLACE]: new classes that implement this interface for Word
    public class WordFormatter : IReportFormatter{
        public void FormatReport(){
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    //[REPLACE]: new classes that implement this interface for Plain Text
    public class PlainTextFormatter : IReportFormatter{
        public void FormatReport(){
            Console.WriteLine("Formatting report as a plain text...");
        }
    }

    //[MODIFIED]: generating reports only
    public class ReportManager{

        //[NEW]: accepts IReportFormatter (Dependency Inversion/Injection) to format the report without knowing the specific document type
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; } = "";
        
        public ReportManager(IReportFormatter formatter){
            _formatter = formatter;
        }

        public void GenerateReport(){
            _formatter.FormatReport();
        }
    }

    //[NEW]: class for ReportSaver
    public class ReportSaver{
        
        //[MOVED]: the SaveToFile
        public void SaveToFile(string filename){
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    class Program{
        //[MODIFIED]: Modify your Main method to test your new, clean architecture
        static void Main(String[] args){
            
            //[NEW] 1. Choose the formatter (OCP)
            IReportFormatter formatter = new PdfFormatter();

            //[MODIFIED] 2. Pass it to the manager
            ReportManager manager = new ReportManager(formatter); //[NEW]
            manager.GenerateReport();
            
            //[NEW] 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}