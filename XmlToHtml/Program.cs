using System;
using System.IO;
using System.Xml.Xsl;

namespace XmlToHtml
{
    class Program
    {
        static void Main(string[] args)
        {   
            //If not passed file paths to .xml, .xsl , .html files show usage
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: xml2html.exe xslfile.xsl xmlfile.xml output.html");
                return;
            }

            //Check if exist xml & xsl files.
            if (!File.Exists(args[0]) || !File.Exists(args[1])) 
            {
                Console.WriteLine(args[0] + " or " + args[1] + " doesn't exist");
                return;
            }
            XslCompiledTransform xsl = new XslCompiledTransform();
            String outputFile = args[2];
            xsl.Load(args[0]);
            xsl.Transform(args[1], args[2]);

            if (File.Exists(args[2])) Console.WriteLine(args[2] + " successfully created!");
            else Console.WriteLine("Couldn't create " + args[2]);
            
        }
    }
}
