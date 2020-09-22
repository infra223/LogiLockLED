using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogiLockLED
{
    public partial class ConfigurationForm : Form
    {
        private readonly LedSettings ledSettings;
        public event EventHandler SettingsUpdated;

        public ConfigurationForm(ref LedSettings settings)
        {
            InitializeComponent();
            ledSettings = settings;
            PopulateSettingsToUI();
        }
        

        private void btnColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = (sender as Button).BackColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                (sender as Button).BackColor = colorDialog.Color;
                SetSettingValue(sender, colorDialog.Color);
            }
            
        }

        private void SetSettingValue(object sender, Color color)
        {
            if (sender == btnCapsOffColour)
                ledSettings.CapsOffColour = color;
            if (sender == btnCapsOnColour)
                ledSettings.CapsOnColour = color;

            if (sender == btnNumOffColour)
                ledSettings.NumOffColour = color;
            if (sender == btnNumOnColour)
                ledSettings.NumOnColour = color;

            if (sender == btnScrollOffColour)
                ledSettings.ScrollOffColour = color;
            if (sender == btnScrollOnColour)
                ledSettings.ScrollOnColour = color;
        }

        private void PopulateSettingsToUI()
        {
            cbEnable.Checked = ledSettings.EnableKeyLockLEDs;
            cbEnableCaps.Checked = ledSettings.EnableCaps;
            btnCapsOffColour.BackColor = ledSettings.CapsOffColour;
            btnCapsOnColour.BackColor = ledSettings.CapsOnColour;

            cbEnableNum.Checked = ledSettings.EnableNum;
            btnNumOffColour.BackColor = ledSettings.NumOffColour;
            btnNumOnColour.BackColor = ledSettings.NumOnColour;

            cbEnableScroll.Checked = ledSettings.EnableScroll;
            btnScrollOffColour.BackColor = ledSettings.ScrollOffColour;
            btnScrollOnColour.BackColor = ledSettings.ScrollOnColour;
        }

        private void ApplySettings()
        {
            ledSettings.SaveSettings();
            SettingsUpdated?.Invoke(this, new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ApplySettings();
            this.Close();
        }        

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ledSettings.LoadSettings();
            PopulateSettingsToUI();
            this.Close();
        }

        private void cbEnableCaps_CheckedChanged(object sender, EventArgs e)
        {
            ledSettings.EnableCaps = cbEnableCaps.Checked;
        }

        private void cbEnableNum_CheckedChanged(object sender, EventArgs e)
        {
            ledSettings.EnableNum = cbEnableNum.Checked;
        }

        private void cbEnableScroll_CheckedChanged(object sender, EventArgs e)
        {
            ledSettings.EnableScroll = cbEnableScroll.Checked;
        }

        private void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            ledSettings.EnableKeyLockLEDs = cbEnable.Checked;
        }
    }
}
