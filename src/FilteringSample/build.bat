@echo off

REM Dynamics CRM 2015 online:
REM
REM https://[YOUR_ORGANISATION].api.crm.dynamics.com/XrmServices/2011/Organization.svc  (North America)
REM https://[YOUR_ORGANISATION].api.crm4.dynamics.com/XrmServices/2011/Organization.svc (EMEA)
REM https://[YOUR_ORGANISATION].api.crm5.dynamics.com/XrmServices/2011/Organization.svc (APAC)
REM https://[YOUR_ORGANISATION].api.crm2.dynamics.com/XrmServices/2011/Organization.svc (South America)
REM https://[YOUR_ORGANISATION].api.crm6.dynamics.com/XrmServices/2011/Organization.svc (Oceania)
REM https://[YOUR_ORGANISATION].api.crm7.dynamics.com/XrmServices/2011/Organization.svc (Japan)
REM https://[YOUR_ORGANISATION].api.crm9.dynamics.com/XrmServices/2011/Organization.svc (North America 2)
REM
REM Dynamics CRM 2015 on-premise:
REM
REM http://[ServerName]/[OrganizationName]/XRMServices/2011/Organization.svc

set URL=https://[YOUR_ORGANISATION].api.crm6.dynamics.com/XRMServices/2011/Organization.svc
set NAMESPACE=[YOUR_NAMESPACE]
set /p USERNAME=username:
set /p PASSWORD=password:

echo Generating CRM proxy classes for the following CRM Instance:
echo %URL%

echo Generating CRM proxy classes....

CrmSvcUtil.exe /url:%URL% /n:%NAMESPACE% /u:"%USERNAME%" /p:"%PASSWORD%
