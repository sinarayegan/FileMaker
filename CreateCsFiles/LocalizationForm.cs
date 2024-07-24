using System.Text.RegularExpressions;
using System.Xml;
using CreateCsFiles.Properties;

namespace CreateCsFiles;

public partial class LocalizationForm : Form
{
    public LocalizationForm()
    {
        InitializeComponent();
    }

    private void LocalizationForm_Load(object sender, EventArgs e)
    {
        ProjectTB.Text = Settings.Default.Project;
        OutputTB.Text = Settings.Default.Output;
    }

    private void btnStartOperation_Click(object sender, EventArgs e)
    {
        if (cbEnumOrError.Checked)
        {
            var directoryPath =
                ProjectTB.Text;

            var resxFaFilePath =
                ProjectTB.Text + "\\Harmony2024.Domains\\Localizations\\LanguageManager.fa-IR.resx";
            var resxEnFilePath =
                ProjectTB.Text + "\\Harmony2024.Domains\\Localizations\\LanguageManager.en-US.resx";

            ScanAndAddToResx(directoryPath, resxFaFilePath);
            ScanAndAddToResx(directoryPath, resxEnFilePath);

            // Check for keys in RESX files that are not present in .cs files
            CheckMissingKeysInCsFiles(directoryPath, resxFaFilePath, "MissingKeysFa.txt");
            CheckMissingKeysInCsFiles(directoryPath, resxEnFilePath, "MissingKeysEn.txt");

            //UnMatchingErrors.Main2();
            //UnMatching.Main3();
            //CorrectErrors.Main4();
            //FindErrorsWithSpaces.Main5();

            MessageBox.Show("Operation Completed Successfully");

            static void ScanAndAddToResx(string directoryPath, string resxFilePath)
            {
                try
                {
                    // Get all .cs files in the directory and its subdirectories
                    var csFiles = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

                    // Regular expression pattern to match Display attributes and extract their values
                    var displayPattern = @"\[Display\(\s*Name\s*=\s*\""(?<value>[^\""]+)\""\s*\)\]";

                    // Regular expression pattern to match error messages and extract the second string
                    var errorPattern = @"\bnew\s+Error\(\s*\""[^\""]+\""\s*,\s*\""(?<value>[^\""]+)\""\s*\)";

                    // Regular expression pattern to match error messages with _languageHelper.GetDisplayName
                    var langHelperErrorPattern =
                        @"\bnew\s+Error\(\s*\""[^\""]+\""\s*,\s*_languageHelper\.GetDisplayName\(\s*\""(?<value>[^\""]+)\""\s*\)\s*\)";

                    // Regular expression pattern to match the specified string pattern and extract the last string
                    var customPattern =
                        @"\bpublic\s+static\s+readonly\s+\w+\s+\w+\s+=\s+new\s+\w+\(\s*\d+\s*,\s*\""[^\""]+\""\s*,\s*\""(?<value>[^\""]+)\""\s*\)\s*;";

                    // Load existing RESX file
                    var resxDoc = new XmlDocument();
                    resxDoc.Load(resxFilePath);

                    // Extract existing data names to check for duplicates (case-insensitive)
                    var existingDataNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    foreach (XmlElement dataElement in resxDoc.SelectNodes("//data"))
                        existingDataNames.Add(dataElement.GetAttribute("name"));

                    foreach (var filePath in csFiles)
                        try
                        {
                            // Read the content of the file
                            var fileContent = File.ReadAllText(filePath);

                            // Use Regex to find matches for Display attributes and extract values
                            var displayMatches = Regex.Matches(fileContent, displayPattern);

                            // Output Display values
                            foreach (Match displayMatch in displayMatches)
                            {
                                var displayValue = displayMatch.Groups["value"].Value;

                                // Generate a unique name based on displayValue
                                var uniqueName = GetUniqueName(displayValue);

                                // Check if the uniqueName already exists in the RESX file (case-insensitive)
                                if (!existingDataNames.Contains(uniqueName))
                                {
                                    // If not, add it to the RESX file with an empty value
                                    AddDataToResx(resxDoc, uniqueName);
                                    existingDataNames.Add(uniqueName);
                                }
                            }

                            // Use Regex to find matches for error messages and extract the second string
                            var errorMatches = Regex.Matches(fileContent, errorPattern);

                            // Output error message values
                            foreach (Match errorMatch in errorMatches)
                            {
                                var errorMessage = errorMatch.Groups["value"].Value;

                                // Generate a unique name based on errorMessage
                                var uniqueName = GetUniqueName(errorMessage);


                                // Check if the uniqueName already exists in the RESX file (case-insensitive)
                                if (!existingDataNames.Contains(uniqueName))
                                {
                                    // If not, add it to the RESX file with an empty value
                                    AddDataToResx(resxDoc, uniqueName);
                                    existingDataNames.Add(uniqueName);
                                }
                            }

                            // Use Regex to find matches for error messages with _languageHelper.GetDisplayName
                            var langHelperErrorMatches = Regex.Matches(fileContent, langHelperErrorPattern);

                            // Output langHelper error message values
                            foreach (Match langHelperErrorMatch in langHelperErrorMatches)
                            {
                                var errorMessage = langHelperErrorMatch.Groups["value"].Value;

                                // Generate a unique name based on errorMessage
                                var uniqueName = GetUniqueName(errorMessage);


                                // Check if the uniqueName already exists in the RESX file (case-insensitive)
                                if (!existingDataNames.Contains(uniqueName))
                                {
                                    // If not, add it to the RESX file with an empty value
                                    AddDataToResx(resxDoc, uniqueName);
                                    existingDataNames.Add(uniqueName);
                                }
                            }

                            // Use Regex to find matches for the specified string pattern and extract the last string
                            var customMatches = Regex.Matches(fileContent, customPattern);

                            // Output custom values
                            foreach (Match customMatch in customMatches)
                            {
                                var customValue = customMatch.Groups["value"].Value;

                                // Generate a unique name based on customValue
                                var uniqueName = GetUniqueName(customValue);


                                // Check if the uniqueName already exists in the RESX file (case-insensitive)
                                if (!existingDataNames.Contains(uniqueName))
                                {
                                    // If not, add it to the RESX file with an empty value
                                    AddDataToResx(resxDoc, uniqueName);
                                    existingDataNames.Add(uniqueName);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Error reading file {filePath}: {ex.Message}");
                        }

                    // Save the modified RESX document
                    resxDoc.Save(resxFilePath);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error scanning files: {ex.Message}");
                }
            }

            static void AddDataToResx(XmlDocument resxDoc, string uniqueName)
            {
                // Create a new data element
                var newDataElement = resxDoc.CreateElement("data");

                // Set the name attribute
                newDataElement.SetAttribute("name", uniqueName);

                // Create xml:space attribute and set its value to "preserve"
                var spaceAttribute = resxDoc.CreateAttribute("xml", "space", "http://www.w3.org/XML/1998/namespace");
                spaceAttribute.Value = "preserve";
                newDataElement.Attributes.Append(spaceAttribute);

                // Create a new value element with an empty value
                var valueElement = resxDoc.CreateElement("value");
                valueElement.IsEmpty = true;

                // Append the value element to the data element
                newDataElement.AppendChild(valueElement);

                // Append the new data element to the root of the document
                resxDoc.DocumentElement.AppendChild(newDataElement);
            }

            static string GetUniqueName(string baseName)
            {
                // Replace invalid characters with underscores
                var validName = Regex.Replace(baseName, @"[^\w\d_]", "_");

                // Make sure the name starts with a letter or underscore
                if (!char.IsLetter(validName, 0) && validName[0] != '_') validName = "_" + validName;

                return validName;
            }

            static void CheckMissingKeysInCsFiles(string directoryPath, string resxFilePath, string outputFileName)
            {
                try
                {
                    // Load existing RESX file
                    var resxDoc = new XmlDocument();
                    resxDoc.Load(resxFilePath);

                    // Extract keys from RESX file
                    var resxKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    foreach (XmlElement dataElement in resxDoc.SelectNodes("//data"))
                        resxKeys.Add(dataElement.GetAttribute("name"));

                    // Get all .cs files in the directory and its subdirectories
                    var csFiles = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

                    // Regular expression pattern to match Display attributes and extract their values
                    var displayPattern = @"\[Display\(\s*Name\s*=\s*\""(?<value>[^\""]+)\""\s*\)\]";

                    // Regular expression pattern to match error messages and extract the second string
                    var errorPattern = @"\bnew\s+Error\(\s*\""[^\""]+\""\s*,\s*\""(?<value>[^\""]+)\""\s*\)";

                    // Regular expression pattern to match error messages with _languageHelper.GetDisplayName
                    var langHelperErrorPattern =
                        @"\bnew\s+Error\(\s*\""[^\""]+\""\s*,\s*_languageHelper\.GetDisplayName\(\s*\""(?<value>[^\""]+)\""\s*\)\s*\)";

                    // Regular expression pattern to match the specified string pattern and extract the last string
                    var customPattern =
                        @"\bpublic\s+static\s+readonly\s+\w+\s+\w+\s+=\s+new\s+\w+\(\s*\d+\s*,\s*\""[^\""]+\""\s*,\s*\""(?<value>[^\""]+)\""\s*\)\s*;";

                    // Find keys in RESX file that are not present in .cs files
                    var missingKeys = new HashSet<string>(resxKeys, StringComparer.OrdinalIgnoreCase);
                    foreach (var filePath in csFiles)
                        try
                        {
                            // Read the content of the file
                            var fileContent = File.ReadAllText(filePath);

                            // Use Regex to find matches for Display attributes and extract values
                            var displayMatches = Regex.Matches(fileContent, displayPattern);

                            // Remove matching keys from missingKeys set
                            foreach (Match displayMatch in displayMatches)
                            {
                                var displayValue = displayMatch.Groups["value"].Value;
                                missingKeys.Remove(GetUniqueName(displayValue));
                            }

                            // Use Regex to find matches for error messages and extract the second string
                            var errorMatches = Regex.Matches(fileContent, errorPattern);

                            // Remove matching keys from missingKeys set
                            foreach (Match errorMatch in errorMatches)
                            {
                                var errorMessage = errorMatch.Groups["value"].Value;
                                missingKeys.Remove(GetUniqueName(errorMessage));
                            }

                            // Use Regex to find matches for error messages with _languageHelper.GetDisplayName
                            var langHelperErrorMatches = Regex.Matches(fileContent, langHelperErrorPattern);

                            // Remove matching keys from missingKeys set
                            foreach (Match langHelperErrorMatch in langHelperErrorMatches)
                            {
                                var errorMessage = langHelperErrorMatch.Groups["value"].Value;
                                missingKeys.Remove(GetUniqueName(errorMessage));
                            }

                            // Use Regex to find matches for the specified string pattern and extract the last string
                            var customMatches = Regex.Matches(fileContent, customPattern);

                            // Remove matching keys from missingKeys set
                            foreach (Match customMatch in customMatches)
                            {
                                var customValue = customMatch.Groups["value"].Value;
                                missingKeys.Remove(GetUniqueName(customValue));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Error reading file {filePath}: {ex.Message}");
                        }

                    // Write missing keys to a text file on the desktop


                    // Check if the output directory exists, if not, create it
                    if (!Directory.Exists(Settings.Default.Output)) Directory.CreateDirectory(Settings.Default.Output);

                    var outputPath = Settings.Default.Output;
                    File.WriteAllLines(outputPath, missingKeys);
                    File.WriteAllLines(outputPath, missingKeys);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error checking files: {ex.Message}");
                }
            }
        }
    }
}