.intel_syntax noprefix

.include "console.i"

.data

first:	.long	0
second:	.long	0
result:	.long	0

.text

ask:	.asciz	"Enter a positive integer: "
ans:	.asciz	"G.C.D = "

_entry:
	Prompt	ask
	GetInt	first
	Prompt	ask
	GetInt	second

	mov	eax, first
	mov	ecx, second
	call	_GCD
	mov	result, eax

	Prompt	ans
	PutInt	result
	PutEoL

	ret

.global _entry

.end

