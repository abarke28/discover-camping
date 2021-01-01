# -----------------------------------------------------------
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

Write-Output "Copying binaries to $path"
Push-Location ..

$binFolder = "netcoreapp3.1\*"
Copy-Item -Path $binFolder -Destination $path -Recurse

Write-Output "Binaries copied"
Pop-Location

$executionPath = $path + "discover-camping.exe"

$action = New-ScheduledTaskAction -Execute $executionPath

$triggers = @()
$triggers += New-ScheduledTaskTrigger -Daily -At 06:00 
$triggers += New-ScheduledTaskTrigger -Daily -At 06:01 
$triggers += New-ScheduledTaskTrigger -Daily -At 07:00
$triggers += New-ScheduledTaskTrigger -Daily -At 07:01 