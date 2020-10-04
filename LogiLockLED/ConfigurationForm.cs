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
            }
            
        }


        private void PopulateSettingsToUI()
        {
            cbEnable.Checked = ledSettings.EnableKeyLockLEDs;

            cbEnableCaps.Checked = ledSettings.EnableCaps;
            btnCapsOffColour.BackColor = ledSettings.CapsOffColor;
            btnCapsOnColour.BackColor = ledSettings.CapsOnColor;

            cbEnableNum.Checked = ledSettings.EnableNum;
            btnNumOffColour.BackColor = ledSettings.NumOffColor;
            btnNumOnColour.BackColor = ledSettings.NumOnColor;

            cbEnableScroll.Checked = ledSettings.EnableScroll;
            btnScrollOffColour.BackColor = ledSettings.ScrollOffColor;
            btnScrollOnColour.BackColor = ledSettings.ScrollOnColor;

            cbAutoStartApp.Checked = ledSettings.AutoStartApp;

            cbOsdEnabled.Checked = ledSettings.OsdEnabled;
            cbOSDPosition.SelectedItem = ledSettings.OsdPosition;
            setFontButtonText();
            fontDialog.Font = ledSettings.OsdFont;
            cbOsdPadding.Value = ledSettings.OsdPadding;
            cbOsdMargin.Value = ledSettings.OsdMargin;
            cbOsdRoundedCorners.Checked = ledSettings.OsdRoundedCorners;
            btnOsdTxtColour.BackColor = ledSettings.OsdTextColor;
            btnOsdBkColour.BackColor = ledSettings.OsdBackColor;
            cbOsdOpacity.Value = ledSettings.OsdOpacity;
            cbOsdDurtation.Value = ledSettings.OsdDuration;
            cbOSDShowNum.Checked = ledSettings.OsdShowNum;
            cbOSDShowCaps.Checked = ledSettings.OsdShowCaps;
            cbOSDShowScroll.Checked = ledSettings.OsdShowScroll;

            cbTrayShowNum.Checked = ledSettings.TrayShowNum;
            cbTrayShowCaps.Checked = ledSettings.TrayShowCaps;
            cbTrayShowScroll.Checked = ledSettings.TrayShowScroll;

            btnTrayOnColor.BackColor = ledSettings.TrayOnColor;
            btnTrayOnBgColor.BackColor = ledSettings.TrayOnBackColor;
            btnTrayOffColor.BackColor = ledSettings.TrayOffColor;
            btnTrayOffBgColor.BackColor = ledSettings.TrayOffBackColor;

            cbTrayOnTransparent.Checked = ledSettings.TrayOnBackColor == Color.Transparent;
            cbTrayOffTransparent.Checked = ledSettings.TrayOffBackColor == Color.Transparent;
            cbTrayOnBorder.Checked = ledSettings.TrayOnBorder;
            cbTrayOffBorder.Checked = ledSettings.TrayOffBorder;
        }

        private void ApplySettings()
        {
            ledSettings.EnableKeyLockLEDs = cbEnable.Checked;
            ledSettings.AutoStartApp = cbAutoStartApp.Checked;

            ledSettings.EnableCaps = cbEnableCaps.Checked;
            ledSettings.EnableNum = cbEnableNum.Checked;
            ledSettings.EnableScroll = cbEnableScroll.Checked;
            

            ledSettings.OsdEnabled = cbOsdEnabled.Checked;
            ledSettings.OsdPosition = (OSDPosition)cbOSDPosition.SelectedItem;
            ledSettings.OsdPadding = (int)cbOsdPadding.Value;
            ledSettings.OsdMargin = (int)cbOsdMargin.Value;
            ledSettings.OsdRoundedCorners = cbOsdRoundedCorners.Checked;
            ledSettings.OsdOpacity = (int)cbOsdOpacity.Value;
            ledSettings.OsdDuration = (int)cbOsdDurtation.Value;
            ledSettings.CapsOffColor = btnCapsOffColour.BackColor;
            ledSettings.CapsOnColor = btnCapsOnColour.BackColor;
            ledSettings.NumOffColor = btnNumOffColour.BackColor;
            ledSettings.NumOnColor = btnNumOnColour.BackColor;
            ledSettings.ScrollOffColor = btnScrollOffColour.BackColor;
            ledSettings.ScrollOnColor = btnScrollOnColour.BackColor;
            ledSettings.OsdTextColor = btnOsdTxtColour.BackColor == Color.Black ? Color.FromArgb(3, 3, 3) : btnOsdTxtColour.BackColor;
            ledSettings.OsdBackColor = btnOsdBkColour.BackColor == Color.Black ? Color.FromArgb(3, 3, 3) : btnOsdBkColour.BackColor;
            ledSettings.OsdShowNum = cbOSDShowNum.Checked;
            ledSettings.OsdShowCaps = cbOSDShowCaps.Checked;
            ledSettings.OsdShowScroll = cbOSDShowScroll.Checked;

            ledSettings.TrayShowNum = cbTrayShowNum.Checked;
            ledSettings.TrayShowCaps = cbTrayShowCaps.Checked;
            ledSettings.TrayShowScroll = cbTrayShowScroll.Checked;

            ledSettings.TrayOnColor = btnTrayOnColor.BackColor;
            ledSettings.TrayOnBackColor = cbTrayOnTransparent.Checked ? Color.Transparent : btnTrayOnBgColor.BackColor;
            ledSettings.TrayOffColor = btnTrayOffColor.BackColor;
            ledSettings.TrayOffBackColor = cbTrayOffTransparent.Checked ? Color.Transparent : btnTrayOffBgColor.BackColor;

            ledSettings.TrayOnBorder = cbTrayOnBorder.Checked;
            ledSettings.TrayOffBorder = cbTrayOffBorder.Checked;

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

        private void btnFont_Click(object sender, EventArgs e)
        {
            if( fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                ledSettings.OsdFont = fontDialog.Font;
                setFontButtonText();
            }                       
        }

        private void setFontButtonText()
        {
            btnOsdFont.Text = ledSettings.OsdFont.FontFamily.Name + " " + Math.Round(ledSettings.OsdFont.SizeInPoints) + "pt" + (ledSettings.OsdFont.Style != FontStyle.Regular ? " (" + ledSettings.OsdFont.Style + ")" : "");            
            toolTip.SetToolTip(btnOsdFont, btnOsdFont.Text);
            var buttonFont = new Font(ledSettings.OsdFont.FontFamily, 9 ,ledSettings.OsdFont.Style, ledSettings.OsdFont.Unit);
            btnOsdFont.Font = buttonFont;
        }

        private void cbTrayOnTransparent_CheckedChanged(object sender, EventArgs e)
        {
            btnTrayOnBgColor.Visible = !cbTrayOnTransparent.Checked;            
        }

        private void cbTrayOffTransparent_CheckedChanged(object sender, EventArgs e)
        {
            btnTrayOffBgColor.Visible = !cbTrayOffTransparent.Checked;           
        }
    }
}
