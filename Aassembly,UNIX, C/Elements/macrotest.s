.intel_syntax noprefix

.include "console.i"
.include "mymacro.i"

.data

number:	.long	0
digits:	.long	0

.text

ask:	.asciz	"Enter a positive integer: "
ans:	.asciz	"Number of digits = "

_entry:
	Prompt	ask
	GetInt	number

	mov	eax, 1
	mov	ebx, number
	mov	ecx, 0

1:	Mul10	eax
	inc	ecx		#add ecx, 1

	cmp	eax, ebx
	jbe	1b

	mov	digits, ecx

	Prompt	ans
	PutInt	digits
	PutEoL

	ret

.global	_entry

.end




