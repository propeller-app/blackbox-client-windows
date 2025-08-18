param(
    [string]$ZipPath,
    [string]$InstallDir,
    [string]$ffmpegVersion
)

$ErrorActionPreference = 'Stop'

if (-not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()
    ).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) {

    # Relaunch elevated
    $psi = New-Object System.Diagnostics.ProcessStartInfo
    $psi.FileName = "powershell.exe"
    $psi.Arguments = "-ExecutionPolicy Bypass -File `"$PSCommandPath`" -ZipPath `"$ZipPath`""
    $psi.Verb = "runas"
    $psi.UseShellExecute = $true
    [System.Diagnostics.Process]::Start($psi) | Out-Null
    exit
}

try {
    Write-Host "Installing FFmpeg from $ZipPath..."

    $tempDir = Join-Path $env:TEMP "ffmpeg_temp"
    $targetDir = Join-Path $PSScriptRoot "..\ffmpeg"
    $versionFile = Join-Path $InstallDir "ffmpeg_version.txt"

    Expand-Archive -Path $ZipPath -DestinationPath $tempDir -Force

    $extractedBin = Get-ChildItem -Path $tempDir -Recurse -Filter "ffmpeg.exe" | Select-Object -First 1
    $extractedProbe = Get-ChildItem -Path $tempDir -Recurse -Filter "ffprobe.exe" | Select-Object -First 1

    if (-not (Test-Path $InstallDir)) {
        New-Item -ItemType Directory -Path $InstallDir | Out-Null
    }

    Copy-Item $extractedBin.FullName -Destination (Join-Path $InstallDir "ffmpeg.exe") -Force
    Copy-Item $extractedProbe.FullName -Destination (Join-Path $InstallDir "ffprobe.exe") -Force
    Set-Content -Path $versionFile -Value $ffmpegVersion

    Remove-Item $tempDir -Recurse -Force
    Write-Host "Installation complete."

} catch {
    Write-Host "Install Error: $($_.Exception.Message)"
    exit 1
}
Start-Sleep -Seconds 3
