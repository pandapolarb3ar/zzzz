

/*
 * 
 * 
$IP = Read-Host -Prompt 'Please enter the IP Address.  Format 192.168.x.x'
$MaskBits = 24 # This means subnet mask = 255.255.255.0
$Gateway = "192.168.1.1"
$Dns = "192.168.1.200"
$IPType = "IPv4"

# Retrieve the network adapter that you want to configure
$adapter = Get-NetAdapter | ? {$_.Status -eq "up"}

# Remove any existing IP, gateway from our ipv4 adapter
If (($adapter | Get-NetIPConfiguration).IPv4Address.IPAddress) {
    $adapter | Remove-NetIPAddress -AddressFamily $IPType -Confirm:$false
}

If (($adapter | Get-NetIPConfiguration).Ipv4DefaultGateway) {
    $adapter | Remove-NetRoute -AddressFamily $IPType -Confirm:$false
}

# Configure the IP address and default gateway
$adapter | New-NetIPAddress `
    -AddressFamily $IPType `
    -IPAddress $IP `
    -PrefixLength $MaskBits `
    -DefaultGateway $Gateway

# Configure the DNS client server IP addresses
$adapter | Set-DnsClientServerAddress -ServerAddresses $DNS 

 */

using System;



namespace PowerShellScriptExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "powershell.exe";
            //  startInfo.Arguments = "$IP = Read-Host -Prompt \'Please enter the IP Address.  Format 192.168.x.x\' $MaskBits = 24 ; $Gateway = \"192.168.1.1\";$Dns = \"192.168.1.200\";$IPType = \"IPv4\";$adapter = Get - NetAdapter | ? {$_.Status - eq \"up\"};If(($adapter | Get - NetIPConfiguration).IPv4Address.IPAddress) {$adapter | Remove - NetIPAddress - AddressFamily $IPType - Confirm:$false}If(($adapter | Get - NetIPConfiguration).Ipv4DefaultGateway) {;$adapter | Remove - NetRoute - AddressFamily $IPType - Confirm:$false};$adapter | New - NetIPAddress ` \n -AddressFamily $IPType `\n -IPAddress $IP `\n -PrefixLength $MaskBits `\n -DefaultGateway $Gateway\n;$adapter | Set - DnsClientServerAddress - ServerAddresses $DNS;";
            startInfo.Arguments = "$IP = Read-Host -Prompt \'Please enter the IP Address.  Format 192.168.x.x\'; $MaskBits = 24 ; $Gateway = \"192.168.1.1\";$Dns = \"192.168.1.200\";$IPType = \'IPv4\';$adapter = Get-NetAdapter | ? {$_.Status -eq \'up\'};If(($adapter | Get-NetIPConfiguration).IPv4Address.IPAddress) {$adapter | Remove-NetIPAddress -AddressFamily $IPType -Confirm:$false};If(($adapter | Get-NetIPConfiguration).Ipv4DefaultGateway){;$adapter | Remove-NetRoute -AddressFamily $IPType -Confirm:$false};$adapter | New-NetIPAddress ` \n -AddressFamily $IPType `\n -IPAddress $IP ` \n -PrefixLength $MaskBits `\n -DefaultGateway $Gateway\n;$adapter | Set-DnsClientServerAddress - ServerAddresses $DNS;";  
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}