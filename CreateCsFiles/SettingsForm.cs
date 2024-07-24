using Microsoft.Win32;

namespace CreateCsFiles;

public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
    }


    private void SettingsForm_Load(object sender, EventArgs e)
    {
        // Read values from registry
        CommandsTB.Text = ReadSetting("Commands");
        QueriesTB.Text = ReadSetting("Queries");
        ProjectTB.Text = ReadSetting("Project");
        OutputTB.Text = ReadSetting("Output");
        txbIpServer.Text = ReadSetting("IpServer");
    }

    private void SaveAddresses_Click(object sender, EventArgs e)
    {
        try
        {
            // Save values to registry
            WriteSetting("Commands", CommandsTB.Text);
            WriteSetting("Queries", QueriesTB.Text);
            WriteSetting("Project", ProjectTB.Text);
            WriteSetting("Output", OutputTB.Text);
            WriteSetting("IpServer", txbIpServer.Text);

            MessageBox.Show("Addresses saved successfully.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    // Method to write a setting to the registry
    private void WriteSetting(string name, string value)
    {
        using (var key = Registry.CurrentUser.CreateSubKey($"Software\\{Application.ProductName}"))
        {
            key.SetValue(name, value);
        }
    }

    // Method to read a setting from the registry
    private string ReadSetting(string name)
    {
        using (var key = Registry.CurrentUser.OpenSubKey($"Software\\{Application.ProductName}"))
        {
            return key?.GetValue(name)?.ToString() ?? string.Empty;
        }
    }
}