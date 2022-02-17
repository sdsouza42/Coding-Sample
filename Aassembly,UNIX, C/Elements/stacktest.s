.intel_syntax noprefix

.include "console.i"

.text

_LCM:
	push	eax
	push	ecx
	call	_GCD
	mov	ebx, eax
	pop	ecx
	pop	eax
	mul	ecx
	div	ebx
	ret

ask:	.asciz	"Enter a positive integer: "
ans:	.asciz	"L.C.M = "

_entry:
	mov	ebp, esp
	sub	esp, 12

	Prompt	ask
	GetInt	[ebp-4]	#ebp-4 -> first
	Prompt	ask
	GetInt	[ebp-8]	#ebp-8 -> second

	mov	eax, [ebp-4]
	mov	ecx, [ebp-8]
	call	_LCM
	mov	[ebp-12], eax	#ebp-12 -> result

	Prompt	ans
	PutInt	[ebp-12]
	PutEoL

	mov	esp, ebp
	ret

.global _entry

.end

