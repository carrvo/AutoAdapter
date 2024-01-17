Describe "AutoAdapter" {
	BeforeAll {
		Import-Module ".\AutoAdapter.DuckTyping.PowerShell.psd1"
		Import-Module ".\AutoAdapter.DuckTyping.PowerShell.Tests.dll"
		Add-Type -Path ".\AutoAdapter.DuckTyping.Tests.dll"
	}
	It "Converts" {
		Remove-TypeData -TypeName AutoAdapter.Tests.IAdapterTest -ErrorAction SilentlyContinue
		Register-AutoAdapter -Interface AutoAdapter.Tests.IAdapterTest
		$test = New-Test
		$test | Select-Object -ExpandProperty Called | Should Be $false
		{ $test | Invoke-Test } | Should Not Throw
		$test | Select-Object -ExpandProperty Called | Should Be $true
	}
}