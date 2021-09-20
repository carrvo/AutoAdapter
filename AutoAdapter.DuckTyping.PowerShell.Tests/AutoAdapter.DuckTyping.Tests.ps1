Describe "AutoAdapter" {
	BeforeAll {
		Import-Module ".\AutoAdapter.DuckTyping.PowerShell.Tests.psd1"
	}
	It "Converts" {
		$test = New-Test
		$test | Select-Object -ExpandProperty Called | Should Be $false
		{ Invoke-Test -InputObject $test } | Should Not Throw
		$test | Select-Object -ExpandProperty Called | Should Be $true
	}
}