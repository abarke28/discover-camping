# discover-camping
Selenium project to check if camping reservations are open

#### Setup
Add an `App.config` xml config file to bin with the following content:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>  
        <appSettings>
             <add key="SenderEmail" value="example@gmail.com"/>  
             <add key="SenderPw" value="example123!"/>  
             <add key="Emails" value="watcher1@gmail.com;watcher2@gmail.com"/>  
        </appSettings>  
    </configuration>

Build from source with `dotnet build`

#### Install
Install by navigating to the binaries directory and executing the powershell script

`cd bin\...\netcoreapp3.1`

`.\generate_task.ps1 [install path]`

`install path` is an optional parameter with the default being `c:\tasks\discover-camping-poller`

#### Info
Task will check if reservations are available every day at

- 06:00
- 06:01
- 07:00
- 07:01

Notification emails will be sent if reservations are available

Log written to `c:\Users\Public\Logs\poller.log`
