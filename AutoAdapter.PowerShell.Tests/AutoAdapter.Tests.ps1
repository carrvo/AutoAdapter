Describe "AutoAdapter" {
	BeforeAll {
		Import-Module ".\AutoAdapter.PowerShell.Tests.dll"
	}
	It "Converts" {
		$test = New-Test
		$test | Select-Object -ExpandProperty Called | Should Be $false
		{ Invoke-Test -InputObject $test } | Should Not Throw
		$test | Select-Object -ExpandProperty Called | Should Be $true
	}
}