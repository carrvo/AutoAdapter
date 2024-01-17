<#
.SYNOPSIS
Provides a mechanism for automatically applying the ADAPTER PATTERN without custom code.

.PARAMETER Interface
The interface that will be implemented (ducktyped) by a given object.
#>
function Register-Adapter {
	Param(
		[Parameter(Mandatory)]
		[ValidateScript({$_.IsInterface})]#, ErrorMessage = "Must be an interface type!")]
		[System.Type]$Interface
	)
	Update-TypeData -TypeName $Interface.FullName -TypeConverter AutoAdapter.Adapt[$Interface]
}