$downloadPath = Join-Path $PSScriptRoot "\Download-FFmpeg.ps1"
$ffmpegUrl = "https://github.com/GyanD/codexffmpeg/releases/download/2025-08-14-git-cdbb5f1b93/ffmpeg-2025-08-14-git-cdbb5f1b93-full_build.zip"


# Check current ffmpeg version using ffmpeg_version.txt which has the currently installed ffmpegUrl
$versionFile = Join-Path $PSScriptRoot "..\ffmpeg\ffmpeg_version.txt"
if (Test-Path $versionFile) {
	$currentVersion = Get-Content $versionFile
	if ($currentVersion -eq $ffmpegUrl) {
		Write-Host "FFmpeg is already up to date: $currentVersion"
		Write-Host "Program will exit in 5 seconds."
		Start-Sleep -Seconds 5
		exit 0
	} else {
		Write-Host "Current FFmpeg version: $currentVersion"
		Write-Host "Updating FFmpeg to new version: $ffmpegUrl"
	}
} else {
	Write-Host "No previous FFmpeg version found, installing new version: $ffmpegUrl"
}

$zipPath = & $downloadPath -ffmpegUrl $ffmpegUrl
$InstallDir = $targetDir = Join-Path $PSScriptRoot "..\ffmpeg"
Write-Host "Downloaded zip path: $zipPath"
# Run installer elevated
Start-Process powershell.exe -ArgumentList "-ExecutionPolicy Bypass -File `"$PSScriptRoot\Install-FFmpeg.ps1`" -ZipPath `"$zipPath`" -InstallDir `"$InstallDir`" -ffmpegVersion `"$ffmpegUrl`"" -Verb runAs -Wait

