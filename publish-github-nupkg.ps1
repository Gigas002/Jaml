$packageName=$args[0]
if($packageName) {            
    dotnet pack "Jaml.Wpf/Jaml.Wpf.csproj" --configuration Release
    dotnet nuget push "Jaml.Wpf/bin/Release/$packageName" --source "github"
} else {            
    Write-Host "Please, specify .nupkg file name (not full path!)"           
}
