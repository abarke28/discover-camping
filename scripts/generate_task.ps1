# -----------------------------------------------------------
# Script: generate_task.ps1
# Author: Alex Barker
# Date: 2021-01-01
# Description: Generate windows scheduled task to run poller
# -----------------------------------------------------------

Write-Output "Generating Windows Scheduled Task for Poller"

$action = New-ScheduledTaskAction -Execute 'discover-camping.exe'

$triggers = @()
$triggers += New-ScheduledTaskTrigger -Daily -At 06:00 
$triggers += New-ScheduledTaskTrigger -Daily -At 06:01 
$triggers += New-ScheduledTaskTrigger -Daily -At 07:00
$triggers += New-ScheduledTaskTrigger -Daily -At 07:01 