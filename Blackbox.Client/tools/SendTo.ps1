# if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit }

# Get the folder where this script is located
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition

# Blackbox.exe is one folder up from the "tools" folder
$blackboxExePath = Join-Path (Split-Path -Parent $scriptDir) "Blackbox.exe"

# Shortcut name
$shortcutName = "Blackbox.lnk"

# Get the current user's SendTo folder
$sendToFolder = Join-Path $env:APPDATA "Microsoft\Windows\SendTo"

# Ensure the SendTo folder exists
if (-not (Test-Path $sendToFolder)) {
    New-Item -Path $sendToFolder -ItemType Directory -Force | Out-Null
}

# Full path for the shortcut
$shortcutPath = Join-Path $sendToFolder $shortcutName

# Create the shortcut
$wsh = New-Object -ComObject WScript.Shell
$shortcut = $wsh.CreateShortcut($shortcutPath)
$shortcut.TargetPath = $blackboxExePath
$shortcut.WorkingDirectory = Split-Path $blackboxExePath
$shortcut.IconLocation = $blackboxExePath
$shortcut.Save()

Write-Host "Shortcut created in SendTo: $shortcutPath"
Start-Sleep -Seconds 3