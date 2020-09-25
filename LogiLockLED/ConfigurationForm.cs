using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LogiLockLED
{
    public enum OSDPosition { Centre = 1, Top_Left, Top_Right, Bottom_Left, Bottom_Right }
    public partial class ConfigurationForm : Form
    {
        private readonly LedSettings ledSettings;
        public event EventHandler SettingsUpdated;        

        

        public ConfigurationForm(ref LedSettings settings)
        {
            InitializeComponent();
            ledSettings = settings;
            cbOSDPosition.DataSource = Enum.GetValues(typeof(OSDPosition));
            cbOSDPosition.SelectedIndex = 0;

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

            if (sender == btnOsdTxtColour)
                ledSettings.OsdTextColour = color == Color.Black ? Color.FromArgb(3, 3, 3) : color;
            if (sender == btnOsdBkColour)
                ledSettings.OsdBackColour = color == Color.Black ? Color.FromArgb(3, 3, 3) : color;

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

            cbAutoStartApp.Checked = ledSettings.AutoStartApp;

            cbOsdEnabled.Checked = ledSettings.OsdEnabled;
            cbOSDPosition.SelectedItem = ledSettings.OsdPosition;
            btnOsdFont.Text = ledSettings.OsdFont.SizeInPoints.ToString() + ", " + ledSettings.OsdFont.FontFamily.Name;
            fontDialog.Font = ledSettings.OsdFont;
            cbOsdPadding.Value = ledSettings.OsdPadding;
            cbOsdMargin.Value = ledSettings.OsdMargin;
            cbOsdRoundedCorners.Checked = ledSettings.OsdRoundedCorners;
            btnOsdTxtColour.BackColor = ledSettings.OsdTextColour;
            btnOsdBkColour.BackColor = ledSettings.OsdBackColour;
            cbOsdOpacity.Value = ledSettings.OsdOpacity;
        }

        private void ApplySettings()
        {
            ledSettings.OsdEnabled = cbOsdEnabled.Checked;
            ledSettings.OsdPosition = (OSDPosition)cbOSDPosition.SelectedItem;
            ledSettings.OsdPadding = (int)cbOsdPadding.Value;
            ledSettings.OsdMargin = (int)cbOsdMargin.Value;
            ledSettings.OsdRoundedCorners = cbOsdRoundedCorners.Checked;
            ledSettings.OsdOpacity = (int)cbOsdOpacity.Value;

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

        private void cbAutoStartApp_CheckedChanged(object sender, EventArgs e)
        {
            ledSettings.AutoStartApp = cbAutoStartApp.Checked;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if( fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                ledSettings.OsdFont = fontDialog.Font;
                btnOsdFont.Text = ledSettings.OsdFont.SizeInPoints.ToString() + ", " + ledSettings.OsdFont.FontFamily.Name;
            }                       
        }
    }
}
