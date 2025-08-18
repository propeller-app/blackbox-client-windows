param(
    [string]$ZipPath = "$env:TEMP\ffmpeg.zip",
    [string]$ffmpegUrl
)

$ErrorActionPreference = 'Stop'


Write-Host "Downloading FFmpeg $ffmpegUrl..."
Write-Host "Destination: $ZipPath"

try {
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    Start-BitsTransfer -Source $ffmpegUrl -Destination $ZipPath
    Write-Host "Download complete."
}
catch {
    Write-Host "BITS Error: $($_.Exception.Message)"
    exit 1
}

Write-Output $ZipPath