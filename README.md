## Hosted Web Core Bootstrapper

Bootstraps an IIS based application using Hosted Web Core.

Needs to be run with administrator privileges in order to run properly. 

All third party dependencies are embeded into main executable via Costura.Fody - all that is required to deploy is the main executable.

### How to configure cell to be used with buildpack ###


1. RDP into the cell
2. Run powershell as administrator and run the following script (make necessary modifications):

```PowerShell
Set-ItemProperty -path HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System -name EnableLUA -value 0
Set-DnsClientServerAddress -InterfaceIndex 12 -ServerAddresses ("127.0.0.1", "10.0.20.5") #replace 10.0.20.5 with AD DNS
Set-Service "consul" -startuptype "automatic"
Set-Service "containerizer" -startuptype "automatic"
Set-Service "garden-windows" -startuptype "automatic"
Set-Service "hakim" -startuptype "automatic"
Set-Service "metron_agent" -startuptype "automatic"
Set-Service "rep_windows" -startuptype "automatic"
Set-Service "route_emitter_windows" -startuptype "automatic"
Set-Service "bosh-agent" -startuptype "automatic"
Add-Computer -DomainName "almirex.io" -Restart #replace almirex.io with proper name
```

3. Allow machine to be restarted. 
4. Log back in. 
5. Run the following powershell

```PowerShell 
Set-DnsClientServerAddress -InterfaceIndex 12 -ServerAddresses ("127.0.0.1", "10.0.20.5")  #replace 10.0.20.5 with AD DNS
```

6. Add domain users to be impersonated to local admin group
7. RDP Login once with each domain user to be impersonated to create local profile

### Assign service account to the app ###
For the app to be run under domain account, set it's environmental variables ```SERVICE_USERNAME``` (DOMAIN\username) & ```SERVICE_PASSWORD``` to the domain account associated with SPN



With :heart: from @mxplusb & @macsux.
