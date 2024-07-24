using System.Diagnostics;
using System.Net;
using System.Reflection;
using Microsoft.Win32;

namespace CreateCsFiles;

public partial class Form1 : Form
{
    private readonly string insertString = @"\Harmony";
    private string commandsPath;
    private string Harmony = ".CPanel";
    private string queriesPath;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = new List<string> { "Command", "Query" };
        comboBox1.SelectedIndex = -1;
        comboBox2.DataSource = new List<string> { "Command", "Query" };
        comboBox2.SelectedIndex = -1;
        comboBox3.DataSource = new List<string> { "Command", "Query" };
        comboBox3.SelectedIndex = -1;
        comboBox4.DataSource = new List<string> { "Command", "Query" };
        comboBox4.SelectedIndex = -1;
        comboBox5.DataSource = new List<string> { "Single", "PagedList", "IEnumerable", "Response", "No Response" };
        comboBox5.SelectedIndex = 0;
        comboBox6.DataSource = new List<string> { "Single", "PagedList", "IEnumerable", "Response", "No Response" };
        comboBox6.SelectedIndex = 0;
        comboBox7.DataSource = new List<string> { "Single", "PagedList", "IEnumerable", "Response", "No Response" };
        comboBox7.SelectedIndex = 0;
        comboBox8.DataSource = new List<string> { "Single", "PagedList", "IEnumerable", "Response", "No Response" };
        comboBox8.SelectedIndex = 0;
        comboBox9.DataSource = new List<string> { "Response", "No Response" };
        comboBox9.SelectedIndex = 0;
        comboBox10.DataSource = new List<string> { "Response", "No Response" };
        comboBox10.SelectedIndex = 0;
        comboBox11.DataSource = new List<string> { "Response", "No Response" };
        comboBox11.SelectedIndex = 0;
        label5.Text = "";
        label4.Text = "";
        label3.Text = "";
        label6.Text = "";


        //var versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
        //var currentVersion = Application.ProductVersion;

        //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Version.txt");

        //File.WriteAllText(filePath, versionInfo!.ToString());
    }

    private string ReadSetting(string name)
    {
        using (var key = Registry.CurrentUser.OpenSubKey($"Software\\{Application.ProductName}"))
        {
            return key?.GetValue(name)?.ToString() ?? string.Empty;
        }
    }

    private void Generate_Click(object sender, EventArgs e)
    {
        var folderName = EntityName.Text + "s";
        var actionName = EntityName.Text;
        var nameSpace = txbNameSpace.Text;
        var comboBoxes = new List<ComboBox> { comboBox1, comboBox2, comboBox3, comboBox4 };

        var txb1 = textBox1.Text.Trim();
        var txb2 = textBox2.Text.Trim();
        var txb3 = textBox3.Text.Trim();
        var txb4 = textBox4.Text.Trim();
        var txb5 = textBox5.Text.Trim();
        var txb6 = textBox6.Text.Trim();
        var txb7 = textBox7.Text.Trim();
        var txb8 = textBox8.Text.Trim();

        // Validate that a folder name is entered
        if (string.IsNullOrWhiteSpace(actionName) || string.IsNullOrEmpty(nameSpace))
        {
            MessageBox.Show("Please enter a Entity and NameSpace.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var commandsBasePath = ReadSetting("Commands");
        var queriesBasePath = ReadSetting("Queries");
        if (chbForHarmony.Checked)
        {
            Harmony = ".Harmony";
            commandsPath = ModifyPath(commandsBasePath, insertString);
            queriesPath = ModifyPath(queriesBasePath, insertString);
        }
        else
        {
            commandsPath = ModifyPath(commandsBasePath, "\\CPanel");
            queriesPath = ModifyPath(queriesBasePath, "\\CPanel");
        }

        commandsPath = ModifyPath(commandsPath, $"\\{nameSpace}");
        queriesPath = ModifyPath(queriesPath, $"\\{nameSpace}");


        static string ModifyPath(string basePath, string insertString)
        {
            // Find the last occurrence of '\' in the path
            var lastSlashIndex = basePath.LastIndexOf('\\');

            // If a slash is found, insert the string after that, otherwise just prepend the string
            return lastSlashIndex != -1 ? basePath.Insert(lastSlashIndex, insertString) : insertString + basePath;
        }

        try
        {
            // Create the folder
            //Directory.CreateDirectory(nameSpace);


            // Check if "Create" checkbox is checked
            if (createCheckBox.Checked)
                CreateCommandFile(createCheckBox.Text, actionName, commandsPath, nameSpace, comboBox9);
            if (editCheckBox.Checked)
                CreateCommandFile(editCheckBox.Text, actionName, commandsPath, nameSpace, comboBox10);
            if (deleteCheckBox.Checked)
                CreateCommandFile(deleteCheckBox.Text, actionName, commandsPath, nameSpace, comboBox11);
            if (GetById.Checked) CreateQueryFile(GetById.Name, actionName, queriesPath, nameSpace);
            if (GetAll.Checked) CreateQueryFile(GetAll.Name, actionName, queriesPath, nameSpace);

            foreach (var comboBox in comboBoxes)
                if (comboBox is { SelectedIndex: >= 0, Name: "comboBox1" })
                {
                    if (comboBox.Text == "Command")
                        CreateCommandFile(txb1 + actionName + txb2, commandsPath, nameSpace, comboBox5);
                    else
                        CreateQueryFile1(txb1 + actionName + txb2, queriesPath, nameSpace, comboBox5);
                }
                else if (comboBox is { SelectedIndex: >= 0, Name: "comboBox2" })
                {
                    if (comboBox.Text == "Command")
                        CreateCommandFile(txb3 + actionName + txb4, commandsPath, nameSpace, comboBox6);
                    else
                        CreateQueryFile1(txb3 + actionName + txb4, queriesPath, nameSpace, comboBox6);
                }
                else if (comboBox is { SelectedIndex: >= 0, Name: "comboBox3" })
                {
                    if (comboBox.Text == "Command")
                        CreateCommandFile(txb5 + actionName + txb6, commandsPath, nameSpace, comboBox7);
                    else
                        CreateQueryFile1(txb5 + actionName + txb6, queriesPath, nameSpace, comboBox7);
                }
                else if (comboBox is { SelectedIndex: >= 0, Name: "comboBox4" })
                {
                    if (comboBox.Text == "Command")
                        CreateCommandFile(txb7 + actionName + txb8, commandsPath, nameSpace, comboBox8);
                    else
                        CreateQueryFile1(txb7 + actionName + txb8, queriesPath, nameSpace, comboBox8);
                }


            MessageBox.Show("File created inside the folder.", "File Created", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating folder: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CreateCommandFile(string chbText, string actionName, string folderPath, string nameSpace,
        ComboBox type)
    {
        var newFolderPath = Path.Combine(folderPath, chbText + actionName);
        var NameSpace = chbText + actionName;


        Directory.CreateDirectory(newFolderPath);


        var fileName1 = chbText + actionName + "Command";
        var fileName2 = chbText + actionName + "CommandHandler";
        var fileName3 = chbText + actionName + "CommandRequest";
        var fileName4 = chbText + actionName + "CommandResponse";
        var fileName5 = chbText + actionName + "CommandValidator";
        var filePath = string.Empty;
        var fileContent = string.Empty;

        var listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName4, fileName5 };
        if (type.SelectedIndex == 1) listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName5 };
        for (var i = 0; i < listFileNames.Count; i++)
        {
            if (i == 0)
            {
                if (listFileNames.Count == 5)
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." + NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] + $" : Command<{fileName4}>" +
                        "\n{\n \n}";
                }

                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." + NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] + " : Command" +
                        "\n{\n \n}";
                }
            }

            else if (i == 1)
            {
                if (listFileNames.Count == 5)
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : ICommandHandler<{fileName1},{fileName4}>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Result<{fileName4}>> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }

                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : ICommandHandler<{fileName1}>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Result> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }
            }
            else
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent = $"namespace HarmonyCore.Application{Harmony}.{nameSpace}." + "Commands" + "." +
                              NameSpace +
                              ";" +
                              "\npublic sealed class " + listFileNames[i] +
                              "\n{\n \n}";
            }

            File.WriteAllText(filePath, fileContent);
        }
    }

    private void CreateQueryFile(string chbText, string actionName, string folderPath, string nameSpace)
    {
        var NameSpace = chbText + actionName;
        var newFolderPath = Path.Combine(folderPath, chbText + actionName);
        if (chbText == "GetById")
        {
            NameSpace = $"Get{actionName}ById";
            newFolderPath = Path.Combine(folderPath, $"Get{actionName}ById");
        }

        if (chbText == "GetAll")

        {
            NameSpace = $"GetAll{actionName}s";
            newFolderPath = Path.Combine(folderPath, NameSpace);
        }


        Directory.CreateDirectory(newFolderPath);

        var fileName1 = chbText + actionName + "Query";
        var fileName2 = chbText + actionName + "QueryHandler";
        var fileName3 = chbText + actionName + "QueryRequest";
        var fileName4 = chbText + actionName + "QueryResponse";
        var fileName5 = chbText + actionName + "QueryFilters";

        if (chbText == "GetById")
        {
            fileName1 = $"Get{actionName}ById" + "Query";
            fileName2 = $"Get{actionName}ById" + "QueryHandler";
            fileName3 = $"Get{actionName}ById" + "QueryRequest";
            fileName4 = $"Get{actionName}ById" + "QueryResponse";
        }

        if (chbText == "GetAll")
        {
            fileName1 = NameSpace + "Query";
            fileName2 = NameSpace + "QueryHandler";
            fileName3 = NameSpace + "QueryRequest";
            fileName4 = NameSpace + "QueryResponse";
            fileName5 = NameSpace + "QueryFilters";
        }

        var filePath = string.Empty;
        var fileContent = string.Empty;

        var listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName4, fileName5 };
        for (var i = 0; i < (chbText == "GetAll" ? 5 : 4); i++)
        {
            if (i == 0)
            {
                if (chbText == "GetAll")
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Queries" + "." + NameSpace + ";" +
                        "\npublic sealed class " + listFileNames[i] + $" : IQuery<PagedList<{fileName4}>>" +
                        "\n{\n \n}";
                }
                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Queries" + "." + NameSpace + ";" +
                        "\npublic sealed class " + listFileNames[i] + $" : IQuery<{fileName4}>" +
                        "\n{\n \n}";
                }
            }

            else if (i == 1)
            {
                if (chbText == "GetAll")
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Queries" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : IQueryHandler<{fileName1},PagedList<{fileName4}>>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Maybe<PagedList<{fileName4}>>> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }
                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Queries" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : IQueryHandler<{fileName1},{fileName4}>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Maybe<{fileName4}>> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }
            }
            else
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent = $"namespace HarmonyCore.Application{Harmony}.{nameSpace}." + "Queries" + "." + NameSpace +
                              ";" +
                              "\n  public sealed class " + listFileNames[i] +
                              "\n{\n \n}";
            }

            File.WriteAllText(filePath, fileContent);
        }
    }

    private void CreateCommandFile(string chbText, string folderPath, string nameSpace, ComboBox type)
    {
        var newFolderPath = Path.Combine(folderPath, chbText);
        var NameSpace = chbText;


        Directory.CreateDirectory(newFolderPath);


        var fileName1 = chbText + "Command";
        var fileName2 = chbText + "CommandHandler";
        var fileName3 = chbText + "CommandRequest";
        var fileName4 = chbText + "CommandResponse";
        var fileName5 = chbText + "CommandValidator";
        var filePath = string.Empty;
        var fileContent = string.Empty;

        var listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName4, fileName5 };
        if (type.SelectedIndex == 4) listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName5 };
        for (var i = 0; i < listFileNames.Count; i++)
        {
            if (i == 0)
            {
                if (listFileNames.Count == 5)
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." + NameSpace + ";" +
                        "\npublic sealed class " + listFileNames[i] + $" : Command<{fileName4}>" +
                        "\n{\n \n}";
                }

                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." + NameSpace + ";" +
                        "\npublic sealed class " + listFileNames[i] + " : Command" +
                        "\n{\n \n}";
                }
            }

            else if (i == 1)
            {
                if (listFileNames.Count == 5)
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : ICommandHandler<{fileName1},{fileName4}>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Result<{fileName4}>> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }

                else
                {
                    filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                    fileContent =
                        $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                        "Commands" + "." +
                        NameSpace + ";" +
                        "\n  public sealed class " + listFileNames[i] +
                        $" : ICommandHandler<{fileName1}>" +
                        "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                        "public " +
                        fileName2 +
                        "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                        $"public async Task<Result> Handle({fileName1} request, CancellationToken cancellationToken)"
                        + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
                }
            }
            else
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent = $"namespace HarmonyCore.Application{Harmony}.{nameSpace}." + "Commands" + "." +
                              NameSpace +
                              ";" +
                              "\n  public sealed class " + listFileNames[i] +
                              "\n{\n \n}";
            }

            File.WriteAllText(filePath, fileContent);
        }
    }

    private void CreateQueryFile1(string chbText, string folderPath, string nameSpace, ComboBox type)
    {
        var NameSpace = chbText;
        var newFolderPath = Path.Combine(folderPath, chbText);

        Directory.CreateDirectory(newFolderPath);

        var fileName1 = chbText + "Query";
        var fileName2 = chbText + "QueryHandler";
        var fileName3 = chbText + "QueryRequest";
        var fileName4 = chbText + "QueryResponse";
        var fileName5 = chbText + "QueryFilters";

        var typeOfResponse = string.Empty;


        var filePath = string.Empty;
        var fileContent = string.Empty;

        var listFileNames = new List<string> { fileName1, fileName2, fileName3, fileName4, fileName5 };
        for (var i = 0; i < (type.SelectedIndex == 1 ? 5 : 4); i++)
        {
            if (i == 0)
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent =
                    $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                    "Queries" + "." + NameSpace + ";" +
                    "\npublic sealed class " + listFileNames[i] +
                    $" : IQuery<{TypeOfResponseQueries(fileName4, type)}" +
                    "\n{\n \n}";
            }

            else if (i == 1)
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent =
                    $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\nusing HarmonyCore.Application.Commons.Data;\nusing HarmonyCore.Domain.Common.Primitives.Maybe;\nusing HarmonyCore.Domain.DomainServices.ThePublic;\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                    "Queries" + "." +
                    NameSpace + ";" +
                    "\n  public sealed class " + listFileNames[i] +
                    $" : IQueryHandler<{fileName1},{TypeOfResponseQueries(fileName4, type)}" +
                    "\r\n{\r\nprivate readonly IUnitOfWork _unitOfWork;\r\n " +
                    "public " +
                    fileName2 +
                    "(IUnitOfWork unitOfWork)\r\n    {\r\n        _unitOfWork = unitOfWork;\r\n    } \n" +
                    $"public async Task<Maybe<{TypeOfResponseQueries(fileName4, type)}> Handle({fileName1} request, CancellationToken cancellationToken)"
                    + "\r\n{\n throw new NotImplementedException(); \r\n}\r\n}";
            }

            else
            {
                filePath = Path.Combine(newFolderPath, listFileNames[i] + ".cs");
                fileContent =
                    $"using HarmonyCore.Application.Commons.Abstractions.Messaging;\n\nnamespace HarmonyCore.Application{Harmony}.{nameSpace}." +
                    "Queries" + "." + NameSpace + ";" +
                    "\npublic sealed class " + listFileNames[i] +
                    "\n{\n \n}";
            }

            File.WriteAllText(filePath, fileContent);
        }
    }

    private void EntityName_TextChanged(object sender, EventArgs e)
    {
        label3.Text = EntityName.Text;
        label4.Text = EntityName.Text;
        label5.Text = EntityName.Text;
        label6.Text = EntityName.Text;
    }

    private void Reset_Click(object sender, EventArgs e)
    {
        // Clear all textboxes and comboboxes
        EntityName.Text = "";
        txbNameSpace.Text = "";
        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
        textBox5.Text = "";
        textBox6.Text = "";
        textBox7.Text = "";
        textBox8.Text = "";

        comboBox1.SelectedIndex = -1;
        comboBox2.SelectedIndex = -1;
        comboBox3.SelectedIndex = -1;
        comboBox4.SelectedIndex = -1;

        // Uncheck all checkboxes
        createCheckBox.Checked = false;
        editCheckBox.Checked = false;
        deleteCheckBox.Checked = false;
        GetById.Checked = false;
        GetAll.Checked = false;

        // Reset labels
        label3.Text = "";
        label4.Text = "";
        label5.Text = "";
        label6.Text = "";
    }


    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm();
        settingsForm.ShowDialog();
    }


    private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var versionInfo = Assembly.GetExecutingAssembly().GetName().Version;

        var serverIp = ReadSetting("IpServer");

        using (var client = new WebClient())
        {
            var versionUrl =
                $"http://{serverIp}:88/version.txt"; // Replace with the actual URL of your version.txt file
            var onlineVer = client.DownloadString(versionUrl).Trim();

            if (onlineVer != versionInfo!.ToString())
            {
                var result = MessageBox.Show("New version available. Do you want to update?", "Update Available",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var updateUrl = $"http://{serverIp}:88/Output/FileMakerSetup.exe";

                    // Download the update
                    var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var updatePath = Path.Combine(appDataPath, "FileMaker", "FileMakerSetup.exe");

                    client.DownloadFile(updateUrl, updatePath);

                    // Run the installer
                    Process.Start(updatePath);

                    // Close the application
                    Application.Exit();
                }
            }

            else
            {
                MessageBox.Show("No updates available.", "No Updates", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }

    private void localizationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var localizationForm = new LocalizationForm();
        localizationForm.ShowDialog();
    }

    public string TypeOfResponseQueries(string fileName, ComboBox type)
    {
        if (type.SelectedIndex == 0 || type.SelectedIndex == 3) return $"{fileName}>";
        if (type.SelectedIndex == 1) return $"PagedList<{fileName}>>";
        if (type.SelectedIndex == 2) return $"IEnumerable<{fileName}>>";
        return string.Empty;
    }
}