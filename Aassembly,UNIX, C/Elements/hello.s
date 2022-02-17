.intel_syntax

.include "console.i"

.text

greet: .ascii	"Hello World!"

_entry:
	mov	%eax, 12 	#length of greet message
	lea	%ebx, greet	#address of greet message
	PutStr	%ebx, %eax
	PutEoL

	ret

.global	_entry

.end

