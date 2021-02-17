del ".\HTMLReport\*.html"
".\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" ".\Reports.Core.Tests\bin\Debug\Reports.Core.Tests.dll" --result="Reports.Core.Tests.xml;format=nunit3" --work=".\TestResults"
".\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" ".\Reports.Helper.Tests\bin\Debug\Reports.Helper.Tests.dll" --result="Reports.Helper.Tests.xml;format=nunit3" --work=".\TestResults"
".\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" ".\Reports.Import.Tests\bin\Debug\Reports.Import.Tests.dll" --result="Reports.Import.Tests.xml;format=nunit3" --work=".\TestResults"

".\packages\extent.0.0.3\tools\extent.exe"  -d ".\TestResults" -o ".\HTMLReportExtend" -r v3html --merge