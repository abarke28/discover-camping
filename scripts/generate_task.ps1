﻿# -----------------------------------------------------------
# Script: generate_task.ps1
# Author: Alex Barker
# Date: 2021-01-01
# Description: Generate windows scheduled task to run poller
# -----------------------------------------------------------

param(
	[string]$path = 'c:\tasks\discover-camping-poller\'
)

Write-Output "Generating Windows Scheduled Task for Poller`n"

if(Test-Path($path)){
	Write-Output "Target directory $path already exists.`nDelete directory and try again`n"
	Exit 1
}

try{
	New-Item -Path $path -ItemType "Directory"
	Write-Output "Copying binaries to $path"
	Push-Location ..
	$binFolder = "netcoreapp3.1\*"
	Copy-Item -Path $binFolder -Destination $path -Recurse
	Write-Output "Binaries copied"
	Pop-Location
}
catch{
	Write-Output "Copying failed, exiting script"
	Exit 1
}

$executionPath = $path + "discover-camping.exe"

$action = New-ScheduledTaskAction -Execute $executionPath

# Run task on and just after 6am & 7am daily, and every 30 minutes generally
$triggers = @()
$triggers += New-ScheduledTaskTrigger -Daily -At 06:00 
$triggers += New-ScheduledTaskTrigger -Daily -At 06:01 
$triggers += New-ScheduledTaskTrigger -Daily -At 07:00
$triggers += New-ScheduledTaskTrigger -Daily -At 07:01 
$triggers += New-ScheduledTaskTrigger -Once -At 06:15 -RepititionInterval (New-TimeSpan -Minutes 30)

$settings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBatteries -WakeToRun

Write-Output "Registering windows scheduled task`n"
Register-ScheduledTask -Action $action -Trigger $triggers -TaskName "BergLake" -Description "Check availability of Berg Lake resos" -Settings $settings
Write-Output "Task Scheduled. Exiting."