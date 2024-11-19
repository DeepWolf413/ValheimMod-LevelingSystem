[CmdletBinding()]
param (
    [Parameter(Mandatory = $false)]
    [ValidateNotNullOrEmpty()]
    [ValidatePattern('^[a-zA-Z0-9_]+$')]
    [string]$PackageName,

    [Parameter(Mandatory = $false)]
    [ValidateNotNullOrEmpty()]
    [ValidatePattern('^[a-zA-Z0-9_]+$')]
    [string]$PackageAuthor,

    [Parameter(Mandatory = $false)]
    [ValidateNotNullOrEmpty()]
    [ValidatePattern('^\d+\.\d+\.\d+$')]
    [string]$PackageVersion,

    [Parameter(Mandatory = $false, HelpMessage = "Immediately initiates the build process. Ignored if the package hasn't been initialized yet.")]
    [switch]$QuickBuild,

    [Parameter(Mandatory = $false, HelpMessage = "Immediately initiates the publish process to Thunderstore. Ignored if the package hasn't been initialized yet.")]
    [switch]$QuickPublish
)
begin {
    New-Variable -Name THUNDERSTORE_CONFIG_FILEPATH -Value "$PSScriptRoot\thunderstore.toml" -Option Constant -Scope Local
    if (-not (Test-Path $THUNDERSTORE_CONFIG_FILEPATH)) {
        return
    }

    $packageConfig = Get-Content -Path $THUNDERSTORE_CONFIG_FILEPATH | ConvertFrom-Toml
    if ($PackageName -eq "") {
        $PackageName = $packageConfig.package.name
    }

    if ($PackageAuthor -eq "") {
        $PackageAuthor = $packageConfig.package.namespace
    }

    if ($PackageVersion -eq "") {
        $PackageVersion = $packageConfig.package.versionNumber
    }
}
process {
    if (-not (Test-Path $THUNDERSTORE_CONFIG_FILEPATH)) {
        Write-Host "Initializing package files..."

        tcli init --config-path $THUNDERSTORE_CONFIG_FILEPATH --package-name $PackageName --package-namespace $PackageAuthor --package-version $PackageVersion
        Write-Host "Package files created!" -ForegroundColor Green
    }

    do {
        Write-Host "Please confirm that the thunderstore.toml file is filled with the correct information before proceeding." -ForegroundColor DarkGray
        if (-not $QuickBuild -and -not $QuickPublish) {
            Write-Host "[B] - Build | [P] - Publish | [Q] - Quit"
            $Answer = Read-Host
        }
        else {
            Write-Host "[Enter] - Continue | [Q] - Quit"
            $Answer = Read-Host
        }
        
        if ($Answer -eq "B" -or $QuickBuild) {
            tcli build --config-path $THUNDERSTORE_CONFIG_FILEPATH --package-name $PackageName --package-namespace $PackageAuthor --package-version $PackageVersion
            break
        } elseif ($Answer -eq "P" -or $QuickPublish) {
            Write-Host "An authentication token is required to publish a package." -ForegroundColor DarkGray
            Write-Host "Please enter your Thunderstore Authentication token:"
            $token = Read-Host
            if ($token -eq "") {
                Write-Host "No token provided. Aborting..." -ForegroundColor Red
                break
            }

            tcli publish --token $token --config-path $THUNDERSTORE_CONFIG_FILEPATH --package-name $PackageName --package-namespace $PackageAuthor --package-version $PackageVersion
            break
        }
    } while ($Answer -ne "Q")
}
end {
}
