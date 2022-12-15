# LogiLockLED
LogiLockLED is a system tray application that makes it easier to monitor Num, Caps and Scroll lock states.  Some modern keyboards and laptops do not have indicator lights for some of these keys and could cause frustration.  This is where LogiLockLED can help.

LogiLockLED has three ways to make life easier for you:
- On-Screen display shows up when any of the locks are triggered
- System tray icons shows key lock states
- Users of backlit Logitech keyboards can illuminate the lock keys in different colors based on lock state.
- You can choose which lock keys should be monitored

Multitude of configuration options are available to disable/enable features and adjust the look and feel of the notifications and icons.  The application can easily be enabled or disabled from the context menu on the main system tray icon.


# Releases
The latest release is available at: 
https://github.com/infra223/LogiLockLED/releases


# How to use
Download and install the latest release of the application : https://github.com/infra223/LogiLockLED/releases 

When the application start it will show an icon in the notification area, also known as the system tray.  By default it will also show the Caps and Num lock icons.

The default Windows 10 behaviour is to hide icons in the notification area after some time.  If you want the icons to be permanently visible, follow these steps:
- Right click on a blank area of the taskbar to show a context menu.
- Select the “Taskbar settings” option to show the Taskbar settings window.
- Scroll down until you see the “Notification area” section.   Click on the “Select which icons appear on the taskbar” item, which will show a list of icons that appeared in the notification area.
- Find the “LogiLockLED” item in the list and turn it on.

### Configuration:
LogiLockLED allows for a number of customizations and tweaks in the configuration window:
- Right click on the LogiLockLED icon in the notification area / system tray and click “Configuration”
- The configuration window has a General Settings  area for global settings
- Below that there is a number of tabs for configuring notifications
  - Key Back Light: Settings for Logitech backlit keyboards
  - On-Screen Display: Look and feel settings for the OSD window
  - System Tray Indicators: Settings for key lock icons in the notification area

### OpenRGB back light integration:

OpenRGB integration enables LogiLockLED  to update key backlights for any RGB keyboard supported by OpenRGB via the SDK server. 

- Download and Install OpenRGB (https://openrgb.org/)
- On first run make sure it detects your RGB keyboard
- Start the SDK Server using the default server port 6742 (SDK Server tab)
- Enable OpenRGB to start automatically and enable SDK server:
  Under Settings tab > General Settings, mark the following check boxes
                 - [x] Start At Login
                 - [x] Start Mnimized
                 - [x] Start Server

Configure LogiLockLED to make use of the OpenRGB LED controller:
- Under Key Backlight tab > LED Controller
- Select "OpenRGB"
- Click Apply and test

LogiLockRGB makes use of the OpenRGB.NET library (https://github.com/diogotr7/OpenRGB.NET) ported to .Net Framework 4.8.

### Logitech back light integration:
***Important: If you want to make changes to the light scheme used in G HUB, you need to disable LogiLockLED first (see below)***

- Install G Hub and ensure your keyboard is accessible
- If you already have LogiLockLED installed and running, disable it by exiting the application or unchecking the "Enable Key Lock LEDs" setting in the configuration window and apply the change.
- In G Hub: select or create a "FREESTYLE" colour scheme for your keyboard. This will not work with any animated schemes.

Configure LogiLockLED to make use of the Logitech G HUB LED controller:
- Under Key Backlight tab > LED Controller
- Select "Logitech G HUB"
- Click Apply and test

If you are using your keyboard with game profiles it is advised to disable this application while playing games.  If not, LogiLockLED might change key back light values while in game and G Hub might ignore the game profile, which might not be preferable.  Quickest way to disable is to right click on the LogiLockLED icon in the notification area and uncheck the "Enabled" menu item.  Just remember to enable it again when you are done.

*** There are known compatibility issues between the latest G HUB and Logitech's LED ILLUMINATION SDK.  If you experience issues please consider using the OpenRGB option***

#### Note
This application makes use of Logitech's LED ILLUMINATION SDK that can be downloaded from their website: https://www.logitechg.com/en-us/innovation/developer-lab.html. 
The use of this SDK is subject to Logitech's End-User License Agreement for Logitech Gaming LED SDK.

Source Code for LogiLockLED is licensed under the MIT license.
