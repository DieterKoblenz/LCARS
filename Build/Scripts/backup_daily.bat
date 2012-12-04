@ECHO OFF
REM
REM	This batch file expects %1 to be the filename for the SQL backup file!
REM 

mysqldump --user=root --password=put_your_password_here gluon > %APPDATA%\Gluon\Backups\%1

