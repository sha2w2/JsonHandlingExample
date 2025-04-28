using System;
using System.Xml;

class XmlReaderExample
{
    public static void ReadXml()
    {
        string xmlContent = @"<Users>
            <User>
                <Name>John Doe</Name>
                <Age>30</Age>
                <City>New York</City>
            </User>
            <User>
                <Name>Jona Doe</Name>
                <Age>25</Age>
                <City>Chicago</City>
            </User>
        </Users>";

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlContent);

        XmlNodeList userNodes = doc.SelectNodes("//User");
        foreach (XmlNode userNode in userNodes)
        {
            Console.WriteLine($"Name: {userNode.SelectSingleNode("Name").InnerText}");
            Console.WriteLine($"Age: {userNode.SelectSingleNode("Age").InnerText}");
            Console.WriteLine($"City: {userNode.SelectSingleNode("City").InnerText}\n");
        }
    }
}