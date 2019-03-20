EF commands for Package manager console

Add-migration 
update-database (for updating database)
Update-Database -Migration '20171221074632_added new column for ScannerAlert in TicketType entity'

Remove-Migration


npm install rimraf -g
rimraf node_modules

webpack --config webpack.config.vendor.js 

Invoke-RestMethod http://localhost:7000/api/reservation -Method GET 
Invoke-RestMethod http://localhost:7000/api/reservation/1 -Method GET 

invoke-restmethod http://localhost:64052/api/reservation 
-method post 
-body(@{clientName="Anne";location="Metting room 4"} | convertto-json) 
-contenttype "application/json"

invoke-restmethod http://localhost:64052/api/reservation 
-method Put 
-Body(@{reservationId="1";clientName="Bob";location="Media room"} | ConvertTo-Json) 
-ContentType "application/json"

 Invoke-RestMethod http://localhost:64052/api/reservation/2 -Method Delete
 
 Invoke-WebRequest http://localhost:64052/api/reservation/object |select @{n='content-type';e={$_.Headers."content-type"}}, content
 
 