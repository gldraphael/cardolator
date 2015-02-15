; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Cardolator"
#define MyAppVersion "2.0"
#define MyAppPublisher "Galdin Raphael, Malhar Comps 2014"
#define MyAppURL "http://malharfest.org"
#define MyAppExeName "Cardolator.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{DC376CAE-B8EF-47B9-ACC5-B5EF4D2043E8}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\Setup
OutputBaseFilename=cardolator_2.0_setup
Compression=lzma
SolidCompression=yes
AppCopyright=Copyright � Galdin Raphael 2014
VersionInfoVersion=2.0
VersionInfoCompany=Malhar Comps 2014
VersionInfoCopyright=Copyright � Galdin Raphael 2014
VersionInfoProductName=Cardolator
VersionInfoProductVersion=2.0

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\Cardolator.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\BL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\DA.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\Entity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\MahApps.Metro.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\State.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\System.Windows.Interactivity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Galdin\Documents\Visual Studio 2013\Projects\Cardolator\UI\bin\Release\ViewModels.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "X:\Setups\Windows Tools\.NET 4.5 full\dotnetfx45_full_x86_x64.exe"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
;Filename: "{app}\dotnetfx45_full_x86_x64.exe"; Parameters: "/sp- /silent /norestart"
Filename: "{app}\{#MyAppExeName}"; Flags: nowait postinstall skipifsilent; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"

;[InstallDelete]
;Type: files; Name: "{app}\dotnetfx45_full_x86_x64.exe"
