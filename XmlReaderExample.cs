using System;
using System.Xml;

class XmlReaderExample
{
    public static void ReadXml()
    {
        // Well-formed XML string with proper encoding
        string xmlContent = @"<?xml version='1.0' encoding='UTF-8'?>
        <Users>
            <User>
                <Name>John Doe</Name>
                <Age>30</Age>
                <City>New York</City>
            </User>
            <User>
                <Name>Jane Smith</Name>
                <Age>25</Age>
                <City>Chicago</City>
            </User>
        </Users>";

        try
        {
            // Create and configure XML document
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlContent);

            // Select all User nodes
            XmlNodeList userNodes = doc.SelectNodes("//User");
            
            if (userNodes?.Count > 0)
            {
                Console.WriteLine("User List:");
                Console.WriteLine("----------");
                
                foreach (XmlNode userNode in userNodes)
                {
                    // Safely extract data with null checks
                    string name = userNode.SelectSingleNode("Name")?.InnerText?.Trim() ?? "N/A";
                    string age = userNode.SelectSingleNode("Age")?.InnerText?.Trim() ?? "N/A";
                    string city = userNode.SelectSingleNode("City")?.InnerText?.Trim() ?? "N/A";

                    // Format output consistently
                    Console.WriteLine($"• Name:\t{name}");
                    Console.WriteLine($"  Age:\t{age}");
                    Console.WriteLine($"  City:\t{city}");
                    Console.WriteLine();  // Blank line between users
                }
            }
            else
            {
                Console.WriteLine("Warning: No user records found in XML data.");
            }
        }
        catch (XmlException ex)
        {
            Console.WriteLine($"XML Error: {ex.Message}");
            Console.WriteLine($"Line: {ex.LineNumber}, Position: {ex.LinePosition}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }
}