using System.Globalization;
using System.Text;
using ContainerExampleConsoleApp.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace ContainerExampleConsoleApp.Classes;

internal class FileOperations
{
    /// <summary>
    /// First read from contact.csv into a List of <seealso cref="Contacts"/> followed
    /// by seeing (there are) if there are gaps similar to in DatabaseExampleConsoleApp
    /// </summary>
    /// <returns></returns>
    public static int[] MissingContactIdentifiers()
    {
        var (_, contacts) = ReadContacts("Contacts.csv");
        var existingIdentifiers = contacts.Select(x => x.ContactId).ToList();
        return existingIdentifiers.Missing();
    }
    /// <summary>
    /// Read file into a strong type, <seealso cref="Contacts"/>
    /// </summary>
    /// <remarks>
    /// Uses <see cref="CsvReader"/> NuGet package
    /// </remarks>
    public static (bool success, List<Contacts> contacts) ReadContacts(string fileName)
    {
        List<Contacts> list = new();

        StringBuilder errorBuilder = new();

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            Delimiter = ",",
            HasHeaderRecord = false,
        };

        using var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        using (var textReader = new StreamReader(fs, Encoding.UTF8))

        using (var csv = new CsvReader(textReader, configuration))
        {

            while (csv.Read())
            {
                try
                {
                    var record = csv.GetRecord<Contacts>();
                    list.Add(record);
                }
                catch (Exception ex)
                {
                    errorBuilder.AppendLine(ex.Message);
                }
            }
        }

        /*
         * If errors (there are none) while reading we write to a log
         */
        if (errorBuilder.Length > 0)
        {
            errorBuilder.Insert(0, $"Errors for {fileName}\n");

            File.WriteAllText(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "ParseErrors.txt"),
                errorBuilder.ToString());

            return (false, null);
        }
        else
        {
            return (true, list);
        }
    }

}